using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Модуль 5. Методы в C# 
            
            5.1. Введение. Методы

            Создайте кортеж User, содержащий имя пользователя Name и массив с текстовой информацией о его пяти любимых блюдах Dishes. 
            Заполните имя пользователя через ввод в консоль, а информацию о блюдах — в цикле через консоль
            
                (string Name, string[] dishes) User;

                Console.WriteLine("Введите имя");
                User.Name = Console.ReadLine();

                User.dishes = new string[5];
                for (int i = 0; i < User.dishes.Length; i++)
                {
                    Console.WriteLine("Введите любимое блюдо номер {0}", i + 1);
                    User.dishes[i] = Console.ReadLine();
                }
                Console.ReadKey();

            Какой код позволяет создать бесконечный цикл?

            2.for(int i=0; ; i++) { ... }
            4.while (true) { …}

            1.while(false) { ... }          Данный цикл не будет работать, так как условие неверно
            3.do { ...} while (false)       Данный цикл отработает один раз и остановится, так как условие неверно

            Какие служебные слова относятся к условной конструкции switch?

            case, switch
            end, begin. done, if, else, continue    не относятся 

            Выберите правильное написание тернарной операции:

            a == b ? c = a : 0;

            if (a == b) { c = a; }                  не относятся   
            else (a == b) ? c = a ;                 не относятся 
            a == b ? c;                             не относятся 
            (a == b) ? c = a;                       не относятся 

            // 5.1. Методы
            Копирование кода — одна из самых плохих вещей в программировании, которую необходимо всеми силами избегать. 
            Копирование кода ведёт к ошибкам: часто по невнимательности, или, что хуже, когда в одном месте скопированный код поменяли,
            а в другом — забыли или не нашли.
            C# дает для этого мощный инструмент — методы. В общем виде синтаксис метода выглядит вот так:

                модификатор возвращаемое значение Название метода ( параметры метода) 
                {
	                тело метода
                }

             основным в идее использования методов является переиспользование уже существующего кода
             Давайте запишем наше условие так, чтобы не нужно было его копировать:

                static void ShowColor() 
                {
                    Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
                    switch (Console.ReadLine()) 
                    {
                    case "red":
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine("Your color is red!");


            */

            var (name, age) = ("Евгения", 27);

            Console.WriteLine("Мое имя: {0}", name);
            Console.WriteLine("Мой возраст: {0}", age);

            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите возрас с цифрами:");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ваше имя: {0}", name);
            Console.WriteLine("Ваш возраст: {0}", age);

            ShowColor();

            var array = GetArrayFromConsole();
        }

        /*
        static - 'то первое слово, которое нам не знакомо.Оно является модификатором метода
        Но, так как мы пишем метод сейчас в нашем классе Program, этот модификатор является необходимым. Если мы уберём его, 
        увидим ошибку при попытке использовать метод.
        void — тип данных, означающий «ничего», «пустоту». Это значит, что при вызове этого метода ничего не вернётся, он просто 
        выполнит свои действия и никакого взаимодействия с программой, которая его вызывает, не будет.
        */
        static void ShowColor()  
        {
            Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
            var color = Console.ReadLine();

            switch (color)
            {
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is red!");
                    break;

                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is green!");
                    break;
                case "cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is cyan!");
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Your color is yellow!");
                    break;
            }
        }

        /* Visual Studio помогает нам не совершать ошибок.А именно, мы говорим, что метод должен вернуть значение… Но не возвращаем его.
         В чём ошибка?
            Неправильное название метода
            Ошибка в типе данных
            Слишком длинный метод
            Метод не возвращает значение - X (объявление метода расходится с его фактическими действиями.)

         Для начала модифицируем наш метод так, чтобы значение в нем сохранялось. 
         Теперь у нас есть переменная, в которой сохранилось значение, которое ввёл пользователь

                Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
                var color = Console.ReadLine();
                witch (color)

         Чтобы вернуть её в основную программу, нам понадобится служебное слово return. Добавим его в конце метода после блока switch.

                    return color;
            }

        Метод возвращает значение, но мы никак не получаем его. Получать значение необязательно, а вот отдавать из метода — да.
        Если же нам не требуется возвращать из метода значение, то мы указываем тип данных void.

        Обратите внимание: оператор return также возвращает из метода не только значение, но и нас с вами. То есть, если мы укажем 
        return сразу после того, как прочитали значение из консоли, то логика в блоке switch не будет работать.
        Код сразу станет бледным и появится подсказка, что код не достижим. Это является ошибкой: зачем нам код, который не выполнится?

        В случае же, если бы нам нужен был не весь наш метод, а просто мы хотели бы читать данные из консоли, то мы могли бы обойтись 
        только одной командой — Console.ReadLine().

             static string GetDataFromConsole()
                {
                    return Console.Readline();
                }

        Сокращенная запись метода -  только с методами, в которых всего лишь одна операция

                static string GetDataFromConsole() => Console.ReadLine();

        Напишите программу, которая в цикле вызывает метод ShowColor(), записывает его значение в массив из трех цветов favcolors, 
        а потом отображает значения этого массива. 

             static int[] GetArrayFromConsole()
                {
                 var result = new int[5];
                 for (int i = 0; i < result.Length; i++)
                    {
                     Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                     result[i] = int.Parse(Console.ReadLine());
                    }
                    return result;
                 }

        Модифицируйте метод из скринкаста:  после ввода массива с клавиатуры необходимо отсортировать массив и вывести его на экран.

        static int[] GetArrayFromConsole()
        {
            var result = new int[5];
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }

            int temp = 0;

            for(int i = 0; i < result.Length; i++)
                for (int j = i + 1; j < result.Length; j++)
                    if (result[i] > result[j]) 
                    {
                        temp = result[i];
                        result[j] = result[i];
                        result[i] = temp;
                    }
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }

                return result;
        }

        Напишите вызов метода GetArrayFromConsole() в переменную array.
        var array = GetArrayFromConsole();

        */

        static int[] GetArrayFromConsole()
        {
            var result = new int[5];
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }

            int temp = 0;

            for (int i = 0; i < result.Length; i++)
                for (int j = i + 1; j < result.Length; j++)
                    if (result[i] > result[j])
                    {
                        temp = result[i];
                        result[j] = result[i];
                        result[i] = temp;
                    }
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }

            return result;
        }
    }
}
