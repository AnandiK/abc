using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using GetDetails.Models;

namespace GetDetails_in_ASP.NET_MVC.Controllers
{
    public class GetDetailsController : Controller
    {
        // GET: GetDetails
        public ActionResult Index1()
        {


            //String constring = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=iKloudProSMB; Integrated Security=true";
            //SqlConnection sqlcon = new SqlConnection(constring);
            //String pname = "GetDetails";
            //sqlcon.Open();
            //SqlCommand com = new SqlCommand(pname, sqlcon);
            //com.CommandType = CommandType.StoredProcedure;
            //SqlDataReader dr = com.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //return View(dt);
            List<CustomerVM> cs = new List<CustomerVM>();
            string constring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("GetDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CustomerVM csmodel = new CustomerVM();
                        csmodel.ID = reader["ID"].ToString();
                        csmodel.XMLSerialNo = reader["XMLSerialNo"].ToString();
                        csmodel.XMLPayorBankRoutNo = reader["XMLPayorBankRoutNo"].ToString();
                        csmodel.XMLSAN = reader["XMLSAN"].ToString();
                        csmodel.XMLTransCode = reader["XMLTransCode"].ToString();
                        csmodel.XMLAmount = reader["XMLAmount"].ToString();
                        csmodel.DbtAccNo = reader["DbtAccNo"].ToString();
                        csmodel.ReturnCode = reader["ReturnCode"].ToString();
                        cs.Add(csmodel);
                    }
                }
            }
            return View(cs);


        }

        [HttpPost]
        public ActionResult Index1(string cbutton,string ID)
        {

            if (cbutton == "send")
            {
                String constring = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=iKloudProSMB; Integrated Security=true";
                SqlConnection sqlcon = new SqlConnection(constring);
                String pname = "UpdateCHIStatus"; ;
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();
            }
           
        
            if (cbutton == "Unmark")
            {

                //var ID = cs.ID;
                String constring = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=iKloudProSMB; Integrated Security=true";
                String updatedata = "update IWFinalMainTransactions set CHIStatus = 0,ReturnCode =0 WHERE ID =" + ID;
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

            }
            return null;

        }
    }
}


    


