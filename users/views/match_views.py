from django.http import HttpResponseRedirect, JsonResponse
from users.models import Profile, ProfileLike, ProfileDislike, Block
from django.http import JsonResponse
from django.shortcuts import render, redirect
from datetime import date, timedelta
from django.db.models import Q
import random

def create_random_profile_from_database(user):
    other_profiles = Profile.objects.exclude(user=user)
    if other_profiles.exists():
        random_profile = other_profiles.order_by('?').first()   
        return random_profile
    

def card_views(request):
    user = request.user
    random_profile = create_random_profile_from_database(user)
    data = {
        'first_name': random_profile.first_name,
        'last_name': random_profile.last_name,
        'date_of_birth': random_profile.date_of_birth,
        'gender': random_profile.gender,
        'city': random_profile.city,
        'description': random_profile.description
    }
    return JsonResponse(data)
    
def view_that_shows_card(request):
    user = request.user
    user_profile = user.profile

    preferences = user_profile.preferences

    if preferences.lower() == "bygender":
        matched_profiles = match_algorithm_byGender(user)
    elif preferences.lower() == "byage":
        desired_age = request.POST.get('minAge')
        if desired_age is None:
            desired_age = 20
        try:
            matched_profiles = match_algorithm_ByAge(user, int(desired_age))
        except ValueError:
            return JsonResponse({'error': "Invalid desired age format"})
    elif preferences.lower() == "byhobby":
        matched_profiles = match_algorithm_byHobby(user)
    else:
        return redirect('match_settings')

    random_profile = random.choice(matched_profiles) if matched_profiles else None

    if random_profile:
        return render(request, 'card.html', {'profile': random_profile})
    else:
        return render(request, 'error.html', {'error_message': 'No matched profiles found.'})


def match_settings(request):
    if request.method == 'POST':
        selected_algorithm = request.POST.get('algorithm')
        if selected_algorithm:
            user_profile = request.user.profile
            user_profile.preferences = selected_algorithm
            user_profile.save()
            return redirect('card')
    
    return render(request, "match_algorithm.html")

def match_algorithm_byHobby(user):
    user_profile = user.profile
    user_hobbies = user_profile.hobby.all()

    other_profiles = Profile.objects.exclude(user=user)

    block_profiles = Block.objects.filter(blocker=user).values_list('blocked_user', flat=True)
    liked_profiles = ProfileLike.objects.filter(user=user).values_list('liked_profile', flat=True)
    disliked_profiles = ProfileDislike.objects.filter(user=user).values_list('disliked_profile', flat=True)

    liked_or_disliked_profiles = liked_profiles.union(disliked_profiles, block_profiles)

    matched_profiles = []

    for profile in other_profiles:
        if profile.hobby.filter(id__in=user_hobbies).exists() and profile.user not in liked_or_disliked_profiles:
            matched_profiles.append(profile)

    return matched_profiles


def match_algorithm_ByAge(user, desired_age):
    user_profile = user.profile
    date_of_birth = user_profile.date_of_birth

    other_profiles = Profile.objects.exclude(user=user)

    block_profiles = Block.objects.filter(blocker=user).values_list('blocked_user', flat=True)
    liked_profiles = ProfileLike.objects.filter(user=user).values_list('liked_profile', flat=True)
    disliked_profiles = ProfileDislike.objects.filter(user=user).values_list('disliked_profile', flat=True)

    liked_or_disliked_profiles = liked_profiles.union(disliked_profiles, block_profiles)

    if date_of_birth:
        user_age = (date.today() - date_of_birth).days // 365
    else:
        user_age = None

    if user_age:
        min_age = desired_age - 5
        max_age = desired_age + 5

        matched_profiles = other_profiles.filter(
            Q(date_of_birth__lte=date.today() - timedelta(days=min_age*365)) &
            Q(date_of_birth__gte=date.today() - timedelta(days=max_age*365)) &
            ~Q(user__in=liked_or_disliked_profiles)
        )

        while not matched_profiles.exists() and (min_age > 18 or max_age < 100): 
            matched_profiles = other_profiles.filter(
                Q(date_of_birth__lte=date.today() - timedelta(days=min_age*365)) &
                Q(date_of_birth__gte=date.today() - timedelta(days=max_age*365)) &
                ~Q(user__in=liked_or_disliked_profiles)
            )

        return matched_profiles

def match_algorithm_byGender(user):
    user_profile = user.profile
    match_gender = user_profile.match_gender

    other_profiles = Profile.objects.exclude(user=user)

    block_profiles = Block.objects.filter(blocker=user).values_list('blocked_user', flat=True)
    liked_profiles = ProfileLike.objects.filter(user=user).values_list('liked_profile', flat=True)
    disliked_profiles = ProfileDislike.objects.filter(user=user).values_list('disliked_profile', flat=True)
    liked_or_disliked_profiles = liked_profiles.union(disliked_profiles, block_profiles)
    matched_profiles = other_profiles.exclude(user__in=liked_or_disliked_profiles)


    if match_gender == 'Both':
        matched_profiles = other_profiles.exclude(user__in=liked_or_disliked_profiles)
    elif match_gender == 'Male':
        matched_profiles = other_profiles.filter(gender='Male').exclude(user__in=liked_or_disliked_profiles)
    elif match_gender == 'Female':
        matched_profiles = other_profiles.filter(gender='Female').exclude(user__in=liked_or_disliked_profiles)
    else:
        matched_profiles = other_profiles.filter(gender=match_gender).exclude(user__in=liked_or_disliked_profiles)

    matched_profiles = list(matched_profiles)
    random.shuffle(matched_profiles)

    return matched_profiles
