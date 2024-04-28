using System;

namespace Semester_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library("LateLab");
            Game minecraft = new Game("Minecraft", "Mojang", "PG");
            Game bioshock = new Game("Bioshock", "Irrational Games", "MA");
            Book hobbit = new Book("Hobbit", "J.R.R. Tolkein", "1747077751929");
            Book tkamb = new Book("Game of Thrones", "George R.R. Martin", "8500694532857");
            lib.AddResource(minecraft);
            lib.AddResource(bioshock);
            lib.AddResource(hobbit);
            lib.AddResource(tkamb);
            minecraft.OnLoan = true;
            hobbit.OnLoan = true;
            Console.WriteLine(lib.HasResource("minecraft"));
            Console.WriteLine(lib.HasResource("bioshock"));
            Console.WriteLine(lib.HasResource("hobbit"));
            Console.WriteLine(lib.HasResource("game of thrones"));
        }
    }
}
