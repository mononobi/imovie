# iMovie
Application for rapid and reliable movie collection management.
iMovie is a personal movie collection manager, which can scan your computer for movies, identify movie 
files and download movie details from internet.

# Important
this repository contains an old version of the app that backs to 2013, and is no longer maintained by me.
I only fix the online update part of this app whenever online update needs modifications to continue working.
I'm working on a new version of this app in a new repository. the new app UI will be 
Javascript based to be able to work on all platforms (linux, windows, web and mobile).

# Features
* it can scan your computer's hard disks for movie files, identify the movies automatically, and download all basic details about each       movie from internet, and create a local database of your movies collection.

* open the folder of the movie you desire, directly from the application. you no more need to waste time by 
  searching your computer for movies. iMovie lists all your movies at one place. you can add as many folders as you like, and iMovie is     able to look for movie files inside those folders. all the basic details about the movie will be downloaded and displayed (such as         director(s), actors, plot, IMDB rating, genres, etc). The details are stored offline so that you don't need to connect to internet         everytime.

* search for the title of movie, director, any of actors, genres, etc. There is an intensive search area for you to work with.

* mark a movie as watched, and filter movies that are watched, or not watched, or all.

* sort movies according to title, year, IMDb rating, etc.

* mark a movie as favorite, so that you can keep a favorite list of movies in your collection.

* custom rate a movie out of 10, and store it.

* update movie information at any time with any details you want to be updated, all from the internet without the need to 
  manually enter a value.
  
* you can give a copy of your application to a friend. then he/she can make a request list from your movies, and give the 
  generated list to you (it's a simple text file). then you load the list into your own application, and then automatically 
  copy all of those movies from your computer to an external device of your friend without worrying about the real physical 
  location of the movies on your hard disk, sounds great? I think so.
  
 * when your movie collection grows by time, it's possible that you've been having duplicate versions of the same movie.
   iMovie lets you get a list of all duplicate movies and delete those ones that are not needed to free up space on your hard disk.
   
 * when viewing a movie details, iMovie shows you up to 20 relevant movies to that movie according to genres and IMDB rate.
 
# Usage Notice
the only thing that you have to notice to use this app, is to not rename each movie's folder name after you've archived 
it using the app. otherwise, the link between the data stored in the app and the real movie will be lost and if you insert that movie again, it will be inserted without notice.

# Running The Application
open the project in Visual Studio and build the solution in desired mode (Debug or Release).
to be able to run the application, you should copy 'iMovie/App_Data' folder into the runtime directory.
