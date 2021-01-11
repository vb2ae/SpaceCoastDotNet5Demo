# Introduction to .net 5


Demo given at the space coast sql/.net online user group meeting on Jan 14,2020


# To compile a .net standard library for .net 5.0


Change TargetFramework

     <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
     </PropertyGroup>


To TargetFrameworks so it can compile for .net standard and .net 5.0

      <PropertyGroup>
        <TargetFrameworks>netstandard2.0;.net5.0</TargetFrameworks>
      </PropertyGroup>
      
 
 # Simplified Console apps
 
 To make it easier for people to learn c# you can remove alot of the code on a console app.
 
 
 You can replace 
 
     namespace CsharpDemo
      {
           class Program
           {
                static void Main(string[] args)
                {     
                      Console.WriteLine(lastName);
                }  
           }      
      }

With

     System.Console.Write("Hello world!");
     
     
# Records with C#

      namespace CsharpDemo
      {

            public record Person(string firstName, string lastName);

      }
      
# Deconstructors


            var person = new Person("Ken", "Tucker");
            var (firstName, lastName) = person;

