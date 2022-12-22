/*
Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/

Console.Clear();
Console.WriteLine("Hello, World!");

// Методы

int CheckInputNumber(string Text)
{
    Console.ForegroundColor = ConsoleColor.Yellow;

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
    int size;
    while (true)
    {
        size = CheckInputNumber(text);

        if (size < 0) Console.WriteLine("Задано отрицательное значение, попробуйте еще раз.");

        else if (size == 0) Console.WriteLine("Задано нулевое значение, попробуйте еще раз.");

        else break;
    }
    return size;
}

void EnterArrayParameter(out int size_0, out int size_1, out int leftRange, out int rightRange)
{
    size_0 = CheckSize("Введите количество строк массива : ");

    size_1 = CheckSize("Введите количество столбцов массива : ");

    while (true)
    {
        leftRange = CheckInputNumber("Введите величину левого значения (края) массива : ");

        rightRange = CheckInputNumber("Введите величину правого значения (края) массива : ");

        if (leftRange < rightRange) break;

        else if (leftRange == rightRange) Console.WriteLine("Значения левого и правого края массива равны, попробуйте еще раз.");

        else Console.WriteLine("Заданное значение левого края массива больше правого, попробуйте еще раз.");
    }
}

void MakePrintArray(int m, int n, int leftRange, int rightRange)
{
    double[,] array = new double[m, n];
    Random rand = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = Math.Round((rand.Next(leftRange, rightRange) + rand.NextDouble()), 3);

            Console.ForegroundColor = ConsoleColor.Green;

            var ar = String.Format("{0,10}", array[i, j]);

            System.Console.Write(ar);
            Console.ResetColor();

            if (j < array.GetLength(1) - 1) System.Console.Write(" | ");
        }
        System.Console.WriteLine();
    }
}

//  Код задачи

EnterArrayParameter(out int size_0, out int size_1, out int leftRange, out int rightRange);

System.Console.WriteLine($"\nДвумерный массив размером | {size_0} x {size_1} |, заполненный случайными вещественными числами :\n");

MakePrintArray(size_0, size_1, leftRange, rightRange);
System.Console.WriteLine("");