﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class Membership
    {
        public Guid OrganisationId { get; set; }
        public Guid UserId { get; set; }

        public Organisation Organisation { get; set; }
        public User User { get; set; }
    }
}
