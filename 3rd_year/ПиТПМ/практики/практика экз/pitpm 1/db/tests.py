from django.test import TestCase
from django.core.exceptions import ValidationError
from django.utils.timezone import now
from datetime import timedelta
from db.models import Event


class TestEvent(TestCase):
    def test_create_event(self):
        """Проверяет успешное создание события."""
        event = Event(event_name="Conference", event_date=now() + timedelta(days=1))
        event.full_clean()  # Проверка валидации

    def test_event_date_in_past(self):
        """Проверяет, что нельзя создать событие с датой в прошлом."""
        event = Event(event_name="Past Event", event_date=now() - timedelta(days=1))
        with self.assertRaises(ValidationError):
            event.full_clean()

    def test_long_event_name(self):
        """Проверяет, что нельзя создать событие с именем, превышающим 100 символов."""
        long_name = "A" * 101  # Строка длиной 101 символ
        event = Event(event_name=long_name, event_date=now() + timedelta(days=1))
        with self.assertRaises(ValidationError):
            event.full_clean()
