using System.ComponentModel.DataAnnotations;

public class Agricultor
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El tamaño del campo es obligatorio.")]
    [Range(1, 1000, ErrorMessage = "El tamaño del campo debe estar entre 1 y 1000 hectáreas.")]
    [DataType(DataType.Text)]
    [Display(Name = "Tamaño del Campo (ha)")]
    public int TamanoCampo { get; set; }
}
