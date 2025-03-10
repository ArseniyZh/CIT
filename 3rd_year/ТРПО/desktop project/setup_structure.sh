#!/usr/bin/env bash

# Создание основных файлов в корне
touch main.py
touch config.py
touch requirements.txt

# Создание директорий
mkdir -p database
mkdir -p ui/widgets
mkdir -p controllers
mkdir -p resources/images
mkdir -p utils

# Файлы внутри database
touch database/__init__.py
touch database/connection.py
touch database/queries.py

# Файлы внутри ui
touch ui/__init__.py
touch ui/main_window.py

# Файлы внутри controllers
touch controllers/__init__.py
touch controllers/main_controller.py

# Файлы внутри utils
touch utils/__init__.py
touch utils/helpers.py

echo "Структура проекта успешно создана!"
