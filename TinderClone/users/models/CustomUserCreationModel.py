from .models import CustomUser
from django import forms
from django.core.exceptions import ValidationError



class CustomUserCreationForm(forms.ModelForm):
    class Meta:
        model = CustomUser
        fields = ['status', 'hobby', 'photo', 'city', 'age', 'gender', 'description']

    def __init__(self, *args, **kwargs):
        super(CustomUserCreationForm, self).__init__(*args, **kwargs)
        # Add custom labels, placeholders, and other attributes as needed
        self.fields['status'].required = True
        self.fields['hobby'].required = True
        self.fields['photo'].required = True
        self.fields['city'].required = True
        self.fields['age'].required = True
        self.fields['gender'].required = True
        self.fields['description'].required = True

    def validation_age(self):
        age = self.cleaned_data['age']
        if age < 18:
            raise ValidationError("You must be at least 18 years old.")
        return age