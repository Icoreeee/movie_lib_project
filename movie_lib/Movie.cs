using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace movie_lib
{
    internal class Movie
    {
        public enum QualityType { SD, HD, UHD }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public QualityType Quality { get; private set; }
        int ID;
        public Movie(int id) { ID = id; }

        public void InputData()
        {
            Console.Write("Title - ");
            Title = Console.ReadLine();

            Console.Write("Year - ");
            Year = int.Parse(Console.ReadLine());

            bool notDone = true;
            while (notDone) {
                Console.WriteLine("Quality (0 - SD, 1 - HD, 2 - UHD) - ");
                int tempInput = int.Parse(Console.ReadLine());
                if (tempInput >= 0 && tempInput <= 2)
                {
                    Quality = (QualityType)tempInput;
                    notDone = false;
                }
                else
                {
                    Console.WriteLine("Write number from 0 to 2");
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
