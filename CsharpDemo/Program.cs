using System;
using System.Collections.Generic;
using System.Data.Common;

namespace CsharpDemo
{
    public record Person(string FirstName, string LastName);
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Ken", "Tucker");
            Console.WriteLine(person);
            var (firstName, lastName) = person;
            Console.WriteLine(firstName);
            Console.WriteLine(lastName);
        }
    }
}

//System.Console.Write("Hello world!");
