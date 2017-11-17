using BWMP_db.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

        VesselClass v = new VesselClass();

        //=============//
        // New Project //
        //=============//

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // If empty then False.
            if (textboxVesselId.Text != "" & textboxVesselName.Text != "")
            {
                // Get values from input fields.
                v.VesselId = textboxVesselId.Text;
                v.VesselName = textboxVesselName.Text;
                v.VesselStatus = comboboxVesselStatus.Text;

                // Inserting data into database
                bool success = v.Insert(v);
                if (success == true)
                {
                    // Succesfully inserted.
                    MessageBox.Show("New BWMP succesfully inserted", "OK",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    // Clear method.
                    Clear();
                }
                else
                {
                    // Failed to add.
                    MessageBox.Show("UPS! Something goes wrong :(");
                }

                // Load data into data grid view after add.
                DataTable dt = v.Select();
                dataGridView1.DataSource = dt;
            }
            else
            {
                
                MessageBox.Show("Please provide ID and Vesssel name");
            }
            
        }


        //load

        private void BWMP_db_Load(object sender, EventArgs e)
        {
            //Load data into data grid after app start
            DataTable dt = v.Select();
            dataGridView1.DataSource = dt;
            //Hide column
            dataGridView1.Columns["MainId"].Visible = false;

            string myconnstrng = ConfigurationManager.ConnectionStrings["BWMP_db.Properties.Settings.databaseConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(myconnstrng);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM data WHERE VesselStatus LIKE 'Open'", conn);
            DataTable checkbox = new DataTable();
            adapter.Fill(checkbox);
            dataGridView1.DataSource = checkbox;
        }
        //clear method
        public void Clear()
        {
            textboxVesselId.Text = "";
            textboxVesselName.Text = "";
            comboboxVesselStatus.Text = "";
        }


        //data on click
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get data from data grid and load it to the textboxes.
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
            textboxMainId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textboxVesselId.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textboxVesselName.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            comboboxVesselStatus.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            }
            else
            {
                Exception ex;
            }

        }
        // clear but
        private void buttonClear_Click(object sender, EventArgs e)
        {
            //Clear Data.
            Clear();
        }

        //update
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
        // delete
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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM data WHERE VesselId LIKE '%" + keyword + "%' OR VesselName LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        //some tests
        private void bTest_Click(object sender, EventArgs e)
        {

            modules.NewProjectForm pokaz = new modules.NewProjectForm();
            pokaz.ShowDialog();
        }
        // tests again
        private void buttonNPS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to open NPS?", "Start NPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start("Notepad");
            }
        }
        // checkbox test
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                //get value from textbox
                //string keyword = textboxSearch.Text;

                SqlConnection conn = new SqlConnection(myconnstrng);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM data WHERE VesselStatus LIKE 'Open'", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = v.Select();
                dataGridView1.DataSource = dt;
                Clear();
            }
        }


    }
}
