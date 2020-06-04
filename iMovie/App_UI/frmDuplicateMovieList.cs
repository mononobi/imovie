using System.Data;

namespace iMovie
{
    public partial class frmDuplicateMovieList : frmMovieList
    {
        public frmDuplicateMovieList(DataTable dtMovies) : base(dtMovies, "Duplicate Movie List")
        {
        }
    }
}
