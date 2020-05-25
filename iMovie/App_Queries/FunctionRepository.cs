using System;
using System.Collections.Generic;
using System.Text;

namespace iMovie
{
    public class FunctionRepository
    {
        public const string CountGenreName =
        @"select count(*) as value
        from Genre
        where lower(GenreName)=lower(@GenreName)";

        public const string CountLanguageName =
        @"select count(*) as value
        from _Language 
        where lower(LanguageName)=lower(@LanguageName)";

        public const string CountPersonIMDBLink =
        @"select count(*) as value
        from Person
        where lower(IMDBLink)=lower(@PersonIMDBLink)";

        public const string CountRootPath =
        @"select count(*) as value
        from MovieRootPath 
        where lower(PathString)=lower(@PathString)";

        public const string CountUsername =
        @"select count(*) as value
        from Users 
        where lower(Username)=lower(@Username)";

        public const string CountDirector =
        @"select count(PersonID) as value
	    from Director
	    where PersonID=@PersonID";

        public const string CountActor =
        @"select count(PersonID) as value
	    from Actor
	    where PersonID=@PersonID";

        public const string GetMovieMainGenreType =
        @"select Genre.IsMain as value from Genre
        inner join Movie_Genre on Movie_Genre.GenreID = Genre.GenreID
        where Movie_Genre.MovieID = @MovieID and Movie_Genre.IsMain = 1";

        public const string GetMovieIMDbRate =
        @"select Movie.IMDBRate as value
        from Movie
        where Movie.MovieID=@MovieID";

        public const string GetMovieMainGenreID =
        @"select Movie_Genre.GenreID as value from Movie_Genre
        where Movie_Genre.MovieID = @MovieID and Movie_Genre.IsMain = 1";

        public const string CountMovieByFileLink =
        @"select count(*) as value
        from Movie
        where lower(Movie.FileLink)=lower(@FileLink)";
    }
}
