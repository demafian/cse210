using System;

class Program
{
    static void Main(string[] args)
    {
        var person = new Person();
        person.PromptForName();
        Console.WriteLine($"\nYour name is {person.GetFormalName()}");
    }
}