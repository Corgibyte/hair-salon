using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HairSalon.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }

    public int StylistId { get; set; }

    public int ClientId { get; set; }

    [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]

    public DateTime? DateTime { get; set; }

    public int Duration { get; set; }

    public string Notes { get; set; }

    [Display(Name = "Total Bill")]
    public int TotalBill { get; set; }

    public virtual Stylist Stylist { get; set; }

    public virtual Client Client { get; set; }

    public Appointment()
    {
    }
  }
}