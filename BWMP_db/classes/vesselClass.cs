using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BWMP_db.classes
{
    //==============================================================//
    // vesselClass is responsible for project module core functions //
    //==============================================================//

    class VesselClass
    {
        // Data carriers.
        public int MainId { get; set; }
        public string VesselId { get; set; }
        public string VesselName { get; set; }
        public string VesselStatus { get; set; }
        public string VesselLcs { get; set; }
        public string VesselMethodSeq { get; set; }
        public string VesselMethodFt { get; set; }
        public string VesselMethodDil { get; set; }
        public string SfaCreated { get; set; }
        public string SfaSent { get; set; }
        public string NOrder { get; set; }
        public string SfaRec { get; set; }
        public string AppStage { get; set; }
        public string Certificate { get; set; }
        public string SharePoint { get; set; }
        public double Hmax { get; set; }

        public double Hadd { get; set; }
        public double Hused { get; set; }

        public string Notes { get; set; }
        public string PoChecked { get; set; }
        public string NOrderClosed { get; set; }


        // Connection string to SQL Local database.
        static string myconnstrng = ConfigurationManager.ConnectionStrings["BWMP_db.Properties.Settings.databaseConnectionString"].ConnectionString;

        //====================================//
        // Selecting data from Local database //
        //====================================//

        public DataTable Select()
        {
            // Database connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                // SQL Query.
                string sql = "SELECT * FROM data";
                // Creating cmd (combine sql and conn).
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Creating sql DataAdapter using cmd.
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                // Open connection.
                conn.Open();
                sqlAdapter.Fill(dt);
            }
            catch(Exception ex) { }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //=============================//
        // Insering data into database //
        //=============================//

        public bool Insert(VesselClass v)
        {
            // Creating a default return type and setting value to false.
            bool isSuccess = false;

            // Database connection.
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                // SQL Query.
                string sql = "INSERT INTO data(VesselId, VesselName, VesselStatus, VesselLcs, VesselMethodSeq, VesselMethodFt, VesselMethodDil, SfaCreated, SfaSent, NOrder, SfaRec, AppStage, Certificate, SharePoint, Hmax, Hadd, Hused, Notes, PoChecked, NOrderClosed) VALUES (@VesselId, @VesselName, @VesselStatus, @VesselLcs, @VesselMethodSeq, @VesselMethodFt, @VesselMethodDil, @SfaCreated, @SfaSent, @NOrder, @SfaRec, @AppStage, @Certificate, @SharePoint, @Hmax, @Hadd, @Hused, @Notes, @PoChecked, @NOrderClosed)";
                //string sql = "INSERT INTO data(VesselId, VesselName, VesselStatus, VesselLcs) VALUES (@VesselId, @VesselName, @VesselStatus, @VesselLcs)";
                // Creating cmd (combine sql and conn).
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Creating parameters to add data.
                cmd.Parameters.AddWithValue("@VesselId", v.VesselId);
                cmd.Parameters.AddWithValue("@VesselName", v.VesselName);
                cmd.Parameters.AddWithValue("@VesselStatus", v.VesselStatus);
                cmd.Parameters.AddWithValue("@VesselLcs", v.VesselLcs);
                cmd.Parameters.AddWithValue("@VesselMethodSeq", v.VesselMethodSeq);
                cmd.Parameters.AddWithValue("@VesselMethodFt", v.VesselMethodFt);
                cmd.Parameters.AddWithValue("@VesselMethodDil", v.VesselMethodDil);
                cmd.Parameters.AddWithValue("@SfaCreated", v.SfaCreated);
                cmd.Parameters.AddWithValue("@SfaSent", v.SfaSent);
                cmd.Parameters.AddWithValue("@NOrder", v.NOrder);
                cmd.Parameters.AddWithValue("@SfaRec", v.SfaRec);
                cmd.Parameters.AddWithValue("@AppStage", v.AppStage);
                cmd.Parameters.AddWithValue("@Certificate", v.Certificate);
                cmd.Parameters.AddWithValue("@SharePoint", v.SharePoint);
                cmd.Parameters.AddWithValue("@Hmax", v.Hmax);
                cmd.Parameters.AddWithValue("@Hadd", v.Hadd);
                cmd.Parameters.AddWithValue("@Hused", v.Hused);
                cmd.Parameters.AddWithValue("@Notes", v.Notes);
                cmd.Parameters.AddWithValue("@PoChecked", v.PoChecked);
                cmd.Parameters.AddWithValue("@NOrderClosed", v.NOrderClosed);
                // Open connection.
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // If the SQL query runs succesfully then the value of rows will be greater than zero, else value will be zero.
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //====================//
        // Update/edit method //
        //====================//

        public bool Update(VesselClass v)
        {
            // Creating a default return type and setting value to false.
            bool isSuccess = false;

            // Database connection.
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                // SQL Query.
                string sql = "UPDATE data SET VesselId=@VesselId, VesselName=@VesselName, VesselStatus=@VesselStatus WHERE MainId=@MainId";
                // Creating SQL command.
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Create parameters to add data.
                cmd.Parameters.AddWithValue("@VesselId", v.VesselId);
                cmd.Parameters.AddWithValue("@VesselName", v.VesselName);
                cmd.Parameters.AddWithValue("@VesselStatus", v.VesselStatus);
                cmd.Parameters.AddWithValue("@MainId", v.MainId);
                // Open database connection.
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // If the query runs sucesfully then value of rows will be greater than zero, alse value will be zero.
                if (rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //===============================//
        // Delete data from our database //
        //===============================//

        public bool Delete(VesselClass v)
        {
            // Create default return value and set it to false.
            bool isSuccess = false;

            // Create sql connection.
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                // SQL to dalete data.
                string sql = "DELETE FROM data WHERE MainId=@MainId";
                // Create SQL command.
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Create parameters to delete.
                cmd.Parameters.AddWithValue("@MainId", v.MainId);
                // Open database connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        
    }
}
