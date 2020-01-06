using System;
using System.Collections.Generic;
using System.Text;

namespace iMovie
{
    [Serializable]
    public class PathSource
    {
        private long pathID = 0;
        private string pathString = "";
        private static long nextID = 0;

        public PathSource(string pathString)
        {
            this.PathID = GetID();
            this.PathString = pathString;
        }

        protected long GetID()
        {
            try
            {
                PathSource.nextID++;
                return PathSource.nextID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long PathID
        {
            get
            {
                try
                {
                    return this.pathID;
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
                    this.pathID = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string PathString
        {
            get
            {
                try
                {
                    return this.pathString;
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
                    this.pathString = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public override string ToString()
        {
            return this.PathString;
        }
    }
}
