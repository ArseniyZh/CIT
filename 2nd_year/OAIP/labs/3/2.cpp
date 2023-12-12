#include <iostream>
#include <limits>

using namespace std;


int getPositiveIntegerInput() {
    int input;
    while (true) {
        cout << "Input positive number: ";
        cin >> input;

        if (input <= 0 || cin.fail()) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
        } else {
            break;
        };
    };
    return input;
}


string decToHex(int dec) {
    string result = "";

    while (dec > 0) {
        int remainder = dec % 16;
        char hexDigit;

        if (remainder < 10) {
            hexDigit = '0' + remainder;
        } else {
            hexDigit = 'A' + (remainder - 10);
        }

        result = hexDigit + result;
        dec /= 16;
    }

    return result;
}


int main() {
    int x;
    x = getPositiveIntegerInput();

    cout << x << "(10) = " << decToHex(x) << "(16)";

    return 0;
}
