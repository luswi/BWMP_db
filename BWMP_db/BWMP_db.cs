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
            dataGridView1.Columns["AppStage"].Visible = false;
            dataGridView1.Columns["Certificate"].Visible = false;
            dataGridView1.Columns["SharePoint"].Visible = false;
            dataGridView1.Columns["Hmax"].Visible = false;
            dataGridView1.Columns["Hadd"].Visible = false;
            dataGridView1.Columns["Hused"].Visible = false;
            dataGridView1.Columns["Notes"].Visible = false;
            dataGridView1.Columns["PoChecked"].Visible = false;
            dataGridView1.Columns["NOrderClosed"].Visible = false;

            // import row 0 as default start ->
            textboxMainId.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            labelVesselIdData.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            labelVesselNameData.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            labelVesselStatusData.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            labelVesselLcsData.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            labelVesselMethodSeqData.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            labelVesselMethodFtData.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            labelVesselMethodDilData.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            labelSfaCreatedData.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
            labelSfaSentData.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();
            labelNOrderData.Text = dataGridView1.Rows[0].Cells[10].Value.ToString();
            labelSfaRecData.Text = dataGridView1.Rows[0].Cells[11].Value.ToString();

            labelAppStageData.Text = dataGridView1.Rows[0].Cells[12].Value.ToString();
            labelCertificateData.Text = dataGridView1.Rows[0].Cells[13].Value.ToString();
            labelSharePointData.Text = dataGridView1.Rows[0].Cells[14].Value.ToString();
            // Hours for project
            double hmax = double.Parse(dataGridView1.Rows[0].Cells[15].Value.ToString());
            double hused = double.Parse(dataGridView1.Rows[0].Cells[17].Value.ToString());
            double hrev = double.Parse(dataGridView1.Rows[0].Cells[16].Value.ToString());
            double hleft = (hmax + hrev) - hused;
            labelHmaxData.Text = hmax.ToString();
            labelHaddData.Text = hrev.ToString();
            labelHusedData.Text = hused.ToString();
            labelHleftData.Text = hleft.ToString();

            textBoxNotesData.Text = dataGridView1.Rows[0].Cells[18].Value.ToString();
            labelPoCheckedData.Text = dataGridView1.Rows[0].Cells[19].Value.ToString();
            labelNOrderClosedData.Text = dataGridView1.Rows[0].Cells[20].Value.ToString();


            // condition check and show image Yes/No.

            // LCS / Methods If nothing then No if selected anything then Yes
            if (labelVesselLcsData.Text == "") { pbLcsStatus.Image = Properties.Resources.no; }
            else { pbLcsStatus.Image = Properties.Resources.yes; }
            if (labelVesselMethodSeqData.Text == "") { pbSeqStatus.Image = Properties.Resources.no; }
            else { pbSeqStatus.Image = Properties.Resources.yes; }
            if (labelVesselMethodFtData.Text == "") { pbFtStatus.Image = Properties.Resources.no; }
            else { pbFtStatus.Image = Properties.Resources.yes; }
            if (labelVesselMethodDilData.Text == "") { pbDilStatus.Image = Properties.Resources.no; }
            else { pbDilStatus.Image = Properties.Resources.yes; }
            //labelVesselMethodDil.ForeColor = System.Drawing.Color.Red;


            // SFA / NOrder
            if (labelSfaCreatedData.Text == "Yes" || labelSfaCreatedData.Text == "SC") { pbSfaCreatedStatus.Image = Properties.Resources.yes; }
            else { pbSfaCreatedStatus.Image = Properties.Resources.no; }
            if (labelSfaSentData.Text == "Yes" || labelSfaSentData.Text == "SC") { pbSfaSentStatus.Image = Properties.Resources.yes; }
            else { pbSfaSentStatus.Image = Properties.Resources.no; }
            if (labelNOrderData.Text == "Yes") { pbNOrderStatus.Image = Properties.Resources.yes; }
            else { pbNOrderStatus.Image = Properties.Resources.no; }
            if (labelSfaRecData.Text == "Yes" || labelSfaRecData.Text == "SC") { pbSfaRecStatus.Image = Properties.Resources.yes; }
            else { pbSfaRecStatus.Image = Properties.Resources.no; }

            // BWMP Approval
            string AppStagecheck = labelAppStageData.Text;
            switch (AppStagecheck)
            {
                case "pre-check":
                    labelAppStageData.BackColor = System.Drawing.Color.White;
                    break;
                case "Started":
                    labelAppStageData.BackColor = System.Drawing.Color.Orange;
                    break;
                case "Approved":
                    labelAppStageData.BackColor = System.Drawing.Color.Green;
                    break;
                case "SC":
                    labelAppStageData.BackColor = System.Drawing.Color.Green;
                    break;
                case "Verification":
                    labelAppStageData.BackColor = System.Drawing.Color.Yellow;
                    break;
                case "Rev.":
                    labelAppStageData.BackColor = System.Drawing.Color.Purple;
                    break;
            }

            if (labelCertificateData.Text == "Yes" || labelCertificateData.Text == "SC") { pbCertificateStatus.Image = Properties.Resources.yes; }
            else { pbCertificateStatus.Image = Properties.Resources.no; }

            if (labelSharePointData.Text == "Update!") { pbSharePointStatus.Image = Properties.Resources.no; }
            else { pbSharePointStatus.Image = Properties.Resources.yes; }

            // Invoice
            if (labelPoCheckedData.Text == "Yes") { pbPoChechedStatus.Image = Properties.Resources.yes; }
            else { pbPoChechedStatus.Image = Properties.Resources.no; }
            if (labelNOrderClosedData.Text == "Yes") { pbNOrderClosedStatus.Image = Properties.Resources.yes; }
            else { pbNOrderClosedStatus.Image = Properties.Resources.no; }

            // BWMP Status
            string VesselStatuscheck = labelVesselStatusData.Text;
            switch (VesselStatuscheck)
            {
                case "Open":
                    labelVesselStatusData.BackColor = System.Drawing.Color.CornflowerBlue;
                    break;
                case "Closed":
                    labelVesselStatusData.BackColor = System.Drawing.Color.Green;
                    break;
                case "OnHold":
                    labelVesselStatusData.BackColor = System.Drawing.Color.Orange;
                    break;
                case "Piraeus":
                    labelVesselStatusData.BackColor = System.Drawing.Color.Green;
                    break;

            }
            // <- end



            Count();

            
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

        //=======================================//
        // Count project and put into labelCount //
        //=======================================//
        public void Count()
        { 
        string myconnstrng = ConfigurationManager.ConnectionStrings["BWMP_db.Properties.Settings.databaseConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrng);
            conn.Open();
            SqlCommand commOpen = new SqlCommand("SELECT COUNT(*) FROM data WHERE VesselStatus='Open'", conn);
            SqlCommand commOnHold = new SqlCommand("SELECT COUNT(*) FROM data WHERE VesselStatus='OnHold'", conn);
            SqlCommand commTotal = new SqlCommand("SELECT COUNT(*) FROM data WHERE VesselStatus='Open' or VesselStatus='OnHold'", conn);
            Int32 countOpen = Convert.ToInt32(commOpen.ExecuteScalar());
            Int32 countOnHold = Convert.ToInt32(commOnHold.ExecuteScalar());
            Int32 countTotal = Convert.ToInt32(commTotal.ExecuteScalar());
            if (countOpen>0)
            {
                labelCountOpen.Text = "Open projects: " + Convert.ToString(countOpen.ToString());
            }
            else
            {
                labelCountOpen.Text = "Open projects: 0";
            }
            if (countOnHold>0)
            {
                labelCountOnHold.Text = "OnHold projects: " + Convert.ToString(countOnHold.ToString());
            }
            else
            {
                labelCountOnHold.Text = "OnHold projects: 0";
            }
            if (countTotal>0)
            {
                labelCountTotal.Text = "Total projects: " + Convert.ToString(countTotal.ToString());
            }
            else
            {
                labelCountTotal.Text = "Total projects: 0";
            }
            conn.Close();


            
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
                labelVesselStatusData.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                labelVesselLcsData.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                labelVesselMethodSeqData.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                labelVesselMethodFtData.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                labelVesselMethodDilData.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                labelSfaCreatedData.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
                labelSfaSentData.Text = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
                labelNOrderData.Text = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
                labelSfaRecData.Text = dataGridView1.Rows[rowIndex].Cells[11].Value.ToString();

                labelAppStageData.Text = dataGridView1.Rows[rowIndex].Cells[12].Value.ToString();
                labelCertificateData.Text = dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();
                labelSharePointData.Text = dataGridView1.Rows[rowIndex].Cells[14].Value.ToString();
                // Hours for project
                double hmax = double.Parse(dataGridView1.CurrentRow.Cells[15].Value.ToString());
                double hused = double.Parse(dataGridView1.CurrentRow.Cells[17].Value.ToString());
                double hrev = double.Parse(dataGridView1.CurrentRow.Cells[16].Value.ToString());
                double hleft = (hmax + hrev) - hused;
                labelHmaxData.Text = hmax.ToString();
                labelHaddData.Text = hrev.ToString();
                labelHusedData.Text = hused.ToString();
                labelHleftData.Text = hleft.ToString();

                textBoxNotesData.Text = dataGridView1.Rows[rowIndex].Cells[18].Value.ToString();
                labelPoCheckedData.Text = dataGridView1.Rows[rowIndex].Cells[19].Value.ToString();
                labelNOrderClosedData.Text = dataGridView1.Rows[rowIndex].Cells[20].Value.ToString();

                
                // Condition check and show image Yes/No.

                // LCS / Methods If nothing then No if selected anything then Yes
                if (labelVesselLcsData.Text == "") { pbLcsStatus.Image = Properties.Resources.no; }
                else { pbLcsStatus.Image = Properties.Resources.yes; }
                if (labelVesselMethodSeqData.Text == "") { pbSeqStatus.Image = Properties.Resources.no; }
                else { pbSeqStatus.Image = Properties.Resources.yes; }
                if (labelVesselMethodFtData.Text == "") { pbFtStatus.Image = Properties.Resources.no; }
                else { pbFtStatus.Image = Properties.Resources.yes; }
                if (labelVesselMethodDilData.Text == "") { pbDilStatus.Image = Properties.Resources.no; }
                else { pbDilStatus.Image = Properties.Resources.yes; }
                //labelVesselMethodDil.ForeColor = System.Drawing.Color.Red;
                
                // SFA / NOrder
                if (labelSfaCreatedData.Text == "Yes" || labelSfaCreatedData.Text == "SC") { pbSfaCreatedStatus.Image = Properties.Resources.yes; }
                else { pbSfaCreatedStatus.Image = Properties.Resources.no; }
                if (labelSfaSentData.Text == "Yes" || labelSfaSentData.Text == "SC") { pbSfaSentStatus.Image = Properties.Resources.yes; }
                else { pbSfaSentStatus.Image = Properties.Resources.no; }
                if (labelNOrderData.Text == "Yes") { pbNOrderStatus.Image = Properties.Resources.yes; }
                else { pbNOrderStatus.Image = Properties.Resources.no; }
                if (labelSfaRecData.Text == "Yes" || labelSfaRecData.Text == "SC") { pbSfaRecStatus.Image = Properties.Resources.yes; }
                else { pbSfaRecStatus.Image = Properties.Resources.no; }

                // BWMP Approval
                string AppStagecheck = labelAppStageData.Text;
                switch (AppStagecheck)
                {
                    case "pre-check":
                        labelAppStageData.BackColor = System.Drawing.Color.White;
                        break;
                    case "Started":
                        labelAppStageData.BackColor = System.Drawing.Color.Orange;
                        break;
                    case "Approved":
                        labelAppStageData.BackColor = System.Drawing.Color.Green;
                        break;
                    case "SC":
                        labelAppStageData.BackColor = System.Drawing.Color.Green;
                        break;
                    case "Verification":
                        labelAppStageData.BackColor = System.Drawing.Color.Yellow;
                        break;
                    case "Rev.":
                        labelAppStageData.BackColor = System.Drawing.Color.Purple;
                        break;
                }

                if (labelCertificateData.Text == "Yes" || labelCertificateData.Text == "SC") { pbCertificateStatus.Image = Properties.Resources.yes; }
                else { pbCertificateStatus.Image = Properties.Resources.no; }

                if (labelSharePointData.Text == "Update!") { pbSharePointStatus.Image = Properties.Resources.no; }
                else { pbSharePointStatus.Image = Properties.Resources.yes; }

                // Invoice
                if(labelPoCheckedData.Text == "Yes") { pbPoChechedStatus.Image = Properties.Resources.yes; }
                else { pbPoChechedStatus.Image = Properties.Resources.no; }
                if (labelNOrderClosedData.Text == "Yes") { pbNOrderClosedStatus.Image = Properties.Resources.yes; }
                else { pbNOrderClosedStatus.Image = Properties.Resources.no; }

                // BWMP Status
                string VesselStatuscheck = labelVesselStatusData.Text;
                switch (VesselStatuscheck)
                {
                    case "Open":
                        labelVesselStatusData.BackColor = System.Drawing.Color.CornflowerBlue;
                        break;
                    case "Close":
                        labelVesselStatusData.BackColor = System.Drawing.Color.Green;
                        break;
                    case "OnHold":
                        labelVesselStatusData.BackColor = System.Drawing.Color.Orange;
                        break;
                    case "Piraeus":
                        labelVesselStatusData.BackColor = System.Drawing.Color.Green;
                        break;
                    
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
        // Delete button //
        //===============//

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete project ?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Get MainId.
                v.MainId = Convert.ToInt32(textboxMainId.Text);
                bool isSuccess = v.Delete(v);
                if (isSuccess == true)
                {
                    // If successfully deleted.
                    MessageBox.Show("Data deleted");
                    // Refresh data.

                    //DataTable dt = v.Select();
                    //dataGridView1.DataSource = dt;
                    //Clear();

                    string myconnstrng = ConfigurationManager.ConnectionStrings["BWMP_db.Properties.Settings.databaseConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(myconnstrng);
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM data WHERE VesselStatus LIKE 'Open' OR VesselStatus Like 'OnHold'", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;


                }
                else
                {
                    // If failed.
                    MessageBox.Show("Something goes wrong");
                }
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
                //get value from textbox.
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

        //==========//
        // Top menu //
        //==========//

        private void bWMPdbInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 2.0 Stable\n More info: LUSWI", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonEditShow_Click(new object(), new EventArgs());

        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonNew_Click(new object(), new EventArgs());
        }

        private void sharePointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://groups.dnvgl.com/sites/bwmp-exchange/Lists/BWMP%20Production%20List/BWMP%20Production%20List.aspx");
        }

        private void sFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"P:\tebpl350\04 Sales\04-3 Project Agreements\04-3-10 Special Projects\BWMP group");
        }

        //===============================================//
        // When new add and close then refresh datagrid. //
        //===============================================//

        private void BWMP_db_Activated(object sender, EventArgs e)
        {
            string myconnstrng = ConfigurationManager.ConnectionStrings["BWMP_db.Properties.Settings.databaseConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(myconnstrng);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM data WHERE VesselStatus LIKE 'Open' OR VesselStatus Like 'OnHold'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        //===============//
        // Open New Form //
        //===============//


        private void buttonNew_Click(object sender, EventArgs e)
        {
            modules.NewProjectForm newProject = new modules.NewProjectForm();
            newProject.ShowDialog();
        }


        //================//
        // Open Edit Form //
        //================//

        private void buttonEditShow_Click(object sender, EventArgs e)
        {



            // Transfer data into edit form.
            modules.EditProjectForm editProject = new modules.EditProjectForm();

            v.MainId = int.Parse(textboxMainId.Text);

            editProject.textboxMainId.Text = v.MainId.ToString();

            editProject.textboxVesselIdEdit.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            editProject.textboxVesselNameEdit.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            editProject.comboboxVesselStatusEdit.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            editProject.comboboxVesselLcsEdit.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            editProject.comboboxVesselMethodSeqEdit.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            editProject.comboboxVesselMethodFtEdit.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            editProject.comboboxVesselMethodDilEdit.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            editProject.comboboxSfaCreatedEdit.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            editProject.comboboxSfaSentEdit.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            editProject.comboboxNOrderEdit.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            editProject.comboboxSfaRecEdit.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            editProject.comboboxPoCheckedEdit.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            editProject.comboboxNOrderClosedEdit.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            


            editProject.comboboxApprovalStageEdit.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            editProject.comboboxCertificateEdit.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            editProject.comboboxSharePointEdit.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            editProject.textboxNotesEdit.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();

            double hmax = double.Parse(dataGridView1.CurrentRow.Cells[15].Value.ToString());
            double hused = double.Parse(dataGridView1.CurrentRow.Cells[17].Value.ToString());
            double hrev = double.Parse(dataGridView1.CurrentRow.Cells[16].Value.ToString());
            double hleft = (hmax + hrev) - hused;

            editProject.comboboxHmaxEdit.Text = hmax.ToString();
            editProject.comboboxHaddEdit.Text = hrev.ToString();
            editProject.comboboxHusedEdit.Text = hused.ToString();
            editProject.textboxHleftEdit.Text = hleft.ToString();





            editProject.ShowDialog();
        }



    }
}
