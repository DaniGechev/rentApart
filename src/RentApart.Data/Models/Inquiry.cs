namespace RentApart.Data.Models;

public class Inquiry
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public int PropertyId { get; set; }
    public Property Property { get; set; } = null!;

    public string SenderId { get; set; } = string.Empty;
    public ApplicationUser Sender { get; set; } = null!;
}
