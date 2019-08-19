using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.Entities;
using System.Xml.Linq;
using System.IO;

namespace Epam.TreeLayerArchitecture.DAL
{
    public class UserDAL : IStorableUser
    {
        private Dictionary<Guid, User> users;
        private XElement usersXml;
        private string fileName;               
        string FileNameConst = @"users.xml";

        public UserDAL()
        {
            try
            {
                users = new Dictionary<Guid, User>();
                this.fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileNameConst);
                this.usersXml = XElement.Load(this.fileName);
                this.users = this.ReadFromXml();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        #region CRUD cache logic
        public bool Delete(Guid userId)
        {
            if (users.ContainsKey(userId))
            {
                users.Remove(userId);
                XElement userElement = this.ReadUserElement(userId);
                userElement.Remove();
                this.usersXml.Save(this.fileName);
                return true;
            }
            else
            {
                return false;
            }

        }  
        public bool AddUser(User user)
        {
            if (users.Any(u => u.Value.UserId == user.UserId))
            {
                return false;
            }

            users.Add(user.UserId, user);

            XElement addElement = CreateElement(user);
            usersXml.Add(addElement);
            usersXml.Save(fileName);

            return true;
        }
        public bool AddAwards(Guid userId, List<Award> awards)
        {
            User user = GetUser(userId);
            user.Awards.AddRange(awards);

            XElement userElement = ReadUserElement(userId);
            XElement userAwardsElement = userElement.Element("Awards");
            XElement awardsElement = CreateAwardElement(awards);
            userAwardsElement.Add(awardsElement);
            usersXml.Save(fileName);

            return true;
        }
        public ICollection<User> GetAllUsers()
        {
            return users.Values.ToList();
        }
        public User GetUser(Guid userId)
        {
            bool isSuccess = users.TryGetValue(userId, out User user);
            return isSuccess ? user : null;
        }
        #endregion
        #region CRUD XML logic
        private Dictionary<Guid, User> ReadFromXml()
        {
            IEnumerable<User> users =
                from user in usersXml.Elements("User")
                select new
                {
                    UserId = new Guid(user.Attribute("UserId").Value),
                    Name = user.Element("Name").Value,
                    BirthDate = DateTime.Parse(user.Element("BirthDate").Value),
                    Awards = ReadAwards(user),
                }
                into temp
                select new User(temp.Name, temp.BirthDate, temp.Awards)
                {
                    UserId = temp.UserId,
                };

            return users.ToDictionary(user => user.UserId);
        }
        private List<Award> ReadAwards(XElement user)
        {          
            AwardDAL awardDao = new AwardDAL();
            XElement awards = user.Element("Awards");
            IEnumerable<Award> enumAwards =
                from award in awards.Elements("Award")
                select award.Attribute("AwardId").Value
                into ids
                select new Award
                {
                    AwardId = new Guid(ids),
                    Title = awardDao.GetAward(new Guid(ids)).Title
                };
            return enumAwards.ToList();
        }
        private XElement CreateElement(User user)
        {
            XElement awards = CreateAwardElement(user.Awards);

            return
                new XElement(
                    "User",
                    new XAttribute("UserId", user.UserId),
                    new XElement("Name", user.Name),
                    new XElement("BirthDate", user.BirthDate.Date.ToShortDateString()),
                    new XElement("Awards", awards));
        }

        private XElement CreateAwardElement(List<Award> awards)
        {
            XElement awardsElement = null;
            foreach (var award in awards)
            {
                awardsElement = new XElement(
                    "Award",
                    new XAttribute("AwardId", award.AwardId));
            }

            return awardsElement;
        }
        private XElement ReadUserElement(Guid userId)
        {
            XElement element =
                (from el in usersXml.Elements("User")
                 where el.Attribute("UserId").Value.ToString() == userId.ToString()
                 select el)
                .FirstOrDefault();

            return element;
        }
        #endregion
    }
}
