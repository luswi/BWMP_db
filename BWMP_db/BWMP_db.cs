using BWMP_db.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BWMP_db
{
    public partial class BWMP_db : Form
    {
        public BWMP_db()
        {
            InitializeComponent();
        }
        vesselClass v = new vesselClass();
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // get values from input fields
            v.VesselId = textboxVesselId.Text;
            v.VesselName = textboxVesselName.Text;
            v.VesselStatus = comboboxVesselStatus.Text;

            // inserting data into database
            bool success = v.Insert(v);
            if(success==true)
            {
                //Succesfully inserted
                MessageBox.Show("New vessel succesfully inserted");
                //Clear method
                Clear();
            }
            else
            {
                //Failed to add
                MessageBox.Show("Failed to add.");
            }
            //Load data into data grid view after add
            DataTable dt = v.Select();
            dataGridView1.DataSource = dt;



        }




        private void BWMP_db_Load(object sender, EventArgs e)
        {
            //Load data into data grid after app start
            DataTable dt = v.Select();
            dataGridView1.DataSource = dt;
            //Hide column
            dataGridView1.Columns["MainId"].Visible=false;
        }
        //clear method
        public void Clear()
        {
            textboxVesselId.Text = "";
            textboxVesselName.Text = "";
            comboboxVesselStatus.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get data from data grid and load it to the textboxes.
            int rowIndex = e.RowIndex;
            textboxMainId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textboxVesselId.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textboxVesselName.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            //Clear Data.
            Clear();
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // get data from texboxes
            //we need to convert from string to int using Parse
            v.MainId = int.Parse(textboxMainId.Text);
            v.VesselId = textboxVesselId.Text;
            v.VesselName = textboxVesselName.Text;
            v.VesselStatus = comboboxVesselStatus.Text;
                        
            //update data in database
            bool success = v.Update(v);
            if (success == true)
            {
                //updated successfully
                MessageBox.Show("Data updated");
                //Load data on data grid
                DataTable dt = v.Select();
                dataGridView1.DataSource = dt;
                Clear();
            }
            else
            {
                //fail
                MessageBox.Show("Update failed");
            }


        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //delete project
            //Get MainId
            v.MainId = Convert.ToInt32(textboxMainId.Text);
            bool isSuccess = v.Delete(v);
            if (isSuccess == true)
            {
                //deleted
                MessageBox.Show("Data deleted");
                //Refresh data
                DataTable dt = v.Select();
                dataGridView1.DataSource = dt;
                Clear();

            }
            else
            {
                //Failed
                MessageBox.Show("Something goes wrong");
            }
        }



        //Search box
        static string myconnstrng = ConfigurationManager.ConnectionStrings["BWMP_db.Properties.Settings.databaseConnectionString"].ConnectionString;
        
        private void textboxSearch_TextChanged(object sender, EventArgs e)
        {
            //get value from textbox
            string keyword = textboxSearch.Text;

            SqlConnection conn = new SqlConnection(myconnstrng);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM data WHERE VesselId LIKE '%"+keyword+"%' OR VesselName LIKE '%"+keyword+"%'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
