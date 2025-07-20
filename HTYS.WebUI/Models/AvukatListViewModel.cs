namespace HTYS.WebUI.Models
{
    public class AvukatListViewModel
    {
        public List<HTYS.Entities.Avukat> Avukatlar { get; set; } = new();
        public int ToplamMusteri { get; set; }
        public int ToplamIcra { get; set; }
        public int ToplamIhtar { get; set; }
    }
}