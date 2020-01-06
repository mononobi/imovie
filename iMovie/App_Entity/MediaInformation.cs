using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace iMovie
{
    public class MediaInformation
    {
        public MediaInformation()
        {
            this.Duration = new TimeSpan();
            this.Resolution = new Size();
        }

        public TimeSpan Duration { get; set; }
        public Size Resolution { get; set; }
    }
}
