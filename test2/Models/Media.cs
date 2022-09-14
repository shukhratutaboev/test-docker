using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test2.Models;

public class Media
{
    [Required]
    [DisplayName("Photo")]
    public IFormFile? Photo { get; set; }
}