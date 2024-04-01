from django.shortcuts import render, redirect
from django.contrib.auth import logout
from .models.models import CustomUser
from .models.CustomUserCreationModel import CustomUserCreationForm
from django.contrib.auth.decorators import login_required

def home(request):
    return render(request, "home.html")

def navbar(request):
    return render(request, "navbar.html")

def googleLogin(request):
    return render(request, "googleLogin.html")

def profile_creation(request):
    if request.method == 'POST':
        form = CustomUserCreationForm(request.POST, request.FILES)
        if form.is_valid():
            form.save()
            return redirect('home.html')
    else:
        form = CustomUserCreationForm()
    
    return render(request, 'ProfileCreation.html', {'form': form})

def success(request):
    return redirect(request, "success.html")

def logout_view(request):
    logout(request)
    return redirect("/")


