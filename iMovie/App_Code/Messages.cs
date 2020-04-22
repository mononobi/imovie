using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace iMovie
{
    public class Messages
    {
        // Validation

        public const string NotAvailable = "N/A"; 

        public const string InvalidMovieID = "Invalid Movie ID.";
        public const string InvalidMovieName = "Invalid Movie Name.";
        public const string InvalidProductYear = "Invalid Product Year.";
        public const string InvalidAddDate = "Invalid Add Date.";
        public const string InvalidIMDBRate = "Invalid IMDb Rate.";
        public const string InvalidDuration = "Invalid Duration.";
        public const string InvalidPosterLink = "Invalid Poster Link.";
        public const string InvalidFileLink = "Invalid File Link";
        public const string InvalidIMDBLink = "Invalid IMDb Page Link.";
        public const string InvalidStoryLine = "Invalid Storyline.";
        public const string InvalidQuality = "Invalid Quality.";
        public const string MovieNotExist = "Movie not found.";
        public const string IMDBLinkNotExist = "IMDb page link not supplied."; 
        public const string IsSeen = "This movie has been watched already";
        public const string NotSeen = "This movie has not been watched yet";
        public const string NoMovieFound = "Not found any movie.";
        public const string NoDuplicateMovieFound = "Not found any duplicate movies.";
        public const string DeleteCache = "Are you sure you want to clear suggestion cache?";
        public const string InvalidFavoriteRate = "Invalid Favorite Rate.";
        public const string FavoriteListEmpty = "Favorite list is empty.";
        public const string AlreadyExistPathString = "The path already exists.";
        public const string DeleteAllMovies = "BE CAREFUL!\nYou are about to clear all movies in database that can not be undone.\nAre you sure you want to clear all movies?";
          
        public const string InvalidLanguageID = "Invalid Language ID.";
        public const string InvalidLanguageName = "Invalid Language Name.";
        public const string AlreadyExistLanguageName = "Language Name already exists.";

        public const string InvalidGenreID = "Invalid Genre ID.";
        public const string InvalidGenreName = "Invalid Genre Name.";
        public const string AlreadyExistGenreName = "Genre Name already exists.";
         
        public const string InvalidPersonID = "Invalid Person ID.";
        public const string InvalidPersonFName = "Invalid Person First Name.";
        public const string InvalidPersonLName = "Invalid Person Last Name.";
        public const string InvalidPersonFullName = "Invalid Person Full Name.";
        public const string InvalidPhotoLink = "Invalid Photo Link.";

        public const string InvalidUserID = "Invalid User ID.";
        public const string InvalidUsername = "Invalid Username.";
        public const string InvalidPassword = "Invalid Password.";
        public const string InvalidFName = "Invalid First Name.";
        public const string InvalidLName = "Invalid Last Name.";
        public const string InvalidEmail = "Invalid Email.";
        public const string UserCreatedOK = "User created successfully.";
        public const string UnavailableUsername = "Username has been already taken.";
        public const string InputUsernameAndPassword = "Please input Username and Password.";
        public const string UsernameAndPasswordNotMatch = "Username and Password do not match.";
        public const string PasswordAndConfirmationNotMatch = "Password and confirmation do not match.";

        public const string InvalidParamID = "Invalid Parameter ID.";
        public const string InvalidParamName = "Invalid Parameter Name.";
        public const string InvalidParamValue = "Invalid Parameter Value.";

        public const string CouldNotGetPageSource = "Could not get page source.";

        public const string MovieAlreadyExisted = "This movie has been already existed.";
        public const string FolderHasBeenIgnored = "This folder has been ignored.";
        public const string CouldNotGetReleaseYear = "Could not get correct release year.";
        public const string FolderHasNoMovie = "Folder does not contain any movie files.";
        public const string CouldNotInsertMovieForDBError = "Movie could not be inserted due to database error.";
        public const string CouldNotInsertMovie = "Movie could not be inserted.";
        public const string CouldNotOpenFileForDuration = "Could not open file to get duration.";
        public const string FileSameNameExist = "File with the same name exists:";
        public const string FileRenamed = "New file renamed as:";
        public const string FolderSameNameExist = "Folder with the same name exists:";
        public const string FolderRenamed = "New folder renamed as:";
        public const string CouldNotOpenFileForDetails = "Could not open file to read duration and resolution.";
        public const string NoQuery = "Please write your query.";
        public const string ErrorOnIndividualFile = "An error occured while processing this file: ";

        // Titles 

        public const string MessageBoxTitle = "iMovie";

        // Errors

        public const string DatabaseError = "An error occured in database operation.";
        public const string InvalidTargetPath = "Target path is invalid.";
        public const string WaitForInsert = "Please wait to complete insertion.";
        public const string WaitForUpdate = "Please wait to complete update."; 
        public const string InsertComplete = "Insert complete.";
        public const string UpdateComplete = "Update complete.";
        public const string InsertError = "Insert encountered an error.";
        public const string UpdateError = "Update encountered an error.";
        public const string AbortUpdate = "Are you sure you want to exit and abort update?\nYou will be able to continue update from where you leave now.";
        public const string AbortInsert = "Are you sure you want to exit and abort Insertion?\nYou will be able to continue insertion from where you leave now.";
        public const string LogCreated = "Log file created on desktop."; 
        public const string InvalidConnectionString = "Connection string to database is invalid.";
        public const string MissedSQLSupport = "Your computer does not have any SQL Server Express 2008 or 2012 client.";
        public const string NotConnected = "It seems that this computer is not connected to the internet.";
        public const string SelectValues = "Please select some values to update.";
        public const string AreYouSureDeleteItem = "Are you sure you want to delete this item?";
        public const string ForceUpdateSure = "Force update will attempt to update the whole information available.\nEven those that already have valid values.\nAre you sure you want to force update this item?";
        public const string IgnoreUpdate = "By unchecking this item, the whole movie information will be\nupdated through internet, even fields that already have valid values.\nThis cause the update progress to take more time.";
        public const string ApplicationIsOpen = "There's another instance of iMovie running.\nDo you want to close that instance and run a new one?";
        public const string SomeUpdateRunning = "Some updates are in progress, please wait to complete operation.";
        public const string IPBanned = "The last @NUM@ movies failed to update in a row.\nIt seems that the internet resources has been banned your\ncurrent IP address from getting data. it's recommended to change\nyour IP address and continue again. if you want to stop update\nand change your IP address click Cancel.";
        public const string CouldNotLoadSomeFonts = "Some application fonts could not be loaded correctly.";
        public const string MissedFontFile = "Some font files are missing in application fonts directory.";
        public const string CheckInternet = "The last @NUM@ movies failed to update in a row.\nIt's recommended to check your internet connection and continue again.\nIf you want to stop update and check your connection click Cancel.";
        public const string InputIMDbURL = "Please input IMDb page URL of this item to update.";
        public const string CountriesFiltered = "If you are in countries such as Iran you should use a proxy or VPN to download images.\nBecause IMDb media server has been restricted in this countries.";
        public const string SelectDestinationPath = "Please select a correct destination path.";
        public const string SelectPath = "Please select a correct path.";
        public const string SelectFilePath = "Please select a correct file path.";
        public const string NoMovieToCopy = "There's no movies to copy.";
        public const string NoMovieToCopyScript = "There's no movies to generate copy script.";
        public const string ClearCopyList = "Are you sure you want to clear the copy list?";
        public const string RemainingMoviesNotFound = "These remaining movies were not found. Please check root paths and your external devices.";
        public const string ScriptGeneratedSuccessfuly = "Script file generated successfuly.";
        public const string ScriptGenerationFailed = "Failed to generate script.";
        public const string NoMovieToLoadScript = "There's no movies in this script to load.";
        public const string SomeMoviesNotLoadInScript = "@NUM@ movies of this script were not found. this usually happens\nif the original script was created on a database other than this one.\nalso it's possible that some movies have been deleted after scripting.";
        public const string ForbiddenKeywords = "Your query contains some keywords that can modify data, it's not possible to modify data through SQL report console.";
        public const string AppendConfigs = "Do you want to append to existing configs?\nIf you select No, then existing configs will be overwritten.";
        public const string ConfigsGenerated = "Config files generated successfuly.";

        // Mutex

        public const string MutexName = "iMovieMutex";

        // Registry

        public const string RootKey = @"Software\iMovie";
        public const string SubKeyDetectedDatabase = @"SQLServerVersion";
        public const string SubKeyLastBatchInsertPath = @"LastBatchInsertPath";
        public const string SubKeyLastSQLReport = @"LastSQLReport";
        public const string SubKeyLastDuplicateReportDateTime = @"LastDuplicateReportDateTime";
        public const string SubKeyLastCachedDuplicateAproximate = @"LastCachedDuplicateAproximate";
    } 
}
