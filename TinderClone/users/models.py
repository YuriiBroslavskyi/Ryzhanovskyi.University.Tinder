from django.contrib.auth.models import AbstractUser
from django.db import models
from .choices import STATUS_CHOICES, HOBBY_CHOICES, GENDER_CHOICES, GENDER_MATCH_CHOICES, YOUR_CHOICES

class User(AbstractUser):
    email = models.EmailField(unique=True)

    USERNAME_FIELD = 'email'
    REQUIRED_FIELDS = ['username']

    def __str__(self):
        return self.username
    
class Hobby(models.Model):
    name = models.CharField(max_length=100, choices=HOBBY_CHOICES)

    def __str__(self):
        return self.name

class Profile(models.Model):
    user = models.OneToOneField(User, on_delete=models.CASCADE)
    
    first_name = models.CharField(max_length=100)
    last_name = models.CharField(max_length=100)
    status = models.CharField(max_length=100, choices=STATUS_CHOICES, default='regular')
    gender = models.CharField(max_length=10, choices=GENDER_CHOICES)
    match_gender = models.CharField(max_length=10, choices=GENDER_MATCH_CHOICES)
    hobby = models.ManyToManyField(Hobby)
    photo = models.ImageField(upload_to='profile_pics/', blank=True, null=True)  
    city = models.CharField(max_length=100, blank=True)
    date_of_birth = models.DateField(blank=True, null=True)
    description = models.TextField(blank=True)
    preferences = models.CharField(max_length=100, choices=YOUR_CHOICES, default='byGender')  # Change YOUR_CHOICES to your actual choices
    verified = models.BooleanField(default=False)

    def __str__(self):
        return self.user.username

    def get_likes_count(self):
        return self.user.liked_by_users.count()

    def get_dislikes_count(self):
        return self.user.disliked_by_users.count()
    
class ProfileLike(models.Model):
    user = models.ForeignKey(User, on_delete=models.CASCADE, related_name='liked_users')
    liked_profile = models.ForeignKey(User, on_delete=models.CASCADE, related_name='liked_by_users')

    def __str__(self):
        return f"{self.user.username} likes {self.liked_profile.username}"

class ProfileDislike(models.Model):
    user = models.ForeignKey(User, on_delete=models.CASCADE, related_name='disliked_users')
    disliked_profile = models.ForeignKey(User, on_delete=models.CASCADE, related_name='disliked_by_users')

    def __str__(self):
        return f"{self.user.username} dislikes {self.disliked_profile.username}"