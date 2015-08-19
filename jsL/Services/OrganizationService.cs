using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using jsL.Context;
using jsL.Models;

namespace jsL.Services
{
    public class OrganizationService : ServiceBase<Organization>
    {
        public OrganizationService(OpContext context) : base(context)
        {
        }
    }
}