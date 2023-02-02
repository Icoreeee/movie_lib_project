using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace movie_lib
{
    [Serializable]
    internal class Collection
    {
        public string Name { get; private set; }

        List<Movie> movies = new List<Movie>();
        int num = 0;
        public int ID { get; private set; }

        public Collection(int id, string name)
        {
            ID = id;
            Name = name;
            Library.tab.Add(this);
        }

        public void SaveCollection()
        {
            string JsonWrite = JsonConvert.SerializeObject(movies);
            File.WriteAllText(@"C:\OOP\movie_lib\" + Name + ".json", JsonWrite);
            Console.WriteLine($"\nCollection {Name} saved successfully!");
            Console.ReadLine();
        }


        public void LoadCollection()
        {
            string filePath = @"C:\OOP\movie_lib\" + Name + ".json";
            if (File.Exists(filePath))
            {
                string JsonRead = File.ReadAllText(filePath);
                movies = JsonConvert.DeserializeObject<List<Movie>>(JsonRead);
                Console.WriteLine($"\nCollection {Name} loaded successfully!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"\nFile {Name} does not exist in the specified directory.");
                Console.ReadLine();
            }
        }
        //public void DisplaySavedCollections()
        //{
        //    string jsonString = File.ReadAllText(MoviePath);
        //    List<Collection> tab = JsonConvert.DeserializeObject<List<Collection>>(jsonString);
        //    Console.WriteLine("Collections:");
        //    Console.WriteLine("------------");

        //    for (int i = 0; i < N; i++)
        //    {
        //        tab[i].ShowMe();
        //    }
        //}

        //public void SerializeToFile()
        //{
        //    using (Stream stream = File.Open(Name + ".txt", FileMode.Create))
        //    {
        //        BinaryFormatter binaryFormatter = new BinaryFormatter();
        //        binaryFormatter.Serialize(stream, this);
        //    }
        //}

        public void AddMovie()
        {
            Movie m = new Movie(num);
            m.InputData();
            movies.Add(m);
            num++;
        }

        public void ShowMe()
        {
            Console.WriteLine($"{ID} - {Name}");
        }

        public void ShowMovies()
        {
            movies.Sort();
            for (int i = 0; i < num; i++)
            {
                movies[i].ShowMovie();
            }
        }

        public void DeleteMovie()
        {
            if (num == 0)
            {
                Console.WriteLine("This collection doesn't have films!");
            }
            else
            {
                int choose;
                Console.Write($"Which movie to delete (0 - {num - 1})\n");
                ShowMovies();
                choose = int.Parse(Console.ReadLine());
                movies.RemoveAt(choose);
                num--;
                Console.WriteLine("Collection:");
                Console.WriteLine("-----------");
                ShowMovies();
            }
        }
    }
}
