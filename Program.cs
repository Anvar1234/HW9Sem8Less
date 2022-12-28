/*
Примечания:
1) В задаче  54 применил метод сортировки пузырьком. Не помню, чтобы мы применяли его в таком виде, только в 
семинаре №6, но там мы просто переворачивали одномерный массив. В общем, честно говоря, сначала делал методом тыка, 
но понимая, конечно, что хочу получить. Если не сложно ответь плиз, норм вариант упорядочивания применил или 
лучше использовать другой? Думаю, что наверное можно было использовать вывод нескольких одномерных 
массивов (по количеству строк), но это не точно))
2) В задаче 62 сделал 2 вариантами. Но в первом варианте возможно что-то можно докрутить, скорее всего 
условия добавить и возможно заработает для любых матриц. Но силы закончились, голова пересталда соображать)) 
А сегодня уже попробовал другой метод. Он сработал для всех.

*/



/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по 
убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

/*
int[,] GetMatrix(int row, int col, int min, int max)
{
    int[,] matrix = new int[row, col];
    Random rand = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} \t");
        }
        Console.WriteLine();
    }
}


int[,] MatrixOrdering(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if (matrix[i, k] > matrix[i, j])
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, k];
                    matrix[i, k] = temp;
                }
            }
        }
    }
    return matrix;
}

Console.Clear();

Console.Write("Введите кол-во строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите кол-во столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

int[,] randomMatrix = GetMatrix(rows, columns, -10, 10);

PrintMatrix(randomMatrix);

int[,] newMatrix = MatrixOrdering(randomMatrix);
Console.WriteLine();
PrintMatrix(newMatrix);
*/




/*
Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

/*
int[,] GetMatrix(int row, int col, int min, int max)
{
    int[,] matrix = new int[row, col];
    Random rand = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} \t");
        }
        Console.WriteLine();
    }
}

int SumOfRowElements(int[,] matrix)
{
    int min = int.MaxValue;
    int minSum = 0;
    int indexRowOfMin = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            minSum += matrix[i, j];
        }
        if (minSum < min)
        {
            min = minSum;
            indexRowOfMin = i;
        }
        minSum = 0;
    }
    return indexRowOfMin;
}

Console.Write("Введите кол-во строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите кол-во столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

int[,] randomMatrix = GetMatrix(rows, columns, -5, 5);

PrintMatrix(randomMatrix);

Console.WriteLine($"Индекс первой строки с наименьшей суммой элементов = {SumOfRowElements(randomMatrix)}");
*/





/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

/*
int[,] GetMatrix(int row, int col, int min, int max)
{
    int[,] matrix = new int[row, col];
    Random rand = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} \t");
        }
        Console.WriteLine();
    }
}

int[,] MultiplicationOfMatrices(int[,] matrix1, int[,] matrix2)
{
    int[,] multiplicatedMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            multiplicatedMatrix[i,j] = matrix1[i, j]*matrix2[i,j];
        }
    }
    return multiplicatedMatrix;
}

Console.Write("Введите кол-во строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите кол-во столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

int[,] firstRandomMatrix = GetMatrix(rows, columns, -5, 5);
int[,] secondRandomMatrix = GetMatrix(rows, columns, -5, 5);

PrintMatrix(firstRandomMatrix);
Console.WriteLine();
PrintMatrix(secondRandomMatrix);

int[,] resultMatrix = MultiplicationOfMatrices(firstRandomMatrix, secondRandomMatrix);
Console.WriteLine();
Console.WriteLine("Результирующая матрица:");
PrintMatrix(resultMatrix);
*/





/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

/*
int[,,] Get3DArray(int row, int col, int dep, int min, int max)
{
    int[,,] array3D = new int[row, col, dep];
    Random rand = new Random();
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                array3D[i, j, k] = rand.Next(min, max + 1);
            }
        }
    }
    return array3D;
}

void Print3DArray(int[,,] array3D)
{
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                Console.Write($"{array3D[i, j, k]} ({i}, {j}, {k})\t");
            }
            Console.WriteLine();
        }
    }
}

Console.Write("Введите кол-во строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите кол-во столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите глубину 3D массива: ");
int depth = Convert.ToInt32(Console.ReadLine());

int[,,] random3DArray = Get3DArray(rows, columns, depth, 10, 100);

Print3DArray(random3DArray);
*/





/*
Задача 62 (дополнительная). Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

//1 Вариант, работает только для квадратных матриц либо четных сторон прямоугольника.


/*
int[,] GetSpiralMatrix(int m, int n)
{
    int s = 1;
    int[,] matrix = new int[m, n]; 

    int endRow = matrix.GetLength(0) - 1; 
    int endCol = matrix.GetLength(1) - 1; 
    int startRow = 0;
    int startCol = 0;


    while (endRow >= startRow && endCol >= startCol && s <= m * n)
    {                       
        for (int j = startCol; j <= endCol; j++) //верх слева направо.
        {
            matrix[startRow, j] = s;
            s++;
        }
        startRow++;

        for (int i = startRow; i <= endRow; i++) //право сверху вниз.
        {
            matrix[i, endCol] = s;
            s++;
        }
        endCol--;

        for (int j = endCol; j >= startCol; j--) //низ справа налево.
        {
            matrix[endRow, j] = s;
            s++;
        }
        endRow--;

        for (int i = endRow; i >= startRow; i--) //лево снизу вверх.
        {
            matrix[i, startCol] = s;
            s++;
        }
        startCol++;
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} \t");
        }
        Console.WriteLine();
    }
}

Console.Write("Введите кол-во строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите кол-во столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

int[,] spiralMatrix = GetSpiralMatrix(rows, columns);

PrintMatrix(spiralMatrix);
*/





//Вариант 2. Работает для всех матриц.

/*
int[,] GetSpiralMatrix(int m, int n)
{

    int[,] matrix = new int[m, n]; //матрица изначально пустая, поэтому нужно использовать проверку на пустоту (==0).
    int x = 0;
    int y = 0;
    int dx = 0; // Начальное приращение по X.
    int dy = 1; // Начальное приращение по Y, т.к. двигаемся вправо, то 1.
    int newX = 0;
    int newY = 0;
    int temp = 0;
*/
    

    /*
    [x+0, y+dy] //вправо
    [x+dx, y+0] //вниз
    [x+0, y-dy] //влево, знак приращения меняется!!!
    [x-dx, y+0] //вверх, знак приращения меняется!!!

    Приращения всегда или 0, или 1 (с меняющимся знаком).

    Условия для возможности внесения элемента в матрицу:
    Можно, если новое значение записывается в пустую ячейку, если не выходит за границу по m и n, x и y могут равны 0.
    */
/*
    for (int i = 1; i <= m * n; i++) // Заполнение с 1 до общего кол-ва элементов матрицы. 
    {
        matrix[x, y] = i;
        newX = x + dx;
        newY = y + dy;
        if (newX >= 0 && newX < m && newY >= 0 && newY < n && matrix[newX, newY] == 0)
        {
            x = newX;
            y = newY;
        }

        else
        {
            temp = dx; // Меняем знаки и значения переменных приращения в случае невыполнения какого-то условия.
            dx = dy;
            dy = -temp;

            x = x + dx;
            y = y + dy;
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} \t");
        }
        Console.WriteLine();
    }
}

Console.Write("Введите кол-во строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите кол-во столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

int[,] spiralMatrix = GetSpiralMatrix(rows, columns);

PrintMatrix(spiralMatrix);
*/