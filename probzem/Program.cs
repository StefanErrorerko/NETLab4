using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string str = "goal";
        Console.WriteLine(Regex.IsMatch(str, @"^[A-z,a-z]+$"));
        //Regex.Match();
    }
}