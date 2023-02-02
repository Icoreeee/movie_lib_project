using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace movie_lib
{
    internal static class Library
    {
        static string directoryPath = @"C:\OOP\movie_lib\";
        public static List <Collection> tab = new List<Collection>();
        static int N = 0;

        private static bool CheckNameMatch(List<Collection> objects, string inputName)
        {
            return objects.Any(x => x.Name == inputName);
        }

        //public static void SaveCollections()
        //{
        //    string JsonWrite = JsonConvert.SerializeObject(tab);
        //    File.WriteAllText(FilePath, JsonWrite);
        //    Console.WriteLine("Collections saved successfully!");
        //}

        //public static void DisplaySavedCollections()
        //{
        //    string jsonString = File.ReadAllText(FilePath);
        //    List<Collection> tab = JsonConvert.DeserializeObject<List<Collection>>(jsonString);
        //    Console.WriteLine("Collections:");
        //    Console.WriteLine("------------");

        //    for (int i = 0; i < N; i++)
        //    {
        //        tab[i].ShowMe();
        //    }
        //}

        public static void DeleteFile(string filePath)
        {
            string Name = Path.GetFileNameWithoutExtension(filePath);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"Collection {Name} Deleted Successfully!");
            }
            else
            {
                Console.WriteLine($"Collection {Name} not found!");
            }
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
            string[] filePaths = Directory.GetFiles(directoryPath, "*.json");
            for (int i = 0; i < filePaths.Length; i++)
            {
                Collection lc = new Collection(N, Path.GetFileNameWithoutExtension(filePaths[i]));
                tab.Add(lc);
                N++;
            }
        }

        public static void Start()
        {
            LoadLibrary(directoryPath);
            foreach (Collection t in tab)
            {
                t.LoadCollection();
            }
            foreach (Collection t in tab)
            {
                t.ShowMovies();
            }
            Console.ReadLine();
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
            Collection c = new Collection(N, name);
            tab.Add(c);
            N++;
        }

        public static void PrintMovie()
        {
            if (N == 0)
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
                Console.Write(" Collection:");
                Console.WriteLine("-------------\n");
                tab[choose].ShowMe();
                tab[choose].ShowMovies();
            }
        }

        public static void PrintCollections()
        {
            if (N == 0)
            {
                NoCollection();
                return;
            }
            else
            {
                Console.WriteLine("Collections:");
                Console.WriteLine("------------");

                for (int i = 0; i < N; i++)
                {
                    tab[i].ShowMe();
                }
            }
        }

        public static void AddMovie()
        {
            if (N == 0)
            {
                NoCollection();
                return;
            }
            else
            {
                PrintCollections();
                Console.Write($"\nTo which collection (0 - {N - 1})");
                int n = int.Parse(Console.ReadLine());
                tab[n].AddMovie();
            }
        }

        public static void DeleteCollection()
        {
            if (N == 0)
            {
                Console.WriteLine("\nFirst create a collection");
                return;
            }
            else
            {
                int choose;
                PrintCollections();
                Console.Write($"\nWhich collection to delete (0 - {N - 1})");
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
                N--;
                PrintCollections();
            }
        }

        public static void DeleteMovie()
        {
            if (N == 0)
            {
                Console.WriteLine("\nFirst create a collection");
                return;
            }
            else
            {
                int choose;
                PrintCollections();
                Console.Write($"\nFrom which collection delete movie (0 - {N - 1})");
                choose = int.Parse(Console.ReadLine());
                tab[choose].DeleteMovie();
            }
        }
    }
}
