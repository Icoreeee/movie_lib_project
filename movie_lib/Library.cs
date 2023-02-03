using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace movie_lib
{
    public static class Library
    {
        static string directoryPath = @"JsonFiles\";
        public static List <Collection> tab = new List<Collection>();

        private static bool CheckNameMatch(List<Collection> objects, string inputName)
        {
            return objects.Any(x => x.Name == inputName);
        }

        public static void Finish()
        {
            foreach (Collection t in tab)
            {
                t.SaveCollection();
            }
        }

        public static void LoadLibrary(string directoryPath)
        {
            System.IO.Directory.CreateDirectory(directoryPath);
            string[] filePaths = Directory.GetFiles(directoryPath, "*.json");
            for (int i = 0; i < filePaths.Length; i++)
            {
                Collection lc = new Collection(i, Path.GetFileNameWithoutExtension(filePaths[i]));
            }
        }

        public static void Start()
        {
            LoadLibrary(directoryPath);
            foreach (Collection t in tab)
            {
                t.LoadCollection();
            }
        }

        public static void NoCollection()
        {
            Console.WriteLine("\nFirst create a collection");
            Console.ReadLine();
        }

        public static void AddCollection()
        {
            Console.Write("\nCollection name - ");
            string name = Console.ReadLine();

            if (CheckNameMatch(tab, name) == true)
            {
                Console.WriteLine("\nThere is a collection with this name, try another");
                Console.WriteLine("\nPress any key to continue");
                Console.Write("> ");
                Console.ReadLine();
                return;
            }
            Collection c = new Collection(tab.Count(), name);
        }

        public static void PrintMovie()
        {
            if (tab.Count() == 0)
            {
                NoCollection();
                return;
            }
            else
            {
                int choose;
                PrintCollections();
                Console.Write("\nChoose id of collection > ");
                choose = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine(" Collection:");
                Console.WriteLine("-------------");
                tab[choose].ShowMe();
                Console.WriteLine();
                tab[choose].ShowMovies();
            }
        }

        public static void PrintCollections()
        {
            if (tab.Count() == 0)
            {
                NoCollection();
                return;
            }
            else
            {
                Console.WriteLine("Collections:");
                Console.WriteLine("------------");

                for (int i = 0; i < tab.Count(); i++)
                {
                    tab[i].ShowMe();
                }
            }
        }

        public static void AddMovie()
        {
            if (tab.Count() == 0)
            {
                NoCollection();
                return;
            }
            else
            {
                PrintCollections();
                Console.Write($"\nTo which collection (0 - {tab.Count() - 1})");
                int n = int.Parse(Console.ReadLine());
                tab[n].AddMovie();
            }
        }

        public static void DeleteCollection()
        {
            if (tab.Count() == 0)
            {
                Console.WriteLine("\nFirst create a collection");
                return;
            }
            else
            {
                int choose;
                PrintCollections();
                Console.Write($"\nWhich collection to delete (0 - {tab.Count() - 1})");
                choose = int.Parse(Console.ReadLine());
                string filename = tab[choose].Name;
                string filePath = directoryPath + filename + ".json";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"Collection {tab[choose].Name} Deleted Successfully!");
                }
                else
                {
                    Console.WriteLine($"Collection {tab[choose].Name} not found!");
                }
                tab.RemoveAt(choose);
                PrintCollections();
            }
        }

        public static void DeleteMovie()
        {
            if (tab.Count() == 0)
            {
                Console.WriteLine("\nFirst create a collection");
                return;
            }
            else
            {
                int choose;
                PrintCollections();
                Console.Write($"\nFrom which collection delete movie (0 - {tab.Count() - 1})");
                choose = int.Parse(Console.ReadLine());
                Console.WriteLine();
                tab[choose].DeleteMovie();
            }
        }
    }
}
