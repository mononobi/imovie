
namespace iMovie.Converter
{
    public static class Queries
    {
        public static readonly string GetHTTPMovies =
            @"select Movie.*, 0 as FavoriteRate from Movie
              where Movie.IMDbLink not like 'https:%'
              and Movie.IMDbLink is not Null and length(Movie.IMDbLink) > 0";

        public static readonly string GetHTTPPersons =
            @"select * from Person
              where Person.IMDBLink not like 'https:%' and
              Person.IMDbLink is not Null and length(Person.IMDbLink) > 0";

        public static readonly string GetHTTPActors =
            @"select Person.* from Person
              inner join Actor 
              on Person.PersonID = Actor.PersonID
              where Person.IMDBLink not like 'https:%'
              and Person.IMDbLink is not Null and length(Person.IMDbLink) > 0";

        public static readonly string GetHTTPDirectors =
            @"select Person.* from Person
              inner join Director 
              on Person.PersonID = Director.PersonID
              where Person.IMDBLink not like 'https:%'
              and Person.IMDbLink is not Null and length(Person.IMDbLink) > 0";

        public static readonly string UpdateMovieIMDbLink =
            @"update Movie
              SET IMDBLink = @IMDbLink
              where MovieID = @MovieID";

        public static readonly string UpdatePersonIMDbLink =
            @"update Person
              SET IMDBLink = @IMDbLink
              where PersonID = @PersonID";

        public static readonly string UpdateMovieActors =
            @"update Movie_Actor
              set PersonID = @NewPersonID
              where PersonID = @OldPersonID";

        public static readonly string UpdateMovieDirectors =
            @"update Movie_Director
              set PersonID = @NewPersonID
              where PersonID = @OldPersonID";

        public static readonly string DeletePerson =
            @"delete from Actor
              where PersonID = @PersonID;

              delete from Director
              where PersonID = @PersonID;

              delete from Person
              where PersonID = @PersonID;";
    }
}
