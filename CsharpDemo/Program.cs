using System;
using System.Collections.Generic;
using System.Data.Common;

namespace CsharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Ken", "Tucker");
            Console.WriteLine(person);
            var (firstName, lastName) = person;
            Console.WriteLine(firstName);
            Console.WriteLine(lastName);

            var employee = new Employee(){Name = "Ken", position = "Dev"};

            string json = System.Text.Json.JsonSerializer.Serialize(person);

            var person2 = System.Text.Json.JsonSerializer.Deserialize<Person>(json);
        }
    }
}

