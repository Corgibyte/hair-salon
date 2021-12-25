using System;
using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    public int StylistId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }
    public virtual ICollection<Client> Clients { get; set; }

    public Stylist()
    {
      this.Appointments = new HashSet<Appointment>();
      this.Clients = new HashSet<Client>();
    }
  }
}