import pytest

from django.test import TestCase
from django.core.exceptions import ValidationError

from db.models import Flights


class TestFlights(TestCase):
    def test_create_flight(self):
        flight = Flights(flight_number='SU1234', destination='Sheremetyevo')
        flight.full_clean()  # Проверка валидности данных
        flight.save()
        assert flight.flight_number == 'SU1234'
        assert flight.destination == 'Sheremetyevo'

    def test_empty_flight_number(self):
        flight = Flights(flight_number='', destination='Sheremetyevo')
        with pytest.raises(ValidationError):
            flight.full_clean()  # Валидация выбрасывает ошибку

    def test_empty_destination(self):
        flight = Flights(flight_number='SU1234', destination='')
        with pytest.raises(ValidationError):
            flight.full_clean()  # Валидация выбрасывает ошибку

    def test_too_long_flight_number(self):
        flight = Flights(flight_number='SU12345678901234567890', destination='Sheremetyevo')
        with pytest.raises(ValidationError):
            flight.full_clean()  # Валидация выбрасывает ошибку


