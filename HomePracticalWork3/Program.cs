using System;

namespace HomePracticalWork3
{
    class Program
    {
        /*
        Объявить одномерный (5 элементов ) массив с именем A и двумерный массив (3 строки, 4 столбца) дробных чисел с именем B. 
        Заполнить одномерный массив А числами, введенными с клавиатуры пользователем, 
        а двумерный массив В случайными числами с помощью циклов. 
        Вывести на экран значения массивов: массива А в одну строку, массива В — в виде матрицы. 
        Найти в данных массивах общий максимальный элемент, минимальный элемент, общую сумму всех элементов, 
        общее произведение всех элементов, сумму четных элементов массива А, сумму нечетных столбцов массива В*/
        static void Main(string[] args)
        {
            ThirdTask();
            FifthTask();
        }
        static bool Polindrom(string str)
        {
            str = str.ToLower();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                if (str[i] != str[j])
                    return false;
            }
            return true;
        }
        private static void ThirdTask()
        {
            Console.WriteLine("Введите строку:");
            string str = Console.ReadLine();
            if (Polindrom(str))
                Console.WriteLine("Строка является полиндромом!");
            else
                Console.WriteLine("Строка НЕ является полиндромом!");
            Console.ReadLine();
        }
        private static void FifthTask()
        {
            int[,] B = new int[5, 5];
            int sumB = 0, max = B[0, 0], min = B[0, 0];
            int ni = 0, mj = 0, ki = 0, lj = 0;
            bool count = false;
            Random rand = new Random();

            Console.WriteLine("Массив B");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = rand.Next(-100, 100);
                    if (max < B[i, j])
                    {
                        max = B[i, j];
                        ni = i;
                        mj = j;
                    }
                    if (min > B[i, j])
                    {
                        min = B[i, j];
                        ki = i;
                        lj = j;
                    }
                    Console.Write($"{B[i, j]}\t");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if ((i == ni && j == mj) || (i == ki && j == lj))
                    {
                        if (count)
                        {
                            count = false;
                            continue;
                        }
                        else
                        {
                            count = true;
                            continue;
                        }
                    }
                    if (count)
                    {
                        sumB += B[i, j];
                    }
                }
            }
            Console.WriteLine();

            Console.WriteLine("Максимальный элемент массива B = " + max);
            Console.WriteLine("Минимальный элемент массива B = " + min);
        }
        Console.WriteLine("Cуммa элементов массива, расположенных между минимальным и максимальным элементами = " + sumB);
            Console.ReadKey();
        }
    private static void FourthTask()
    {
        Console.WriteLine("Введите предложение для подсчета слов");
        string str = Console.ReadLine();
        string[] strArray = str.Split(' ');
        Console.WriteLine("Количество слов в предложении = " + strArray.Length);
        Console.ReadKey();
    }
    private static void SecondTask()
    {
        Console.WriteLine("Введите размерность массива");

        Console.WriteLine("Введите М");
        int M = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите N");
        int N = int.Parse(Console.ReadLine());
        Random rand = new Random();
        int count = 0;
        int[] A = new int[M];
        int[] B = new int[N];
        for (int i = 0; i < A.Length; i++)
        {
            A[i] = rand.Next(15);
        }
        for (int i = 0; i < B.Length; i++)
        {
            B[i] = rand.Next(15);
            for (int j = 0; j < A.Length; j++)
            {
                if (B[i] == A[j])
                {
                    count++;
                }
            }
        }
        PrintArr("Массив A", A);
        PrintArr("Массив B", B);
        if (count != 0)
        {
            int[] AB = new int[count];

            int z = 0;
            for (int i = 0; i < B.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    if ((B[i] == A[j]) && (!AB.Contains(B[i])))
                    {
                        AB[z] = B[i];
                        z++;
                    }
                }
            }
            Array.Resize(ref AB, z);
            PrintArr("Массив общий", AB);
        }
        else
        {
            Console.WriteLine("Общих элементов в массивах нет");
        }
        Console.ReadKey();
    }
    static void PrintArr(string text, int[] arr)
    {
        Console.WriteLine(text + ": ");
        for (int A = 0; A < arr.Length; A++)
        {
            Console.Write(arr[A] + "\t");
        }
        Console.WriteLine();
        Console.ReadKey();
    }
    private static void FirstTask()
    {
        //тип [] название = new тип [количество]
        double max = 0;

        int n = 5;
        int stroka = 3;
        int stolbec = 4;
        int[] a = new int[n];
        double[,] b = new double[stroka, stolbec];
        Console.WriteLine("Введите элементы массива: ");
        for (int i = 0; i < n; i++)
        {
            a[i] = int.Parse(Console.ReadLine());

        }

        Random random = new Random();
        for (int i = 0; i < stroka; i++)
        {
            for (int j = 0; j < stolbec; j++)
            {
                b[i, j] = random.Next() % 100;
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write("a[{0}]={1}", i, a[i] + " ");
        }

        for (int i = 0; i < stroka; i++)
        {
            Console.WriteLine("\n");
            for (int j = 0; j < stolbec; j++)
            {

                Console.Write(b[i, j] + " ");

            }
            Console.WriteLine("\n");
        }
        double min = a[0];
        for (int i = 0; i < n; i++)
        {
            if (a[i] > max) max = a[i];
            if (min > a[i]) min = a[i];
        }
        for (int i = 0; i < stroka; i++)
        {
            for (int j = 0; j < stolbec; j++)
            {
                if (max < b[i, j]) max = b[i, j];
                if (min > b[i, j]) min = b[i, j];
            }
        }
        int sum1 = 0;
        for (int i = 0; i < n; i++)
        {
            sum1 += a[i];
        }
        double sum2 = 0;
        for (int i = 0; i < stroka; i++)
        {
            for (int j = 0; j < stolbec; j++)
            {
                sum2 += b[i, j];
            }
        }
        double summa = sum1 + sum2;

        double mult1 = 1;
        for (int i = 0; i < n; i++)
        {
            mult1 *= a[i];
        }
        double mult2 = 1;
        for (int i = 0; i < stroka; i++)
        {
            for (int j = 0; j < stolbec; j++)
            {
                mult2 *= b[i, j];
            }
        }
        double mult = mult1 * mult2;

        int sumOfEven = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] % 2 == 0) sumOfEven += a[i];
        }
        double summa = sum1 + sum2;

        double mult1 = 1;
        for (int i = 0; i < n; i++)
        {
            mult1 *= a[i];
        }
        double mult2 = 1;
        for (int i = 0; i < stroka; i++)
        {
            for (int j = 0; j < stolbec; j++)
            {
                mult2 *= b[i, j];
            }
        }
        double mult = mult1 * mult2;

        int sumOfEven = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] % 2 == 0) sumOfEven += a[i];
        }
        Console.WriteLine("Максимальный элемент:" + max);
        Console.WriteLine("Минимальный элемент:" + min);
        Console.WriteLine("Общая сумма:" + summa);
        Console.WriteLine("Общее произведение всех элементов:" + mult);
        Console.WriteLine("Сумма четных элементов массива А:" + sumOfEven);

        for (int i = 0; i < stroka; i++)
        {
            double sumOfOdd = 0;
            for (int j = 0; j < stolbec; j++)
            {
                if (b[i, j] % 2 != 0) sumOfOdd += b[i, j];
            }
            Console.WriteLine("Сумма нечетных столбцов массива В:" + sumOfOdd);
        }

        Console.ReadLine();
    }
    /*
     Пользователь вводит строку. 
     Проверить, является ли эта строка палиндромом. 
     Палиндромом называется строка, которая одинаково читается слева направо и справа налево*/
    private static void Main()
    {
        try
        {
            //while (true)
            {
                //var sum = 150000000.0;
                //var r = CalculateDeposit(1000000, ref sum, 0.2);
                //Console.WriteLine($"За {r} месяцев будет {sum}");
                SayHello();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            Console.ReadLine();
        }
    }
    public static void SayHello()
    {
        Console.WriteLine("Как тебя зовут?");
        var name = Console.ReadLine();
        Console.WriteLine($"Привет, {name}!");
        Console.ReadLine();
    }
    public static bool IsPalindrom(string s)
    {
        Debug.Assert(s.Length > 0);
        s = s.ToLower();
        s = Regex.Replace(s, @"\W", "");
        return ((string)s.Reverse() == s);
    }
    /* Подсчитать количество слов во введенном предложении*/
    public static int CountWords(string S)
    {
        if (S.Length == 0)
            return 0;

        S = S.Trim();
        while (S.Contains("  "))
            S = S.Replace("  ", " ");
        return S.Split(' ').Length;
    }
    /*
     Дан двумерный массив размерностью 5×5, заполненный случайными числами из диапазона от –100 до 100. 
     Определить сумму элементов массива, расположенных между минимальным и максимальным элементами*/
    static void Main(string[] args)
    {
        int[,] B = new int[5, 5];
        int sumB = 0, max = B[0, 0], min = B[0, 0];
        int ni = 0, mj = 0, ki = 0, lj = 0;
        Random rand = new Random();
        try
        {
            Console.WriteLine("Заполнение массива А");
            Console.WriteLine("Массив B");

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = rand.Next(-100, 100);
                    if (max < B[i, j])
                    {
                        max = B[i, j];
                        ni = i;
                        mj = j;
                    }
                    if (min > B[i, j])
                    {
                        min = B[i, j];
                        ki = i;
                        lj = j;
                    }
                    Console.Write($"{B[i, j]}" + "\t");
                }
                Console.WriteLine();
            }
            ();
            Console.WriteLine("Максимальный элемент массива B = " + max);
            Console.WriteLine("Минимальный элемент массива B = " + min);

            Console.WriteLine($"Максимальный элемент {B.Cast<int>().Max()}  находится в массиве на {ni} {mj} позиции");
            Console.WriteLine($"Максимальный элемент {B.Cast<int>().Min()} находится в массиве на {ki} {lj} позиции");

            Console.WriteLine("Cуммa элементов массива, расположенных между минимальным и максимальным элементами = " + sumB);
        }
        catch (Exception)
        {
            Console.WriteLine("Завершение программы");
            Environment.Exit(0);
        }
    }
}