using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test1.Models;

public class Media
{
    [Required]
    [DisplayName("Photo")]
    public IFormFile? Photo { get; set; }
}