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
    public partial class UpdateForm : Form
    {
        Hospital_DbEntities db = new Hospital_DbEntities();
        private Patient selectedPatient;
        public UpdateForm()
        {
            InitializeComponent();
        }
        private void UpdateForm_Load(object sender, EventArgs e)
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

        private void Update_data(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id= Convert.ToInt32(dataGrid_Update.Rows[e.RowIndex].Cells[0].Value);
            selectedPatient = db.Patients.Find(id);
            account_no.Text = selectedPatient.Patient_account_no.ToString();
            file_nmbr.Text = selectedPatient.Patient_file;
            comboBoxTitle.Text = selectedPatient.Title.Title_name;
            firstname.Text = selectedPatient.Patient_firstname;
            middlename.Text = selectedPatient.Patient_middlename;
            surname.Text = selectedPatient.Patient_surname;
            dateof_birth.Value = selectedPatient.Patient_dateof_birth;
            phone.Text = selectedPatient.Patient_phone;
            checkBoxEdit.Checked = selectedPatient.Patient_status;
        }

        private void upd_btn_Click(object sender, EventArgs e)
        {
            int title_id = db.Titles.Where(t => t.Title_name == comboBoxTitle.Text).First().Id;
            selectedPatient.Patient_account_no= Convert.ToInt32(account_no.Text);
            selectedPatient.Patient_file = file_nmbr.Text;
            selectedPatient.Patient_title_id = title_id;
            selectedPatient.Patient_firstname = firstname.Text;
            selectedPatient.Patient_middlename = middlename.Text;
            selectedPatient.Patient_surname = surname.Text;
            selectedPatient.Patient_dateof_birth = dateof_birth.Value;
            selectedPatient.Patient_phone = phone.Text;
            selectedPatient.Patient_status = checkBoxEdit.Checked;
            db.SaveChanges();
        }
    }
}
