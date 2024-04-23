from django.shortcuts import get_object_or_404, redirect
from ..models import Profile, ProfileDislike, ProfileLike

def like_profile(request, username):
    liked_profile = get_object_or_404(Profile, user__username=username)
    
    # Get the User instance for the liked_profile
    liked_user = liked_profile.user
    
    # Check if the user has already liked the profile
    if ProfileLike.objects.filter(user=request.user, liked_profile=liked_user).exists():
        # If liked, unlike the profile
        ProfileLike.objects.filter(user=request.user, liked_profile=liked_user).delete()
    else:
        # If not liked, like the profile
        ProfileLike.objects.create(user=request.user, liked_profile=liked_user)
    
    return redirect('profile_detail', username=username)
