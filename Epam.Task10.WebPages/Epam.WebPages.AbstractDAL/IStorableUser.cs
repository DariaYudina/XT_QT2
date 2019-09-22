using Epam.WebPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WebPages.AbstractDAL
{
    public interface IStorableUser
    {
        bool AddUser(User user);
        bool AddAwards(Guid userId, List<Award> awards);
        bool Delete(Guid userId);
        bool DeleteAward(Guid userId, Guid awardid);
        User GetUser(Guid userId);
        void DeleteUsersAward(Guid awardId);
        IEnumerable<User> GetAllUsers();
    }
}
