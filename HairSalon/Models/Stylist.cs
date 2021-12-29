using System;
using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    public int StylistId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Client> Clients { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; }

    public Stylist()
    {
      this.Clients = new HashSet<Client>();
      this.Appointments = new HashSet<Appointment>();
    }

    public bool IsApptAvailable(DateTime beginDateTime, DateTime endDateTime)
    {
      foreach (Appointment appt in Appointments)
      {
        TimeSpan thisSpan = new TimeSpan(0, appt.Duration, 0);
        DateTime apptEnd = appt.DateTime + thisSpan;
        if (appt.DateTime <= endDateTime && apptEnd >= beginDateTime)
        {
          return false;
        }
      }
      return true;
    }
  }
}