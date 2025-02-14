using System;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Модуль 5. Методы в C# 
            5.6. Итоговый проект
Задание
Необходимо написать программу в классе Program со следующим функционалом:

Необходимо создать метод, который заполняет данные с клавиатуры по пользователю (возвращает кортеж):
Имя;
Фамилия;
Возраст;
Наличие питомца;
Если питомец есть, то запросить количество питомцев;
Если питомец есть, вызвать метод, принимающий на вход количество питомцев и возвращающий массив их кличек (заполнение с клавиатуры);
Запросить количество любимых цветов;
Вызвать метод, который возвращает массив любимых цветов по их количеству (заполнение с клавиатуры);
Сделать проверку, ввёл ли пользователь корректные числа: возраст, количество питомцев, количество цветов в отдельном методе;
Требуется проверка корректного ввода значений и повтор ввода, если ввод некорректен;
Корректный ввод: ввод числа типа int больше 0.
Метод, который принимает кортеж из предыдущего шага и показывает на экран данные.
Вызов методов из метода Main.            
            */

            //Итоговый проект 5.6.1 (HW-03)

            /* можно было и так - и наверное это было бы правильнее
            (string name, string lastname, int age, bool haspet) User = (null, null, 0, false);
            User = GetUserFromConsoleNew(User);
            */

            // Получаем кортеж из метода - описание кортежа Имя; Фамилия; Возраст; Наличие питомца;
            var user = GetUserFromConsole(); // (string name, string lastname, int age, bool haspet) User;

            /*Если питомец есть, то запросить количество питомцев и вызвать метод, принимающий на вход
              количество питомцев и возвращающий массив их кличек(заполнение с клавиатуры);
            */
            int CntPet;

            if (user.haspet == false) //Было введено Да
            {
                //Проверяем ввод количество питомцев
                do
                {
                    Console.WriteLine("Введите количество питомцев");
                } while (CheckNum(Console.ReadLine(), out CntPet));
                string[] pets = CreateArray(CntPet);
            }

            /* Запросить количество любимых цветов;
               Вызвать метод, который возвращает массив любимых цветов по их количеству (заполнение с клавиатуры);
            */
            int cnt_favcolors;
            //Проверяем ввод количество любимых цветов
            do
            {
                Console.WriteLine("Введите количество любимых цветов");
            } while (CheckNum(Console.ReadLine(), out cnt_favcolors));
            string[] favcolors = CreateArray(cnt_favcolors);

            //Метод, который принимает кортеж user и показывает на экран данные
            DisplayUserValue(user.name, user.lastname, user.age, user.haspet);

            Console.ReadKey();
        }

        // Метод, возвращающий кортеж
        static (string name, string lastname, int age, bool haspet) GetUserFromConsole()
        {
            string curr_input;
            string name;
            string lastname;
            int intage;
            bool haspet;

            //Проверяем ввод имени
            do
            {
                Console.WriteLine("Введите имя");
            } while (IsValidName(Console.ReadLine(), out curr_input)); //Если условие истинно, цикл повторяется.
            {
                name = curr_input; // Console.ReadLine();
            }

            //Проверяем ввод фамилии
            do
            {
                Console.WriteLine("Введите фамилию");
            } while (IsValidName(Console.ReadLine(), out curr_input));
            {
                lastname = curr_input; // Console.ReadLine();
            }

            //Проверяем ввод возраста
            do
            {
                Console.WriteLine("Введите возраст");
            } while (CheckNum(Console.ReadLine(), out intage));

            //Проверяем ввод наличия животных
            do
            {
                Console.WriteLine("Есть ли у вас животные? Да или Нет");
            } while (IsValidHaspet(Console.ReadLine()));
            {
                if (Console.ReadLine() == "Да")
                {
                    haspet = true;
                }
                else
                {
                    haspet = false;
                }
            }

            // Возвращаем кортеж с введенными значениями
            return (name, lastname, intage, haspet);
        }

        // Метод для проверки, что строка является именем или фамилией
        static bool IsValidName(string name, out string cur_input)
        {
            bool result;

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ошибка: ввод пустой.");
                cur_input = "";
                return true;
            }

            // Регулярное выражение для проверки: fcdv
            // ^ - начало строки
            // [A-Za-zА-Яа-я] - буквы латинского и русского алфавита
            // - и пробел также разрешены
            // + - один или более символов
            // $ - конец строки
            string pattern = @"^[A-Za-zА-Яа-я\s-]+$";

            //Проверка с использованием регулярного выражения
            cur_input = name;
            result = Regex.IsMatch(name, pattern);
            if (result == false)
            {
                Console.WriteLine("Ошибка: имя и фамилия содержат недопустимые символы.");
                return true;
            }
            else
            {
                return false;
            }
            //return Regex.IsMatch(name, pattern);
        }

        static bool IsValidHaspet(string input)
        {
            bool result;
            if (input == "Да" || input == "Нет")
            {
                result = false;
            }
            else
            {
                result = true;
                Console.WriteLine("Ошибка: допустим ввод Да или Нет.");
            }
            return result;
        }

        static bool CheckNum(string num, out int corrnumber)
        {
            if (int.TryParse(num, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    //Console.WriteLine("Ошибка: допусим только ввод цифрами");
                    return false;
                }
            }
            {
                corrnumber = 0;
                Console.WriteLine("Ошибка: введите возраст цифрами");
                return true;
            }

        }

        static string[] CreateArray(int num)
        {
            var result = new string[num];
            for (int i = 0; i < num; i++)
            {
                Console.Write($"Введите текстом запрашиваемое значение  {i + 1}: ");
                result[i] = Console.ReadLine();
            }
            return result;
        }
        static void DisplayUserValue(string name, string lastname, int age, bool haspet)
        {
            Console.WriteLine("Имя: {0}", name);
            Console.WriteLine("Фамилия: {0}", lastname);
            Console.WriteLine("Возраст: {0}", age);
            Console.WriteLine("Наличие питомца: {0}", haspet);
        }
    }
}
