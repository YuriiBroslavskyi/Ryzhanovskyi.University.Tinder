from django.shortcuts import render, redirect, get_object_or_404
from django.contrib.auth import logout
from users.views.send_mail import send_logging_in_mail, send_created_page_mail
from users.forms import ProfileForm
from users.models import Profile
from django.contrib.auth.decorators import login_required, permission_required

def home(request):
    return render(request, "home.html")

def navbar(request):
    return render(request, "navbar.html")

def googleLogin(request):
    return render(request, "googleLogin.html")

@login_required
def create_profile(request):
    if request.method == 'POST':
        form = ProfileForm(request.POST, request.FILES)
        if form.is_valid():
            profile = form.save(commit=False)
            profile.user = request.user 
            profile.save()
            form.save_m2m()
            send_created_page_mail(request.user)
            return redirect('profile_detail')  
    else:
        form = ProfileForm()
    return render(request, 'ProfileCreation.html', {'form': form})

@login_required
def redirect_after_login(request):
    try:
        profile = request.user.profile
        send_logging_in_mail(request.user)
        return redirect('profile_detail')  
    except Profile.DoesNotExist:
        return redirect('profile_creation')

@login_required
def profile_detail(request, username):
    profile = get_object_or_404(Profile, user__username=username)
    context = {
        'profile': profile,
    }
    return render(request, "profile_detail.html", context)
@login_required
def logout_view(request):
    logout(request)
    return redirect("/")


