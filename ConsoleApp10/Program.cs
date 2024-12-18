using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massiv
{
    class Program
    {
        // Главная точка входа программы
        static async Task Main() // Асинхронный метод для запуска программы
        {
            Console.OutputEncoding = Encoding.UTF8; // Установка кодировки UTF-8 для корректного отображения кириллицы

            // Бесконечный цикл для отображения меню и выполнения выбранных задач
            while (true)
            {
                // Вывод меню на экран
                Console.WriteLine("Выберите задачу для выполнения:");
                Console.WriteLine("1 - Задача 1");
                Console.WriteLine("2 - Задача 2");
                Console.WriteLine("3 - Задача 3");
                Console.WriteLine("4 - Задача 4");
                Console.WriteLine("0 - Выйти");

                string choice = Console.ReadLine(); // Чтение выбора пользователя
                Task selectedTask = null;

                // Обработка выбора пользователя
                switch (choice)
                {
                    case "1":
                        selectedTask = Task1(); // Вызов метода для задачи 1
                        break;
                    case "2":
                        selectedTask = Task2(); // Вызов метода для задачи 2
                        break;
                    case "3":
                        selectedTask = Task3(); // Вызов метода для задачи 3
                        break;
                    case "4":
                        selectedTask = Task4(); // Вызов метода для задачи 4
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы."); // Вывод сообщения при выходе из программы
                        return; // Завершение программы
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте еще раз."); // Сообщение об ошибке при некорректном вводе
                        break;
                }

                // Ожидание завершения выбранной задачи
                if (selectedTask != null)
                {
                    await selectedTask; // Ожидание выполнения задачи
                    Console.WriteLine("Задача завершена."); // Сообщение о завершении задачи
                }

                Console.WriteLine(""); // Пустая строка для разделения вывода между выполненными задачами
            }
        }

        // Задача 1: Заполнение массива и вывод в обратном порядке
        static async Task Task1()
        {
            // Вывод информации о задаче
            Console.WriteLine("Задача 1: Заполнение массива по размерности N:");
            System.Console.OutputEncoding = System.Text.Encoding.UTF8; // Установка кодировки для корректного отображения

            Console.Write("Введите размер массива N: ");
            int N = int.Parse(Console.ReadLine()); // Чтение размера массива

            // Создание массива размерностью N
            int[] array = new int[N];

            // Заполнение массива числами от 1 до N
            for (int i = 0; i < N; i++)
            {
                array[i] = i + 1; // Заполнение массива
            }

            // Вывод элементов массива в обратном порядке
            Console.WriteLine("Элементы массива в обратном порядке:");
            for (int i = N - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " "); // Печать элементов массива
            }
            Console.WriteLine(); // Переход на новую строку
        }

        // Задача 2: Заполнение двумерного массива по шаблону
        static async Task Task2()
        {
            int rows = 15; // Количество строк в массиве
            int columns = 15; // Количество столбцов в массиве

            // Создание двумерного массива
            int[,] aquare = new int[rows, columns];

            // Заполнение массива по шаблону
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Если индекс столбца больше или равен индексу строки, то присваиваем 1
                    if (j >= i)
                    {
                        aquare[i, j] = 1;
                    }
                    else
                    {
                        aquare[i, j] = 0; // В остальных случаях присваиваем 0
                    }
                }
            }

            // Вывод массива на экран1
            Console.WriteLine("\nЗадача 2: Заполнение массива по шаблону:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(aquare[i, j] + " "); // Вывод элемента массива с пробелом
                }
                Console.WriteLine(); // Переход на новую строку после вывода каждого ряда
            }
        }

        // Задача 3: Заполнение двумерного массива по спирали
        static async Task Task3()
        {
            int n = 6; // Размерность массива
            int[,] spiralArray = new int[n, n]; // Инициализация двумерного массива

            // Заполнение массива по спирали
            FillSpiral(spiralArray, n);

            // Вывод заполненного массива
            Console.WriteLine("\nЗадача 3: Заполнение массива спиралью:");
            PrintArray(spiralArray); // Печать массива
        }

        // Метод для заполнения массива по спирали
        static void FillSpiral(int[,] array, int n)
        {
            int value = 1; // Начальное значение для заполнения массива
            int top = 0, bottom = n - 1, left = 0, right = n - 1; // Границы массива

            while (value <= n * n) // Заполняем массив до последнего элемента
            {
                // Заполнение верхней строки
                for (int i = left; i <= right; i++)
                {
                    array[top, i] = value++; // Присваиваем значения в верхней строке
                }
                top++; // Сдвигаем верхнюю границу вниз

                // Заполнение правого столбца
                for (int i = top; i <= bottom; i++)
                {
                    array[i, right] = value++; // Присваиваем значения в правый столбец
                }
                right--; // Сдвигаем правую границу влево

                // Заполнение нижней строки
                if (top <= bottom) // Проверка, есть ли еще строки для заполнения
                {
                    for (int i = right; i >= left; i--)
                    {
                        array[bottom, i] = value++; // Присваиваем значения в нижнюю строку
                    }
                    bottom--; // Сдвигаем нижнюю границу вверх
                }

                // Заполнение левого столбца
                if (left <= right) // Проверка, есть ли еще столбцы для заполнения
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        array[i, left] = value++; // Присваиваем значения в левый столбец
                    }
                    left++; // Сдвигаем левую границу вправо
                }
            }
        }

        // Метод для вывода двумерного массива на экран
        static void PrintArray(int[,] array)
        {
            int n = array.GetLength(0); // Получаем размерность массива
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j] + "\t"); // Печать элемента массива с табуляцией
                }
                Console.WriteLine(); // Переход на новую строку после вывода ряда
            }
        }

        // Задача 4: Пустая задача
        static async Task Task4()
        {
            // Пустой метод, не выполняет действий
        }
    }
}