using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string gender { get; set; }      
        public string phonenumber { get; set; }
        public string address { get; set; }      
        public string department { get; set; }
        public int BasicPay { get; set; }
        public double Deduction { get; set; }
        public double TaxablePay { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }

    }
}
