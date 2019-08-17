using Epam.TreeLayerArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TreeLayerArchitecture.AbstractDAL
{
    public interface IStorableUser
    {
        bool AddUser(User user);
        bool Delete(Guid userId);
        User GetUser(Guid userId);
        ICollection<User> GetAllUsers();
    }
}
