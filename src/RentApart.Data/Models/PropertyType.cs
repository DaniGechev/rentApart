namespace RentApart.Data.Models;

public class PropertyType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Property> Properties { get; set; } = new List<Property>();
}
