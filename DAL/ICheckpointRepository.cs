
using System;
using System.Collections.Generic;
using Myo.Models;

namespace Myo.DAL
{
    public interface ICheckpointRepository : IDisposable
    {
        List<Checkpoint> ListCheckpointByMyo(int idMyo);

        void Save();
    }
}