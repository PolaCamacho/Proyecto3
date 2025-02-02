using System.Linq; // Necesario para Any()
using ACooperativa.Data; // Asegúrate de que esta es la ubicación correcta de CooperativaContext

namespace ACooperativa.Models
{
    public static class PrecargaDatos
    {
        public static void Inicializar(CooperativaContext context)
        {
            // Validar si ya existen agricultores
            if (!context.Agricultores.Any())
            {
                context.Agricultores.AddRange(
                    new Agricultor { Nombre = "Juan Pérez", TamanoCampo = 50 },
                    new Agricultor { Nombre = "Ana Rodríguez", TamanoCampo = 30 }
                );
            }

            // Validar si ya existen maquinarias
            if (!context.Maquinarias.Any())
            {
                context.Maquinarias.AddRange(
                    new Maquinaria
                    {
                        Nombre = "Tractor A",
                        Tipo = "Tractor",
                        CostoPorHora = 100,
                        AgricultorPropietarioId = 1
                    },
                    new Maquinaria
                    {
                        Nombre = "Cosechadora B",
                        Tipo = "Cosechadora",
                        CostoPorHora = 150,
                        AgricultorPropietarioId = 2
                    }
                );
            }

            // Guardar los cambios en la base de datos
            context.SaveChanges();
        }
    }
}
