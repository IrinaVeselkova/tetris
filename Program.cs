// элемент прямая
using System.Security.Cryptography;
// элементы тетриса

string[,] tetrisElementLine1 = new string[,] { {"*"," "},
                                                {"*"," "},
                                                {"*"," "},
                                                {"*"," "}};
string[,] tetrisElementLine2 = new string[,] { {"*"," "},
                                                {"*"," "},
                                                {"*","*"}};
string[,] tetrisElementLine3 = new string[,] { {"*","*"},
                                                {" ","*"},
                                                {" ","*"}};
string[,] tetrisElementLine4 = new string[,] { {"*"," "},
                                                {"*","*"},
                                                {" ","*"}};
string[,] tetrisElementLine5 = new string[,] { {" ","*"},
                                                {"*","*"},
                                                {"*"," "}};
string[,] tetrisElementLine6 = new string[,] { {"*"," "},
                                                {"*","*"},
                                                {"*"," "}};
string[,] tetrisElementLine7 = new string[,] { {"*","*"},
                                                {"*","*"}};

// печать элемента тетриса
void PrintElement(string[,] array)
{


    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] == " ") Console.Write($" ");
            else Console.Write($"*");
            //System.Console.Write(array[i,j]); 
        }
        System.Console.WriteLine();
    }
    // System.Console.WriteLine();

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

PrintElement(tetrisElementLine4);
System.Console.WriteLine();
PrintElement(RoundElementTetris(tetrisElementLine4));
System.Console.WriteLine();
PrintElement(RoundElementTetris(RoundElementTetris(tetrisElementLine4)));
System.Console.WriteLine();
PrintElement(RoundElementTetris(RoundElementTetris(RoundElementTetris(tetrisElementLine4))));

