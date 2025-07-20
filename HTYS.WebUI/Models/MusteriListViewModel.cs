namespace HTYS.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }

    public class MusteriListViewModel
    {
        public List<HTYS.Entities.Musteri> Musteriler { get; set; } = new();
        public PagingInfo PagingInfo { get; set; } = new();
        public string? AramaTerimi { get; set; }
    }
}
