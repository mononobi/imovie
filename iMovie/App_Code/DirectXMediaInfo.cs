using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.DirectX.AudioVideoPlayback;

namespace iMovie
{
    public class DirectXMediaInfo : IMediaInfo
    {
        private Video videoInfo = null;

        public DirectXMediaInfo()
        {
        }
        public bool OpenFile(string filePath)
        {
            try
            {
                this.videoInfo = new Video(filePath, false);

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
                    return this.videoInfo.DefaultSize;
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
                    return new TimeSpan(0, 0, (int)(this.videoInfo.Duration));
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
                    this.videoInfo.Dispose();
                    this.videoInfo = null;
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
