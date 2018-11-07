from django.shortcuts import (
        render, redirect, HttpResponseRedirect,
        HttpResponse
    )


def home(request):
    return render(request, 'base.html')
