int[,,] RandomUnique3DMatrix(int rows, int cols, int depth, int minValue, int maxValue) {
    int[,,] result = new int[rows, cols, depth];
    if (maxValue - minValue < rows * cols * depth) {
        Console.WriteLine("В указанном диапазоне не достаточно уникальных чисел, чтобы заполнить массив.");
        Console.WriteLine("Возвращается массив, заполненный нулями.");
        return result;
    }
    int[] uniqueNumbers = new int[rows * cols * depth];
    Random rnd = new Random();
    uniqueNumbers[0] = rnd.Next(minValue, maxValue);
    int nextNumber;
    bool isUnique = true;
    for(int i = 1; i < uniqueNumbers.Length; ++i) {
        nextNumber = rnd.Next(minValue, maxValue);
        for (int j = 0; j < i; ++j) {
            if (nextNumber == uniqueNumbers[j]) {
                isUnique = false;
                break;
            }
        }
        if (isUnique) {
            uniqueNumbers[i] = nextNumber;
        } else {
            i--;
        }
    }
    int counter = 0;
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            for(int k = 0; k < depth; ++k) {
                result[i, j, k] = uniqueNumbers[counter++];
            }
        }
    }
    return result;
}

void Print3DMatrix(int[,,] matrix) {
    for(int i = 0; i < matrix.GetLength(0); ++i) {
        for (int j = 0; j < matrix.GetLength(1); ++j) {
            for (int k = 0; k < matrix.GetLength(2); ++k) {
                Console.WriteLine($"{matrix[i, j, k]} ({i}, {j}, {k})");
            }
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
            Console.WriteLine("Количество столбцов должно быть больше 0.");
        } else {
            Console.Write("Введите глубину массива: ");
            int depth = Convert.ToInt32(Console.ReadLine());
            if (depth <= 0) {
                Console.WriteLine("Глубина массива должна быть больше 0.");
            } else {
                int[,,] array3D = RandomUnique3DMatrix(rows, cols, depth, 10, 100);
                Print3DMatrix(array3D);
            }
        }
    }
} catch (FormatException) {
    Console.WriteLine("Вы ввели не целое число.");
}