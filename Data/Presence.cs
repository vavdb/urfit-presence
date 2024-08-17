using System.ComponentModel.DataAnnotations.Schema;
namespace urfit_presence.Data;

public class Presence
{
    [Key]
    public int Id { get; set; }
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public int TimeSlotId { get; set; }
    public TimeSlot TimeSlot { get; set; }
    public DateOnly Date { get; set; }

    [NotMapped]
    public string DateWithTimeSlotTime => Date.ToString("dddd dd MMM") + " " + TimeSlot.StartTime;
}