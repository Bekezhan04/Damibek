using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Damibek.Models
{
    public class Solution : ModelBase
    {
        public Solution(string id)
        {
            this.Project = repository.GetProjectById(id);
        }
        public Project Project { get; set; }
    }
}