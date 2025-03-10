from django.core.management.base import BaseCommand
from django.utils import timezone

from db.models import Flights

class Command(BaseCommand):
    help = 'Displays current time'

    def handle(self, *args, **kwargs):
        flight_number = input("Enter flight number: ")
        destination = input("Enter destination: ")
        Flights.objects.create(flight_number=flight_number, destination=destination)
        self.stdout.write(self.style.SUCCESS('Successfully added object'))
