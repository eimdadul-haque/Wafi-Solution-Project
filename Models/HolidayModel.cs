namespace Wafi_Solution_Project.Models
{
    public class HolidayModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Countries>? Countrys { get; set; }
        public DateTime Date { get; set; }
    }
}
