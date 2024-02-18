using MovieDictionaryDAL;
using MovieDictionaryDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExecution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieRepository movieRepository = new MovieRepository();
            int n = 3;
            while (n > 0 && n<5)
            {
                Console.WriteLine("Press 1 to get all movies Name, 2 to Add a Movie Detail, 3 to Update Rating, 4 to Delete a movie, any other key to Exit");
                n = Convert.ToInt32(Console.ReadLine());
                if (n == 1)
                {
                    List<Movie> movi = movieRepository.getAllMovies();
                    foreach (Movie movie in movi)
                    {
                        Console.WriteLine(movie.MovieName);
                    }
                }
                else if (n == 2)
                {

                    DateTime date = DateTime.Now;
                    Console.WriteLine("Enter Movie Name");
                    string MovieName = Console.ReadLine();
                    Console.WriteLine("Enter Movie Genre");
                    string genre = Console.ReadLine();
                    Console.WriteLine("Enter Movie Star");
                    int star = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Movie Comment");
                    string comment = Console.ReadLine();

                    Console.WriteLine(1==movieRepository.addNewMovie(new Movie()
                    {
                        ReleaseDate = date,
                        MovieName = MovieName,
                        Genre = genre,
                        Stars = star,
                        Comments = comment
                    })?"Movie Successfully Added":"Cannot Be Added");
                }
                else if (n == 3)
                {

                    Console.WriteLine("Enter Movie Name whose rating is to be updated");
                    string ID = (Console.ReadLine());
                    Console.WriteLine("Enter New Rating");
                    int number = Convert.ToInt32(Console.ReadLine());
                    int res = movieRepository.UpdateMovieRating(ID, number);
                    if (res == 0) { Console.WriteLine("Wrong Name Entered"); }
                    else { Console.WriteLine("Rating Successfully Updated"); }
                }
                else if (n == 4)
                {

                    Console.WriteLine("Enter Movie Name who is to be deleted");
                    string ID = (Console.ReadLine());
                    int res = movieRepository.deleteMovie(ID);
                    if (res == 0) { Console.WriteLine("Wrong Name Entered"); }
                    else { Console.WriteLine("Movie Successfully Deleted"); }
                }
                else
                {
                    Console.WriteLine("Have A Nice Day");
                    break;
                }
                Console.WriteLine("---------------------------------------------------------------------------------------------");
            }
        }
    }
}
