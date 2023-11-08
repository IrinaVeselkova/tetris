
// элементы тетриса (массив двумерных массивов с элементами тетриса). 

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
                    {"@"," "},
                    {"@"," "}},
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

// печать массива, например с игровым полем и элементом
void PrintElement(string[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]);
        }
        Console.WriteLine();
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
//
string[,] OutTetrisElementInGameSpase(int rowPosition, int colPosition, string[,] tetrisElement, string[,] gameSpace)
{

    for (int i = 0; i < tetrisElement.GetLength(0); i++)
    {
        for (int j = 0; j < tetrisElement.GetLength(1); j++)
        {
            gameSpace[i + rowPosition, j + colPosition] = " ";
        }
    }
    return gameSpace;
}
// очищаем игровое поле
string[,] OutTetrisElementInGameSpace(string[,] array)
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

Console.WriteLine("Чтобы начать игру нажмите любую кнопку");
gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
PrintElement(gameSpace);
OutTetrisElementInGameSpace(gameSpace);
int n = 1000;
string[,] newGameSpace = new string[22, 12];
//Программа выполнения игры. "a" - left, "f" - right, "x" - down, space - roundelement
for (int i = 0; i < n; i++)
{

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.Backspace:
            OutTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
            Console.Clear();
            tetrisElementLines[random] = RoundElementTetris(tetrisElementLines[random]);
            gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
            PrintElement(gameSpace);
            break;

        case ConsoleKey.End:
            if (colPosition == 11 - tetrisElementLines[random].GetLength(1))
            {
                OutTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
            }
            else
            {
                OutTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
                Console.Clear();
                colPosition++;
                gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
                PrintElement(gameSpace);
            }
            if (rowPosition == (21 - tetrisElementLines[random].GetLength(0)))
            {
                Console.Clear();
                rowPosition = 1;
                colPosition = 5;
                PrintElement(InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace));

            }
            break;
        case ConsoleKey.Home:
            if (colPosition == 1)
            {
                OutTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
            }
            else
            {
                OutTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
                Console.Clear();
                colPosition--;
                gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
                PrintElement(gameSpace);
            }
            if (rowPosition == (21 - tetrisElementLines[random].GetLength(0)))
            {
                Console.Clear();
                rowPosition = 1;
                colPosition = 5;
                PrintElement(InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace));

            }
            break;
        case ConsoleKey.PageDown:
            if (rowPosition == (21 - tetrisElementLines[random].GetLength(0)))
            {
                Console.Clear();
                rowPosition = 1;
                colPosition = 5;
                PrintElement(InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace));
            }
            else
            {
                OutTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
                Console.Clear();
                rowPosition++;
                gameSpace = InsertTetrisElementInGameSpase(rowPosition, colPosition, tetrisElementLines[random], gameSpace);
                PrintElement(gameSpace);
            }
            break;
        default:

            break;
    }


}







