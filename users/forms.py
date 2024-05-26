from datetime import date
from django import forms
from .models import Profile, Feedback
from django.forms import ValidationError
from django.utils.translation import gettext_lazy as _

class ProfileForm(forms.ModelForm):
    class Meta:
        model = Profile
        fields = ['first_name', 'last_name', 'gender', 'match_gender', 'hobby', 'photo', 'city', 'date_of_birth', 'description']
        widgets = {
            'first_name': forms.TextInput(attrs={'class': 'custom-input', 'placeholder': 'First Name'}),
            'last_name': forms.TextInput(attrs={'class': 'custom-input', 'placeholder': 'Last Name'}),
            'gender': forms.Select(attrs={'class': 'custom-dropdown'}),
            'match_gender': forms.Select(attrs={'class': 'custom-dropdown'}),
            'hobby': forms.SelectMultiple(attrs={'class': 'custom-dropdown form-control', 'id': "Hobby"}),
            'photo': forms.FileInput(attrs={'class': 'custom-file-input'}),
            'city': forms.TextInput(attrs={'class': 'custom-input', 'placeholder': 'City'}),
            'date_of_birth': forms.DateInput(attrs={'class': 'custom-input', 'type': 'date'}),
            'description': forms.Textarea(attrs={'class': 'custom-textarea', 'placeholder': 'Description'}),
        }

    def clean_date_of_birth(self):
        date_of_birth = self.cleaned_data.get('date_of_birth')
        if date_of_birth:
            age = (date.today() - date_of_birth).days // 365
            if age < 18:
                raise ValidationError(
                    _('You must be 18 years or older to be verified.'),
                    code='invalid_age'
                )
        return date_of_birth
    

class FeedbackForm(forms.ModelForm):
    class Meta:
        model = Feedback
        fields = ['message', 'rating']
        widgets = {
            'message': forms.Textarea(attrs={'class': 'feedback_message', 'placeholder': 'Enter Here '}),
            'rating': forms.Select(choices=[(i, i) for i in range(1, 6)]),
        }
