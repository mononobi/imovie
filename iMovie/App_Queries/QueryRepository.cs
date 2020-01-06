using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace iMovie
{
    public class QueryRepository
    {
        public const string Actor_Get_By_MovieID =
        @"select distinct Person.*,Person.PersonFName || ' ' || Person.PersonLName as FullName
        from Person
        inner join Movie_Actor
        on Movie_Actor.PersonID=Person.PersonID
        where Movie_Actor.MovieID=@MovieID
        order by FullName asc";

        public const string Director_Get_By_MovieID =
        @"select distinct Person.*,Person.PersonFName || ' ' || Person.PersonLName as FullName
        from Person
        inner join Movie_Director
        on Movie_Director.PersonID=Person.PersonID
        where Movie_Director.MovieID=@MovieID
        order by FullName asc";

        public const string FavoriteMovie_Delete =
        @"delete from FavoriteMovie
        where FavoriteMovie.MovieID=@MovieID";

        public const string FavoriteMovie_Get_List =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate
        from Movie
        inner join FavoriteMovie 
        on FavoriteMovie.MovieID = Movie.MovieID
        order by FavoriteMovie.FavoriteRate desc";

        public const string FavoriteMovie_Insert =
        @"delete from FavoriteMovie
        where FavoriteMovie.MovieID=@MovieID;

        insert into FavoriteMovie
        values(@MovieID,@FavoriteRate)";

        public const string FavoriteMovie_Update =
        @"update FavoriteMovie
        set FavoriteRate=@FavoriteRate
        where MovieID=@MovieID";

        public const string Genre_Delete =
        @"delete from Movie_Genre
        where Movie_Genre.GenreID=@GenreID;

        delete from Genre
        where Genre.GenreID=@GenreID";

        public const string Genre_Get_By_GenreID =
        @"select Genre.*
        from Genre 
        where GenreID=@GenreID";

        public const string Genre_Get_By_IsMain =
        @"select Genre.*
        from Genre 
        where IsMain=@IsMain
        order by GenreName asc";

        public const string Genre_Get_By_MovieID =
        @"select distinct Genre.*,Movie_Genre.IsMain
        from Genre
        inner join Movie_Genre
        on Movie_Genre.GenreID=Genre.GenreID
        where Movie_Genre.MovieID=@MovieID
        order by Movie_Genre.IsMain desc, Genre.GenreName asc";

        public const string Genre_Get_By_Name =
        @"select distinct Genre.*
        from Genre
        where Genre.GenreName like @GenreName
        or Genre.GenreName like '%' || @GenreName || '%'
        or Genre.GenreName like '%' || @GenreName
        or Genre.GenreName like @GenreName || '%'
        or @GenreName like Genre.GenreName
        or @GenreName like '%' || Genre.GenreName || '%'
        or @GenreName like '%' || Genre.GenreName
        or @GenreName like Genre.GenreName || '%'
        order by GenreName asc";

        public const string Genre_Get_List =
        @"select Genre.*
        from Genre
        order by Genre.GenreName asc";

        public const string Genre_Insert =
        @"insert into Genre(GenreName, IsMain)
        values(@GenreName, @IsMain)";

        public const string Get_Statistics =
        @"select * from
        (select avg(Movie.IMDbRate) as Value, 'Average Movie Rate' as Name, '0' as Priority
        from Movie where Movie.IMDBRate > 0

        union

        select count(Movie.MovieID) as Value, 'Movies' as Name, '7' as Priority
        from Movie

        union

        select count(Director.PersonID) as Value, 'Directors' as Name, '1' as Priority
        from Director

        union

        select count(Actor.PersonID) as Value, 'Actors' as Name, '2' as Priority
        from Actor

        union

        select count(Movie.MovieID) as Value, 'Watched Movies' as Name, '3' as Priority
        from Movie
        where Movie.IsSeen=1

        union

        select count(User.UserID) as Value, 'Users' as Name, '4' as Priority
        from User

        union

        select count(SuggestionCache.MovieID) as Value, 'Suggestion Cache' as Name, '5' as Priority
        from SuggestionCache

        union

        select count(FavoriteMovie.MovieID) as Value, 'Favorite Movies' as Name, '6' as Priority
        from FavoriteMovie) as result
        order by result.Priority asc";

        public const string Language_Get_By_LanguageID =
        @"select _Language.*
        from _Language 
        where _Language.LanguageID=@LanguageID";

        public const string Language_Get_By_MovieID =
        @"select distinct _Language.*
        from _Language
        inner join Movie_Language
        on Movie_Language.LanguageID=_Language.LanguageID
        where Movie_Language.MovieID=@MovieID
        order by LanguageName asc";

        public const string Language_Get_List =
        @"select _Language.*
        from _Language
        order by LanguageName asc";

        public const string Language_Insert =
        @"insert into _Language(LanguageName)
        values(@LanguageName)";

        public const string Movie_Actor_Delete =
        @"delete from Movie_Actor
        where MovieID=@MovieID
        and PersonID=@PersonID";

        public const string Movie_Actor_Insert =
        @"insert into Movie_Actor
        values(@MovieID,@PersonID)";

        public const string Movie_Delete =
        @"delete from Movie_Director
        where MovieID=@MovieID;

        delete from DuplicateMovie
        where MovieID=@MovieID;

        delete from DuplicateMovie
        where MovieID in
        (
        select MovieID from DuplicateMovie
        where GroupID in
        (
        select GroupID from DuplicateMovie
        group by GroupID
        having count(MovieID) <= 1
        )
        );

        delete from Movie_Actor
        where MovieID=@MovieID;

        delete from Movie_Genre
        where MovieID=@MovieID;

        delete from Movie_Language
        where MovieID=@MovieID;

        delete from FavoriteMovie
        where MovieID=@MovieID;

        delete from SuggestionCache
        where MovieID=@MovieID;

        delete from RequestMovie
        where MovieID=@MovieID;

        delete from RequestMovieCopy
        where MovieID=@MovieID;

        delete from ToWatchMovie
        where MovieID=@MovieID;

        delete from Movie
        where MovieID=@MovieID";

        public const string Movie_Delete_All =
        @"delete from Movie_Director;
        
        delete from DuplicateMovie;

        update SystemParameters
        set ParamValue = null
        where ParamID = 1;

        delete from Movie_Actor;

        delete from Movie_Genre;

        delete from Movie_Language;

        delete from FavoriteMovie;

        delete from SuggestionCache;

        delete from RequestMovie;

        delete from RequestMovieCopy;

        delete from ToWatchMovie;

        delete from Movie";

        public const string Movie_Director_Delete =
        @"delete from Movie_Director
        where MovieID=@MovieID
        and PersonID=@PersonID";
         
        public const string Movie_Director_Delete_All =
        @"delete from Movie_Director
        where MovieID=@MovieID";

        public const string Movie_Director_Insert =
        @"insert into Movie_Director
        values(@MovieID,@PersonID)";

        public const string Movie_Genre_Delete =
        @"delete from Movie_Genre
        where MovieID=@MovieID
        and GenreID=@GenreID";

        public const string Movie_Genre_Insert =
        @"insert into Movie_Genre
        values(@MovieID,@GenreID,@IsMain)";

        public const string Movie_Get_By_ActorID =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join Movie_Actor 
        on Movie.MovieID=Movie_Actor.MovieID
        where Movie_Actor.PersonID=@ActorID 
        order by Movie.MovieName asc";

        public const string Movie_Get_By_DirectorID =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join Movie_Director 
        on Movie.MovieID=Movie_Director.MovieID
        where Movie_Director.PersonID=@DirectorID 
        order by Movie.MovieName asc";

        public const string Movie_Get_By_Duration =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where Movie.Duration between @LowerBound and @UpperBound
        order by Movie.Duration desc, Movie.MovieName asc";

        public const string Movie_Get_By_FileLink =
        @"select distinct Movie.*
        from Movie
        where Movie.FileLink=@FileLink
        order by Movie.MovieName asc";

        public const string Movie_Get_By_GenreID =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join Movie_Genre 
        on Movie.MovieID=Movie_Genre.MovieID
        where Movie_Genre.GenreID=@GenreID
        order by Movie.MovieName asc";

        public const string Movie_Get_By_IMDBLink =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate , '' as DisplayQuality
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where Movie.IMDBLink=@IMDBlink
        order by Movie.MovieName asc";

        public const string Movie_Get_By_LanguageID =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join Movie_Language
        on Movie.MovieID=Movie_Language.MovieID
        where Movie_Language.LanguageID=@LanguageID
        order by Movie.MovieName asc";

        public const string Movie_Get_By_MovieID =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate, '' as DisplayQuality
        from Movie 
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where Movie.MovieID=@MovieID";

        public const string Movie_Get_By_MovieID_And_IMDBLink =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate , '' as DisplayQuality
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where Movie.IMDBLink=@IMDBlink and Movie.MovieID=@MovieID 
        order by Movie.MovieName asc";
        
        public const string Movie_Get_By_MovieID_Or_IMDBLink =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate , '' as DisplayQuality
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where Movie.IMDBLink=@IMDBlink or Movie.MovieID=@MovieID 
        order by Movie.MovieName asc";

        public const string Movie_Get_By_Name =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate,'' as DisplayQuality
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where Movie.MovieName like @MovieName
        or Movie.MovieName like '%' || @MovieName || '%'
        or Movie.MovieName like '%' || @MovieName
        or Movie.MovieName like @MovieName || '%'
        or @MovieName like Movie.MovieName
        or @MovieName like '%' || Movie.MovieName || '%'
        or @MovieName like '%' || Movie.MovieName
        or @MovieName like Movie.MovieName || '%'
        order by Movie.MovieName asc";

        public const string Movie_Get_By_ProductYear =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate, '' as DisplayQuality
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where @ProductNull Movie.ProductYear between @LowerBound and @UpperBound
        order by Movie.ProductYear desc, Movie.MovieName asc";

        public const string Movie_Get_By_Quality =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate, '' DisplayQuality
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where Quality=@Quality
        order by Movie.MovieName asc";

        public const string Movie_Get_By_Rate =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate, '' DisplayQuality
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where Movie.IMDBRate between @LowerBound and @UpperBound
        order by Movie.IMDBRate desc, Movie.MovieName asc";

        public const string Movie_Get_Duplicate_List_Exact =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate, '' as DisplayQuality
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where Movie.MovieName in
        (
        select M.MovieName
        from Movie as M
        group by M.MovieName || M.ProductYear
        having count(M.MovieID)>1
        )
        order by Movie.MovieName asc";

        public const string Movie_Get_Details_By_ID =
        @"select distinct Movie.MovieID,Movie.Duration,Movie.FileLink,Movie.IMDBLink,Movie.IMDBRate,Movie.IsSeen,Movie.StoryLine,
		           Movie.MovieName,Movie.PosterLink,Movie.ProductYear,Movie.AddDate,Movie.Quality,FavoriteMovie.FavoriteRate
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        where Movie.MovieID=@MovieID;

        select distinct Person.PersonID,Person.PersonFName || ' ' || Person.PersonLName as FullName,Person.PersonFName,Person.PersonLName,Person.IMDBLink,Person.PhotoLink
        from Person
        inner join Movie_Director
        on Movie_Director.PersonID=Person.PersonID
        where Movie_Director.MovieID=@MovieID
        order by PersonFName asc;

        select distinct Person.PersonID,Person.PersonFName || ' ' || Person.PersonLName as FullName,Person.PersonFName,Person.PersonLName,Person.IMDBLink,Person.PhotoLink
        from Person
        inner join Movie_Actor
        on Movie_Actor.PersonID=Person.PersonID
        where Movie_Actor.MovieID=@MovieID
        order by PersonFName asc;

        select distinct _Language.LanguageID,_Language.LanguageName
        from _Language
        inner join Movie_Language
        on Movie_Language.LanguageID=_Language.LanguageID
        where Movie_Language.MovieID=@MovieID;

        select distinct Genre.GenreID,Genre.GenreName,Movie_Genre.IsMain
        from Genre
        inner join Movie_Genre
        on Movie_Genre.GenreID=Genre.GenreID
        where Movie_Genre.MovieID=@MovieID
        order by Movie_Genre.IsMain desc, Genre.GenreName asc";

        public const string Movie_Get_List =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate , '' as DisplayQuality
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        order by @NewestFirst Movie.MovieName asc, Movie.ProductYear asc";

        public const string Movie_Insert =
        @"insert into Movie(MovieName,ProductYear,AddDate,IMDbRate,Duration,PosterLink,FileLink,IsSeen,IMDBLink,Quality,StoryLine)
        values(@MovieName,@ProductYear,@AddDate,@IMDBRate,@Duration,@PosterLink,@FileLink,@IsSeen,@IMDBLink,@Quality,@StoryLine)";

        public const string Movie_Language_Delete =
        @"delete from Movie_Language
        where MovieID=@MovieID
        and LanguageID=@LanguageID";

        public const string Movie_Language_Insert =
        @"insert into Movie_Language
        values(@MovieID,@LanguageID)";

        public const string Movie_Update =
        @"update Movie
        set MovieName=@MovieName,
        ProductYear=@ProductYear,
        IMDBRate=@IMDBRate,
        Duration=@Duration,
        PosterLink=@PosterLink,
        FileLink=@FileLink,
        IsSeen=@IsSeen,
        IMDBLink=@IMDBLink,
        Quality=@Quality,
        StoryLine=@StoryLine
        where MovieID=@MovieID";

        public const string Movie_Update_IsSeen =
        @"update Movie
        set IsSeen=@IsSeen
        where MovieID=@MovieID";

        public const string Movie_Update_Online =
        @"update Movie
        set ProductYear=@ProductYear,
        IMDBRate=@IMDBRate,
        Duration=@Duration,
        PosterLink=@PosterLink,
        IMDBLink=@IMDBLink,
        StoryLine=@StoryLine
        where MovieID=@MovieID";

        public const string Movie_Update_Quality =
        @"update Movie
        set Quality=@Quality
        where MovieID=@MovieID";

        public const string MovieRootPath_Delete =
        @"delete from MovieRootPath
        where PathID=@PathID";

        public const string MovieRootPath_Get_List =
        @"select *
        from MovieRootPath
        order by PathString asc";

        public const string MovieRootPath_Insert =
        @"insert into MovieRootPath(PathString)
        values(@PathString)";

        public const string Person_Delete =
        @"delete from Movie_Actor
        where PersonID=@PersonID;

        delete from Movie_Director
        where PersonID=@PersonID;

        delete from Actor
        where PersonID=@PersonID; 

        delete from Director
        where PersonID=@PersonID;

        delete from Person
        where PersonID=@PersonID";

        public const string Person_Get_By_IMDBLink =
        @"select Person.* , Person.PersonFName || ' ' || Person.PersonLName as FullName
        from Person 
        where Person.IMDBLink=@IMDBLink
        order by FullName";

        public const string Person_Get_By_Name =
        @"select distinct Person.*,PersonFName || ' ' || PersonLName as FullName
        from Person 
        @JoinDirector
        @JoinActor
        where 
        (
           PersonFName || ' '  || PersonLName like '%' || @PersonFullName || '%'
        or @PersonFullName like '%' || PersonFName || ' '  || PersonLName || '%'

        )
        order by FullName asc";

        public const string Person_Get_By_Name_Exact =
        @"select Person.*, Person.PersonFName || ' ' || Person.PersonLName as FullName
        from Person
        where Person.PersonFName || ' ' || Person.PersonLName = @FullName
        order by FullName asc";

        public const string Person_Get_By_PersonID =
        @"select Person.*,PersonID,PersonFName|| ' ' ||PersonLName as FullName
        from Person 
        where PersonID=@PersonID";

        public const string Person_Get_List =
        @"select distinct Person.*,PersonFName || ' ' || PersonLName as FullName
        from Person
        @JoinDirector
        @JoinActor
        order by FullName asc";

        public const string Person_Get_Type_By_PersonID =
        @"select count(*) as IsValid, 'Actor' as Type 
        from Actor
        where Actor.PersonID=@PersonID

        union

        select count(*) as IsValid, 'Director' as Type
        from Director
        where Director.PersonID=@PersonID";

        public const string Person_Insert =
        @"insert into Person(PersonFName,PersonLName,IMDBLink,PhotoLink)
        values(@PersonFName,@PersonLName,@IMDBLink,@PhotoLink)";

        public const string Actor_Insert =
        @"insert into Actor
        values(@PersonID)";

        public const string Director_Insert =
        @"insert into Director
        values(@PersonID)";

        public const string Person_Update_PhotoLink_By_PersonID =
        @"update Person
        set PhotoLink=@PhotoLink
        where PersonID=@PersonID";

        public const string RequestMovie_Delete =
        @"delete from RequestMovie
        where MovieID=@MovieID";

        public const string RequestMovie_Get_List =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate
        from Movie
        left join FavoriteMovie 
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join RequestMovie
        on RequestMovie.MovieID=Movie.MovieID
        order by Movie.MovieName asc";

        public const string RequestMovie_Insert =
        @"delete from RequestMovie
        where MovieID=@MovieID;

        insert into RequestMovie
        values(@MovieID)";

        public const string RequestMovieCopy_Delete =
        @"delete from RequestMovieCopy
        where MovieID=@MovieID";

        public const string RequestMovieCopy_Delete_All =
        @"delete from RequestMovieCopy";

        public const string RequestMovieCopy_Get_List =
        @"select distinct Movie.*,'' as DisplayQuality,FavoriteMovie.FavoriteRate
        from Movie
        left join FavoriteMovie 
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join RequestMovieCopy
        on RequestMovieCopy.MovieID=Movie.MovieID
        order by Movie.MovieName asc";

        public const string RequestMovieCopy_Insert =
        @"delete from RequestMovieCopy
        where MovieID=@MovieID;

        insert into RequestMovieCopy
        values(@MovieID)";

        public const string SuggestionCache_Delete =
        @"delete from SuggestionCache";

        public const string SuggestionCache_Insert =
        @"delete from SuggestionCache
        where MovieID=@MovieID;

        insert into SuggestionCache
        Values(@MovieID)";

        public const string ToWatchMovie_Delete =
        @"delete from ToWatchMovie
        where MovieID=@MovieID";

        public const string ToWatchMovie_Get_List =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate,ToWatchMovie.AddDate
        from Movie
        left join FavoriteMovie 
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join ToWatchMovie
        on ToWatchMovie.MovieID=Movie.MovieID
        order by ToWatchMovie.AddDate asc";

        public const string ToWatchMovie_Insert =
        @"delete from ToWatchMovie
        where MovieID = @MovieID;

        insert into ToWatchMovie
        values(@MovieID, @AddDate)";

        public const string Users_Insert =
        @"insert into Users(Username,PasswordHash,FName,LName,Email)
        values(@Username,@PasswordHash,@FName,@LName,@Email)";

        public const string Users_Login =
        @"select *
        from Users
        where Username=@Username and PasswordHash=@PasswordHash";

        /// <summary>
        /// For movies with main genre of 'Animation' or 'Documentary' or 'Reality-Show' and ...
        /// </summary>
        public const string Movie_Get_Similar_By_MovieID_ForNotMovie =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate,'' as DisplayQuality,count(RelatedMovie.GenreID) as CommonGenre
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join Movie_Genre as RelatedMovie
        on RelatedMovie.MovieID=Movie.MovieID
        inner join Movie_Genre as FirstMovie
        on FirstMovie.MovieID=@MovieID
        inner join Genre
        on Genre.GenreID=FirstMovie.GenreID
        where RelatedMovie.MovieID<>@MovieID and RelatedMovie.GenreID=FirstMovie.GenreID
        and Movie.IMDBRate between @MinRate and @MaxRate
        and Movie.MovieID in (
                              select inMovie.MovieID
		              from Movie as inMovie
		              inner join Movie_Genre as inMovie_Genre
		              on inMovie_Genre.MovieID=inMovie.MovieID 
		              where inMovie_Genre.GenreID=@MainGenre and inMovie_Genre.IsMain=1
		             )
        group by Movie.MovieID
        order by Movie.IsSeen asc, count(RelatedMovie.GenreID) desc, Movie.IMDBRate desc
        limit @Num";

        /// <summary>
        /// For cinematic movies
        /// </summary>
        public const string Movie_Get_Similar_By_MovieID_ForMovie =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate,'' as DisplayQuality,count(RelatedMovie.GenreID) as CommonGenre
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join Movie_Genre as RelatedMovie
        on RelatedMovie.MovieID=Movie.MovieID
        inner join Movie_Genre as FirstMovie
        on FirstMovie.MovieID=@MovieID
        inner join Genre
        on Genre.GenreID=FirstMovie.GenreID
        where RelatedMovie.MovieID<>@MovieID and RelatedMovie.GenreID=FirstMovie.GenreID
        and Movie.IMDBRate between @MinRate and @MaxRate
        and Movie.MovieID not in (
                                    select exMovie.MovieID
            		                    from Movie as exMovie
            		                    inner join Movie_Genre as exMovie_Genre
            		                    on exMovie_Genre.MovieID=exMovie.MovieID 
            		                    where exMovie_Genre.GenreID in (
            		                                                select exGenre.GenreID
            		              	                                    from Genre as exGenre
            		              	                                    where exGenre.IsMain=1
            		              	                                )
            		                    and exMovie_Genre.IsMain=1
		                    )
        group by Movie.MovieID
        order by Movie.IsSeen asc, count(RelatedMovie.GenreID) desc, Movie.IMDBRate desc
        limit @Num";

        public const string Movie_Suggest_Random =
        @"select * from
        (
        select distinct Movie.*,FavoriteMovie.FavoriteRate,'' as DisplayQuality
        from Movie
        left join FavoriteMovie 
        on FavoriteMovie.MovieID=Movie.MovieID
        @JoinActor
        @JoinDirector
        @JoinGenre
        @JoinLanguage
        where 
        (
        Movie.MovieName like @MovieName
        or Movie.MovieName like '%' || @MovieName || '%'
        or Movie.MovieName like '%' || @MovieName
        or Movie.MovieName like  @MovieName || '%'
        or @MovieName like Movie.MovieName
        or @MovieName like '%' || Movie.MovieName || '%'
        or @MovieName like '%' || Movie.MovieName
        or @MovieName like Movie.MovieName || '%'
        )
        and
        (
        @ProductNull Movie.ProductYear between @ProductYearLower and @ProductYearUpper
        )
        and
        (
        Movie.IMDBRate between @IMDBRateLower and @IMDBRateUpper
        )
        and
        (
        Movie.Duration between @DurationLower and @DurationUpper
        )
        and 
        (
        Movie.MovieID not in (select MovieID from SuggestionCache)
        )
        @IgnoreMovieID
        @IsSeen
        @ActorID
        @DirectorID
        @GenreID
        @LanguageID
        @QualityID
        @IsFavorite
        @GroupBy
        ORDER BY random()
        limit @SuggestCount
        )";

        public const string Movie_Filter_Search =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate,'' as DisplayQuality
        from Movie
        left join FavoriteMovie 
        on FavoriteMovie.MovieID=Movie.MovieID
        @JoinActor
        @JoinDirector
        @JoinGenre
        @JoinLanguage
        where 
        (
        Movie.MovieName like @MovieName
        or Movie.MovieName like '%' || @MovieName || '%'
        or Movie.MovieName like '%' || @MovieName
        or Movie.MovieName like  @MovieName || '%'
        or @MovieName like Movie.MovieName
        or @MovieName like '%' || Movie.MovieName || '%'
        or @MovieName like '%' || Movie.MovieName
        or @MovieName like Movie.MovieName || '%'
        )
        and
        (
        @ProductNull Movie.ProductYear between @ProductYearLower and @ProductYearUpper
        )
        and
        (
        Movie.IMDBRate between @IMDBRateLower and @IMDBRateUpper
        )
        and
        (
        Movie.Duration between @DurationLower and @DurationUpper
        )
        @IgnoreMovieID
        @IsSeen
        @ActorID
        @DirectorID
        @GenreID
        @LanguageID
        @QualityID
        @IsFavorite
        @GroupBy
        order by @OrderBy @OrderType";

        public const string Movie_Get_By_AddDate =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate , '' as DisplayQuality
	    from Movie
	    left join FavoriteMovie
	    on FavoriteMovie.MovieID=Movie.MovieID
	    where Movie.AddDate between @LowerBound and @UpperBound
	    order by Movie.AddDate desc, Movie.MovieName asc, Movie.ProductYear desc";

        public const string DuplicateMovie_Insert =
        @"insert into DuplicateMovie(MovieID, GroupID)
        values(@MovieID, @GroupID)";

        public const string DuplicateMovie_Delete_By_MovieID =
        @"delete from DuplicateMovie
        where MovieID=@MovieID;

        delete from DuplicateMovie
        where MovieID in
        (
        select MovieID from DuplicateMovie
        where GroupID in
        (
        select GroupID from DuplicateMovie
        group by GroupID
        having count(MovieID) <= 1
        )
        );";

        public const string DuplicateMovie_Delete_All =
        @"delete from DuplicateMovie;

        update SystemParameters
        set ParamValue = null
        where ParamID = 1;";

        public const string DuplicateMovie_Get_List =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate, '' as DisplayQuality, DuplicateMovie.GroupID
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join DuplicateMovie
        on DuplicateMovie.MovieID=Movie.MovieID
        order by DuplicateMovie.GroupID asc, Movie.MovieName asc";

        public const string DuplicateMovie_Get_By_MovieID =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate, '' as DisplayQuality, DuplicateMovie.GroupID
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join DuplicateMovie
        on DuplicateMovie.MovieID=Movie.MovieID
        where DuplicateMovie.MovieID=@MovieID";

        public const string DuplicateMovie_Get_By_GroupID =
        @"select distinct Movie.*,FavoriteMovie.FavoriteRate, '' as DisplayQuality, DuplicateMovie.GroupID
        from Movie
        left join FavoriteMovie
        on FavoriteMovie.MovieID=Movie.MovieID
        inner join DuplicateMovie
        on DuplicateMovie.MovieID=Movie.MovieID
        where DuplicateMovie.GroupID=@GroupID
        order by Movie.MovieName asc";

        public const string DuplicateMovie_Cleanup =
        @"delete from DuplicateMovie
        where MovieID in
        (
        select MovieID from DuplicateMovie
        where GroupID in
        (
        select GroupID from DuplicateMovie
        group by GroupID
        having count(MovieID) <= 1
        )
        )";

        public const string Param_Get_By_ParamID =
        @"select * from SystemParameters
        where ParamID=@ParamID";

        public const string Param_Update_By_ParamID =
        @"update SystemParameters
        set ParamValue=@ParamValue
        where ParamID=@ParamID";

        public const string Param_Insert =
        @"insert into SystemParameters(ParamID, ParamName, ParamValue)
        values(@ParamID, @ParamName, @ParamValue)";
    }
}
