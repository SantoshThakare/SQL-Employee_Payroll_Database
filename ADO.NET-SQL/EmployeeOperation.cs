using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayRoll
{
    public class EmployeeOperation
    {
        private SqlConnection con;
           
        private void connection()
        {
            string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Employee_Payroll_Database;Integrated Security=True";
            con = new SqlConnection(constr);

        }
        public void  GetAllEmployees()
        {
            connection();
            List<Employee> EmpList = new List<Employee>();


            SqlCommand com = new SqlCommand("GetEmployee", con);
            com.CommandType = CommandType.StoredProcedure;

            //SqlCommand com = new SqlCommand("select * from PayRollTable", con);
            //com.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
             
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new Employee
                    {

                       id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["Name"]),
                        gender = Convert.ToString(dr["gender"]),
                        StartDate = Convert.ToDateTime(dr["StartDate"]),
                        phonenumber = (dr["phonenumber"]).ToString(),
                        department = Convert.ToString(dr["department"]),
                        address = Convert.ToString(dr["address"]),
                        BasicPay = Convert.ToInt32(dr["BasicPay"]),
                        Deduction = Convert.ToInt32(dr["Deduction"]),
                        TaxablePay = Convert.ToInt32(dr["TaxablePay"]),
                        Tax = Convert.ToInt32(dr["Tax"]),
                        NetPay = Convert.ToInt32(dr["NetPay"]),
                    }
                    );
            }
            Display(EmpList); 

        }
        public bool InsertEmployee(Employee obj)
        {

            connection();
            SqlCommand com = new SqlCommand("InsertEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@StartDate", obj.StartDate);
            com.Parameters.AddWithValue("@Gender", obj.gender);
            com.Parameters.AddWithValue("@Phonenumber", obj.phonenumber);
            com.Parameters.AddWithValue("@Department", obj.department);
            com.Parameters.AddWithValue("@address", obj.address);
            com.Parameters.AddWithValue("@BasicPay", obj.BasicPay);
            com.Parameters.AddWithValue("@deduction", obj.Deduction);
            com.Parameters.AddWithValue("@TaxablePay", obj.TaxablePay);
            com.Parameters.AddWithValue("@Tax", obj.Tax);
            com.Parameters.AddWithValue("@Netpay", obj.NetPay);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

        public double Updatemeployee(Employee obj)
        {
            try
            {   
                connection();
                SqlCommand com = new SqlCommand("UpdateEmployee", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@name", obj.Name);
                com.Parameters.AddWithValue("@StartDate", obj.StartDate);
            com.Parameters.AddWithValue("@Gender", obj.gender);
            com.Parameters.AddWithValue("@Phonenumber", obj.phonenumber);
            com.Parameters.AddWithValue("@Department", obj.department);
            com.Parameters.AddWithValue("@address", obj.address);
            com.Parameters.AddWithValue("@BasicPay", obj.BasicPay);
            com.Parameters.AddWithValue("@deduction", obj.Deduction);
            com.Parameters.AddWithValue("@TaxablePay", obj.TaxablePay);
            com.Parameters.AddWithValue("@Tax", obj.Tax);
            com.Parameters.AddWithValue("@Netpay", obj.NetPay);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {

                    return obj.BasicPay;
                }
                else
                {
                    return 0.0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            finally
            {
                con.Close();
            }
        }

        public bool DeleteEmployee(string  name)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteEmByName", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", name);

            con.Open();
            var i = com.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public void Display(List<Employee> employees)
        {
            foreach (var data in employees)
            {
                Console.WriteLine(data.id + "\t" + data.Name + "\t" + data.gender+ "\t" + data.StartDate + "\t" +
                    data.phonenumber +"\t" + data.department +"\t " +data.address +"\t" + data.BasicPay +"\t" +
                    data.Deduction + "\t" + data.TaxablePay +"\t" + data.Tax+ "\t" + data.NetPay+ "\t");
            }
        }
        public bool ShowEmployeeName(string name)
        {

            connection();
            SqlCommand com = new SqlCommand("ShowEmpDataByName", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", name);

            con.Open();
            var i = com.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

    }

}
