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
            5.3. Передача параметров

            Задание 5.3.8
            Необходимо передать по ссылке размерность массива в метод GetArrayFromConsole и изменить её на 6.

        Было:     
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
        
        Стало:
        static int[] GetArryFromConsole(ref int num)
        {
            var result = new int[num];
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }
            return result;
        }

            На самом деле, есть ещё один способ менять переменные из метода. Это модификатор параметра out. 
            Этот модификатор значит, что параметр является выходным, то есть его значение является результатом работы метода.

        static void GetName(out string name)
        {
            Console.WriteLine("Введите имя");
            name = Console.ReadLine();

        }

            Зачем же это может понадобиться? Например, если мы хотим менять в одном методе сразу несколько объектов:

        static void GetName(out string name, out string oldname)
        {
            oldname = "Евгения";
            Console.WriteLine("Введите имя");
            name = Console.ReadLine();

        }

            Задание 5.3.9
            Подумайте, в чём может быть основная разница между модификаторами ref и out?

                    out должно быть обязательно изменено, а ref можно не менять

            Параметр out обязательно необходимо вернуть из метода, то есть параметру обязательно нужно присвоить какое-либо значение.
            Иначе компилятор выдаст ошибку.

            Задание 5.3.10
            Напишите сигнатуру (объявление) метода GetAge с выходными параметрами Name и Age типов string и byte соответственно.

                        void GetAge(out string name, out byte Age)

            Модификатор out не требует изначальной инициализации переменных: нам не нужно присваивать им какое-то значение изначально, 
            мы можем объявить его сразу в методе.

        GetName(out string name, out var oldname);

        Console.WriteLine(name);
        Console.WriteLine(oldname);

            Обратите внимание: все модификаторы требуется указывать и при вызове метода так же.

            Задание 5.3.12 Соотнесите модификаторы и описания:

                    ref - входной параметр передача по ссылке, в методе можно изменять
                    in  - входной параметр передача по ссылке, но в методе нельзя изменять (за искл. ссылочных переменных)
                    out - входной параметр передача по ссылке, можно не объявлять заранее

            Задание 5.3.13 
            Используйте код метода SortArray. Сейчас этот метод сортирует массив по возрастанию значения. 
            Создайте методы SortArrayDesc и SortArrayAsc — сортировка массива от большего к меньшему и сортировка массива от меньшего к большему.

            Метод SortArray модифицируйте так, чтобы он вызвал оба этих метода. Результаты методов SortArrayAsc и SortArrayDesc должны представлять собой массивы.

            Метод SortArray должен иметь один входной параметр array и два выходных: sorteddesc и sorted asc.

            Подсказка 1 SortArrayAsc — копия метода SortArray без изменений, просто скопируйте и переименуйте метод.
            Подсказка 2 Для того чтобы изменить порядок сортировки, нужно просто изменить знак с «больше» на «меньше» в условии перестановки элементов.
            Подсказка 3 Метод SortArray не должен ничего возвращать.
            Подсказка 4 Объявление метода SortArray:

                    static void SortArray(in int[] array,  out int[] sorteddesc, out int[] sortedask)
                    {

            Решение:        

        static void SortArray(in int[] array, out int[] sorteddesc, out int[] sortedask)
        {
            sorteddesc = SortArrayDesc(array);
            sortedask = SortArrayAsc(array);
        }       

            static int[] SortArrayDesc(int[] result)
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

        static int[] SortArrayAsc(int[] result)
        {
            int temp = 0;

            for (int i = 0; i > result.Length; i++)
                for (int j = i + 1; j < result.Length; j++)  //изменили знак
                    if (result[i] > result[j])
                    {
                        temp = result[i];
                        result[j] = result[i];
                        result[i] = temp;
                    }

            return result;
        }
            */
        }
    }
}
