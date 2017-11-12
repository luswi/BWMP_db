using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWMP_db.classes
{
    class vesselClass
    {
        //Data carrier
        public int MainId
        {
            get;
            set;
        }
        public string VesselId
        {
            get;
            set;
        }
        public string VesselName
        {
            get;
            set;

        }
        public string VesselStatus
        {
            get;
            set;

        }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["BWMP_db.Properties.Settings.databaseConnectionString"].ConnectionString;


        //Selecting data from database
        public DataTable Select()
        {
            //1. database connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //2. Wrtiting SQL Query
                string sql = "SELECT * FROM data";
                // creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                // creating sql DataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        // Insering data into database
        public bool Insert(vesselClass v)
        {
            // creating a default return type and setting its value to false
            bool isSuccess = false;

            //1. database connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //2 create sql query to insert SQL data
                string sql = "INSERT INTO data(VesselId, VesselName, VesselStatus) VALUES (@VesselId, @VesselName, @VesselStatus)";
                // creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                // creating parameters to add data
                cmd.Parameters.AddWithValue("@VesselId", v.VesselId);
                cmd.Parameters.AddWithValue("@VesselName", v.VesselName);
                cmd.Parameters.AddWithValue("@VesselStatus", v.VesselStatus);

                // open connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the query runs succesfully then the value of rows will be greater than zero, else value will be zero
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        // update method here
        public bool Update(vesselClass v)
        {
            // create default return type and sets its default values to false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL to update our data
                string sql = "UPDATE date SET VesselId=@VesselId, VesselName=@VesselName, VesselStatus=@VesselStatus";
                //Creating SQL command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //create parameters to add data
                cmd.Parameters.AddWithValue("@VesselId", v.VesselId);
                cmd.Parameters.AddWithValue("@VesselName", v.VesselName);
                cmd.Parameters.AddWithValue("@VesselStatus", v.VesselStatus);
                //open database connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if the query runs sucesfully then value of rows will be greater than zero, alse value will be zero.
                if (rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        // delete from our databaseee


    }
}
