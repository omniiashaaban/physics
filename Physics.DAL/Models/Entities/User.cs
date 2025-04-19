using Physics.DAL.Models.Entities;
using System.ComponentModel.DataAnnotations;

public class User 
{
    public int Id { get; set; } //

    public String UserType { get; set; }
    public string NationalId { get; set; } //
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } //

    [StringLength(20)]
    public string PhoneNumber   {get; set;} //

    public DateTime CreatedAt { get; set; } //

    public ICollection<Maintenance> Maintenances { get; set; }

    public ICollection<Reservation> Reservations { get; set; }

    public ICollection<AlertRecipient> AlertRecipients { get; set; }

}