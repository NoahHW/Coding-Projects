from django.shortcuts import render
from django.http import HttpResponse

# Create your views here.
# takes a request and returns a response
# its an action

def say_hello(request):
    return render(request, 'hello.html', {'name': 'Mosh'})
# pull data from db 
# send Email