using System;
using System.Collections.Generic;
using System.Text;

namespace iMovie
{
    public class MediaInfoContainer
    {
        private static readonly IList<IMediaInfo> mediaInfoProviders = new List<IMediaInfo>();
        static MediaInfoContainer()
        {
            mediaInfoProviders.Clear();
            mediaInfoProviders.Add(new NRecoMediaInfo());
            mediaInfoProviders.Add(new DirectXMediaInfo());
        }

        public static IList<IMediaInfo> MediaInfoProviders
        {
            get
            {
                return mediaInfoProviders;
            }
        }
    }
}
