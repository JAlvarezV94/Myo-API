using System;
using Myo.Models;

namespace Myo.DAL
{
    public class MyoRepository : IMyoRepository, IDisposable
    {

        private readonly MyoContext context;
        public MyoRepository(MyoContext context)
        {
            this.context = context;
        }

        public void CreateMyo(Models.Myo myo)
        {
            context.Myos.Add(myo);
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