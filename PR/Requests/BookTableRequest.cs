using PR.Validations;
using System.ComponentModel.DataAnnotations;

namespace PR.Requests;

public class BookTableRequest
{

    [Required(ErrorMessage = "Please enter your name.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Please enter your phone number.")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Please enter your email.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Please provide a date.")]
    [ValidDateTime]
    public DateTime? BookDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Please choose your table.")]
    public int? TableId { get; set; }
}
