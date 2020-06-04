using System.Data;

namespace iMovie
{
    public partial class frmOfflineMovieList : frmMovieList
    {
        public frmOfflineMovieList(DataTable dtMovies) : base(dtMovies, "Offline Movie List")
        {
        }
    }
}
