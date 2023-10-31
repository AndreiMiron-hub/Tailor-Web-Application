namespace TailorWebApp.Utils.HelperClasses
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Offset = (pageNumber - 1) * pageSize;
        }

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 50;
            Offset = 0;
        }
    }
}