from django.urls import path
from . import views

from django.conf import settings
from django.conf.urls.static import static

urlpatterns = [
    path("", views.home),
    path('navbar', views.navbar, name='navbar'),
    path('googleLogin/', views.googleLogin, name='googleLogin'),
    path('profile/', views.profile_detail, name='profile_detail'),
    path('profile_creation/', views.create_profile, name='profile_creation'),
    path("logout/", views.logout_view, name='logout'),
    path('redirect_after_login/', views.redirect_after_login, name='redirect_after_login'),
]

if settings.DEBUG:
    urlpatterns += static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)
