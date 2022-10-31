namespace WoWItems.API.Services
{
    public class PaginationMetadata
    {
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public PaginationMetadata(int totaItemCount, int pageSize, int currentPage)
        {
            TotalItemCount = totaItemCount;
            TotalPageCount = (int)Math.Ceiling(totaItemCount / (double)pageSize);
            PageSize = pageSize;
            CurrentPage = currentPage;
        }
    }
}
