#include <iostream>
#include <limits>

using namespace std;


int cinX() {
    int x;

    while (true) {
        cout << "Input number x less than 0 or greater than 129: ";
        cin >> x;
        cout << x << endl;
        if (cin.fail() || x > 0 && x <= 129) {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
        } else {
            break;
        };
    };

    return x;
}


int main() {
    float x;
    float result = 1.0;
    x = cinX();
    for (int i=2; i<=128; i+=2) {
        // cout << (x - i)/(x - i - 1) << endl;
        result *= (x - i)/(x - i - 1);
    }

    cout << result;

    return 0;
}
