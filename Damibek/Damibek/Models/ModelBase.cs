using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Damibek.DAL;

namespace Damibek.Models
{
    public abstract class ModelBase
    {
        public Repository repository = new Repository();
        public ModelBase()
        {
            this.Projects = repository.GetAllProjects();
        }
        public ModelBase(string pagename)
        {
            this.Projects = repository.GetAllProjects(pagename);
        }
        public List<Project> Projects { get; set; } 
    }
}