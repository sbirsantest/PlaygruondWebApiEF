using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class Organisation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Organisation> Organisations { get; set; }
    }
}
