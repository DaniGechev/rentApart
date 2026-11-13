namespace RentApart.Data.Models;

public class Property
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public double Area { get; set; }
    public int Rooms { get; set; }
    public ListingType ListingType { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public int CityId { get; set; }
    public City City { get; set; } = null!;

    public int PropertyTypeId { get; set; }
    public PropertyType PropertyType { get; set; } = null!;

    public string OwnerId { get; set; } = string.Empty;
    public ApplicationUser Owner { get; set; } = null!;

    public ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();
    public ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
