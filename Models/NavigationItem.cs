namespace LocalHomepage.Models
{
    public record NavigationItem
    {
        public required string Header { get; init; }
        public required string Title { get; init; }
        public required string Url { get; init; }
        public required string Description { get; init; }
    }
}
