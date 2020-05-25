using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace iMovie
{
    public class Subscene
    {
        private static string[] realValues = { "%", "&", "[", "]", "=", "{", "}", "#", "@", "$", "^", @"""", ";", ",", "?", "/", @"\", ">", "<", "|", "+", "`", "(", ")" };
        private static string[] queryValues = { "%25", "%26", "%5B", "%5D", "%3D", "%7B", "%7D", "%23", "%40", "%24", "%5E", "%22", "%3B", "%2C", "%3F", "%2F", "%5C", "%3E", "%3C", "%7C", "%2B", "%60", "%28", "%29" };

        private string SearchQueryPattern = @"https://subscene.com/subtitles/title.aspx?q=@QUERY@&l=";
        private string EachFoundMovieTagPattern = @"<div class=""title"">\n<a href=""/subtitles/[^/<>"" ]*"">[^<>]*</a>\n</div>";
        private string MovieURLPattern = @"https://subscene.com/subtitles/[^/<>"" ]*";
        private string MovieRootURLPattern = @"https://subscene.com";
    }
} 