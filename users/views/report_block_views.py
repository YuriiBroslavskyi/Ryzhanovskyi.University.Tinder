from django.shortcuts import redirect, render
from django.http import HttpResponse
from django.urls import reverse
from ..models import Report, Block, Profile
from django.http import HttpResponseNotAllowed


def report_user(request, reported_user_id):
    if request.method == 'POST':
        reporter = request.user
        reason = request.POST.get('reason')

        if not reason:
            return HttpResponse('Reason is required', status=400)

        try:
            reported_user = Profile.objects.get(id=reported_user_id)
        except Profile.DoesNotExist:
            return HttpResponse('Reported user does not exist', status=404)

        report = Report(reporter=reporter, reported_user=reported_user.user, reason=reason)
        report.save()
        return redirect('card')
    else:
        return redirect('report_reason', reported_user_id=reported_user_id)

def report_reason(request, reported_user_id):
    return render(request, 'report.html', {'reported_user_id': reported_user_id})



def block_user(request, blocked_user_id):
    if request.method == 'POST':
        blocker = request.user

        try:
            blocked_user = Profile.objects.get(id=blocked_user_id)
        except Profile.DoesNotExist:
            return HttpResponse('Blocked user does not exist', status=404)

        if Block.objects.filter(blocker=request.user, blocked_user=blocked_user.user.id).exists():
            return HttpResponse('User is already blocked')

        block = Block(blocker=blocker, blocked_user=blocked_user.user)
        block.save()
        return redirect('card')
    else:
        return HttpResponseNotAllowed(['POST', 'GET'])