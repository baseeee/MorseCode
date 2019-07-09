using System;
using Morse;

class Tester
{
    static void Main(string[] args)
    {
        Console.Write("Enter English or Morse Code: ");
        string input = Console.ReadLine();
        Code c = new Code(input);
        Console.WriteLine("'{0}' Translates to '{1}'", c.GetInput(), c.GetTranslation());
        // Play() method is only supported on Windows
        //code.Play();
    }
}