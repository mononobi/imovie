using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;
using Shell32;
using System.Drawing;

namespace iMovie
{ 
    public class InsertManager
    {
        private volatile bool exitRequest = false;
        private bool generateLog = false;
        private bool forceInsert = false;

        private string[] videoFormat = { "mkv", "mp4", "avi", "wmv", "dat", "mov", "divx", "xvid", "m4v", "ts", "flv", "mpg", "mpeg", "m2ts", "3gp", "vob" };
        private string[] patterns = new string[0];
        private string[] ignoreChars = new string[0];

        private string personImagePath = PathUtils.GetApplicationPersonPath();
        private string moviePosterPath = PathUtils.GetApplicationMoviePosterPath();

        /// <summary>
        /// Initializes an instance of InsertManager with specified values
        /// </summary>
        /// <param name="generateLog">
        /// Value indicating that this instance should generate log to report it's state</param>
        /// <param name="forceInsert">
        /// Value indicating that should ignore the minimum video file size limit</param>
        /// <param name="owner">
        /// The windows form that is owner of this instance</param>
        public InsertManager(bool generateLog, bool forceInsert)
        {
            try
            {
                this.GenerateLog = generateLog;
                this.ForceInsert = forceInsert;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Initializes an instance of InsertManager with default values
        /// </summary>
        public InsertManager()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reads directors information from pictures of directors.
        /// Example file name: Alejandro L. Innaritu
        /// </summary>
        /// <param name="rootFolder">
        /// The root folder containing directors photos</param>
        public void InsertDirectorsFromFile(string rootFolder)
        {
            try
            {
                string[] files = new string[0];
                string[] fullName = new string[0];
                string tempName = "";
                string[] sep = new string[1];
                sep[0] = " ";
                string fname = "";
                string lname = "";

                if (Directory.Exists(rootFolder) == true)
                {
                    files = Directory.GetFiles(rootFolder);

                    foreach (string s in files)
                    {
                        tempName = Path.GetFileNameWithoutExtension(s);
                        fullName = tempName.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                        int len = fullName.Length;
                        int i = 0;
                        fname = fullName[0];
                        i++;

                        while (i < len)
                        {
                            lname += fullName[i] + " ";
                            i++;
                        }

                        lname = lname.Trim();

                        Person p = new Person(0, fname, lname, "", Path.GetFileName(s));

                        long r = Person_SP.Insert(p, false, true);

                        if (r <= 0)
                        {
                            MessageBox.Show(fname + " " + lname);
                        }

                        fname = "";
                        lname = "";
                        fullName = new string[0];
                        tempName = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reads movies information from pictures of movies.
        /// Example file name: The Man Who Cried (2003)
        /// </summary>
        /// <param name="rootFolder">
        /// The root folder containing movies photos</param>
        public void InsertMoviesFromFile(string rootFolder)
        {
            try 
            {
                Regex reg = new Regex(@"[(][0-9]{4}[)]");

                string[] files = new string[0];
                string fullName = "";
                string movieName = "";
                string year = "";
              
                if (Directory.Exists(rootFolder) == true)
                {
                    files = Directory.GetFiles(rootFolder);

                    foreach (string s in files)
                    {
                        fullName = Path.GetFileNameWithoutExtension(s);
                        year = reg.Match(fullName).Value;
                        movieName = fullName.Replace(year, "");

                        fullName = fullName.Trim();
                        year = year.Trim();
                        year = year.Replace("(", "");
                        year = year.Replace(")", "");
                        movieName = movieName.Trim();

                        Movie m = new Movie(0, movieName, Convert.ToInt32(year), DateTime.Now, 0, new TimeSpan(0, 0, 1), Path.GetFileName(s), "", false, "", enVideoQuality.Indeterminate, "", 0);

                        long r = Movie_SP.Insert(m);

                        if (r <= 0)
                        {
                            MessageBox.Show(fullName);
                        }

                        fullName = "";
                        year = "";
                        movieName = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reads actors information from pictures of actors.
        /// Example file name: Alejandro L. Innaritu
        /// </summary>
        /// <param name="rootFolder">
        /// The root folder containing actors photos</param>
        public void InsertActorsFromFile(string rootFolder)
        { 
            try
            {
                string[] files = new string[0];
                string[] fullName = new string[0];
                string tempName = "";
                string[] sep = new string[1];
                sep[0] = " ";
                string fname = "";
                string lname = "";

                if (Directory.Exists(rootFolder) == true)
                {
                    files = Directory.GetFiles(rootFolder);

                    foreach (string s in files)
                    {
                        tempName = Path.GetFileNameWithoutExtension(s);
                        fullName = tempName.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                        int len = fullName.Length;
                        int i = 0;
                        fname = fullName[0];
                        i++;

                        while (i < len)
                        {
                            lname += fullName[i] + " ";
                            i++;
                        }

                        lname = lname.Trim();

                        Person p = new Person(0, fname, lname, "", Path.GetFileName(s));

                        long r = Person_SP.Insert(p, true, false);

                        if (r <= 0)
                        {
                            MessageBox.Show(fname + " " + lname);
                        }

                        fname = "";
                        lname = "";
                        fullName = new string[0];
                        tempName = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reads actors and directors information from pictures of them.
        /// Example file name: Alejandro L. Innaritu
        /// </summary>
        /// <param name="rootFolder">
        /// The root folder containing actors and directors photos</param>
        public void InsertActorsAndDirectorsFromFile(string rootFolder)
        {
            try
            {
                string[] files = new string[0];
                string[] fullName = new string[0];
                string tempName = "";
                string[] sep = new string[1];
                sep[0] = " ";
                string fname = "";
                string lname = "";

                if (Directory.Exists(rootFolder) == true)
                {
                    files = Directory.GetFiles(rootFolder);

                    foreach (string s in files)
                    {
                        tempName = Path.GetFileNameWithoutExtension(s);
                        fullName = tempName.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                        int len = fullName.Length;
                        int i = 0;
                        fname = fullName[0];
                        i++;

                        while (i < len)
                        {
                            lname += fullName[i] + " ";
                            i++;
                        }

                        lname = lname.Trim();

                        Person p = new Person(0, fname, lname, "", Path.GetFileName(s));

                        long r = Person_SP.Insert(p, true, true);

                        if (r <= 0)
                        {
                            MessageBox.Show(fname + " " + lname);
                        }

                        fname = "";
                        lname = "";
                        fullName = new string[0];
                        tempName = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reads movie information from folder of a movie
        /// and corrects these information from different aspects like
        /// making titlecase, removing extra . and _ and replacing them with white space and ...
        /// Example folder name: The Man Who Cried (2003) DVDRip, The Man Who Cried [2003] ...
        /// </summary>
        /// <param name="movieFolder">
        /// The folder containing a movie</param>
        public enInsertResult InsertMovieSingle(string movieFolder)
        { 
            try
            {
                enInsertResult insertResult = enInsertResult.Unknown;

                string[] folders = new string[0];
                string fullName = "";
                string movieName = "";
                string year = "";
                string OriginalName = "";

                if (Directory.Exists(movieFolder) == true)
                {
                    fullName = Path.GetFileName(movieFolder);

                    // This folder should be ignored
                    if(this.ForceInsert == false && this.ShouldBeIgnored(fullName) == true)
                    {
                        if (this.GenerateLog == true)
                        {
                            iMovieBase.log.GenerateSilent(Messages.FolderHasBeenIgnored + Environment.NewLine + movieFolder);
                        }

                        return enInsertResult.Ignored;
                    }

                    // This movie already existed
                    if (Movie_SP.CountByFileLink(fullName) > 0)
                    {
                        if (this.GenerateLog == true)
                        {
                            iMovieBase.log.GenerateSilent(Messages.MovieAlreadyExisted + Environment.NewLine + movieFolder);
                        }

                        return enInsertResult.AlreadyExisted;
                    }

                    if (fullName.Length > 5)
                    {
                        int dashIndex = -1;
                        dashIndex = fullName.IndexOf("-", fullName.Length - 5);

                        if (dashIndex >= 0)
                        {
                            OriginalName = fullName.Substring(0, dashIndex);
                            OriginalName = OriginalName.TrimEnd();
                        }
                        else
                        {
                            OriginalName = fullName;
                        }
                    }

                    fullName = fullName.Trim();

                    movieName = fullName;

                    movieName = RemoveExtraChars(movieName);

                    year = GetYear(movieName, out movieName);

                    movieName = RemoveExtraChars(movieName);

                    movieName = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(movieName);
                    movieName = SetCountingLetters(movieName);

                    string[] files = new string[0];
                    files = Directory.GetFiles(movieFolder);

                    bool isEmpty = true;

                    TimeSpan ts = new TimeSpan();
                    Size size = new Size();

                    foreach (string f in files)
                    {
                        MediaInformation mInfo = new MediaInformation();
                        bool isFile = false;
                        mInfo = ReadMediaInformation(f, out isFile);

                        if (isFile == true)
                        {
                            isEmpty = false;

                            ts += mInfo.Duration;

                            if (size == new Size())
                            {
                                size = mInfo.Resolution;
                            }
                        }
                    }

                    enVideoQuality quality = MapVideoQuality(size.Width, size.Height);

                    if (year.Length == 0 && this.GenerateLog == true)
                    {
                        iMovieBase.log.GenerateSilent(Messages.CouldNotGetReleaseYear + Environment.NewLine + movieFolder);
                    }

                    try
                    {
                        if (isEmpty == true)
                        {
                            insertResult = enInsertResult.EmptyFolder;

                            throw new Exception(Messages.FolderHasNoMovie);
                        }
                        else
                        {
                            string pathRoot = movieFolder;
                            pathRoot = pathRoot.Replace(Path.GetFileName(movieFolder), "");

                            string newName = movieName + " " + "[" + year + "]" + " " + "[" + Enums.GetVideoQuality(quality) + "]";
                            string fullNewName = pathRoot + newName;

                            fullNewName = RenameDirectory(movieFolder, fullNewName);

                            if (year.Length == 0)
                            {
                                year = "0";
                            }

                            Movie m = new Movie(0, movieName, Convert.ToInt32(year), DateTime.Now, 0, ts, "", Path.GetFileName(fullNewName), false, "", quality, "", 0);

                            string namePhoto = m.FullTitle + ".jpg";
                            string imageLink = moviePosterPath + namePhoto;

                            if (File.Exists(imageLink) == true)
                            {
                                m.PosterLink = Path.GetFileName(imageLink);
                            }

                            long r = Movie_SP.Insert(m);

                            if (r > 0)
                            {
                                insertResult = enInsertResult.SuccessfullInsert;
                            }
                            else if (r <= 0)
                            {
                                RenameDirectory(fullNewName, movieFolder);
  
                                if (this.GenerateLog == true)
                                {
                                    iMovieBase.log.GenerateSilent(Messages.CouldNotInsertMovieForDBError + Environment.NewLine + movieFolder);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (this.GenerateLog == true)
                        {
                            iMovieBase.log.GenerateSilent(Messages.CouldNotInsertMovie + Environment.NewLine + movieFolder + Environment.NewLine + ex.Message);
                        }
                    }
                      
                    fullName = "";
                    year = "";
                    movieName = "";
                    OriginalName = "";
                }

                return insertResult;
            }
            catch (Exception ex)
            {
                if (this.GenerateLog == true)
                {
                    iMovieBase.log.GenerateSilent(Messages.CouldNotInsertMovie + Environment.NewLine + movieFolder + Environment.NewLine + ex.Message);
                }

                return enInsertResult.Unknown;
            }
        }

        /// <summary>
        /// Reads movies information from folders of movies
        /// and corrects these information from different aspects like
        /// making titlecase, removing extra . and _ and replacing them with white space and ...
        /// Example folder name: The Man Who Cried (2003) DVDRip, The Man Who Cried [2003] ...
        /// </summary>
        /// <param name="rootFolder">
        /// Root folder containing movies folders</param>
        /// <param name="owner">
        /// Windows form that is owner of this instance</param>
        public void InsertMovieBatch(string rootFolder, bool includeIndividualFiles, Form owner = null)
        {
            int total = 0;
            int inserted = 0;
            int existed = 0;
            int empty = 0;
            int ignored = 0;

            try 
            {
                string[] folders = new string[0];

                if (Directory.Exists(rootFolder) == true)
                {
                    this.patterns = ConfigManager.GetExtraCharacters();
                    this.ignoreChars = ConfigManager.GetIgnoreCharacters();

                    if (includeIndividualFiles == true)
                    {
                        ProcessIndividualMovieFiles(rootFolder);
                    }

                    folders = Directory.GetDirectories(rootFolder);

                    foreach (string s in folders)
                    {
                        total++;

                        if (owner != null)
                        {
                            (owner as frmBatchMovie).InvokeHandle("Inserting: " + Path.GetFileName(s));
                        }

                        enInsertResult result = this.InsertMovieSingle(s);

                        switch (result)
                        {
                            case enInsertResult.AlreadyExisted:

                                existed++;

                                break;

                            case enInsertResult.EmptyFolder:

                                empty++;

                                break;

                            case enInsertResult.SuccessfullInsert:

                                inserted++;

                                break;

                            case enInsertResult.Ignored:

                                ignored++;

                                break;
                        }

                        if (owner != null)
                        {
                            (owner as frmBatchMovie).InvokeHandle();
                        }

                        if (this.ExitRequest == true)
                        {
                            break;
                        }
                    }
                }

                int errors = total - (inserted + existed + empty + ignored);

                if (this.GenerateLog == true)
                {
                    iMovieBase.log.GenerateSilent("Total folders processed: " + total.ToString() + Environment.NewLine +
                                                  "Movies inserted: " + inserted.ToString() + Environment.NewLine +
                                                  "Movies already existed: " + existed.ToString() + Environment.NewLine +
                                                  "Movies failed to insert: " + errors.ToString() + Environment.NewLine +
                                                  "Ignored folders: " + ignored.ToString() + Environment.NewLine +
                                                  "Empty folders: " + empty.ToString());
                }

                this.ExitRequest = false;
                return;
            }
            catch (Exception ex)
            {
                int errors = total - (inserted + existed + empty + ignored);

                if (this.GenerateLog == true)
                {
                    iMovieBase.log.GenerateSilent("Total folders processed: " + total.ToString() + Environment.NewLine +
                                                  "Movies inserted: " + inserted.ToString() + Environment.NewLine +
                                                  "Movies already existed: " + existed.ToString() + Environment.NewLine +
                                                  "Movies failed to insert: " + errors.ToString() + Environment.NewLine +
                                                  "Ignored folders: " + ignored.ToString() + Environment.NewLine +
                                                  "Empty folders: " + empty.ToString());
                }

                this.ExitRequest = false;

                throw ex;
            }
        }

        /// <summary>
        /// Chooses the correct video quality depend on specified video display size
        /// </summary>
        /// <param name="width">
        /// Video width</param>
        /// <param name="height">
        /// Video height</param>
        /// <returns>
        /// enum representing the correct video quality</returns>
        public enVideoQuality MapVideoQuality(int width, int height)
        { 
            try 
            {
                int VCD_Width_Min = 100;
                int VCD_Height_Min = 60; 

                int DVD_Width_Min = 500;
                int DVD_Height_Min = 250;

                int HD_Width_Min = 900;
                int HD_Height_Min = 400;

                int Full_HD_Width_Min = 1500;
                int Full_HD_Height_Min = 800;

                int mul = height * width;

                if (mul >= Full_HD_Height_Min * Full_HD_Width_Min && width >= Full_HD_Width_Min)
                {
                    // 1080
                    return enVideoQuality._1080p;
                }
                if (mul >= HD_Height_Min * HD_Width_Min && width >= HD_Width_Min)
                {
                    // 720
                    return enVideoQuality._720p;
                }
                if (mul >= DVD_Height_Min * DVD_Width_Min && width >= DVD_Width_Min)
                {
                    // DVD
                    return enVideoQuality.DVD;
                }
                if (mul >= VCD_Height_Min * VCD_Width_Min && width >= VCD_Width_Min)
                {
                    // VCD
                    return enVideoQuality.VCD;
                }
                else
                {
                     // N/A
                    return enVideoQuality.Indeterminate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RenameDirectory(string oldName, string newName)
        {
            try 
            {
                string name = newName;

                if (oldName.Equals(newName, StringComparison.CurrentCultureIgnoreCase) == false)
                {
                    if (Directory.Exists(oldName) == true)
                    {
                        if (Directory.Exists(newName) == false)
                        {
                            Directory.Move(oldName, newName);
                            name = newName;
                        }
                        else
                        {
                            int i = 1;

                            while (Directory.Exists(newName + " - " + i.ToString()) == true)
                            {
                                i++;
                            }

                            name = newName + " - " + i.ToString();
                            Directory.Move(oldName, name);

                            if (this.GenerateLog == true)
                            {
                                iMovieBase.log.GenerateSilent(Messages.FolderSameNameExist + Environment.NewLine + newName + Environment.NewLine + Messages.FolderRenamed + Environment.NewLine + name);
                            }
                        }
                    }
                }

                return name;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RenameFile(string oldName, string newName)
        {
            try
            {
                string name = newName;
                string ext = Path.GetExtension(newName);

                if (oldName.Equals(newName, StringComparison.CurrentCultureIgnoreCase) == false)
                {
                    if (File.Exists(oldName) == true)
                    {
                        if (File.Exists(newName) == false)
                        {
                            File.Move(oldName, newName);
                            name = newName;
                        }
                        else
                        {
                            int i = 1;

                            newName = newName.Replace(ext, "");

                            while (File.Exists(newName + " - " + i.ToString() + ext) == true)
                            {
                                i++;
                            }

                            name = newName + " - " + i.ToString() + ext;
                            File.Move(oldName, name);

                            if (this.GenerateLog == true)
                            {
                                iMovieBase.log.GenerateSilent(Messages.FileSameNameExist + Environment.NewLine + newName + Environment.NewLine + Messages.FileRenamed + Environment.NewLine + name);
                            }
                        }
                    }
                }

                return name;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Tries to open specified file as a video if meets the conditions
        /// </summary>
        /// <param name="path">
        /// File path to open</param>
        /// <param name="isFile">
        /// a value indicating the file has been met the conditions or not</param>
        /// <returns>
        /// Media information associated with file path or empty object if could not open 
        /// the file or file does not met the conditions</returns>
        public MediaInformation ReadMediaInformation(string path, out bool isFile)
        {
            try 
            {
                isFile = false;
                bool result = false;
 
                if (File.Exists(path) == true)
                {
                    if (IsVideoFileExtension(path) == true)
                    {
                        try
                        {
                            FileInfo inf = new FileInfo(path);

                            foreach(IMediaInfo infoProvider in MediaInfoContainer.MediaInfoProviders)
                            {
                                try
                                {
                                    result = infoProvider.OpenFile(path);

                                    if (inf.Length > 70000000 || this.ForceInsert == true)
                                    {
                                        isFile = true;
                                    }

                                    if (result == true)
                                    {
                                        if (inf.Length <= 70000000 && this.ForceInsert == false)
                                        {
                                            if (infoProvider.GetDuration().TotalMinutes >= 10)
                                            {
                                                isFile = true;
                                            }
                                            else
                                            {
                                                isFile = false;
                                            }
                                        }

                                        if (isFile == true)
                                        {
                                            MediaInformation mediaInformation = new MediaInformation();
                                            mediaInformation.Duration = infoProvider.GetDuration();
                                            mediaInformation.Resolution = infoProvider.GetResolution();

                                            return mediaInformation;
                                        }
                                        else
                                        {
                                            return new MediaInformation();
                                        }
                                    }
                                }
                                finally
                                {
                                    infoProvider.Dispose();
                                }
                            }
                        }
                        catch
                        {

                        }
                        finally
                        {
                            if (this.GenerateLog == true && result == false && isFile == true)
                            {
                                iMovieBase.log.GenerateSilent(Messages.CouldNotOpenFileForDetails + Environment.NewLine + path);
                            }
                        }
                    }
                }

                return new MediaInformation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns an indicating value that the specified file is a video file or not
        /// </summary>
        /// <param name="filePath">
        /// The file path</param>
        /// <returns>
        /// true for video and false for others</returns>
        public bool IsVideoFileExtension(string filePath)
        {
            try
            {
                string ext = Path.GetExtension(filePath);
                ext = ext.Replace(".", "");

                int i = this.videoFormat.Length;

                while (i > 0)
                {
                    if (this.videoFormat[i - 1].Equals(ext, StringComparison.CurrentCultureIgnoreCase) == true)
                    {
                        return true;
                    }

                    i--;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the string that all the counting letters are in lowercase
        /// </summary>
        /// <param name="value">
        /// String to be corrected</param>
        /// <returns>
        /// Corrected string</returns>
        public string SetCountingLetters(string value)
        {
            try  
            {
                string result = value;

                int len = result.Length;

                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (char.IsDigit(result[i]) == true)
                        {
                            if (len > i + 2)
                            {
                                if (result[i + 1].ToString().Equals("s", StringComparison.CurrentCultureIgnoreCase) == true && result[i + 2].ToString().Equals("t", StringComparison.CurrentCultureIgnoreCase) == true)
                                {
                                    result = result.Remove(i + 1, 2);
                                    result = result.Insert(i + 1, "st");
                                }
                                else if (result[i + 1].ToString().Equals("t", StringComparison.CurrentCultureIgnoreCase) == true && result[i + 2].ToString().Equals("h", StringComparison.CurrentCultureIgnoreCase) == true)
                                {
                                    result = result.Remove(i + 1, 2);
                                    result = result.Insert(i + 1, "th");
                                }
                                else if (result[i + 1].ToString().Equals("r", StringComparison.CurrentCultureIgnoreCase) == true && result[i + 2].ToString().Equals("d", StringComparison.CurrentCultureIgnoreCase) == true)
                                {
                                    result = result.Remove(i + 1, 2);
                                    result = result.Insert(i + 1, "rd");
                                }
                                else if (result[i + 1].ToString().Equals("n", StringComparison.CurrentCultureIgnoreCase) == true && result[i + 2].ToString().Equals("d", StringComparison.CurrentCultureIgnoreCase) == true)
                                {
                                    result = result.Remove(i + 1, 2);
                                    result = result.Insert(i + 1, "nd");
                                }
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExitRequest  
        {
            get
            {
                try
                {
                    return this.exitRequest;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            set
            {
                try
                {
                    this.exitRequest = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool GenerateLog
        {
            get
            {
                try
                {
                    return this.generateLog;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            set
            {
                try
                {
                    this.generateLog = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool ForceInsert
        {
            get
            {
                try
                {
                    return this.forceInsert;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            set
            {
                try
                {
                    this.forceInsert = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string GetYear(string movieName, out string movieNameResult)
        {
            try
            {
                string year = "";
                movieName = movieName.Trim();

                Regex reg = new Regex(@"[1|2]{1}[0|9]{1}[0-9]{2}"); // 2000

                int len = movieName.Length;

                int i = reg.Matches(movieName).Count;

                if (i > 0)
                {
                    year = reg.Matches(movieName)[i - 1].Value;
                }

                if (Movie.IsProductYear(year) == false)
                {
                    year = "";
                }
                else if (len <= 4)
                {
                    year = "";
                }
                else
                {
                    if (year.Length > 0)
                    {
                        string tmpName = movieName;
                        int lastIndex = tmpName.LastIndexOf(year);
                        tmpName = tmpName.Remove(lastIndex, year.Length);
                        tmpName = tmpName.Insert(lastIndex, ":");
                        tmpName= StringCompare.RemoveDuplicateSpace(tmpName);

                        int tmpID = tmpName.IndexOf(":");

                        if (tmpID == 0)
                        {
                            year = "";
                        }
                        else if (tmpID == 1)
                        {
                            if (movieName[0] == '[' || movieName[0] == '(')
                            {
                                year = "";
                            }
                        }

                        if(year.Length > 0)
                        {
                            movieName = tmpName;
                        }
                    }
                }

                if (year.Length > 0)
                {
                    int idx = movieName.IndexOf(":");
                    movieName = movieName.Substring(0, idx);

                    if (movieName[idx - 1] == '[' || movieName[idx - 1] == '(')
                    {
                        movieName = movieName.Remove(idx - 1);
                    }
                }

                movieName = movieName.Trim();

                movieNameResult = movieName;

                return year;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RemoveExtraChars(string movieName)
        {
            try
            {
                movieName = movieName.Replace(".", " ");
                movieName = movieName.Replace("_", " ");
                movieName = movieName.Trim();

                movieName = StringCompare.RemoveDuplicateSpace(movieName);

                movieName = movieName.Trim('-');
                movieName = movieName.Trim('.');
                movieName = movieName.Trim('_');
                movieName = movieName.Replace("[DVD]", "");
                movieName = movieName.Replace("[480p]", "");
                movieName = movieName.Replace("[360p]", "");
                movieName = movieName.Replace("[1080p]", "");
                movieName = movieName.Replace("[720p]", "");
                movieName = movieName.Replace("[VCD]", "");
                movieName = movieName.Replace("[Indeterminate]", "");
                movieName = movieName.Replace("[]", "");
                movieName = movieName.Replace("()", "");
                movieName = movieName.Replace("[", "");
                movieName = movieName.Replace("]", "");
                movieName = movieName.Trim();

                movieName = StringCompare.RemoveDuplicateSpace(movieName);

                foreach (string pat in patterns)
                {
                    movieName = Regex.Replace(movieName, pat, "", RegexOptions.IgnoreCase);
                    movieName = StringCompare.RemoveDuplicateSpace(movieName);
                }

                movieName = movieName.Trim();

                movieName = StringCompare.RemoveDuplicateSpace(movieName);

                return movieName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> CopyMovies(string destination, DataTable dtFolderNames, DataTable dtRootPaths)
        {
            try
            {
                List<string> notFounded = new List<string>();

                if (Directory.Exists(destination) == true)
                {
                    List<string> fullSourcePath = new List<string>();
                    List<string> fullDestinationPath = new List<string>();
                    List<long> movieID = new List<long>();

                    bool found = false;

                    foreach (DataRow movie in dtFolderNames.Rows)
                    {
                        found = false;

                        foreach (DataRow root in dtRootPaths.Rows)
                        {
                            if (Directory.Exists(root["PathString"].ToString() + @"\" + movie["FileLink"].ToString()) == true)
                            {
                                fullSourcePath.Add(root["PathString"].ToString() + @"\" + movie["FileLink"].ToString());
                                fullDestinationPath.Add(destination + @"\" + movie["FileLink"].ToString());
                                movieID.Add(Convert.ToInt64(movie["MovieID"].ToString()));

                                found = true;
                            }
                        }

                        if (found == false)
                        {
                            notFounded.Add(movie["FileLink"].ToString());
                        }
                    }

                    if (fullSourcePath.Count > 0)
                    {
                        for (int i = 0; i < fullSourcePath.Count; i++)
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(fullSourcePath[i], fullDestinationPath[i], Microsoft.VisualBasic.FileIO.UIOption.AllDialogs);
                            Movie_SP.RequestMovieCopyDelete(movieID[i]);
                        }
                    }

                    return notFounded;
                }
                else
                {
                    throw new Exception(Messages.SelectDestinationPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GenerateCopyRequestScript(DataTable dtCopyRequest, string destination)
        {
            try
            {
                if (dtCopyRequest.Rows.Count > 0)
                {
                    string script = "";

                    foreach (DataRow dt in dtCopyRequest.Rows)
                    {
                        script += dt["MovieID"].ToString() + "*" + dt["IMDbLink"].ToString() + Environment.NewLine;
                    }

                    StreamWriter write = new StreamWriter(destination, false);
                    write.Write(script);
                    write.Close();
                    write.Dispose();

                    return true;
                }
                else
                {
                    throw new Exception(Messages.NoMovieToCopyScript);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadCopyRequestScript(string filePath, out long failed, out long notFound)
        {
            try
            {
                DataTable result = new DataTable();
                failed = 0;
                notFound = 0;

                if (File.Exists(filePath) == true)
                {
                    StreamReader reader = new StreamReader(filePath);
                    List<string> id = new List<string>();

                    while (!reader.EndOfStream)
                    {
                        try
                        {
                            string item = reader.ReadLine();
                            string[] info = item.Split('*');

                            if (info.Length == 2)
                            {
                                if (id.Contains(info[0]) == false)
                                {
                                    DataTable dtTemp = new DataTable();
                                    dtTemp = Movie_SP.GetByMovieIDOrIMDbBLink(Convert.ToInt64(info[0]), info[1]);

                                    if (result.Columns.Count == 0)
                                    {
                                        foreach (DataColumn dc in dtTemp.Columns)
                                        {
                                            result.Columns.Add(dc.ColumnName);
                                        }
                                    }

                                    foreach (DataRow dr in dtTemp.Rows)
                                    {
                                        if (id.Contains(dr["MovieID"].ToString()) == false)
                                        {
                                            result.ImportRow(dr);
                                            id.Add(dr["MovieID"].ToString());
                                        }
                                    }

                                    if (dtTemp.Rows.Count == 0)
                                    {
                                        notFound++;
                                    }
                                }
                            }
                            else
                            {
                                failed++;
                            }
                        }
                        catch (Exception ex)
                        {
                            failed++;
                        }
                    }

                    if (result.Rows.Count > 0)
                    {
                        Movie_SP.RequestMovieCopyDeleteAll();

                        foreach (string s in id)
                        {
                            Movie_SP.RequestMovieCopyInsert(Convert.ToInt64(s));
                        }
                    }

                    reader.Close();
                    reader.Dispose();
               
                    return result;
                }
                else
                {
                    throw new Exception(Messages.SelectFilePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Movie> GetMovieListFromPath(string rootFolder)
        {
            try
            {
                string[] folders = new string[0];
                string fullName = "";
                string movieName = "";
                string year = "";
                string OriginalName = "";
                List<Movie> resultMovieList = new List<Movie>();

                if (Directory.Exists(rootFolder) == true)
                {
                    folders = Directory.GetDirectories(rootFolder);

                    foreach (string movieFolder in folders)
                    {
                        if (Directory.Exists(movieFolder) == true)
                        {
                            fullName = Path.GetFileName(movieFolder);

                            if (fullName.Length > 5)
                            {
                                int dashIndex = -1;
                                dashIndex = fullName.IndexOf("-", fullName.Length - 5);

                                if (dashIndex >= 0)
                                {
                                    OriginalName = fullName.Substring(0, dashIndex);
                                    OriginalName = OriginalName.TrimEnd();
                                }
                                else
                                {
                                    OriginalName = fullName;
                                }
                            }

                            fullName = fullName.Trim();

                            movieName = fullName;

                            movieName = RemoveExtraChars(movieName);

                            year = GetYear(movieName, out movieName);

                            movieName = RemoveExtraChars(movieName);

                            movieName = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(movieName);
                            movieName = SetCountingLetters(movieName);

                            string[] files = new string[0];
                            files = Directory.GetFiles(movieFolder);
                            bool isEmpty = true;

                            foreach (string f in files)
                            {
                                if (IsVideoFileExtension(f) == true)
                                {
                                    isEmpty = false;
                                    break;
                                }
                            }

                            if (isEmpty == true)
                            {
                                continue;
                            }
                            else
                            {
                                if (year.Length == 0)
                                {
                                    year = "0";
                                }

                                Movie movie = new Movie(0, movieName, Convert.ToInt32(year), DateTime.Now, 0, new TimeSpan(0, 0, 0), "", "", false, "", enVideoQuality.Indeterminate, "", 0);
                                resultMovieList.Add(movie);
                            }

                            fullName = "";
                            year = "";
                            movieName = "";
                            OriginalName = "";
                        }
                    }
                }

                return resultMovieList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public float CalculateSize(DataTable dtFolderNames, DataTable dtRootPaths)
        {
            float size = 0;

            try
            {
                List<string> fullSourcePath = new List<string>();

                foreach (DataRow movie in dtFolderNames.Rows)
                {
                    foreach (DataRow root in dtRootPaths.Rows)
                    {
                        if (Directory.Exists(root["PathString"].ToString() + @"\" + movie["FileLink"].ToString()) == true)
                        {
                            fullSourcePath.Add(root["PathString"].ToString() + @"\" + movie["FileLink"].ToString());
                        }
                    }
                }

                if (fullSourcePath.Count > 0)
                {
                    for (int i = 0; i < fullSourcePath.Count; i++)
                    {
                        //Calculate Size Here
                        foreach (string file in Directory.GetFiles(fullSourcePath[i]))
                        {
                            try
                            {
                                size += new FileInfo(file).Length;
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                        }
                    }
                }

                return size;
            }
            catch (Exception ex)
            {
                return size;
            }
        }

        private void ProcessIndividualMovieFiles(string rootPath)
        {
            string[] files = new string[0];
            if (Directory.Exists(rootPath) == true)
            {
                files = Directory.GetFiles(rootPath);

                foreach (string f in files)
                {
                    try
                    {
                        if (File.Exists(f) == true)
                        {
                            if (IsVideoFileExtension(f) == true)
                            {
                                string fileName = Path.GetFileNameWithoutExtension(f);
                                string folderPath = Path.Combine(rootPath, fileName);

                                if (Directory.Exists(folderPath) == false)
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                string[] totalMovieRelatedFiles = new string[0];
                                totalMovieRelatedFiles = Directory.GetFiles(rootPath, fileName + "*");

                                foreach (string relatedFile in totalMovieRelatedFiles)
                                {
                                    string newRelatedFilePath = relatedFile;

                                    while (File.Exists(Path.Combine(folderPath, Path.GetFileName(newRelatedFilePath))) == true)
                                    {
                                        string relatedExtension = Path.GetExtension(relatedFile);
                                        string newRelatedFileName = Path.GetFileNameWithoutExtension(relatedFile);
                                        newRelatedFileName += " - Copy";

                                        newRelatedFilePath = Path.Combine(rootPath, newRelatedFileName + relatedExtension);
                                    }

                                    File.Move(relatedFile, Path.Combine(folderPath, Path.GetFileName(newRelatedFilePath)));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (this.GenerateLog == true)
                        {
                            iMovieBase.log.GenerateSilent(Messages.ErrorOnIndividualFile + Environment.NewLine + f + Environment.NewLine + Environment.NewLine + ex.Message);
                        }
                    }
                }
            }
        }

        private bool ShouldBeIgnored(string folderName)
        {
            foreach(string s in this.ignoreChars)
            {
                if (folderName.StartsWith(s) == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
