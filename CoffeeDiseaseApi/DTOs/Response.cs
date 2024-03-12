namespace CoffeeDiseaseApi.DTOs
{
    public record Response
    {
        public List<Model> Models { get; init; } = null!;
    }
}
