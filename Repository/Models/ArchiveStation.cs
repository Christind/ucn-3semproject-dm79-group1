namespace Repository.Models
{
    public class ArchiveStation
    {
        public int ID { get; set; }
        public int ArchiveId { get; set; }
        public decimal StationLat { get; set; }
        public decimal StationLong { get; set; }
        public virtual Archive Archive { get; set; }
    }
}