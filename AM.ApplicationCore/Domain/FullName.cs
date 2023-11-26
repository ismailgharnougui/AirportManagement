using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{

  //  [Owned] // 1 ere methde de configuartion du type complexe
    public class FullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
