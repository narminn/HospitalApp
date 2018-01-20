using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital
{
    public partial class Form1 : Form
    {
        Hospital_DbEntities db = new Hospital_DbEntities();
        
        OpenFileDialog img = new OpenFileDialog();
       

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in db.Titles)
            {
                comboBoxTitle.Items.Add(item.Title_name);
                //comboBoxTitle.ValueMember = item.Id.ToString();
            }
            foreach (var item in db.Marital_Statuses)
            {
                marital_status.Items.Add(item.Marital_status_name);
                //marital_status.ValueMember = item.Id.ToString();
            }
            foreach (var item in db.Occupations)
            {
                occupation.Items.Add(item.Occupation_name);
                //occupation.ValueMember = item.Id.ToString();
            }
            foreach (var item in db.Religions)
            {
                religion.Items.Add(item.Religion_name);
                //religion.ValueMember = item.Id.ToString();
            }
            foreach (var item in db.State_of_origins)
            {
                stateof_origin.Items.Add(item.State_of_origin_name);
                //stateof_origin.ValueMember = item.Id.ToString();
            }
            foreach (var item in db.Card_Types)
            {
                card_type.Items.Add(item.Card_type_name);
                //card_type.ValueMember = item.Id.ToString();
            }
            foreach (var item in db.State_of_origins)
            {
                rel_stateof_origin.Items.Add(item.State_of_origin_name);
                //rel_stateof_origin.ValueMember = item.Id.ToString();
            }
            foreach (var item in db.Next_of_kins)
            {
                relat.Items.Add(item.Kin_fullname);
            }
        }
        private void label29_Click(object sender, EventArgs e)
        {
            img.ShowDialog();
            this.pictureBoxProfile.Image = Image.FromFile(img.FileName);


        }

        private void new_accnt_btn_Click(object sender, EventArgs e)
        {
            string imageName = DateTime.Now.ToString("yyyyMMddssHHmm") + img.SafeFileName;
            WebClient webclient = new WebClient();
            string path = @"C:\Users\Dr.Rashad\source\repos\Hospital\Hospital\Upload\" + imageName;
            webclient.DownloadFile(img.FileName, path);
            int title_id = db.Titles.Where(t => t.Title_name == comboBoxTitle.Text).First().Id;
            int mr_st_id = db.Marital_Statuses.Where(t => t.Marital_status_name == marital_status.Text).First().Id;
            int st_org_id = db.State_of_origins.Where(t => t.State_of_origin_name == stateof_origin.Text).First().Id;
            int rel_id = db.Religions.Where(t => t.Religion_name == religion.Text).First().Id;
            int occ_id = db.Occupations.Where(t => t.Occupation_name == occupation.Text).First().Id;
            int card_id= db.Card_Types.Where(t => t.Card_type_name == card_type.Text).First().Id;
            int rel_st_org = db.State_of_origins.Where(r => r.State_of_origin_name == rel_stateof_origin.Text).First().Id;
            int relation = db.Next_of_kins.Where(r => r.Kin_fullname == relat.Text).First().Id;
            Patient ptnt = new Patient();
            ptnt.Patient_title_id = title_id;
            ptnt.Patient_firstname = firstname.Text;
            ptnt.Patient_middlename = middlename.Text;
            ptnt.Patient_surname = surname.Text;
            string value = "";
            bool isChecked = male_btn.Checked;
            if (isChecked)
                value = male_btn.Text;
            else
                value = female_btn.Text;
            ptnt.Patient_gender = value;
            ptnt.Patient_marital_status_id = mr_st_id;
            ptnt.Patient_dateof_birth = dateof_birth.Value;
            ptnt.Patient_stateof_origin_id = st_org_id;
            ptnt.Patient_tribe = tribe.Text;
            ptnt.Patient_religion_id = rel_id;
            ptnt.Patient_occupation_id = occ_id;
            ptnt.Patient_permanent_address = perm_address.Text;
            ptnt.Patient_home_address = home_address.Text;
            ptnt.Patient_phone = phone.Text;
            ptnt.Patient_account_no = Convert.ToInt32(account_no.Text);
            ptnt.Patient_photo = imageName;
            ptnt.Patient_file = file_nmbr.Text;
            ptnt.Patient_card_type_id = card_id;
            ptnt.Patient_status = checkBoxEdit.Checked;
            ptnt.Patient_relation_id = relation;
            Next_of_kins next = new Next_of_kins();
            next.Kin_fullname = rel_fullname.Text;
            string kvalue = "";
            bool k_isChecked = rel_male_btn.Checked;
            if (isChecked)
                value = rel_male_btn.Text;
            else
                value = rel_female_btn.Text;
            next.Kin_gender = kvalue;
            next.Kin_stateof_origin_id = rel_st_org;
            next.Kin_phone = rel_phone.Text;
            next.Kin_address = rel_address.Text;
            next.Kin_relation_of_patient = rel_of_patient.Text;
            db.Patients.Add(ptnt);
            db.Next_of_kins.Add(next);
            db.SaveChanges();
            

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Patiens_Info_Form pat_info = new Patiens_Info_Form();
            pat_info.ShowDialog();
            this.Hide();
        }
    }

}
