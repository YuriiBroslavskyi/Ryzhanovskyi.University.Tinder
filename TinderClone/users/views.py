from django.shortcuts import render, redirect
from django.contrib.auth import logout

# Create your views here.

def home(request):
    return render(request, "home.html")

def navbar(request):
    return render(request, "navbar.html")

def googleLogin(request):
    return render(request, "googleLogin.html")

def logout_view(request):
    logout(request)
    return redirect("/")


