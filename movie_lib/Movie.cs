using System;

namespace movie_lib
{
    [Serializable]
    internal class Movie : IComparable<Movie>
    {
        public enum QualityType { SD, HD, UHD }
        public enum GenreType { Action, Drama, Adventure, Comedy, Fantasy, Horror, Musical, Sports }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public QualityType Quality { get; private set; }
        public GenreType Genre { get; private set; }
        
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
                Console.Write("\nGenre \n0) - Action \n1) - Drama \n2) - Adventure \n3) - Comedy \n4) - Fantasy \n5) - Horror \n6) - Musical \n7) - Sports \n> ");
                int genreInput = int.Parse(Console.ReadLine());
                if (genreInput >= 0 && genreInput <= 2)
                {
                    Genre = (GenreType)genreInput;
                    notDone = false;
                }
                else
                {
                    Console.Write("\nWrite number from 0 to 2");
                }

                Console.Write("\nQuality \n0) - SD \n1) - HD \n2) - UHD \n> ");
                int qualityInput = int.Parse(Console.ReadLine());
                if (qualityInput >= 0 && qualityInput <= 2)
                {
                    Quality = (QualityType)qualityInput;
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
            Console.WriteLine($"{Title}, {Year}, {Genre}, {Quality}");
        }
    }
}