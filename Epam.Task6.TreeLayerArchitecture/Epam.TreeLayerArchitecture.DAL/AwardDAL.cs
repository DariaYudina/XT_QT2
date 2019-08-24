using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Epam.TreeLayerArchitecture.DAL
{
    public class AwardDAL : IStorableAward
    {
        private const string FileNameConst = @"awards.xml";
        private string fileName;
        private Dictionary<Guid, Award> awards;
        private XElement awardsXml;
        public AwardDAL()
        {
            //awards = new Dictionary<Guid, Award>();
            fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileNameConst);
            awardsXml = XElement.Load(this.fileName);
            awards = this.ReadFromXml();
        }
        #region CRUD cache logic
        public bool AddAward(Award award)
        {
            awards.Add(award.AwardId, award);

            awards.Add(award.AwardId, award);
            XElement addElement = CreateElement(award);
            awardsXml.Add(addElement);
            awardsXml.Save(fileName);
            return true;
        }

        public bool DeleteAward(Guid awardId)
        {
            if (awards.ContainsKey(awardId))
            {
                awards.Remove(awardId);

                awards.Remove(awardId);
                XElement element = FindElementByAwardId(awardId);
                element.Remove();
                awardsXml.Save(fileName);

                return true;
            }
            else
            {
                return false;
            }
        }

        public  IEnumerable<Award> GetAllAwards()
        {
            return awards.Values.ToList();
        }

        public Award GetAward(Guid awardId)
        {
            bool isSuccess = this.awards.TryGetValue(awardId, out Award award);
            return isSuccess ? award : null;
        }
        #endregion

        #region CRUD XML logic

        private Dictionary<Guid, Award> ReadFromXml()
        {
            IEnumerable<Award> awards =
                from award in this.awardsXml.Elements("Award")
                select new Award()
                {
                    AwardId = new Guid(award.Attribute("AwardId").Value),
                    Title = award.Element("Title").Value,
                };

            return awards.ToDictionary(award => award.AwardId);
        }

        private XElement CreateElement(Award award)
        {
            return
                new XElement(
                    "Award",
                    new XAttribute("AwardId", award.AwardId),
                    new XElement("Title", award.Title));
        }

        private XElement FindElementByAwardId(Guid awardId)
        {
            XElement element =
                (from el in this.awardsXml.Elements("Award")
                 where el.Attribute("AwardId").Value.ToString() == awardId.ToString()
                 select el)
                .FirstOrDefault();

            return element;
        }
        #endregion
    }
}
