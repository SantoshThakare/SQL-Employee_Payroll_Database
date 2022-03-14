using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeOperation operation = new EmployeeOperation();

            //operation.GetAllEmployees();

            //bool res = operation.DeleteEmployee("Harshal");
            //Console.WriteLine(res);

            //bool result = operation.ShowEmployeeName("Santosh");
            //Console.WriteLine(result);

            

            Employee employee = new Employee();
            employee.Name = "Arjun";
            employee.StartDate = DateTime.Now;
            employee.gender = "Male";
            employee.phonenumber = "9655454878";
            employee.address = "Dhule";
            employee.department = "Quality Department";
            employee.BasicPay = 39000;
            employee.Deduction = 2000;
            employee.TaxablePay = 4000;
            employee.Tax = 620;
            employee.NetPay = 37000;
            Console.ReadLine();
            
        }
    }
}
