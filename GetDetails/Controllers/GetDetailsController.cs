using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace GetDetails_in_ASP.NET_MVC.Controllers
{
    public class GetDetailsController : Controller
    {
        // GET: GetDetails
        public ActionResult Index()
        {


            String constring = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=iKloudProSMB; Integrated Security=true";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "GetDetails";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return View(dt);


        }

        [HttpPost]
        public ActionResult Index(string cbutton)
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

            return null;
        }

        [HttpPost]
        public ActionResult Unmark(int ID)
        {


                String constring = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=iKloudProSMB; Integrated Security=true";
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UpdateCHIStatusandReturnCode";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("ID", ID);
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
                return null;
            }

        }
    }


