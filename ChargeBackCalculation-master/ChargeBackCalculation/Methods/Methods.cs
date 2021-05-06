using ChargeBackCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChargeBackCalculation.Methods
{
    public class Methods
    {
        UserLoginDbContext db = new UserLoginDbContext();
        public void Save(UserLoginDbContext userContext)
        {

            userContext.SaveChanges();
        }
    }
}