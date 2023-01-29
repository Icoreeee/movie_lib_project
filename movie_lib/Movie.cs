using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace movie_lib
{
    internal class Movie : IComparable<Movie>
    {
        public enum QualityType { SD, HD, UHD }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public QualityType Quality { get; private set; }
        int ID;
        public Movie(int id) { ID = id; }

        public int CompareTo(Movie other)
        { 
            if (other == null) 
                return 1;
            return Year.CompareTo(other.Year);
        }

        public void InputData()
        {
            Console.Write("\nTitle - ");
            Title = Console.ReadLine();

            Console.Write("\nYear - ");
            Year = int.Parse(Console.ReadLine());

            bool notDone = true;
            while (notDone) {
                Console.Write("\nQuality (0 - SD, 1 - HD, 2 - UHD) - ");
                int tempInput = int.Parse(Console.ReadLine());
                if (tempInput >= 0 && tempInput <= 2)
                {
                    Quality = (QualityType)tempInput;
                    notDone = false;
                }
                else
                {
                    Console.Write("\nWrite number from 0 to 2");
                }
            }
        }

        public void ShowMovie()
        {
            Console.WriteLine($"{Title}, {Year}, {Quality}");
        }

        public void PrintId()
        {
            Console.Write(ID);
        }

    }
}