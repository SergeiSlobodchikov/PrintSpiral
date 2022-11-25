
Console.WriteLine("Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.\n" +
                "Укажите размер массива количество строк и столбцов");
int row = Convert.ToInt32(Console.ReadLine());
int column = Convert.ToInt32(Console.ReadLine());

int[,] array = new int[row, column];
int numRow = array.GetLength(0), numColumn = array.GetLength(1);
int upLeftCorner = 0, downRightCorner = 0, downLeftCorner = 0, upRightCorner = 0;
int counter = 1;
int i = 0;
int j = 0;
while (counter <= numRow * numColumn)
{
    array[i, j] = counter;
    if (i == upLeftCorner && j < numColumn - upRightCorner - 1) j++;
    else if (j == numColumn - upRightCorner - 1 && i < numRow - downRightCorner - 1) i++;
    else if (i == numRow - downRightCorner - 1 && j > downLeftCorner) j--;
    else i--;

    if ((i == upLeftCorner + 1) && (j == downLeftCorner) && (downLeftCorner != numColumn - upRightCorner - 1))
    {
        upLeftCorner++;
        downRightCorner++;
        downLeftCorner++;
        upRightCorner++;
    }
    counter++;
}

upLeftCorner = 0;
upRightCorner = 0;
downLeftCorner = 0;
downRightCorner = 0;
counter = 1;
i = 0;
j = 0;
Console.Clear();
PrintSpiralW(array, upLeftCorner, upRightCorner, downRightCorner, downLeftCorner);

void PrintSpiralW(int[,] array, int upLeftCorner, int upRightCorner, int downRightCorner, int downLeftCorner)
{
    numColumn = array.GetLength(1);
    numRow = array.GetLength(0);
    int sleep = 10;
    const int width = 4;
    Console.CursorVisible = false;
    while (counter <= numColumn * numRow)
    {
        Thread.Sleep(sleep);
        if (counter == numColumn * numRow)
        {
            Console.SetCursorPosition(0, numRow + 1);
            Console.Write($"Конец");
            Console.ResetColor();
            return;
        }
        if (i == upLeftCorner && j < numColumn - upRightCorner - 1)
        {
            if (j == 0 && i == 0) Console.Write($"{array[i, j].ToString().PadLeft(width - 1, '0'),width}");
            j++;
            Console.Write($"{array[i, j].ToString().PadLeft(width - 1, '0'),width}");
        }
        else if (j == numColumn - upRightCorner - 1 && i < numRow - downRightCorner - 1)
        {
            Console.SetCursorPosition(Console.CursorLeft - width, Console.CursorTop + 1);
            Thread.Sleep(sleep);
            i++;
            Console.Write($"{array[i, j].ToString().PadLeft(width - 1, '0'),width}");
        }
        else if (i == numRow - downRightCorner - 1 && j > downLeftCorner)
        {
            Console.SetCursorPosition(Console.CursorLeft - 2 * width, Console.CursorTop);
            j--;
            Console.Write($"{array[i, j].ToString().PadLeft(width - 1, '0'),width}");
        }
        else
        {
            Console.SetCursorPosition(Console.CursorLeft - width, Console.CursorTop - 1);
            i--;
            Console.Write($"{array[i, j].ToString().PadLeft(width - 1, '0'),width}");
        }
        counter++;

        if ((i == upLeftCorner + 1) && (j == downLeftCorner) && (downLeftCorner != numColumn - upRightCorner - 1))
        {
            PrintSpiralW(array, upLeftCorner + 1, upRightCorner + 1, downRightCorner + 1, downLeftCorner + 1);
        }
    }
}