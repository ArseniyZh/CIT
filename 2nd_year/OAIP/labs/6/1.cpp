#include <iostream>

using namespace std;

class Time {
private:
    int hours;
    int minutes;

public:
    Time(int h, int m) : hours(h), minutes(m) {}

    int getMinutes() const {
        return hours * 60 + minutes;
    }
};

int main() {
    int h, m;

    cout << "Enter the hours: ";
    cin >> h;
    cout << "Enter the minutes: ";
    cin >> m;

    Time myTime(h, m);
    int totalMinutes = myTime.getMinutes();
    cout << "Total minutes: " << totalMinutes << endl;

    return 0;
}
