from django.urls import path
from . import views

urlpatterns = [
    path("", views.home),
    path('navbar', views.navbar, name='navbar'),
    path('googleLogin', views.googleLogin, name='googleLogin'),
    path('profile_creation/', views.profile_creation, name='profile_creation'),
    path('success/', views.success, name='success'),
    path("logout", views.logout_view)
]