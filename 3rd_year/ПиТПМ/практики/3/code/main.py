import math

class Geometry:
    def rectangle_area(self, width, height):
        return width * height

    def cylinder_volume(self, radius, height):
        return math.pi * radius**2 * height

    def percentage_of_number(self, percentage, number):
        return (percentage / 100) * number
