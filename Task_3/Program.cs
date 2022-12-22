/*
Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/

Console.Clear();
Console.WriteLine("Hello, World!");

// Методы

int CheckInputNumber(string Text)
{
    Console.ForegroundColor = ConsoleColor.Blue;

    int number;
    string text;

    while (true)
    {
        Console.Write(Text);
        text = Console.ReadLine();

        if (int.TryParse(text, out number)) break;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Заданное значение числа не соответствует критерию, попробуйте еще раз.");
        Console.ResetColor();
    }
    Console.ResetColor();
    return number;
}

int CheckSize(string text)
{
metka:

    int size = CheckInputNumber(text);

    if (size < 0)
    {
        Console.WriteLine("Задано отрицательное значение, попробуйте еще раз.");
        goto metka;
    }

    if (size == 0)
    {
        Console.WriteLine("Задано нулевое значение, попробуйте еще раз.");
        goto metka;
    }

    return size;
}

void EnterArrayParameter(out int size_0, out int size_1, out int leftRange, out int rightRange)
{
    size_0 = CheckSize("Введите количество строк массива : ");

    size_1 = CheckSize("Введите количество столбцов массива : ");

metka:

    leftRange = CheckInputNumber("Введите величину левого значения (края) массива : ");

    rightRange = CheckInputNumber("Введите величину правого значения (края) массива : ");

    if (leftRange == rightRange)
    {
        Console.WriteLine("Значения левого и правого края массива равны, попробуйте еще раз.");
        goto metka;
    }

    if (leftRange > rightRange)
    {
        Console.WriteLine("Заданное значение левого края массива больше правого, попробуйте еще раз.");
        goto metka;
    }
}

int[,] MakePrintArray(int m, int n, int leftRange, int rightRange)
{
    int[,] array = new int[m, n];
    Random rand = new Random();

    Console.ForegroundColor = ConsoleColor.Blue;
    System.Console.WriteLine($"\nЗадан двумерный массив размером | {m} х {n} |, заполненный случайными целыми числами в диапазоне [ {leftRange} ; {rightRange} ):\n");

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rand.Next(leftRange, rightRange);

            Console.ForegroundColor = ConsoleColor.Green;

            var ar = String.Format("{0,7}", array[i, j]);

            System.Console.Write(ar);
            Console.ResetColor();

            if (j < array.GetLength(1) - 1) System.Console.Write(" | ");
        }
        System.Console.WriteLine();
    }
    return array;
}

void ArithmeticMeanColumn(int size_0, int size_1, int[,] Arr)
{
    double[] ArMeanCol = new double[size_1];

    for (int j = 0; j < Arr.GetLength(1); j++)
    {
        double ArithmeticMean = 0;

        for (int i = 0; i < Arr.GetLength(0); i++)
        {
            ArithmeticMean += +Arr[i, j];
        }

        ArMeanCol[j] = Math.Round(ArithmeticMean / size_0, 2);

        Console.ForegroundColor = ConsoleColor.Green;

        var ar = String.Format("{0,7}", ArMeanCol[j]);

        System.Console.Write(ar);
        Console.ResetColor();

        if (j < Arr.GetLength(1) - 1) System.Console.Write(" | ");
    }
}

//  Код задачи

EnterArrayParameter(out int size_0, out int size_1, out int leftRange, out int rightRange);

int[,] Arr = MakePrintArray(size_0, size_1, leftRange, rightRange);

Console.ForegroundColor = ConsoleColor.Yellow;

System.Console.WriteLine("\nСреднее арифметическое значение элементов в каждом столбце массива :\n");

ArithmeticMeanColumn(size_0, size_1, Arr);

System.Console.WriteLine("\n");
