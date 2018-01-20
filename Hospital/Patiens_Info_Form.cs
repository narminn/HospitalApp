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
    public partial class Patiens_Info_Form : Form
    {
        Hospital_DbEntities db = new Hospital_DbEntities();
        public Patiens_Info_Form()
        {
            InitializeComponent();
        }

        private void Patiens_Info_Form_Load(object sender, EventArgs e)
        {
            
            fillData();
            }
        private void fillData()
        {
            dataGrid_PatientsInfo.Rows.Clear();
            int i = 0;
            List<Patient> ptnt_list = db.Patients.ToList();
            foreach (Patient item in ptnt_list)
            {
                dataGrid_PatientsInfo.Rows.Add();
                dataGrid_PatientsInfo.Rows[i].Cells[0].Value = item.Patient_account_no;
                dataGrid_PatientsInfo.Rows[i].Cells[1].Value = item.Patient_file;
                dataGrid_PatientsInfo.Rows[i].Cells[2].Value = item.Title.Title_name;
                dataGrid_PatientsInfo.Rows[i].Cells[3].Value = item.Patient_firstname;
                dataGrid_PatientsInfo.Rows[i].Cells[4].Value = item.Patient_middlename;
                dataGrid_PatientsInfo.Rows[i].Cells[5].Value = item.Patient_surname;
                dataGrid_PatientsInfo.Rows[i].Cells[6].Value = item.Patient_dateof_birth;
                dataGrid_PatientsInfo.Rows[i].Cells[7].Value = item.Patient_phone;
                dataGrid_PatientsInfo.Rows[i].Cells[8].Value = item.Patient_status;
                i++;
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            fillData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateForm up_form = new UpdateForm();
            up_form.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteForm del_form = new DeleteForm();
            del_form.ShowDialog();
            this.Hide();
        }
    }
}
