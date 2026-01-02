namespace Api4_Movies.DTO
{
    public record MovieRankingDto(
        int Id,
        string Title,
        int Year,
        decimal AvgScore,
        int Votes
        );
}
