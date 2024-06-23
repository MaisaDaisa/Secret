#include <iostream>
using namespace std;

void printMas(int* mas, int start, int end);
int povnaNashtis(int* mas, int start, int end, int gamyofi);

int main() {

    const int max_n = 100000;
    int m = 0;

    while (!(m <= 1015 && m >= 2)) {
        cout << "Chawere m (2 <= m <= 1015): ";
        cin >> m;
    }

    int sidide = 0;
    while (!(2 <= sidide && sidide <= max_n)) {
        cout << "ramden ricxva ginda iyos A (2 <= A <= 100000): ";
        cin >> sidide;
    }

    int A[max_n] = { 0 };

    for (int i = max_n - sidide; i < max_n; i++) {
        int temp = -1;
        while (!(0 <= temp && temp < 10)) {
            cout << "Chawere ricxvi (0 <= ricxvi < 10): ";
            cin >> temp;
        }
        A[i] = temp;
    }

    int startIndex = max_n - sidide;

    printMas(A, startIndex, max_n);

    int nashti = povnaNashtis(A, startIndex, max_n, m);

    cout << "NASHTI ARIS " << nashti << endl;
    return 0;
}

void printMas(int* mas, int start, int end) {
    for (int i = start; i < end; i++) {
        cout << mas[i] << " ";
    }
    cout << endl;
}

int povnaNashtis(int* mas, int start, int end, int gamyofi) {
    int nashti = 0;
    for (int i = start; i < end; i++) {
        nashti = (nashti * 10 + mas[i]) % gamyofi;
    }
    return nashti;
}
