int[,] CreateSpiralMatrix(int rows)
{
    int[,] matrix = new int[rows, rows];
    int leftBorder = 0;
    int rightBorder = rows - 1;
    int topBorder = 0;
    int bottomBorder = rows - 1;
    int i = 1;
    int point;
    while (i <= rows * rows) {
        for (point = leftBorder; point <= rightBorder; point++) {
            matrix[topBorder, point] = i++;
        }
        topBorder++;
        for (point = topBorder; point <= bottomBorder; point++) {
            matrix[point, rightBorder] = i++;
        }
        rightBorder--;
        for (point = rightBorder; point >= leftBorder; point--) {
            matrix[bottomBorder, point] = i++;
        }
        bottomBorder--;
        for (point = bottomBorder; point >= topBorder; point--) {
            matrix[point, leftBorder] = i++;
        }
        leftBorder++;
    }
    return matrix;
}

void PrintSpiral(int[,] matrix)
{
    for(int i = 0; i < matrix.GetLength(0); ++i)
    {
        for (int j = 0; j < matrix.GetLength(1) - 1; ++j)
        {
            Console.Write($"{matrix[i, j].ToString().PadLeft(2, '0')}, ");
        }
        Console.WriteLine($"{matrix[i, matrix.GetLength(1) - 1].ToString().PadLeft(2, '0')}");
    }
}

Console.Write("Введите количество строк/столбцов: ");
try {
    int rows = Convert.ToInt32(Console.ReadLine());
    if (rows > 0) {
        PrintSpiral(CreateSpiralMatrix(rows));
    } else {
        Console.WriteLine("Количество строк/столбцов должно быть больше 0.");
    }
} catch (FormatException) {
    Console.WriteLine("Вы ввели не целое число.");
}