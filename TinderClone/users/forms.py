from django import forms
from .models import Profile
from .choices import HOBBY_CHOICES

class ProfileForm(forms.ModelForm):
    class Meta:
        model = Profile
        fields = ['first_name', 'last_name', 'gender', 'hobby', 'photo', 'city', 'age', 'description']
        widgets = {
            'first_name': forms.TextInput(attrs={'class': 'custom-input', 'placeholder': 'First Name'}),
            'last_name': forms.TextInput(attrs={'class': 'custom-input', 'placeholder': 'Last Name'}),
            'gender': forms.Select(attrs={'class': 'custom-dropdown'}),
            'hobby': forms.SelectMultiple(attrs={'class': 'custom-dropdown form-control', 'id': "Hobby"}),
            'photo': forms.FileInput(attrs={'class': 'custom-file-input'}),
            'city': forms.TextInput(attrs={'class': 'custom-input', 'placeholder': 'City'}),
            'age': forms.NumberInput(attrs={'class': 'custom-input'}),
            'description': forms.Textarea(attrs={'class': 'custom-textarea', 'placeholder': 'Description'}),
        }
