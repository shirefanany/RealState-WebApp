using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-P202DNN;Initial Catalog=Elmorshdy;Integrated Security=True");
            string cmdText = "getunitdata";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            DataTable model = new DataTable();
            model.Load((IDataReader)reader);
            return (ActionResult)this.View((object)model);
        }

        public ActionResult Property(int id)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-P202DNN;Initial Catalog=Elmorshdy;Integrated Security=True");
            string cmdText = "Unit_id";
            connection.Open();
            DataTable dataTable = new DataTable();
            SqlCommand selectCommand = new SqlCommand(cmdText, connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@PID", (object)id);
            new SqlDataAdapter(selectCommand).Fill(dataTable);
            return (ActionResult)this.View((object)dataTable);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}