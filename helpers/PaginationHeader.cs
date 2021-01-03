namespace smartschool.helpers
{
    public class PaginationHeader
    {
        public PaginationHeader(int currentPages, int totalPages, int itemsPerPage, int totalItems)
        {
            this.CurrentPages = currentPages;
            this.TotalPages = totalPages;
            this.ItemsPerPage = itemsPerPage;
            this.TotalItems = totalItems;
        }

        public int CurrentPages { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
    }
}