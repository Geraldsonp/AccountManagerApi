namespace ApplicationLayer.Domain;

public class Person
{
    public int PersonId { get; set; }

    public string Name { get; set; } = null!;

    public Gender Gender { get; set; }

    public int Age { get; set; }

    public string Identification { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;
}
