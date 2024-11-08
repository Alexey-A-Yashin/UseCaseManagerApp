using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users", Schema = "public")]
public class UserUCM
{
    [Key]
    public int id { get; set; } = 0;

    [Required(ErrorMessage = "Введите имя")]
    public string name { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Введите возраст")]
    public int age { get; set; } = 0;
}