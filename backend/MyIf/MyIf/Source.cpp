#include <iostream>
#include <Windows.h>

void main()
{
	using namespace std;
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);

	//\n - перехід на новий рядок

	cout << "--Робота з оператор if--\n";

	// Python if - if умова:
	// Умова - це вираз, який повертає true або false
	//>, <, >=, <=, !=, ==
	//Створення змінної
	// тип_даний ІМЯ_ЗМІННОЇ;
	//int - цілі числа, bool - істина або хиба, diuble - дробові числа
	//char - символ
	int age = 23;
	cout << "age = " << age << endl;
	if (age == 25) // Умовний оператор if перевіряє чи age == 23
	{// початок блоку якщо умова вірна
		cout << "Умова вірна " << age << " == 23\n";
	}// кінець блоку, якщо умова була вірна
}