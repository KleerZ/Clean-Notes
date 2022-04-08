using System.ComponentModel.DataAnnotations;

namespace Notes.MVC.Models;

public class FolderViewModel
{
    [Required(ErrorMessage = "Введите название папки")]
    [MaxLength(30, ErrorMessage = "Максимальная длина названия папки - 50")]
    public string Name { get; set; }
    public Guid Id { get; set; }
}