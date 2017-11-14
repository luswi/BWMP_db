﻿using BWMP_db.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            textboxVesselId.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textboxVesselName.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            //Clear Data.
            Clear();
        }
    }
}
