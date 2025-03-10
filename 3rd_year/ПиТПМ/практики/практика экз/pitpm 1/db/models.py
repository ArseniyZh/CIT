from django.db import models
from django.core.exceptions import ValidationError
from django.utils.timezone import now
from django.utils.timezone import make_aware
from django.utils import timezone


class Event(models.Model):
    event_name = models.CharField(max_length=100)
    event_date = models.DateTimeField()

    def clean(self):
        # Проверка, что название события не пустое
        if not self.event_name:
            raise ValidationError({"event_name": "Название события не может быть пустым."})

        # Проверка, что дата события указана
        if not self.event_date:
            raise ValidationError({"event_date": "Дата события должна быть указана."})

        # Преобразование event_date в aware, если он naive
        if self.event_date and timezone.is_naive(self.event_date):
            self.event_date = make_aware(self.event_date)

        # Проверка, что дата события не в прошлом
        if self.event_date < timezone.now():
            raise ValidationError({"event_date": "Дата события не может быть в прошлом."})