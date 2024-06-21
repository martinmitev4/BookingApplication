using BA.Domain.Domain;
using BA.Domain.Identity;
using BA.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<BookingApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<BookingApplicationUser>();
        }
        public IEnumerable<BookingApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public BookingApplicationUser Get(string id)
        {
            return entities
               .Include(z => z.Reservations)
               .Include("Reservations.BookReservations")
               .Include("Reservations.BookReservations.BookingList")
               .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(BookingApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(BookingApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(BookingApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

    }
}
