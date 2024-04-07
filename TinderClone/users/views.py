from sqlite3 import IntegrityError
from django.shortcuts import render, redirect
from django.contrib.auth import logout
from .forms import ProfileForm
from .models import Profile
from django.contrib.auth.decorators import login_required, permission_required

def home(request):
    return render(request, "home.html")

def navbar(request):
    return render(request, "navbar.html")

def googleLogin(request):
    return render(request, "googleLogin.html")

def create_profile(request):
    if request.method == 'POST':
        form = ProfileForm(request.POST, request.FILES)
        if form.is_valid():
            profile = form.save(commit=False)
            profile.user = request.user 
            profile.save()
            return redirect('profile_detail')  
    else:
        form = ProfileForm()
    return render(request, 'ProfileCreation.html', {'form': form})

@login_required
def redirect_after_login(request):
    try:
        profile = request.user.profile 
        return redirect('profile_detail')  
    except Profile.DoesNotExist:
        return redirect('profile_creation')

@login_required
def profile_detail(request):
    return render(request, "profile_detail.html")

@login_required
def logout_view(request):
    logout(request)
    return redirect("/")


