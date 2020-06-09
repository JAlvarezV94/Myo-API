
using System;
using Myo.Models;

namespace Myo.DAL
{
    public interface IUserRepository : IDisposable
    {
        User GetUserById(int userId);
        User GetUserByCredentials(string username, string password);
        void Save();
    }
}