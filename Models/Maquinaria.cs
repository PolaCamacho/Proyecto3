namespace ACooperativa.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Maquinaria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El tipo de maquinaria es obligatorio.")]
        [DataType(DataType.Text)]
        public string Tipo { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "El costo por hora debe ser un valor positivo.")]
        [Display(Name = "Costo por Hora")]
        public decimal CostoPorHora { get; set; }

        [Required]
        [Display(Name = "Propietario")]
        public int AgricultorPropietarioId { get; set; }
    }

}
