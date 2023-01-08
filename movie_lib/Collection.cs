using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_lib
{
    internal class Collection
    {

        const int MaxMovies = 100;

        public string Name { get; private set; }

        Movie[] movies;
        int num = 0;
        public int ID { get; private set; }

        public Collection(int id, string name)
        {
            ID = id;
            Name = name;
            movies = new Movie[MaxMovies];
        }

        public void AddMovie()
        {
            Movie m = new Movie(num);
            m.InputData();
            movies[num] = m;
            num++;
        }

        public void Show()
        {
            Console.WriteLine($"{ID} - {Name}");
        }

        public void ShowMovies()
        {
            for (int i = 0; i < num; i++)
            {
                movies[i].ShowMovie();
            }
        }

        public void DeleteMovie()
        {
            if (num == 0) Console.WriteLine("This collection don't have films!");
            else
            {
                int choose;
                Console.Write($"Which movie to delete (0 - {num - 1})\n");
                ShowMovies();
                choose = int.Parse(Console.ReadLine());
                movies = movies.Where((source, index) => index != choose).ToArray();
                num--;
                Console.WriteLine("Collection:");
                Console.WriteLine("-----------");



                0/85
                        000
                ShowMovies();
            }
        }
    }
}
