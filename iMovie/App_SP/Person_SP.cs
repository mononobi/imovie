using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iMovie
{
    public class Person_SP
    {
        public static long Insert(Person person, bool isActor, bool isDirector)
        { 
            try
            {
                long personID = 0;
                personID = AccessDatabase.Insert(QueryRepository.Person_Insert, "@PersonFName", person.PersonFName,
                                                 "@PersonLName", person.PersonLName, "@IMDBLink", person.IMDBLink,
                                                 "@PhotoLink", person.PhotoLink);

                if (personID <= 0)
                {
                    throw new Exception(Messages.DatabaseError);
                }

                if (isActor == true)
                {
                    AccessDatabase.Insert(QueryRepository.Actor_Insert, "@PersonID", personID);
                }

                if (isDirector == true)
                {
                    AccessDatabase.Insert(QueryRepository.Director_Insert, "@PersonID", personID);
                }

                return personID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetList(bool isActor = false, bool isDirector = false)
        { 
            try
            {
                string joinActor = string.Empty;
                string joinDirector = string.Empty;

                if (isActor == true)
                {
                    joinActor = @"inner join Actor 
						        on Person.PersonID=Actor.PersonID";
                }

                if (isDirector == true)
                {
                    joinDirector = @"inner join Director 
                                   on Person.PersonID=Director.PersonID";
                }

                string finalQuery = QueryRepository.Person_Get_List.Replace("@JoinActor", joinActor);
                finalQuery = finalQuery.Replace("@JoinDirector", joinDirector);

                DataTable dtPersons = new DataTable();
                dtPersons = AccessDatabase.Select(finalQuery);
                 
                return dtPersons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByName(string personName, bool isActor = false, bool isDirector = false)
        {
            try
            {
                string joinActor = string.Empty;
                string joinDirector = string.Empty;

                if (isActor == true)
                {
                    joinActor = @"inner join Actor 
						        on Person.PersonID=Actor.PersonID";
                }

                if (isDirector == true)
                {
                    joinDirector = @"inner join Director 
                                   on Person.PersonID=Director.PersonID";
                }

                string finalQuery = QueryRepository.Person_Get_By_Name.Replace("@JoinActor", joinActor);
                finalQuery = finalQuery.Replace("@JoinDirector", joinDirector);

                DataTable dtPersons = new DataTable();
                dtPersons = AccessDatabase.Select(finalQuery,
                                                  "@PersonFullName", personName);

                return dtPersons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByID(long personID)
        {
            try
            {
                DataTable dtPerson = new DataTable();
                dtPerson = AccessDatabase.Select(QueryRepository.Person_Get_By_PersonID, "@PersonID", personID);

                return dtPerson;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetActorByMovieID(long movieID)
        {
            try
            {
                DataTable dtPerson = new DataTable();
                dtPerson = AccessDatabase.Select(QueryRepository.Actor_Get_By_MovieID, "@MovieID", movieID);

                return dtPerson;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDirectorByMovieID(long movieID)
        {
            try
            {
                DataTable dtPerson = new DataTable();
                dtPerson = AccessDatabase.Select(QueryRepository.Director_Get_By_MovieID, "@MovieID", movieID);

                return dtPerson;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void GetTypeByID(long personID, out bool isActor, out bool isDirector)
        { 
            try
            {
                DataTable dtType = new DataTable();
                dtType = AccessDatabase.Select(QueryRepository.Person_Get_Type_By_PersonID, "@PersonID", personID);

                isActor = Convert.ToBoolean(Convert.ToInt64(dtType.Rows[0]["IsValid"]));
                isDirector = Convert.ToBoolean(Convert.ToInt64(dtType.Rows[1]["IsValid"]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long Delete(long personID)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Delete(QueryRepository.Person_Delete, "@PersonID", personID);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long UpdatePhotoLinkByID(long personID, string photoLink)
        {
            try
            {
                long count = 0;
                count = AccessDatabase.Update(QueryRepository.Person_Update_PhotoLink_By_PersonID,
                                               "@PersonID", personID, "@PhotoLink", photoLink);

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByIMDBLink(string imdbLink)
        {
            try
            {
                DataTable dtPersons = new DataTable();
                dtPersons = AccessDatabase.Select(QueryRepository.Person_Get_By_IMDBLink,
                                                  "@IMDBLink", imdbLink);

                return dtPersons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetByNameExact(string personName)
        { 
            try
            {
                DataTable dtPersons = new DataTable();
                dtPersons = AccessDatabase.Select(QueryRepository.Person_Get_By_Name_Exact,
                                                  "@FullName", personName);

                return dtPersons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long GetPersonID(string personFullName, string personIMDbLink)
        {
            try
            {
                DataTable dtPersons = new DataTable();

                if (personIMDbLink.Length > 0)
                {
                    dtPersons = Person_SP.GetByIMDBLink(personIMDbLink);

                    if (dtPersons.Rows.Count > 0)
                    {
                        return Convert.ToInt64(dtPersons.Rows[0]["PersonID"]);
                    }
                    else
                    {
                        dtPersons = new DataTable();

                        dtPersons = Person_SP.GetByNameExact(personFullName);
                        Person[] ps = Person.FetchAllPerson(dtPersons);

                        foreach (Person p in ps)
                        {
                            if (p.IMDBLink.Length == 0)
                            {
                                return p.PersonID;
                            }
                        }
                    }
                }
                else
                {
                    dtPersons = new DataTable();

                    dtPersons = Person_SP.GetByNameExact(personFullName);
                    Person[] ps = Person.FetchAllPerson(dtPersons);

                    foreach (Person p in ps)
                    {
                        if (p.IMDBLink.Length == 0)
                        {
                            return p.PersonID;
                        }
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static long IsSamePerson(string personFullName, string personIMDbLink, DataRow dtMoviePersons)
        {
            try 
            {
                if (personIMDbLink.Length > 0)
                {
                    if (dtMoviePersons["IMDBLink"].ToString().Equals(personIMDbLink, StringComparison.CurrentCultureIgnoreCase) == true)
                    {
                        return Convert.ToInt64(dtMoviePersons["PersonID"].ToString());
                    }
                    else
                    {
                        if (dtMoviePersons["FullName"].ToString().Equals(personFullName, StringComparison.CurrentCultureIgnoreCase) == true &&
                            dtMoviePersons["IMDBLink"].ToString().Length == 0)
                        {
                            return Convert.ToInt64(dtMoviePersons["PersonID"].ToString());
                        }
                    }
                }
                else
                {
                    if (dtMoviePersons["FullName"].ToString().Equals(personFullName, StringComparison.CurrentCultureIgnoreCase) == true && 
                        dtMoviePersons["IMDBLink"].ToString().Length == 0)
                    {
                        return Convert.ToInt64(dtMoviePersons["PersonID"].ToString());
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
