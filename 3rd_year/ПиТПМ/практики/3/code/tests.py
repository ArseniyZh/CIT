import math

import pytest

from main import Geometry

class TestGeometry:
    def setup_method(self):
        self.geometry = Geometry()

    def test_rectangle_area(self):
        width = 3
        height = 5
        expected = 15
        assert self.geometry.rectangle_area(width, height) == expected

    def test_cylinder_volume(self):
        radius = 2
        height = 4
        expected = math.pi * radius**2 * height
        assert self.geometry.cylinder_volume(radius, height) == pytest.approx(expected)

    def test_percentage_of_number(self):
        percentage = 20
        number = 50
        expected = 10
        assert self.geometry.percentage_of_number(percentage, number) == expected
