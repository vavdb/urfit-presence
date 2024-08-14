public class Person
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Presence> Presences { get; set; }
    
    public override string ToString()
    {
        return Name;
    }
}