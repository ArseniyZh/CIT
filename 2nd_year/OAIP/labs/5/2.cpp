#include <iostream>
#include <cmath>

using namespace std;

double calculateMaxDeviation(const int* arr, int size) {
    double sum = 0;
    for (int i = 0; i < size; ++i) {
        sum += arr[i];
    }
    double average = sum / size;

    double maxDeviation = 0;
    for (int i = 0; i < size; ++i) {
        double deviation = abs(average - arr[i]);
        if (deviation > maxDeviation) {
            maxDeviation = deviation;
        }
    }

    return maxDeviation;
}

int main() {
    const int maxSize = 100;
    int arr[maxSize];

    int size;

    cout << "Enter the size of the array: ";
    cin >> size;

    cout << "Enter the elements of the array:\n";
    for (int i = 0; i < size; ++i) {
        cout << "arr[" << i << "]: ";
        cin >> arr[i];
    }

    double maxDeviation = calculateMaxDeviation(arr, size);

    cout << "Absolute value of the maximum deviation: " << maxDeviation << endl;

    return 0;
}
