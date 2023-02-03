using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace movie_lib
{
    public class Collection
    {
        public string Name { get; private set; }

        public static List<Movie> movies = new List<Movie>();
        public int ID { get; private set; }

        public Collection(int id, string name)
        {
            ID = id;
            Name = name;
            Library.tab.Add(this);
        }

        public void SaveCollection()
        {
            var jsonString = JsonConvert.SerializeObject(movies);
            File.WriteAllText(@"JsonFiles\" + Name + ".json", jsonString);
        }


        public void LoadCollection()
        {
            string filePath = @"JsonFiles\" + Name + ".json";
            if (File.Exists(filePath))
            {
                string JsonRead = File.ReadAllText(filePath);
                movies = JsonConvert.DeserializeObject<List<Movie>>(JsonRead);
            }
            else
            {
                Console.WriteLine($"\nFile {Name} does not exist in the specified directory.");
            }
        }

        public void AddMovie()
        {
            Movie m = new Movie(movies.Count);
            m.InputData();
            movies.Add(m);
        }

        public void ShowMe()
        {
            Console.WriteLine($"{ID} - {Name}");
        }

        public void ShowMovies()
        {
            movies.Sort();
            for (int i = 0; i < movies.Count; i++)
            {
                Console.Write($"{i} ");
                movies[i].ShowMovie();
            }
        }

        public void DeleteMovie()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("This collection doesn't have films!");
            }
            else
            {
                int choose;
                Console.Write($"Which movie to delete (0 - {movies.Count-1})\n");
                ShowMovies();
                Console.Write("\n> ");
                choose = int.Parse(Console.ReadLine());
                movies.RemoveAt(choose);
                Console.WriteLine("\nCollection:");
                Console.WriteLine("-----------");
                ShowMovies();
            }
        }
    }
}