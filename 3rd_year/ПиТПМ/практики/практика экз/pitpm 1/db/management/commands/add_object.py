from django.core.management.base import BaseCommand
from django.core.exceptions import ValidationError
from db.models import Event
from django.utils.timezone import datetime


class Command(BaseCommand):
    help = 'Creates a new event'

    def handle(self, *args, **kwargs):
        # Запрос ввода данных у пользователя
        event_name = input("Enter event name: ")
        event_date_str = input("Enter event date and time (YYYY-MM-DD HH:MM:SS): ")

        try:
            # Преобразование строки в datetime
            event_date = datetime.strptime(event_date_str, "%Y-%m-%d %H:%M:%S")
            
            # Создание объекта модели
            event = Event(event_name=event_name, event_date=event_date)
            
            # Проверка валидации
            event.full_clean()
            event.save()
            
            self.stdout.write(self.style.SUCCESS(f"Successfully added event '{event_name}' on {event_date}."))
        except ValidationError as e:
            self.stderr.write(self.style.ERROR(f"Failed to create event: {e.message_dict}"))
        except ValueError:
            self.stderr.write(self.style.ERROR("Invalid date format. Please use 'YYYY-MM-DD HH:MM:SS'."))
