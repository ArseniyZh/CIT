from django.db import models
from django.core.exceptions import ValidationError


class Flights(models.Model):
    flight_number = models.CharField(max_length=10)
    destination = models.CharField(max_length=100)
    
    def clean(self):
        # Проверка, что номер рейса не пустой
        if not self.flight_number:
            raise ValidationError("Flight number cannot be empty.")
        # Проверка, что место назначения не пустое
        if not self.destination:
            raise ValidationError("Destination cannot be empty.")
        # Проверка на превышение длины flight_number
        if len(self.flight_number) > 10:
            raise ValidationError("Flight number cannot exceed 10 characters.")
