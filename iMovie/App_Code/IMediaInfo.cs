using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace iMovie
{
    public interface IMediaInfo
    {
        bool OpenFile(string filePath);
        Size GetResolution();
        TimeSpan GetDuration();
        void Dispose();
    }
}
