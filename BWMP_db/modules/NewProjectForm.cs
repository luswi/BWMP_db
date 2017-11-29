using BWMP_db.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BWMP_db.modules
{
    public partial class NewProjectForm : Form
    {
        public NewProjectForm()
        {
            InitializeComponent();

        }

        VesselClass v = new VesselClass();



        //===============================//
        // Add New Project into database //
        //===============================//

        private void newProject_Click(object sender, EventArgs e)
        {
            // If Vessel id or Vessel Name are empty then False.
            if(textboxVesselId.Text != "" & textboxVesselName.Text != "")
            {
                // Get values from input fields.
                v.VesselId = textboxVesselId.Text;
                v.VesselName = textboxVesselName.Text;
                v.VesselStatus = comboboxStatus.Text;
                v.VesselLcs = comboboxVesselLcs.Text;
                v.VesselMethodSeq = comboboxVesselMethodSeq.Text;
                v.VesselMethodFt = comboboxVesselMethodFt.Text;
                v.VesselMethodDil = comboboxVesselMethodDil.Text;
                v.SfaCreated = comboboxSfaCreated.Text;
                v.SfaSent = comboboxSfaSent.Text;
                v.NOrder = comboboxNOrder.Text;
                v.SfaRec = comboboxSfaRec.Text;
                v.AppStage = comboboxApprovalStage.Text;
                v.Certificate = comboboxCertificate.Text;
                v.SharePoint = comboboxSharePoint.Text;
                v.Hmax = double.Parse(comboboxHmax.Text);
                v.Notes = textboxNotes.Text;
                v.PoChecked = comboboxPoChecked.Text;
                v.NOrderClosed = comboboxNOrderClosed.Text;
                v.Hadd = 0;
                v.Hused = 0;

                // Inserting data into database.
                bool success = v.Insert(v);
                if (success == true)
                {
                    // Successfully inserted into database.
                    //MessageBox.Show("New BWMP succesfully inserted", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Close();
                    
                    
                    
                    


                }
                else
                {
                    // Failed to add into database.
                    MessageBox.Show("UPS! Something goes wrong :(", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
                

                

            }
            else
            {
                MessageBox.Show("Please provide Vessel ID / Vessel Name","We need:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NewProjectForm_Load(object sender, EventArgs e)
        {
            // Load preselected Hmax 4.5 (one method)
            comboboxHmax.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://groups.dnvgl.com/sites/bwmp-exchange/Lists/BWMP%20Production%20List/BWMP%20Production%20List.aspx");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(@"P:\tebpl350\04 Sales\04-3 Project Agreements\04-3-10 Special Projects\BWMP group");
        }
    }
}
