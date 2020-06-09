using System;

namespace Myo.DAL
{
    public interface IMyoRepository : IDisposable
    {
        void CreateMyo(Myo.Models.Myo myo);

        void Save();
    }
}