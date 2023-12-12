#include <iostream>
#include <cmath>

using namespace std;

class Point {
private:
    double x;
    double y;

public:
    Point(double xCoord, double yCoord) : x(xCoord), y(yCoord) {}

    void moveX(double deltaX) {
        x += deltaX;
    }

    void moveY(double deltaY) {
        y += deltaY;
    }

    double distanceToOrigin() const {
        return sqrt(x * x + y * y);
    }

    double distanceTo(const Point& other) const {
        double deltaX = x - other.x;
        double deltaY = y - other.y;
        return sqrt(deltaX * deltaX + deltaY * deltaY);
    }
};

int main() {
    int x1, y1, x2, y2;
    cout << "Point #1:" << endl << "x: "; cin >> x1; cout << "y: "; cin >> y1;
    Point point1(x1, y1);

    cout << "Point #2:" << endl << "x: "; cin >> x2; cout << "y: "; cin >> y2;
    Point point2(x2, y2);

    cout << "Point #1:" << endl;
    cout << "x: " << x1 << " + "; cin >> x1;
    cout << "y: " << y1 << " + "; cin >> y1;
    point1.moveX(x1);
    point1.moveY(y1);

    cout << "Point #2:" << endl;
    cout << "x: " << x2 << " + "; cin >> x2;
    cout << "y: " << y2 << " + "; cin >> y2;
    point2.moveX(x1);
    point2.moveY(y1);

    cout << "Distance to Origin (Point 1): " << point1.distanceToOrigin() << endl;
    cout << "Distance to Origin (Point 2): " << point2.distanceToOrigin() << endl;

    cout << "Distance between Point 1 and Point 2: " << point1.distanceTo(point2) << endl;

    return 0;
}
