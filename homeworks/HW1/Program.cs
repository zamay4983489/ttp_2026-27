using System;
using System.Collections.Generic;

namespace HW1
{
    class Program
    {

        static List<string> istoriya = new List<string>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Добро пожаловать в мини-банкомат!");

            double balance = -1;
            while (balance < 0)
            {
                Console.WriteLine("Введите начальный баланс:");
                string stroka = Console.ReadLine();
                double chislo;
                bool poluchilos = double.TryParse(stroka, out chislo);

                if (poluchilos == false)
                {
                    Console.WriteLine("Это не число, попробуйте ещё раз");
                }
                else if (chislo < 0)
                {
                    Console.WriteLine("Баланс не может быть отрицательным");
                }
                else
                {
                    balance = chislo;
                }
            }

            istoriya.Add($"Открыт счёт с балансом {balance} ₽");

            int vibor = -1;

            while (vibor != 0)
            {
                Console.WriteLine();
                Console.WriteLine("=== МЕНЮ ===");
                Console.WriteLine("1 - Показать баланс");
                Console.WriteLine("2 - Пополнить счёт");
                Console.WriteLine("3 - Снять деньги");
                Console.WriteLine("4 - Показать историю операций");
                Console.WriteLine("0 - Выйти");
                Console.WriteLine("Что вы хотите сделать?");

                string vvod = Console.ReadLine();
                bool poluchilos = int.TryParse(vvod, out vibor);

                if (poluchilos == false)
                {
                    Console.WriteLine("Нужно ввести номер пункта меню (число)");
                    vibor = -1;
                }
                else if (vibor == 1)
                {
                    PrintBalance(balance);
                }
                else if (vibor == 2)
                {
                    balance = Popolnit(balance);
                }
                else if (vibor == 3)
                {
                    balance = Snyat(balance);
                }
                else if (vibor == 4)
                {
                    PrintIstoriya();
                }
                else if (vibor == 0)
                {
                    Console.WriteLine("До свидания!");
                }
                else
                {
                    Console.WriteLine("Такого пункта нет, попробуйте ещё раз");
                }
            }
        }

        static double Popolnit(double balance)
        {
            Console.WriteLine("Введите сумму пополнения:");
            string vvod = Console.ReadLine();
            double summa;
            bool poluchilos = double.TryParse(vvod, out summa);

            if (poluchilos == false)
            {
                Console.WriteLine("Это не число, операция отменена");
            }
            else if (summa > 0)
            {
                balance = balance + summa;
                Console.WriteLine($"Счёт пополнен на {summa} ₽");
                istoriya.Add($"Пополнение: +{summa} ₽, баланс стал {balance} ₽");
            }
            else
            {
                Console.WriteLine("Сумма должна быть больше нуля!");
            }

            return balance;
        }

        static double Snyat(double balance)
        {
            Console.WriteLine("Введите сумму снятия:");
            string vvod = Console.ReadLine();
            double summa;
            bool poluchilos = double.TryParse(vvod, out summa);

            if (poluchilos == false)
            {
                Console.WriteLine("Это не число, операция отменена");
            }
            else if (summa <= 0)
            {
                Console.WriteLine("Сумма должна быть больше нуля!");
            }
            else if (summa > balance)
            {
                Console.WriteLine("Недостаточно денег на счёте!");
            }
            else
            {
                balance = balance - summa;
                Console.WriteLine($"Вы сняли {summa} ₽");
                istoriya.Add($"Снятие: -{summa} ₽, баланс стал {balance} ₽");
            }

            return balance;
        }

        static void PrintBalance(double balance, string valuta = "₽")
        {
            Console.WriteLine($"Ваш баланс: {balance} {valuta}");
        }

        static void PrintIstoriya()
        {
            if (istoriya.Count == 0)
            {
                Console.WriteLine("История пустая");
            }
            else
            {
                Console.WriteLine("История операций:");
                for (int i = 0; i < istoriya.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {istoriya[i]}");
                }
            }
        }
    }
}
