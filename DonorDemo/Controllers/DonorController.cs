using DonorDemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DonorDemo.Controllers
{
    public class DonorController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select DonorId, DonorName, DonorMobile, DateOfJoining from dbo.DonorInfo";

            DataTable table = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DonorDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }



        public HttpResponseMessage Get(string dateOfJoining)
        {
            string query = @"
                select DonorId, DonorName, DonorMobile, DateOfJoining from dbo.DonorInfo 
                where DateOfJoining='" + dateOfJoining + "'";

           
            Console.WriteLine(query);

            DataTable table = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DonorDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(DonorInfo don )
        {
            try
            {
                /* string query = @" 
                     insert into dbo.DonorInfo values
                     (
                     '" + don.DonorName + @"'

                     '" + don.DonorMobile + @"'
                     ,
                     '" + don.DateOfJoining + @"'
                     ,
                     )
                     ";*/
                string query = @" insert into dbo.DonorInfo(don.DonorName,don.DonorMobile,don.DateOfJoining) 
                                values('" + don.DonorName + @"','" + don.DonorMobile + @"' , '" + don.DateOfJoining + @"')";
                DataTable table = new DataTable();

                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DonorDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Adding Successfully";
            }
            catch (Exception)
            {
                return "Faild ";
            }


            /*public HttpResponseMessage Delete(int DonorId)
            {
                string query = @"
                select DonorId, DonorName, DonorMobile, DateOfJoining from dbo.DonorInfo 
                where DonorId=" + DonorId + @"";

                DataTable table = new DataTable();

                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DonorDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return Request.CreateResponse(HttpStatusCode.OK, table);
            }*/


        }
    }
}
