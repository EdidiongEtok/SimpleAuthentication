using SimpleAuthenticationDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthenticationDomain
{
    public class Movie:AuditableEntity 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}
