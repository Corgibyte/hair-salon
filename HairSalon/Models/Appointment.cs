using System;

namespace HairSalon.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public int StylistId { get; set; }
    public int ClientId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Notes { get; set; }
    public int Price { get; set; }
    public virtual Client Client { get; set; }
    public virtual Stylist Stylist { get; set; }
  }
}