using BWMP_db.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BWMP_db.modules
{
    public partial class EditProjectForm : Form
    {
        public EditProjectForm()
        {
            InitializeComponent();
        }

        VesselClass v = new VesselClass();

        private void buttonEditOK_Click(object sender, EventArgs e)
        {

            // Get data from texboxes.
            // We need to convert from string to int using Parse.
            v.MainId = int.Parse(textboxMainId.Text);
            v.VesselId = textboxVesselIdEdit.Text;
            v.VesselName = textboxVesselNameEdit.Text;
            v.VesselStatus = comboboxVesselStatusEdit.Text;
            v.VesselLcs = comboboxVesselLcsEdit.Text;
            v.VesselMethodSeq = comboboxVesselMethodSeqEdit.Text;
            v.VesselMethodFt = comboboxVesselMethodFtEdit.Text;
            v.VesselMethodDil = comboboxVesselMethodDilEdit.Text;
            v.SfaCreated = comboboxSfaCreatedEdit.Text;
            v.SfaSent = comboboxSfaSentEdit.Text;
            v.NOrder = comboboxNOrderEdit.Text;
            v.SfaRec = comboboxSfaRecEdit.Text;
            v.AppStage = comboboxApprovalStageEdit.Text;
            v.Certificate = comboboxCertificateEdit.Text;
            v.SharePoint = comboboxSharePointEdit.Text;
            v.Hmax = double.Parse(comboboxHmaxEdit.Text);
            v.Hadd = double.Parse(comboboxHaddEdit.Text);
            v.Hused = double.Parse(comboboxHusedEdit.Text);
            v.Notes = textboxNotesEdit.Text;
            v.PoChecked = comboboxPoCheckedEdit.Text;
            v.NOrderClosed = comboboxNOrderClosedEdit.Text;



            // Update data in database.
            bool success = v.Update(v);
            if (success == true)
            {
                // Updated successfully.
                //MessageBox.Show("Data updated");
                // Load data on data grid.

                //DataTable dt = v.Select();
                //dataGridView1.DataSource = dt;
                Close();
            }
            else
            {
                // Update failed.
                MessageBox.Show("Update failed");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
