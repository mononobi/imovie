/*
This files contains different queries that help you identify any bad data generated in application database.
*/

--not https movies
select * from Movie
where IMDBLink not like 'https://%'
and Movie.IMDbLink is not Null and length(Movie.IMDbLink) > 0

--not https persons
select * from Person
where IMDBLink not like 'https://%'
and Person.IMDbLink is not Null and length(Person.IMDbLink) > 0
order by Person.PersonID

--not https actors
select Person.* from Person
inner join Actor 
on Person.PersonID = Actor.PersonID
where Person.IMDBLink not like 'https:%'
and Person.IMDbLink is not Null and length(Person.IMDbLink) > 0
order by Person.PersonID

--not https directors
select Person.* from Person
inner join Director 
on Person.PersonID = Director.PersonID
where Person.IMDBLink not like 'https:%'
and Person.IMDbLink is not Null and length(Person.IMDbLink) > 0
order by Person.PersonID

--invalid movie poster link
select * from Movie
where (Movie.PosterLink not like '%.jpg' or Movie.PosterLink like '%http:%')
and PosterLink is not null and length(PosterLink) > 0

--invalid person photo link
select * from Person
where (Person.PhotoLink not like '%.jpg' or Person.PhotoLink like '%http:%')
and Person.PhotoLink is not null and length(Person.PhotoLink) > 0

--persons whose neither an actor nor director v1 (lower performance)
select * from Person p
where not EXISTS(select * from Actor a
				 where a.PersonID = p.PersonID)
and not EXISTS(select * from Director d
			   where d.PersonID = p.PersonID)

--persons whose neither an actor nor director v2 (best performance)
select * from Person p
where p.PersonID not in (select a.PersonID from Actor a)
and p.PersonID not in(select d.PersonID from Director d)

--actors or directors whose not in any movie
select * from Person p
where p.PersonID not in (select a.PersonID from Movie_Actor a)
and p.PersonID not in (select a.PersonID from Movie_Director a)
