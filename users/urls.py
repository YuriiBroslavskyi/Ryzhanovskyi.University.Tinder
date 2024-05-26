from django.urls import path

from .views import match_views
from .views import views
from .views import like_views
from .views import chat_views
from .views import report_block_views
from .views import feedback_views

from django.conf import settings
from django.conf.urls.static import static

urlpatterns = [
    path("", views.home),
    path('navbar', views.navbar, name='navbar'),
    path('googleLogin/', views.googleLogin, name='googleLogin'),
    path('profile/<str:username>/', views.profile_detail, name='profile_detail'),
    path('profile_creation/', views.create_profile, name='profile_creation'),
    path("logout/", views.logout_view, name='logout'),
    path('card/', match_views.view_that_shows_card, name='card'),
    path('next-profile/', match_views.card_views, name='next_profile'),
    path('redirect_after_login/', views.redirect_after_login, name='redirect_after_login'),
    path('like/<str:username>/', like_views.like_profile, name='like_profile'),
    path('dislike/<str:username>/', like_views.dislike_profile, name='dislike_profile'),
    path('match-settings/', match_views.match_settings, name='match_settings'),
    path('ws/chat/', chat_views.chat, name='chat'),
    path('report/<int:reported_user_id>/reason/', report_block_views.report_reason, name='report_reason'),
    path('report/<int:reported_user_id>/', report_block_views.report_user, name='report_profile'),
    path('block/<int:blocked_user_id>/', report_block_views.block_user, name='block_profile'),
    path('feedback/', feedback_views.feedback, name='feedback'),
]


if settings.DEBUG:
    urlpatterns += static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)
