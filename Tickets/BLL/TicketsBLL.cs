using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
 
using Tickets.DAL;
namespace Tickets.BLL
{
    public class TicketsBLL
    {
        public readonly Contexto Contexto;

        public TicketsBLL(Contexto contexto)
        {
            Contexto = contexto;
        }

         public bool Existe(int id)
        {
            return Contexto.Tickets.Any(o => o.TicketId == id);
        }
        private bool Insertar(Models.Tickets Tickets)
        {
            Contexto.Tickets.Add(Tickets);
            return Contexto.SaveChanges() > 0;
        }
        private bool Modificar(Models.Tickets cliente)
        {
            var PrioridadADesechar = Contexto.Tickets.Find(cliente.TicketId);
            if (cliente != null)
            {
                Contexto.Entry(PrioridadADesechar).State = EntityState.Detached;
                Contexto.Entry(cliente).State = EntityState.Modified;
                return Contexto.SaveChanges() > 0;
            }
            return false;

        }

        public bool Guardar(Models.Tickets tickets)
        {
            if (Contexto.Tickets.Any(p => p.TicketId != tickets.TicketId))
            {
                return false;
            }
            if (!Existe(tickets.TicketId))
                return Insertar(tickets);
            else
                return Modificar(tickets);
        }

        public bool Eliminar(Models.Tickets tickets)
        {


            if (tickets != null)
            {
                Contexto.Entry(tickets).State = EntityState.Deleted;
                return Contexto.SaveChanges() > 0;
            }
            return false;

        }

  

        public List<Models.Tickets> GetList(Expression<Func<Models.Tickets, bool>> criterio)
        {
            return Contexto.Tickets.AsNoTracking().Where(criterio).ToList();
        }

    }
}
