#include <iostream>

using namespace std;

int main() {
    int a, b, c;

    cout << "Enter the number a: ";
    cin >> a;

    cout << "Enter the number b: ";
    cin >> b;

    cout << "Enter the number c: ";
    cin >> c;

    if (a >= b && b >= c) {
        a *= 2;
        b *= 2;
        c *= 2;
    } else {
        a = abs(a);
        b = abs(b);
        c = abs(c);
    }

    cout << "a = " << a << " " << "b = " << b << " " << "c = " << c;

    return 0;
}
