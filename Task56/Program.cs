int[,] RandomMatrix(int rows, int cols, int minValue, int maxValue) {
    int[,] result = new int[rows, cols];
    Random rnd = new Random();
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            result[i, j] = rnd.Next(minValue, maxValue);
        }
    }
    return result;
}

void PrintMatrix(int[,] matrix) {
    for(int i = 0; i < matrix.GetLength(0); ++i) {
        for (int j = 0; j < matrix.GetLength(1) - 1; ++j) {
            Console.Write($"{matrix[i, j]}, ");
        }
        Console.WriteLine($"{matrix[i, matrix.GetLength(1) - 1]}");
    }
}

int GetRowNumWithLowestSum(int[,] matrix) {
    int result = 0;
    int sum;
    int lowestSum = 0;
    for (int i = 0; i < matrix.GetLength(1); ++i) {
        lowestSum += matrix[0, i];
    }
    for (int i = 1; i < matrix.GetLength(0); ++i) {
        sum = 0;
        for (int j = 0; j < matrix.GetLength(1); ++j) {
            sum += matrix[i, j];
        }
        if (sum < lowestSum) {
            lowestSum = sum;
            result = i;
        }
    }
    return result;
}

Console.Write("Введите количество строк: ");
try {
    int rows = Convert.ToInt32(Console.ReadLine());
    if (rows <= 0) {
        Console.WriteLine("Количество строк должно быть больше 0.");
    } else {
        Console.Write("Введите количество столбцов: ");
        int cols = Convert.ToInt32(Console.ReadLine());
        if (cols <= 0) {
            Console.WriteLine("количество столбцов должно быть больше 0.");
        } else {
            int[,] matrix = RandomMatrix(rows, cols, 0, 10);
            PrintMatrix(matrix);
            Console.WriteLine($"Строка с наименьшей суммой элементов - {GetRowNumWithLowestSum(matrix) + 1}.");
        }
    }
} catch (FormatException) {
    Console.WriteLine("Вы ввели не целое число.");
}