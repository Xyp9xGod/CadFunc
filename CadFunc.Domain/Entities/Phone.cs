using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadFunc.Domain.Entities
{
    public class Phone : Entity
    {
        public string Number { get; private set; }
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
    }
}
