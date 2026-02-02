#include <iostream>
#include <Windows.h>
using namespace std;

class Interval {
private:
    int first;   // минимально знач
    int second;  // максимальное знач

public:
    void Read() 
    {
        cout << "Введите first (начальное): ";
        cin >> first;
        cout << "Введите second (конечное): ";
        cin >> second;
    }

    void Display() const 
    {
        cout << "Интервал: [" << first << ", " << second << ")\n";
    }

    bool rangecheck(int x) const 
    {
        return (x >= first && x < second);
    }
};

int main() 
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    Interval interval;
    interval.Read();
    interval.Display();

    int x;
    cout << "Введите число для проверки: ";
    cin >> x;

    if (interval.rangecheck(x)) 
    {
        cout << "Число " << x << " принадлежит интервалу\n";
    }
    else 
    {
        cout << "Число " << x << " не принадлежит интервалу\n";
    }

    return 0;
}