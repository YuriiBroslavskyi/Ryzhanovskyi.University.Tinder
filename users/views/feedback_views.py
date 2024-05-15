from django.shortcuts import render, redirect
from ..models import Feedback
from ..forms import FeedbackForm

def feedback(request):
    if request.method == 'POST':
        form = FeedbackForm(request.POST)
        if form.is_valid():
            feedback = form.save(commit=False)
            feedback.user = request.user
            feedback.save()
            return redirect('/')
    else:
        form = FeedbackForm()
    return render(request, 'feedback.html', {'form': form})
