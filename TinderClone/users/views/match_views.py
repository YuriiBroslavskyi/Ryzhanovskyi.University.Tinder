from django.http import JsonResponse
from users.models import Profile
from django.shortcuts import render, redirect
import random

def create_random_profile_from_database(user):
    other_profiles = Profile.objects.exclude(user=user)
    if other_profiles.exists():
        random_profile = other_profiles.order_by('?').first()   
        return random_profile

def match_algorithm(user):
    user_profile = user.profile
    user_gender = user_profile.gender
    match_gender = user_profile.match_gender

    other_profiles = Profile.objects.exclude(user=user)

    if match_gender == 'Both':
        if match_gender == 'Male':
            matched_profiles = other_profiles.filter(gender='Male')
        elif match_gender == 'Female':
            matched_profiles = other_profiles.filter(gender='Female')
        else:
            matched_profiles = other_profiles
    else:
        matched_profiles = other_profiles.filter(gender=match_gender)

    matched_profiles = list(matched_profiles)
    random.shuffle(matched_profiles)

    return matched_profiles

def view_that_shows_card(request):
    user = request.user
    matched_profiles = match_algorithm(user)
    
    random_profile = random.choice(matched_profiles) if matched_profiles else None
    
    if random_profile:
        return render(request, 'card.html', {'profile': random_profile})
    else:
        return render(request, 'error.html', {'error_message': 'No matched profiles found.'})

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