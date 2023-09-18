using Microsoft.EntityFrameworkCore;
namespace Tickets.DAL
{
    public class Contexto: DbContext
    {
        //No me estaba permitiendo hacer using Tickets.Models; y despues nombrar a la clase Ticket, tuve que hacerlo de la forma que se ve abajo
        public DbSet<Models.Tickets> Tickets { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) {}
    }
}
