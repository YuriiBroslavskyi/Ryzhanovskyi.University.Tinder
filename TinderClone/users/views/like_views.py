from django.shortcuts import get_object_or_404, redirect
from .send_mail import send_liked_message
from ..models import Profile, ProfileDislike, ProfileLike

def like_profile(request, username):
    liked_profile = get_object_or_404(Profile, user__username=username)
    
    liked_user = liked_profile.user
    
    # Check if the user has already liked the profile
    if not ProfileLike.objects.filter(user=request.user, liked_profile=liked_user).exists():
        like = ProfileLike(user=request.user, liked_profile=liked_user)
        like.save()
        send_liked_message(user=liked_profile.user)
    
    return redirect('profile_detail', username=username)

def dislike_profile(request, username):
    disliked_profile = get_object_or_404(Profile, user__username=username)
    
    disliked_user = disliked_profile.user
    
    # Check if the user has already disliked the profile
    if not ProfileDislike.objects.filter(user=request.user, disliked_profile=disliked_user).exists():
        dislike = ProfileDislike(user=request.user, disliked_profile=disliked_user)
        dislike.save()

    return redirect('profile_detail', username=username)
