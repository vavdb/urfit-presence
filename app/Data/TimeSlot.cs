namespace urfit_presence.Data;

public class TimeSlot
{
    [Key]
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public ICollection<Presence> Presences { get; set; }
    
    public override string ToString()
    {
        return DayOfWeek.ToString() + " " + StartTime;
    }
    
}