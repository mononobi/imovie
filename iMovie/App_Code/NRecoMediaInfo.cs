using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using NReco.VideoInfo;

namespace iMovie
{
    public class NRecoMediaInfo: IMediaInfo
    {
        private MediaInfo videoInfo = null;

        public NRecoMediaInfo()
        {
        }
        public bool OpenFile(string filePath)
        {
            try
            {
                var ffProbe = new FFProbe();
                this.videoInfo = ffProbe.GetMediaInfo(filePath);

                if(this.videoInfo != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Size GetResolution()
        {
            try
            {
                if (this.videoInfo != null)
                {
                    foreach (MediaInfo.StreamInfo info in this.videoInfo.Streams)
                    {
                        if (info.Height > 0 && info.Width > 0)
                        {
                            return new Size(info.Width, info.Height);
                        }
                    }
                }

                return new Size();
            }
            catch (Exception ex)
            {
                return new Size();
            }
        }
        public TimeSpan GetDuration()
        {
            try
            {
                if (this.videoInfo != null)
                {
                    return new TimeSpan(this.videoInfo.Duration.Hours,
                                        this.videoInfo.Duration.Minutes,
                                        this.videoInfo.Duration.Seconds);
                }

                return new TimeSpan();
            }
            catch (Exception ex)
            {
                return new TimeSpan();
            }
        }

        public void Dispose()
        {
            try
            {
                if (this.videoInfo != null)
                {
                    this.videoInfo = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
