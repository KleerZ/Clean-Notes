using System.ComponentModel.DataAnnotations;

namespace Notes.Identity.Models.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "Обязательное поле")]
    [MaxLength(20, ErrorMessage = "Превышена максимальная размерность поля (20)")]
    [MinLength(1, ErrorMessage = "Минимальная размерность поля - 1")]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "Обязательное поле")]
    [DataType(DataType.Password)]
    [MaxLength(8, ErrorMessage = "Превышена максимальная размерность поля (8)")]
    [MinLength(8, ErrorMessage = "Минимальная размерность поля - 8")]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
}