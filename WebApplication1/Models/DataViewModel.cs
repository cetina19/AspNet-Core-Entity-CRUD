namespace WebApplication1.Models
{
    public class DataViewModel
    {
        public int? Id { get; set; }
        //public string? RequestId { get; set; }
        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string? BookName { get; set; }
        //public string? RequestName { get; set; }
        //public bool ShowRequestName => !string.IsNullOrEmpty(RequestName);

        public float? Price { get; set; }
        //public string? RequestDate { get; set; }
        //public bool ShowRequestDate => !string.IsNullOrEmpty(RequestDate);
    }
}
