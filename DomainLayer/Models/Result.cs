﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DomainLayer.Models
{
    public class Result : BaseEntity
    {
        public int Id
        {
            get;
            set;
        }
        public string ResultName
        {
            get;
            set;
        }
        
    }
}