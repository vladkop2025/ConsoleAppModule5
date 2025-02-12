﻿using System;
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
            2. Параметры методов

            Задание 5.2.1
            Выберите методы, которые принимают значения:
               
                    Console.WriteLine
                    Console.Write
             

            Параметры метода — значение, который метод принимает извне для использования. Они указываются в скобках в объявлении метода.
            Используем тот, что у нас уже есть, — метод ShowColor()

                    static string ShowColor(string username)

            Тип данных может быть любым, также как и имя переменной (имя должно соответствовать всем правилам, которые вы узнали ранее).
            То, что мы вводим методу в скобках — некие переменные и их значение, они называются аргументами метода.
            Иногда можно встретить такие определения как формальные параметры и фактические параметры.
                Формальные параметры — это собственно параметры метода, то есть переменная, её тип и название.
                Фактические параметры — значения, которые передаются формальным параметрам.
            Между параметрами в методе и параметрами, которые мы пытаемся передать, должно быть соответствие по типу.

            Давайте добавим параметр, чтобы все же передать возраст в метод. Для этого требуется написать ещё один параметр через запятую.

                    static string ShowColor(string username, int userage)

            Как сделать перенос строки: имя, возраст на одной, а "Напишите свой любимый цвет" на другой? Напишете нужный строковый литерал.

                    Console.WriteLine("Имя {0} Возраст {1} \nНапишите свой любимый цвет {2}", name, age, favcolor);

            Обратите внимание: Этот литерал работает для операционной системы Windows. Для работы без привязки к конкретной операционной 
            системе необходимо использовать Environment.NewLine.


            Внесите корректировки в код вывода ваших параметров на экран так, чтобы имя и возраст выводились одной строкой, а "Напишите свой любимый цвет" — другой.
            
                    Console.WriteLine("{0}, {1} лет \nНапишите свой любимый цвет на английском с маленькой буквы {2}", username, userage);

            Сейчас мы использовали всего два параметра метода, но сколько же их может быть еще? Весьма много, но есть некоторые оговорки.  
            Число 7 — некий психологический предел, когда становится не слишком удобно работать с методом.
            Что же делать, если параметров действительно требуется много? Сто, двадцать, тридцать? Массив?
            Собственно, как параметр метода мы действительно можем передать и массив. 

                    static void ShowColors(string[] favcolors)
                     {
                        Console.WriteLine("Ваши любимые цвета:");
                        foreach (var color in favcolors)
                        {
                            Console.WriteLine(color);
                        }
                     }

            Задание 5.2.8
            Разделить метод из задания 5.1.6 GetArrayFromConsole() на два: один метод GetArrayFromConsole() должен читать введенные с клавиатуры массивы 
            и возвращать их, второй метод SortArray() должен принимать параметром массив array типа данных int, сортировать его и возвращать.

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


        static int[] SortArray(int[] result)
        {
            int temp = 0;

            for (int i = 0; i < result.Length; i++)
                for (int j = i + 1; j < result.Length; j++)
                    if (result[i] > result[j])
                    {
                        temp = result[i];
                        result[j] = result[i];
                        result[i] = temp;
                    }

            return result;
        }

            Но если у нас не массив? Если мы хотим не передавать массив, а просто много значений? Причем не зная, сколько значений?
            Писать условия? Передавать в цикле? Создавать массив для каждого случая?
            И на помощь нам приходит массив параметров params. Это ключевое слово обозначает как раз передачу массива параметров, 
            то есть массив отдельно не нужно объявлять.

            Внимание: массив params нужен для передачи неопределенного количества параметров, то есть, когда мы заранее не знаем, 
            сколько их будет. Может быть один, два, десять или не быть вовсе.


        static void ShowColors(params string[] favcolors)
        {
            Console.WriteLine("Ваши любимые цвета:");
            foreach (var color in favcolors)
            {
                Console.WriteLine(color);
            }
        }

            Запустим выполнение, но результат будет идентичный. А если вдруг мы хотим указать из этого массива только первый и последний элемент? Давайте сделаем:

                    ShowColors(favcolors[0],favcolors[2]);

            Задание 5.2.9
            Какой результат будет отображен на экране, если мы введём cyan, red и green

                    cyan, green

            Задание 5.2.10
            Как вызвать метод так, чтобы результат совпадал со скриншотом? (не выводим цвета в мринципе)
              
                    ShowColor();

            В случае же, если мы хотим кроме массива параметров передать какой-то ещё параметр, его необходимо ставить перед этим массивом. 
            Давайте посмотрим на примере, передадим в наш метод имя.

                    static void ShowColors(string username, params string[] favcolors)

            Метод в этом случае вызывается следующим образом:

                    ShowColors(name)

            Задание 5.2.11 
            Передайте в метод кроме имени (name) ещё массив всех введенных ранее цветов (favcolors).

                    ShowColors(name, params string[] favcolors)

            Задание 5.2.12 
            Что будет, если указать параметры, поменяв их местами? - Ошибка

                    ShowColors(params string[] favcolors, string username) 
             
            Кроме того, чтобы указывать параметры с помощью переменных или массива, мы можем указать их просто с помощью литералов, 
            самостоятельно напечатав необходимое значение. Или комбинировать эти подходы.

                    ShowColors(name, "red", "cyan");

            А если же нам требуется в соответствии с логикой то указывать, то не указывать разные параметр?
            Здесь на помощь нам приходят необязательные параметры — это параметры, которые уже имеют некое значение «по умолчанию» и его можно опустить.
            Например, если мы не хотим вводить имя каждый раз в метод. Давайте просто введём какое-то значение для него?
            Делается это следующим образом:

                    static void ShowColors(string username = "Jane", params string[] favcolors)

            Задание 5.2.13 
            Вызовите метод, не передавая в него никаких параметров.
            
                    static void ShowColors(,)

            Задание 5.2.14
            Используйте методы из задания 5.2.8. Модифицируйте метод GetArrayFromConsole так, чтобы размерность массива указывалась 
            в качестве необязательного параметра num. Значение по умолчанию оставить 5. 

        static int[] GetArrayFromConsole(int num = 5)
        {
            var result = new int[num];
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }
            return result;

        }

            Задание 5.2.15 
            Вызовите метод GetArrayFromConsole, не указывая необязательный параметр. Результат работы метода должен быть в переменной array. 
            Передайте эту переменную в метод SortArray, а результат этого метода сохраните в переменной sortedarray.

                    var array = GetArrayFromConsole();
                    var sortedarray = SortArray(array);

            Задание 5.2.16
            Измените размерность массива для метода GetArrayFromConsole на 3.
                    
                    var array = GetArrayFromConsole(3);

            Задание 5.2.17
            Создайте метод ShowArray с параметрами: массив чисел, признак сортировки логического типа, необязательный параметр, по умолчанию ЛОЖЬ. 
            Метод должен выводить массив на экран. Если значение признака сортировки равно ИСТИНА, то предварительно массив нужно отсортировать.

        static void ShowArray(int[] array, bool IsSort = false)
        {
            var temp = array;
            if (IsSort) 
            {
                temp = SortArray(Array);
            }

        }

            Задание 5.2.18 
            Вызовите сначала метод заполнения данных массива размерности 10, а потом метод его вывода на экран с сортировкой.

        var array = GetArrayFromConsole(10);
        ShowArray(Array,true);

            */

        }
    }
}
