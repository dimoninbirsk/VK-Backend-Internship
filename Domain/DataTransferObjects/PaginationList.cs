namespace VKBackendInternship.Domain.DataTransferObjects
{
    public class PaginationList<T>
    {
        public PaginationList() { }
        public PaginationList(int count, int pageIndex, List<T> list) 
        {
            this.Count = count;
            this.PageIndex = pageIndex;
            this.List = list;
        }
        public List<T> List { get; set; }
        public int Count { get; set; }
        public int PageIndex { get; set; }
    }
}
