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

void SortRowsDescending(int[,] matrix) {
    for (int i = 0; i < matrix.GetLength(0); ++i) {
        for (int j = 0; j < matrix.GetLength(1) - 1; ++j) {
            int maxIndex = j;
            for (int k = j + 1; k < matrix.GetLength(1); ++k) {
                if (matrix[i, k] > matrix[i, maxIndex]) {
                    maxIndex = k;
                }
            }
            int temp = matrix[i, j];
            matrix[i, j] = matrix[i, maxIndex];
            matrix[i, maxIndex] = temp;
        }
    }
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
            int[,] matrix = RandomMatrix(rows, cols, 10, 100);
            PrintMatrix(matrix);
            SortRowsDescending(matrix);
            Console.WriteLine();
            PrintMatrix(matrix);
        }
    }
} catch (FormatException) {
    Console.WriteLine("Вы ввели не целое число.");
}