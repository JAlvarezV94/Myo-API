using System;
using System.Collections.Generic;

namespace Myo.DAL
{
    public interface IMyoRepository : IDisposable
    {
        void CreateMyo(Myo.Models.Myo myo);

        List<Myo.Models.Myo> ListMyosByUser(int idUser);

        Myo.Models.Myo GetMyoById(int idMyo);

        void UpdateMyo(Models.Myo myo);
        
        void DeleteMyo(Models.Myo myoToDelete);

        void Save();
    }
}