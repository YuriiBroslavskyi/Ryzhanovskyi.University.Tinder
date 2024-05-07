from django.core.mail import send_mail
from django.contrib.auth.decorators import login_required
from django.conf import  settings
from django.shortcuts import redirect
from django.core.mail import send_mail

from_email = settings.EMAIL_HOST_USER

def send_logging_in_mail(user):
    subject = "Welcome to Our Website!"
    message = f"Hello {user.first_name},\n\nWelcome back to our website!\n\nThank you for logging in."
    to_email = user.email
    send_mail(subject, message, from_email, [to_email], fail_silently=False)

def send_welcome_mail(user):
    subject = "Welcome to Our Website!"
    message = f"Hello {user.first_name},\n\nWelcome to our website GnomeLove, to complete registration u need to create your profile, Good luck!!\n\nThank you for visiting us."
    to_email = user.email
    send_mail(subject, message, from_email, [to_email], fail_silently=False)


def send_created_page_mail(user):
    subject = "Welcome to Our Website!"
    message = f"Hello {user.first_name},\n\nYou complete registarion with creating up your profile, good luck at finding ur love *_*\n\nThank you for logging in."
    to_email = user.email
    send_mail(subject, message, from_email, [to_email], fail_silently=False)

def send_liked_message(user):
    subject = "Greetings!"
    message = f"Hello {user.first_name},\n\nSomeone is liked you.\nGo and check it!"
    to_email = user.email
    send_mail(subject, message, from_email, [to_email], fail_silently=False)
    