﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tables
{
   public class LoyaltyStoreGroup : Entity
    {
        public string Name { get; set; }
    }
}
