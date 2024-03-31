from django.urls import path
from . import views

urlpatterns = [
    path("", views.home),
    path('navbar', views.navbar, name='navbar'),
    path('googleLogin', views.googleLogin, name='googleLogin'),
    path("logout", views.logout_view)
]