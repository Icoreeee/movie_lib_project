using System;
namespace movie_lib
{
    public static class Application
    {

        public static void Continue()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.Write("> ");
            Console.ReadLine();
        }

        public static void Menu()
        {
            bool finish = false;
            Library.Start();

            while (!finish)
            {
                Console.WriteLine("          Main Menu");
                Console.WriteLine("============================");
                Console.WriteLine("| 1 Add collection         |");
                Console.WriteLine("| 2 Add movie              |");
                Console.WriteLine("| 3 Show collections       |");
                Console.WriteLine("| 4 Show movies            |");
                Console.WriteLine("| 5 Delete collection      |");
                Console.WriteLine("| 6 Delete movie           |");
                Console.WriteLine("| 0 Finish                 |");
                Console.WriteLine("============================\n");
                Console.Write("> ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Library.Finish();
                        finish = true;
                        break;
                    case 1:
                        Library.AddCollection();
                        break;
                    case 2:
                        Library.AddMovie();
                        break;
                    case 3:
                        Console.Clear();
                        Library.PrintCollections();
                        Continue();
                        break;
                    case 4:
                        Console.Clear();
                        Library.PrintMovie();
                        Continue();
                        break;
                    case 5:
                        Console.Clear();
                        Library.DeleteCollection();
                        Continue();
                        break;
                    case 6:
                        Console.Clear();
                        Library.DeleteMovie();
                        Continue();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
