using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Models.Administration
{
    public class User
    {
        public const int NameMaxLength = 128;

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public ICollection<Organisation> Organisations { get; set; }
    }
}
