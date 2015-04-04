using GuessData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication.Models
{
    public class GuessModel 
    {
        public People Person { get; set; }
        public bool Decision { get; set; }
    }
}
