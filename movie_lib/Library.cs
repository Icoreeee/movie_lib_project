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

        public void NoCollection()
        {
            Console.WriteLine("\nFirst create a collection");
            Console.WriteLine("\nPress any key to continue");
            Console.Write("> ");
            Console.ReadLine();
        }

        public void AddCollection()
        {
                Console.Write("\nCollection name - ");
                string name = Console.ReadLine();

                Collection c = new Collection(N, name);
                tab[N] = c;
                N++;
        }

        public void PrintMovie()
        {
            if (N == 0)
            {
                NoCollection();
                return;
            }
            else
            {
                int choose;
                PrintCollection();
                Console.Write("\nChoose id of collection > ");
                choose = int.Parse(Console.ReadLine());
                tab[choose].ShowMovies();
            }
        }

        public void PrintCollection()
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
                    tab[i].Show();
                }
            }
        }

        public void AddMovie()
        {
            if (N == 0)
            {
                NoCollection();
                return;
            }
            else
            {
                PrintCollection();
                Console.Write($"\nTo which collection (0 - {N - 1})");
                int n = int.Parse(Console.ReadLine());
                tab[n].AddMovie();
            }
        }

        public void DeleteCollection()
        {
            if (N == 0)
            {
                Console.WriteLine("\nFirst create a collection");
                return;
            }
            else
            {
                int choose;
                PrintCollection();
                Console.Write($"\nWhich collection to delete (0 - {N - 1})");
                choose = int.Parse(Console.ReadLine());
                tab = tab.Where((source, index) => index != choose).ToArray();
                N--;
                PrintCollection();
            }
        }

        public void DeleteMovie()
        {
            if (N == 0)
            {
                Console.WriteLine("\nFirst create a collection");
                return;
            }
            else
            {
                int choose;
                PrintCollection();
                Console.Write($"\nFrom which collection delete movie (0 - {N - 1})");
                choose = int.Parse(Console.ReadLine());
                tab[choose].DeleteMovie();
            }
        }
    }
}
