using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital
{
    public partial class DeleteForm : Form
    {
        Hospital_DbEntities db = new Hospital_DbEntities();
        private Patient selectedPatient;
        public DeleteForm()
        {
            InitializeComponent();
        }
        private void DeleteForm_Load(object sender, EventArgs e)
        {
            fillData();
        }
        private void fillData()
        {
            dataGrid_Update.Rows.Clear();
            int i = 0;
            List<Patient> ptnt_list = db.Patients.ToList();
            foreach (Patient item in ptnt_list)
            {
                dataGrid_Update.Rows.Add();
                dataGrid_Update.Rows[i].Cells[0].Value = item.Id;
                dataGrid_Update.Rows[i].Cells[1].Value = item.Patient_account_no;
                dataGrid_Update.Rows[i].Cells[2].Value = item.Patient_file;
                dataGrid_Update.Rows[i].Cells[3].Value = item.Title.Title_name;
                dataGrid_Update.Rows[i].Cells[4].Value = item.Patient_firstname;
                dataGrid_Update.Rows[i].Cells[5].Value = item.Patient_middlename;
                dataGrid_Update.Rows[i].Cells[6].Value = item.Patient_surname;
                dataGrid_Update.Rows[i].Cells[7].Value = item.Patient_dateof_birth;
                dataGrid_Update.Rows[i].Cells[8].Value = item.Patient_phone;
                dataGrid_Update.Rows[i].Cells[9].Value = item.Patient_status;
                i++;
            }

        }

        private void dataGrid_Update_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dataGrid_Update.Rows[e.RowIndex].Cells[0].Value);
            selectedPatient = db.Patients.Find(id);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            
                db.Patients.Remove(selectedPatient);
                db.SaveChanges();
                fillData();
            
        }

       
    }
}
