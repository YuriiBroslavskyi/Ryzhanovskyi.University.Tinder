from django.contrib.auth.models import AbstractUser
from .choices import STATUS_CHOICES, HOBBY_CHOICES, GENDER_CHOICES
from django.db import models

class CustomUser(AbstractUser):
    email = models.EmailField(unique=True)
    status = models.CharField(max_length=100, choices=STATUS_CHOICES, default='regular')
    hobby = models.CharField(max_length=200, choices=HOBBY_CHOICES)
    photo = models.ImageField(upload_to='profile_pics/', blank=True, null=True)
    city = models.CharField(max_length=100, blank=True)
    age = models.PositiveIntegerField(blank=True, null=True)
    gender = models.CharField(max_length=1, choices=GENDER_CHOICES, blank=True)
    description = models.TextField(blank=True)
    
    # Add related_name attributes to resolve clashes
    groups = models.ManyToManyField(
        'auth.Group',
        related_name='custom_user_groups',
        blank=True,
        verbose_name='groups',
        help_text='The groups this user belongs to. A user will get all permissions granted to each of their groups.',
    )
    user_permissions = models.ManyToManyField(
        'auth.Permission',
        related_name='custom_user_permissions',
        blank=True,
        verbose_name='user permissions',
        help_text='Specific permissions for this user.',
    )

    def __str__(self):
        return self.username
