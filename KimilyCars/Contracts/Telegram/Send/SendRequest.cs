namespace KimilyCars.Contracts.Telegram;

public record SendRequest
{
    public string Name { get; set; }
    public string? Phone { get; set; }
    public IEnumerable<string>? Messengers { get; set; }
    public string? Email { get; set; }
    public string Description { get; set; }
}