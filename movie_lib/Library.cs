using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace movie_lib
{
    internal class Library
    {
        const int MaxCollection = 10;
        Collection[] tab;
        int N;

        public Library()
        {
            tab = new Collection[MaxCollection];
            N = 0;
        }

        public void AddCollection()
        {
            Console.Write("Collection name - ");
            string name = Console.ReadLine();

            Collection c = new Collection(N, name);
            tab[N] = c;
            N++;
        }

        public void PrintMovie()
        {
            int choose;
            PrintCollection();
            Console.Write("Choose id of collection > ");
            choose = int.Parse(Console.ReadLine());
            tab[choose].ShowMovies();
        }

        public void PrintCollection()
        {
            Console.WriteLine("Collections:");
            Console.WriteLine("------------");

            for (int i = 0; i < N; i++)
            {
                tab[i].Show();
            }
        }

        public void AddMovie()
        {
            PrintCollection();
            Console.Write($"To which collection (0 - {N - 1})");
            int n = int.Parse(Console.ReadLine());
            tab[n].AddMovie();
        }

        public void DeleteCollection()
        {
            int choose;
            PrintCollection();
            Console.Write($"Which collection to delete (0 - {N - 1})");
            choose = int.Parse(Console.ReadLine());
            tab = tab.Where((source, index) => index != choose).ToArray();
            N--;
            Console.WriteLine("Collections:");
            Console.WriteLine("------------");
            PrintCollection();
        }

        public void DeleteMovie()
        {
            int choose;
            PrintCollection();
            Console.Write($"From which collection delete movie (0 - {N - 1})");
            choose = int.Parse(Console.ReadLine());
            tab[choose].DeleteMovie();
        }
    }
}
