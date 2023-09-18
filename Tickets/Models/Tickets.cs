using System;
using System.ComponentModel.DataAnnotations;

namespace Tickets.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Es necesario completar el campo Fecha")]
        public DateTime Fecha { get; set; } // Fecha del ticket

        [Required(ErrorMessage = "Es necesario completar el campo ClienteId")]
        [Range(1, int.MaxValue, ErrorMessage = "El ClienteId debe ser mayor que cero")]
        public int ClienteId { get; set; } // ID del cliente

        [Required(ErrorMessage = "Es necesario completar el campo SistemaId")]
        [Range(1, int.MaxValue, ErrorMessage = "El SistemaId debe ser mayor que cero")]
        public int SistemaId { get; set; } // ID del sistema

        [Required(ErrorMessage = "Es necesario completar el campo PrioridadId")]
        [Range(1, int.MaxValue, ErrorMessage = "El PrioridadId debe ser mayor que cero")]
        public int PrioridadId { get; set; } // ID de prioridad

        [Required(ErrorMessage = "Es necesario completar el campo SolicitadoPor")]
        public string SolicitadoPor { get; set; } // Persona que solicita

        [Required(ErrorMessage = "Es necesario completar el campo Asunto")]
        public string Asunto { get; set; } // Asunto del ticket

        [Required(ErrorMessage = "Es necesario completar el campo Descripcion")]
        public string Descripcion { get; set; } // Descripción del ticket
    }
}
