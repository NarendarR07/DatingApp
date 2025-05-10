using System;
using System.ComponentModel.DataAnnotations;

namespace API.DataTransferObject;

public class RegisterDTO
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}
