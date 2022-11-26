

Console.WriteLine("Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.\n" +
                "Укажите размер массива количество строк и столбцов");
int row = Convert.ToInt32(Console.ReadLine());
int column = Convert.ToInt32(Console.ReadLine());

int[,] array = new int[row, column];
int counter = 1;
int x = 0;
int y = 0;
int corner = 0;

Console.Clear();
PrintSpiralW(array, corner, y, x);

void PrintSpiralW(int[,] array, int corner, int i, int j)
{  
    int numColumn = array.GetLength(1);
    int numRow = array.GetLength(0);
    int sleep = 100;
    const int width = 5;
    Console.CursorVisible = false;
    while (counter <= numColumn * numRow+1)
    {
        Thread.Sleep(sleep);
        if (counter == numColumn * numRow+1)
        {
            Console.SetCursorPosition(0, numRow + 1);
            Console.Write($"Конец");
            return;
        }
      
        if (i == corner && j < numColumn - corner - 1)
        {
            if (j == 0 && i == 0)
            {
                array[i, j] = counter;
                Console.Write($"{array[i, j].ToString().PadLeft(width - 1, '0'),width}");
                counter++;
            }
            j++;
            array[i, j] = counter;
            Console.Write($"{array[i, j].ToString().PadLeft(width - 1, '0'),width}");
        }
        else if (j == numColumn - corner - 1 && i < numRow - corner - 1)
        {
            Console.SetCursorPosition(Console.CursorLeft - width, Console.CursorTop + 1);
            i++;
            array[i, j] = counter;
            Console.Write($"{array[i, j].ToString().PadLeft(width - 1, '0'),width}");
        }
        else if (i == numRow - corner - 1 && j > corner)
        {
            Console.SetCursorPosition(Console.CursorLeft - 2 * width, Console.CursorTop);
            j--;
            array[i, j] = counter;
            Console.Write($"{array[i, j].ToString().PadLeft(width - 1, '0'),width}");
        }
        else
        {
            Console.SetCursorPosition(Console.CursorLeft - width, Console.CursorTop - 1);
            i--;
            array[i, j] = counter;
            Console.Write($"{array[i, j].ToString().PadLeft(width - 1, '0'),width}");
        }
        counter++;

        if ((i == corner + 1) && (j == corner) && (corner != numColumn - corner - 1))
        {
            PrintSpiralW(array, corner + 1, i, j);
        }
    }
    return;
}