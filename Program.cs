﻿// элемент прямая
using System.Security.Cryptography;
using System;
using System.Text;
using System.IO;
using System.Net.Http.Headers;
// элементы тетриса (массив двумерных массивов с элементами тетриса)
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
//Игровое поле (двумерный массив)
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
int random = new Random().Next(0, 7);// объявление номера элемента
int rowPosition = 1; // начальная позиция строки
int colPosition = 5; // начальная позиция колонки
string [,] tempGameSpace = new string[22,12];
// печать элемента тетриса (не используется)
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
// печать массива, например с игровым полем и элементом
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

    for (int i = 0; i < tetrisElement.GetLength(0); i++)
    {
        for (int j = 0; j < tetrisElement.GetLength(1); j++)
        {
            gameSpace[i + rowPosition, j + colPosition] = tetrisElement[i, j];
        }
    }
    return gameSpace;
}
// очищаем игровое поле
string[,] ClearGameSpace(string[,] array)
{
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
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = gameSpace[i, j];
        }
    }
    return array;
}
System.Console.WriteLine("Чтобы начать игру нажмите любую кнопку");
gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
PrintElement(gameSpace);
ClearGameSpace(gameSpace);
// Программа выполнения игры
for (int i = 0; i < 1000; i++)
{
    switch (Console.ReadLine())
    {
        case " ":
            Console.Clear();
            tetrisElementLines[random] = RoundElementTetris(tetrisElementLines[random]);
            gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
            PrintElement(gameSpace);
            ClearGameSpace(gameSpace);
            break;

        case "f":
            Console.Clear();
            colPosition++;
            gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
            PrintElement(gameSpace);
            ClearGameSpace(gameSpace);
            if (colPosition == 10)
            {
            goto case "a";
            }
            break;
        case "a":
            Console.Clear();
            colPosition--;
            gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
            PrintElement(gameSpace);
            ClearGameSpace(gameSpace);
            if (colPosition == 1)
            {
            goto case "f";
            }
            break;
        case "x":
            Console.Clear();
            rowPosition++;
            gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
            PrintElement(gameSpace);
            ClearGameSpace(gameSpace);
            if (rowPosition == 20)
            {
            goto default;
            }
            break;
        default: 
        gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
        tempGameSpace = gameSpace;
        rowPosition = 1;
        colPosition = 5;
        random = new Random().Next(0,7);
        PrintElement(InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], tempGameSpace));
        goto NextDirection;

    }
NextDirection:

switch (Console.ReadLine())
    {
        case " ":
            Console.Clear();
            tetrisElementLines[random] = RoundElementTetris(tetrisElementLines[random]);
            gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], tempGameSpace);
            PrintElement(gameSpace);
            ClearGameSpace(gameSpace);
            break;

        case "f":
            Console.Clear();
            colPosition++;
            gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], tempGameSpace);
            PrintElement(gameSpace);
            ClearGameSpace(gameSpace);
            if (colPosition == 10)
            {
            goto case "a";
            }
            break;
        case "a":
            Console.Clear();
            colPosition--;
            gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], tempGameSpace);
            PrintElement(gameSpace);
            ClearGameSpace(gameSpace);
            if (colPosition == 1)
            {
            goto case "f";
            }
            break;
        case "x":
            Console.Clear();
            rowPosition++;
            gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], tempGameSpace);
            PrintElement(gameSpace);
            ClearGameSpace(gameSpace);
            if (rowPosition == 16)
            {
            goto default;
            }
            break;
        default: 
        gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], tempGameSpace);
        tempGameSpace = gameSpace;
        rowPosition = 1;
        colPosition = 5;
        random = new Random().Next(0,7);
        PrintElement(InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], tempGameSpace));
        break;

    }

}




