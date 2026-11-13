namespace RentApart.Data.Models;

public class Favorite
{
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;

    public int PropertyId { get; set; }
    public Property Property { get; set; } = null!;
}
