/*
Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/

Console.Clear();
Console.WriteLine("Hello, World!");

NAMBERS(out int size_0, out int size_1, out int leftRange, out int rightRange);

FillAndPrintArray(size_0, size_1, leftRange, rightRange);

// Методы
void FillAndPrintArray(int m, int n, int leftRange, int rightRange)
{
    double[,] array = new double[m, n];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = Math.Round((new Random().Next(leftRange, rightRange) + (Math.Abs(new Random().NextDouble()))), 3);
            Console.ForegroundColor = ConsoleColor.Green;
            var ar = String.Format("{0,10}", array[i, j]);
            System.Console.Write(ar);
            Console.ResetColor();
            System.Console.Write(" | ");
        }
        System.Console.WriteLine();
    }
}

/*
double[] FillArrayWithRandomNumbers(int size, int leftRange, int rightRange)
{
    double[] tempArr = new double[size];
    Random rand = new Random();
    for(int i = 0; i < tempArr.Length; i++)
    {
        tempArr[i] = rand.Next(leftRange, rightRange) - Math.Round(rand.NextDouble(), 3);
    }
    return tempArr;
}
*/

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

void NAMBERS(out int size_0, out int size_1, out int leftRange, out int rightRange)
{
   size_0 = CheckSize("Введите количество строк массива : ");

   size_1 = CheckSize("Введите количество столбцов массива : ");
   
   /*
    while (true)
    {
        size_0 = CheckInputNumber("Введите количество строк массива от двух элементов : ");

        if (size_0 < 0) Console.WriteLine("Задано отрицательное значение, попробуйте еще раз.");

        else if (size_0 == 0) Console.WriteLine("Задано нулевое значение, попробуйте еще раз.");

        else if (size_0 == 1) Console.WriteLine("Задан массив с одним элементом, попробуйте еще раз.");

        else break;
    }

    while (true)
    {
        size_1 = CheckInputNumber("Введите размер столбцов массива от двух элементов : ");

        if (size_1 < 0) Console.WriteLine("Задано отрицательное значение, попробуйте еще раз.");

        else if (size_1 == 0) Console.WriteLine("Задано нулевое значение, попробуйте еще раз.");

        else if (size_1 == 1) Console.WriteLine("Задан массив с одним элементом, попробуйте еще раз.");

        else break;
    }
*/
    while (true)
    {
        leftRange = CheckInputNumber("Введите величину левого значения массива : ");

        rightRange = CheckInputNumber("Введите величину правого значения массива : ");

        if (leftRange <= rightRange) break;

        Console.WriteLine("Заданное значение левого края массива больше правого, попробуйте еще раз.");
    }
}

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