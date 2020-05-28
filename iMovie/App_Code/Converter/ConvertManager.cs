using System;
using System.Data;
using System.IO;

namespace iMovie.Converter
{
    public class ConvertManager
    {
        private Log LOGGER = new Log();
        
        public ConvertManager()
        {
            string logName = "iMovie Convert Log [" + Helper.GetShortDateTimeString().Replace(":", "-") + "].txt";
            this.LOGGER.Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), logName);
        }

        public void FixHTTPMovieURL()
        {
            LOGGER.GenerateSilent("Fixing movies with http url.");
            DataTable dtMovies = AccessDatabase.Select(Queries.GetHTTPMovies);
            Movie[] movies = Movie.FetchAllMovie(dtMovies);

            foreach(Movie item in movies)
            {
                item.IMDBLink = item.IMDBLink.Replace("http:", "https:");
                int r = AccessDatabase.Update(Queries.UpdateMovieIMDbLink, 
                    "@MovieID", item.MovieID, "@IMDbLink", item.IMDBLink);

                if (r == 0)
                {
                    LOGGER.GenerateSilent("Could not find movie." + Environment.NewLine + item.FullTitle);
                }
                else if (r > 1)
                {
                    LOGGER.GenerateSilent("There is more than one movie with the same IMDb " +
                        "link. all of them have been updated." + Environment.NewLine + 
                        item.IMDBLink + Environment.NewLine + item.FullTitle);
                }
            }

            LOGGER.GenerateSilent("Finished fixing movies with http url.");
        }

        public void FixHTTPPersons()
        {
            LOGGER.GenerateSilent("Fixing persons with http url.");

            Person[] httpPersons = this.GetHTTPPersons();
            foreach (Person item in httpPersons)
            {
                bool isActor = false;
                bool isDirector = false;
                Person_SP.GetTypeByID(item.PersonID, out isActor, out isDirector);
                string validIMDbLink = item.IMDBLink.Replace("http:", "https:");
                Person[] validPersons = this.GetPersonByIMDbLink(validIMDbLink);

                int length = validPersons.Length;
                if (length == 0)
                {
                    this.UpdatePersonIMDbLink(item.PersonID, validIMDbLink);
                }
                else if (length == 1)
                {
                    Person validPerson = validPersons[0];
                    bool validIsActor = false;
                    bool validIsDirector = false;
                    Person_SP.GetTypeByID(validPerson.PersonID, out validIsActor, out validIsDirector);

                    if (isActor && !validIsActor)
                    {
                        AccessDatabase.Insert(QueryRepository.Actor_Insert, "@PersonID", validPerson.PersonID);
                    }

                    if (isDirector && !validIsDirector)
                    {
                        AccessDatabase.Insert(QueryRepository.Director_Insert, "@PersonID", validPerson.PersonID);
                    }

                    this.UpdateMovieActors(item.PersonID, validPerson.PersonID);
                    this.UpdateMovieDirectors(item.PersonID, validPerson.PersonID);
                    this.DeletePerson(item.PersonID);
                }
                else
                {
                    LOGGER.GenerateSilent("There is more than one match for person." + 
                        Environment.NewLine + item.FullName + 
                        Environment.NewLine + item.PersonID +
                        Environment.NewLine + item.IMDBLink);
                }
            }

            LOGGER.GenerateSilent("Finished fixing persons with http url.");
        }

        private Person[] GetHTTPPersons()
        {
            DataTable dtPersons = AccessDatabase.Select(Queries.GetHTTPPersons);
            return Person.FetchAllPerson(dtPersons);
        }

        private Person[] GetHTTPActors()
        {
            DataTable dtActors = AccessDatabase.Select(Queries.GetHTTPActors);
            return Person.FetchAllPerson(dtActors);
        }

        private Person[] GetHTTPDirectors()
        {
            DataTable dtDirectors = AccessDatabase.Select(Queries.GetHTTPDirectors);
            return Person.FetchAllPerson(dtDirectors);
        }

        private int UpdatePersonIMDbLink(long personID, string IMDbLink)
        {
            return AccessDatabase.Update(Queries.UpdatePersonIMDbLink, "@PersonID", personID, "@IMDbLink", IMDbLink);
        }

        private int UpdateMovieActors(long oldPersonID, long newPersonID)
        {
            return AccessDatabase.Update(Queries.UpdateMovieActors, "@NewPersonID", newPersonID, "@OldPersonID", oldPersonID);
        }

        private int UpdateMovieDirectors(long oldPersonID, long newPersonID)
        {
            return AccessDatabase.Update(Queries.UpdateMovieDirectors, "@NewPersonID", newPersonID, "@OldPersonID", oldPersonID);
        }

        private int DeletePerson(long personID)
        {
            return AccessDatabase.Delete(Queries.DeletePerson, "@PersonID", personID);
        }

        private Person GetPerson(long personID)
        {
            DataTable result = Person_SP.GetByID(personID);
            Person person = new Person(9999999999, "Fake", "", "");
            person.FetchSinglePerson(result);

            return person;
        }

        private Person[] GetPersonByIMDbLink(string imdbLink)
        {
            DataTable result = Person_SP.GetByIMDBLink(imdbLink);
            return Person.FetchAllPerson(result);
        }
    }
}
