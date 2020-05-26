
using System;
using System.Linq;
using Myo.Models;

namespace Myo.DAL
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly MyoContext context;
        public UserRepository(MyoContext context)
        {
            this.context = context;
        }
        
        public User GetUserByCredentials(string username, string password)
        {
            return context.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}