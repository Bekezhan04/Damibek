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
        public Repository()
        {
            CustomSettings = ConfigurationManager.GetSection("CustomSettings") as NameValueCollection;
        }

        public List<RowProject> GetProject()
        {    
            string path = HttpContext.Current.Server.MapPath(CustomSettings["PathForXMLData"]);
            XDocument Doc = XDocument.Load(path);
            var list = Doc.Descendants("Project").Where(m => Convert.ToBoolean(m.Element("Activ").Value))
                          .Select( x => new RowProject{
                              Name = x.Element("Caption").Value,
                              Description = x.Element("Description").Value
                                                       }
                           ).ToList();
            return list;
        }
    }
}