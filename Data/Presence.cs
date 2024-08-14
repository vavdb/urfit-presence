using System.ComponentModel.DataAnnotations.Schema;

public class Presence
{
    [Key]
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int TimeSlotId { get; set; }
    public TimeSlot TimeSlot { get; set; }
    public DateOnly Date { get; set; }

    [NotMapped]
    public string DateWithTimeSlotTime => Date.ToString("dddd dd MMM") + " " + TimeSlot.StartTime;
}