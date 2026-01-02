namespace Api4_Movies.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Score { get; set; }
    }
}
