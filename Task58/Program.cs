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

int[,] Multiply(int[,] matrixA, int[,] matrixB) {
    int[,] result = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for (int i = 0; i < result.GetLength(0); ++i) {
        for (int j = 0; j < result.GetLength(1); ++j) {
            for (int k = 0; k < matrixA.GetLength(1); ++k) {
                result[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }
    return result;
}

bool isAEnteredCorrectly = false;
Console.Write("Введите количество строк первой матрицы: ");
int[,] matrixA = new int[0, 0];
try {
    int rows = Convert.ToInt32(Console.ReadLine());
    if (rows <= 0) {
        Console.WriteLine("Количество строк должно быть больше 0.");
    } else {
        Console.Write("Введите количество столбцов первой матрицы: ");
        int cols = Convert.ToInt32(Console.ReadLine());
        if (cols <= 0) {
            Console.WriteLine("Количество столбцов должно быть больше 0.");
        } else {
            matrixA = RandomMatrix(rows, cols, 1, 10);
            isAEnteredCorrectly = true;
        }
    }
} catch (FormatException) {
    Console.WriteLine("Вы ввели не целое число.");
}
int[,] matrixB = new int[0, 0];
bool isBEnteredCorrectly = false;
if (isAEnteredCorrectly) {
    Console.Write("Введите количество строк второй матрицы: ");
    try {
        int rows = Convert.ToInt32(Console.ReadLine());
        if (rows <= 0) {
            Console.WriteLine("Количество строк должно быть больше 0.");
        } else {
            Console.Write("Введите количество столбцов второй матрицы: ");
            int cols = Convert.ToInt32(Console.ReadLine());
            if (cols <= 0) {
                Console.WriteLine("Количество столбцов должно быть больше 0.");
            } else {
                matrixB = RandomMatrix(rows, cols, 1, 10);
                isBEnteredCorrectly = true;
            }
        }
    } catch (FormatException) {
        Console.WriteLine("Вы ввели не целое число.");
    }
}

if (isAEnteredCorrectly && isBEnteredCorrectly) {
    PrintMatrix(matrixA);
    Console.WriteLine();
    PrintMatrix(matrixB);
    Console.WriteLine();
    if (matrixA.GetLength(1) == matrixB.GetLength(0)) {
        PrintMatrix(Multiply(matrixA, matrixB));
    } else {
        Console.WriteLine("Эти матрицы нельзя перемножить.");
    }
}