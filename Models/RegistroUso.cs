using System.ComponentModel.DataAnnotations;

public class RegistroUso
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Uso")]
    public DateTime FechaUso { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = "Observaciones")]
    public string Observaciones { get; set; }

    [Required]
    public int MaquinariaId { get; set; }

    [Required]
    public int AgricultorId { get; set; }
}




