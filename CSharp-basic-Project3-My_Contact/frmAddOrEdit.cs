using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_basic_Project3_My_Contact.Repository;
using CSharp_basic_Project3_My_Contact.Services;

namespace CSharp_basic_Project3_My_Contact
{
    public partial class frmAddOrEdit : Form
    {
        private readonly IContactRepository repository;
        public int contactId = 0;

        public frmAddOrEdit()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "افزودن مخاطب جدید";
            }
            else
            {
                this.Text = "ویرایش مخاطب";
                DataTable dt = repository.SelectRow(contactId);
                txtFirstName.Text = dt.Rows[0][1].ToString();
                txtLastName.Text = dt.Rows[0][2].ToString();
                txtAge.Value = int.Parse(dt.Rows[0][3].ToString());
                txtPhoneNumber.Text = dt.Rows[0][4].ToString();
                txtEmailAddress.Text = dt.Rows[0][5].ToString();
                txtAddress.Text = dt.Rows[0][6].ToString();
                btnSubmit.Text = "ویرایش مخاطب";
            }
        }

        bool ValidateInputs()
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید .", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtLastName.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید .", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن را وارد کنید .", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPhoneNumber.Text == "")
            {
                MessageBox.Show("لطفا شماره تماس را وارد کنید .", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtEmailAddress.Text == "")
            {
                MessageBox.Show("لطفا ایمیل را وارد کنید .", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                bool isSuccess;
                if (contactId == 0)
                {
                    isSuccess = repository.Insert(txtFirstName.Text, txtLastName.Text, (int)txtAge.Value, txtPhoneNumber.Text, txtEmailAddress.Text, txtAddress.Text);
                }
                else
                {
                    isSuccess = repository.Update(contactId, txtFirstName.Text, txtLastName.Text, (int)txtAge.Value, txtPhoneNumber.Text, txtEmailAddress.Text, txtAddress.Text);
                }
                if (isSuccess == true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با شکست روبرو شد", "شکست", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

    }
}

