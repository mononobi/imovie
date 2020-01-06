using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Data;
using System.Drawing.Text;

namespace iMovie
{
    public class iMovieBase
    {
        public static bool IsLogin = true;
        public static Users User = new Users();
        public static Log log = new Log();
        public static DataTable MovieRootPath = new DataTable();
        public static PrivateFontCollection AppFonts = new PrivateFontCollection();
    }
} 
