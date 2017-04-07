using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Damibek.Models;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Configuration;


namespace Damibek.DAL
{
    public class Repository
    {
        NameValueCollection CustomSettings;
        readonly string connectionString;
        readonly XDocument dbXml;
        public Repository()
        {
            CustomSettings = ConfigurationManager.GetSection("CustomSettings") as NameValueCollection;
            connectionString = HttpContext.Current.Server.MapPath(CustomSettings["PathForXMLData"]);
            dbXml = XDocument.Load(connectionString);
        }

        public List<Project> GetAllProjects(string pagename = null)
        {

            if(pagename == null)
            return dbXml.Descendants("Project").Where(m => Convert.ToBoolean(m.Element("Activ").Value))
                          .Select( x => new Project{   Name = x.Element("Caption").Value,
                                                          Description = x.Element("Description").Value,
                                                          Id = x.Element("Id").Value
                                                       }
                           ).ToList();
            else
                return dbXml.Descendants("Project").Where(m => Convert.ToBoolean(m.Element("Activ").Value) 
                                                            && m.Element("PageName").Value == pagename)
                              .Select(x => new Project
                              {
                                  Name = x.Element("Caption").Value,
                                  Description = x.Element("Description").Value,
                                  Id = x.Element("Id").Value
                              }
                               ).ToList();
        }

        public Project GetProjectById(string id)
        {
            return dbXml.Descendants("Project").Where(m => m.Element("Id").Value == id)
                              .Select(x => new Project
                              {
                                  Name = x.Element("Caption").Value,
                                  Description = x.Element("Description").Value,
                                  Id = x.Element("Id").Value
                              }
                               ).FirstOrDefault();

        }
    }
}