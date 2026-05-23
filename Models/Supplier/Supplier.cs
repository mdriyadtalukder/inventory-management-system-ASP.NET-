using System.ComponentModel.DataAnnotations;

public class Supplier
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string ContactInfo { get; set; }

    public string Country { get; set; }
}
