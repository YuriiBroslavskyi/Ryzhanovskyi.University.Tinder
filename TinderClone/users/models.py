from django.contrib.auth.models import AbstractUser
from django.db import models
from django.forms import ValidationError
from django.utils.translation import gettext_lazy as _
from .choices import STATUS_CHOICES, HOBBY_CHOICES, GENDER_CHOICES

class User(AbstractUser):
    email = models.EmailField(unique=True)

    USERNAME_FIELD = 'email'
    REQUIRED_FIELDS = ['username']

    def __str__(self):
        return self.username

class Profile(models.Model):
    user = models.OneToOneField(User, on_delete=models.CASCADE)
    
    first_name = models.CharField(max_length=100)
    last_name = models.CharField(max_length=100)
    status = models.CharField(max_length=100, choices=STATUS_CHOICES, default='regular')
    gender = models.CharField(max_length=200, choices=GENDER_CHOICES)
    hobby = models.CharField(max_length=200, choices=HOBBY_CHOICES)
    photo = models.ImageField(upload_to='profile_pics/', blank=True, null=True)  
    city = models.CharField(max_length=100, blank=True)
    age = models.PositiveIntegerField(blank=True, null=True)
    description = models.TextField(blank=True)
    verified = models.BooleanField(default=False)

    def age_verify(self):
        if self.age is not None and self.age < 18:
            raise ValidationError(
                _('You must be 18 years or older to be verified.'),
                code='invalid_age'
            )


    def __str__(self):
        return self.user.username
