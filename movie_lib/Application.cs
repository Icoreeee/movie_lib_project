using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace movie_lib
{
    internal class Application
    {
        Library library;

        public Application()
        {
            library = new Library();
        }

        public void Continue()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.Write("> ");
            Console.ReadLine();
        }

        public void Menu()
        {
            bool finish = false;

            while (!finish)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("=======================");
                Console.WriteLine("| 1 Add collection    |");
                Console.WriteLine("| 2 Add movie         |");
                Console.WriteLine("| 3 Show collections  |");
                Console.WriteLine("| 4 Show movies       |");
                Console.WriteLine("| 5 Delete collection |");
                Console.WriteLine("| 6 Delete movie      |");
                Console.WriteLine("| 0 Finish            |");
                Console.WriteLine("=======================\n");
                Console.Write("> ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        finish = true;
                        break;
                    case 1:
                        library.AddCollection();
                        break;
                    case 2:
                        library.AddMovie();
                        break;
                    case 3:
                        Console.Clear();
                        library.PrintCollection();
                        Continue();
                        break;
                    case 4:
                        Console.Clear();
                        library.PrintMovie();
                        Continue();
                        break;
                    case 5:
                        Console.Clear();
                        library.DeleteCollection();
                        Continue();
                        break;
                    case 6:
                        Console.Clear();
                        library.DeleteMovie();
                        Continue();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
