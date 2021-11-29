while (true)
{
    Console.Write("Введите Число экспертов: ");
    int experts = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    Console.Write("Введите число целей: ");
    int aims = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    double[,] matrix = new double[experts, aims];
    for (int i = 0; i < experts; i++)
    {
        for (int j = 0; j < aims; j++)
        {
            Console.Write("Введите значение " + (i + 1).ToString() + " " + (j + 1).ToString() + ":");
            matrix[i, j] = Convert.ToDouble(Console.ReadLine());
        }
    }
    Console.Clear();

    double[] expsum = new double[experts];
    for (int i = 0; i < experts; i++)
    {
        for (int j = 0; j < aims; j++)
        {
            expsum[i] = expsum[i]+matrix[i, j];
        }
        for(int j = 0; j < aims; j++)
        {
            matrix[i, j] = Math.Round((matrix[i, j] / expsum[i]), 4);
        }
    }

    double[,] results = new double[2, aims];
    for(int i = 0; i < aims; i++)
    {
        for(int j = 0; j < experts; j++)
        {
            results[0, i] = results[0, i] + matrix[j, i];
        }
        results[1, i] = Convert.ToDouble(i + 1);
    }

    for(int i = 0; i < aims; i++)
    {
        results[0, i] = Math.Round((results[0, i] / experts),3);
    }

    for (int i = 0; i < aims; i++)
    {
        for (int j = 0; j < aims - 1; j++)
        {
            if (results[0, j] < results[0, j + 1])
            {
                double t = results[0, j + 1];
                results[0, j + 1] = results[0, j];
                results[0, j] = t;
                t = results[1, j + 1];
                results[1, j + 1] = results[1, j];
                results[1, j] = t;
            }
        }
    }
    Console.WriteLine("Наиболее выгодная цель: " + results[1, 0]);
    Console.WriteLine("Завершить работу? +/-");
    string ans = Console.ReadLine();
    if (ans == "-")
    {
        Console.Clear();
    }
    else { break; }
}
