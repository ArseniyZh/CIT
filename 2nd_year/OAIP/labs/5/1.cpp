#include <iostream>

using namespace std;

void calculateDifferences(int a, int b, int* squareDiff, int* cubeDiff) {
    *squareDiff = a * a - b * b;

    *cubeDiff = a * a * a - b * b * b;
}

int main() {
    int num1, num2;

    cout << "Enter the 1st number: ";
    cin >> num1;

    cout << "Enter the 2nd number: ";
    cin >> num2;

    int resultSquareDiff, resultCubeDiff;

    calculateDifferences(num1, num2, &resultSquareDiff, &resultCubeDiff);

    cout << "The difference of squares: " << resultSquareDiff << endl;
    cout << "The difference of cubes: " << resultCubeDiff << endl;

    return 0;
}
