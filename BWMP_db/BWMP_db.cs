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
            

        }

        //===============================//
        // Load data into data grid view //
        //===============================//

        private void BWMP_db_Load(object sender, EventArgs e)
        {
            // Load data into data grid after app start.
            DataTable dt = v.Select();
            dataGridView1.DataSource = dt;
            // Hide column from data grid view.
            dataGridView1.Columns["MainId"].Visible = false;
            dataGridView1.Columns["VesselLcs"].Visible = false;
            dataGridView1.Columns["VesselMethodSeq"].Visible = false;
            dataGridView1.Columns["VesselMethodFt"].Visible = false;
            dataGridView1.Columns["VesselMethodDil"].Visible = false;
            dataGridView1.Columns["SfaCreated"].Visible = false;
            dataGridView1.Columns["SfaSent"].Visible = false;
            dataGridView1.Columns["NOrder"].Visible = false;
            dataGridView1.Columns["SfaRec"].Visible = false;


        }

        //==============//
        // Clear method //
        //==============//

        public void Clear()
        {
            //textboxVesselId.Text = "";
            //textboxVesselName.Text = "";
            //comboboxVesselStatus.Text = "";
        }

        //=====================================================//
        // Take data from data grid and load it into textboxes //
        //=====================================================//

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get data from data grid and load it to the textboxes.
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                textboxMainId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                labelVesselIdData.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                labelVesselNameData.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                labelVesselLcsData.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();

                //textboxVesselId.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                //textboxVesselName.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                comboboxVesselStatus.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                if(labelVesselLcsData.Text == "Yes")
                {
                    
                    pbLcsStatus.Image = Properties.Resources.yes;
          
                }
                else
                {
                    pbLcsStatus.Image = Properties.Resources.no;
                }
            }
            else
            {
                Exception ex;
            }

        }

        //==============//
        // Clear button //
        //==============//

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //===============//
        // Update button //
        //===============//

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Get data from texboxes.
            // We need to convert from string to int using Parse.
            v.MainId = int.Parse(textboxMainId.Text);
            //v.VesselId = textboxVesselId.Text;
            //v.VesselName = textboxVesselName.Text;
            v.VesselStatus = comboboxVesselStatus.Text;

            // Update data in database.
            bool success = v.Update(v);
            if (success == true)
            {
                // Updated successfully.
                MessageBox.Show("Data updated");
                // Load data on data grid.
                DataTable dt = v.Select();
                dataGridView1.DataSource = dt;
                Clear();
            }
            else
            {
                // Update failed.
                MessageBox.Show("Update failed");
            }


        }
        //===============//
        // Delete button //
        //===============//

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Get MainId.
            v.MainId = Convert.ToInt32(textboxMainId.Text);
            bool isSuccess = v.Delete(v);
            if (isSuccess == true)
            {
                // If successfully deleted.
                MessageBox.Show("Data deleted");
                // Refresh data.
                DataTable dt = v.Select();
                dataGridView1.DataSource = dt;
                Clear();

            }
            else
            {
                // If failed.
                MessageBox.Show("Something goes wrong");
            }
        }



        //============//
        // Search box //
        //============//

        static string myconnstrng = ConfigurationManager.ConnectionStrings["BWMP_db.Properties.Settings.databaseConnectionString"].ConnectionString;

        private void textboxSearch_TextChanged(object sender, EventArgs e)
        {
            // Get value from textbox.
            string keyword = textboxSearch.Text;
            SqlConnection conn = new SqlConnection(myconnstrng);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM data WHERE VesselId LIKE '%" + keyword + "%' OR VesselName LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }




        //
        // test for open app
        //
        private void buttonNPS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to open NPS?", "Start NPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start("Notepad");
            }
        }
        //
        // checkbox test for status 
        //
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //get value from textbox
                //string keyword = textboxSearch.Text;

                SqlConnection conn = new SqlConnection(myconnstrng);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM data WHERE VesselStatus LIKE 'Open' OR VesselStatus LIKE 'OnHold'", conn);
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

        //
        // menu info 
        //

        private void bWMPdbInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.3 Stable", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //
        // When new add and close then refresh datagrid
        //

        private void BWMP_db_Activated(object sender, EventArgs e)
        {
            string myconnstrng = ConfigurationManager.ConnectionStrings["BWMP_db.Properties.Settings.databaseConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(myconnstrng);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM data WHERE VesselStatus LIKE 'Open' OR VesselStatus Like 'OnHold'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //
        // Open New Form
        //


        private void buttonNew_Click(object sender, EventArgs e)
        {
            modules.NewProjectForm newProject = new modules.NewProjectForm();
            newProject.ShowDialog();
        }





        //
        // Open Edit Form
        //

        private void buttonEditShow_Click(object sender, EventArgs e)
        {
            modules.EditProjectForm editProject = new modules.EditProjectForm();
            editProject.textboxVesselId.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            editProject.ShowDialog();
        }


    }
}
