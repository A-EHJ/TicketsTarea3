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

        public bool Modificar(Models.Tickets tickets)
        {
            var PrioridadADesechar = Contexto.Tickets.Find(tickets.TicketId);
            if (tickets != null)
            {
                Contexto.Entry(PrioridadADesechar).State = EntityState.Detached;
                Contexto.Entry(tickets).State = EntityState.Modified;
                return Contexto.SaveChanges() > 0;
            }
            return false;

        }

        public bool Guardar(Models.Tickets tickets)
        {
            if (Existe(tickets.TicketId))
            {
                // El ticket ya existe, intenta modificarlo
                return Modificar(tickets);
            }
            else
            {
                // El ticket no existe, intenta insertarlo
                return Insertar(tickets);
            }
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

        public Models.Tickets? Buscar(int id)
        {
            return Contexto.Tickets.Where(o => o.TicketId == id).AsNoTracking().SingleOrDefault(); ;
        }

        public List<Models.Tickets> GetList(Expression<Func<Models.Tickets, bool>> criterio)
        {
            return Contexto.Tickets.AsNoTracking().Where(criterio).ToList();
        }

    }
}
