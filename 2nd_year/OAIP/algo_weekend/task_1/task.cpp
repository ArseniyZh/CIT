#include <iostream>

using namespace std;


int main() {
    int n, e = 0, p = 1;
    cout << "Enter n: ";
    cin >> n;

    while (p < n) {
        e += 1;
        p *= 2;
    };

    cout << "Result is " << e;
}
