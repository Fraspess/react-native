#include<iostream>
#include<Windows.h>

int main()
{
	using namespace std;
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);

	cout << "--Робота з оператором If Else--\n";
	// Оголощуємо змінну
	int a, b; // оголосили 2 змінних a та b
	cout << "Введіть а = ";
	cin >> a; //очікує вводу цілого числа, якщо 5.27 - вводиться b уже не буде, бо int
	//cin.clear(); // якщо дробове число має проблема із потоком
	cout << "Введіть b = ";
	cin >> b;
	cout << "a = " << a << "\t" << "b = " << b << "\n";
	char ch; // операція яку ми хочемо виконати +, -, /, *
	cout << "Вкажіть операцію(+, -, /, *): ";
	cin >> ch;
	//cout << "ch = " << ch << endl;
	double result=0; // буде зберігати результат операції
	if (ch == '+')
		result = a + b;
	else if (ch == '-')
		result = a - b;
	else if (ch == '/')
	{
		if (b == 0)
			cout << "Операція не можлива a == 0!\n";
		else
			result = a / (double)b; //для того, щоб було дробове ділимо на double
	}
	else if (ch == '*')
		result = a * b;
	else
		cout << "Ви обрали не доступну операці. :(\n";

	cout << "Результат операції = " << result << "\n";

	return 0;
}
