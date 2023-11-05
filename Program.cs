// элемент прямая
using System.Security.Cryptography;
using System;
using System.Text;
using System.IO;
using System.Net.Http.Headers;
// элементы тетриса
string[][,] tetrisElementLines = new string[7][,]
{
    new string[,] { {"@"},
                    {"@"},
                    {"@"},
                    {"@"}},
    new string[,] { {"@"," "},
                    {"@"," "},
                    {"@","@"}},
    new string[,] { {"@","@"},
                    {" ","@"},
                    {" ","@"}},
    new string[,] { {"@"," "},
                    {"@","@"},
                    {" ","@"}},
    new string[,] { {" ","@"},
                    {"@","@"},
                    {"@"," "}},
    new string[,] { {"@"," "},
                    {"@","@"},
                    {"@"," "}},
    new string[,] { {"@","@"},
                    {"@","@"}}};
//Игровое поле
string[,] gameSpace = new string[22, 12] { {"+","-","-","-","-","-","-","-","-","-","-","+"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"|"," "," "," "," "," "," "," "," "," "," ","|"},
                                            {"+","-","-","-","-","-","-","-","-","-","-","+"}};
// печать элемента тетриса
void PrintElementTetris(int item, string[][,] array)
{
    switch (item)
    {
        case 0:
            PrintElement(array[0]);
            break;
        case 1:
            PrintElement(array[1]);
            break;
        case 2:
            PrintElement(array[2]);
            break;
        case 3:
            PrintElement(array[3]);
            break;
        case 4:
            PrintElement(array[4]);
            break;
        case 5:
            PrintElement(array[5]);
            break;
        case 6:
            PrintElement(array[6]);
            break;
        default:
            PrintElement(array[7]);
            break;
    }

}
void PrintElement(string[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write(array[i, j]);
        }
        System.Console.WriteLine();
    }
}
// переворачивание массива
string[,] RoundElementTetris(string[,] array)
{
    string[,] roundElement = new string[array.GetLength(1), array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            roundElement[j, i] = array[array.GetLength(0) - i - 1, j];
        }
    }

    return roundElement;
}

// встраивание элемента тетриса в игровое поле
string[,] InsertTetrisElementInGameSpase(int rowPosition, int colPosition, string[,] tetrisElement, string[,] gameSpace)
{
    string[,] replaceGameSpase = new string[gameSpace.GetLength(0), gameSpace.GetLength(1)];
    replaceGameSpase = gameSpace;
    for (int i = 0; i < tetrisElement.GetLength(0); i++)
    {
        for (int j = 0; j < tetrisElement.GetLength(1); j++)
        {

            replaceGameSpase[i  + rowPosition, j + colPosition] = tetrisElement[i, j];
        }
    }
    return replaceGameSpase;
}
//Перемещение элемента вниз
string[,] DownTetrisElementInGameSpase(int random, int rowPosition, int colPosition, string[,] gameSpace)
{
    for (int i = 0; i < gameSpace.GetLength(0); i++)
    {
        if (Console.ReadLine() == "x")
        {
            Console.Clear();
            PrintElement(InsertTetrisElementInGameSpase(rowPosition++, colPosition, tetrisElementLines[random], gameSpace));
            for (int j = 1; j < 11; j++)
            {
                gameSpace[rowPosition, j] = " ";
            }

        }

    }
    return gameSpace;
}
//двbгаем элемент тетриса влево
string[,] LeftTetrisElementInGameSpase(int random, int rowPosition, int colPosition, string[,] gameSpace)
{
    for (int i = 10; i < gameSpace.GetLength(1); i--)
    {
        if (Console.ReadLine() == "a")
        {
            Console.Clear();
            PrintElement(InsertTetrisElementInGameSpase(rowPosition, colPosition--, tetrisElementLines[random], gameSpace));
            for (int j = 10; j > 1; j--)
            {
                for (int k = 1; k < 20; k++)
                {
                    gameSpace[k, j] = " ";
                }
            }
        }

    }
    return gameSpace;
}
//двигаем элемент вправо
string[,] RightTetrisElementInGameSpase(int random, int rowPosition, int colPosition, string[,] gameSpace)
{
    for (int i = 1; i < 11; i++)
    {
        if (Console.ReadLine() == "f")
        {
            Console.Clear();
            PrintElement(InsertTetrisElementInGameSpase(rowPosition, colPosition++, tetrisElementLines[random], gameSpace));

            for (int j = 10; j > 1; j--)
            {
                for (int k = 1; k < 20; k++)
                {
                    gameSpace[k, j] = " ";
                }
            }
        }

    }
    return gameSpace;
}
//Находим положение элемента на поле
int[] FindPositionElement(string[,] gameSpace)
{
    int[] position = new int[2];
    int[] positionFirst = new int[2];
    int[] positionSecond = new int[2];
    for (int i = 0; i < gameSpace.GetLength(0); i++)
    {
        for (int j = 0; j < gameSpace.GetLength(1); j++)
        {
            if (gameSpace[i, j] == "@")
            {
                positionFirst[0] = i;
                positionFirst[1] = j;
            }
        }
    }
                for (int k = positionFirst[0]+1; k < gameSpace.GetLength(0); k++)
                {
                    for (int m = 0; m < gameSpace.GetLength(1); m++)
                    {
                        if (gameSpace[k, m] == "@")
                        {
                            positionSecond[0] = k;
                            positionSecond[1] = m;
                        }
                    }
                }
    if (positionSecond[0] >= positionFirst[0] )
    {
        position[0] = positionSecond[0] - (positionSecond[0] - positionFirst[0]);
        position[1] = positionSecond[1];
       
    }
    else
    {
        position[0] = positionFirst[0];
        position[1] = positionFirst[1];
    }
    return position;
}
int random = new Random().Next(0, 7);
PrintElement(InsertTetrisElementInGameSpase(1, 5, tetrisElementLines[random], gameSpace));
//DownTetrisElementInGameSpase(random,1, 5, gameSpace);
//LeftTetrisElementInGameSpase(random, 1, 5, gameSpace);
//RightTetrisElementInGameSpase(random, 1, 5, gameSpace);
int[] position = FindPositionElement(InsertTetrisElementInGameSpase(1, 5, tetrisElementLines[random], gameSpace));
System.Console.WriteLine($"{position[0]},{position[1]}");
