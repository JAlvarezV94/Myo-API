
using System;
using System.Collections.Generic;
using System.Linq;
using Myo.Models;

namespace Myo.DAL
{
    public class CheckpointRepository : ICheckpointRepository, IDisposable
    {
        private readonly MyoContext context;
        public CheckpointRepository(MyoContext context)
        {
            this.context = context;
        }

        public List<Checkpoint> ListCheckpointByMyo(int idMyo)
        {
            return context.Checkpoints.Where(c => c.Myo.IdMyo == idMyo).ToList();
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