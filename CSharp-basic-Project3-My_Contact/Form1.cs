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
    public partial class Form1 : Form
    {
        private readonly IContactRepository contactRepository;

        public Form1()
        {
            InitializeComponent();
            contactRepository = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("خوش آمدید");
            BindGrid();
        }

        private void BindGrid()
        {
            dgContact.AutoGenerateColumns = false;
            dgContact.DataSource = contactRepository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgContact.CurrentRow != null)
            {
                string firstName = dgContact.CurrentRow.Cells[1].Value.ToString();
                string lastName = dgContact.CurrentRow.Cells[2].Value.ToString();
                string fullName = firstName + " " + lastName;

                if (MessageBox.Show($"آیا از حذف {fullName} مطمئن هستید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int contactId = int.Parse(dgContact.CurrentRow.Cells[0].Value.ToString());
                    contactRepository.Delete(contactId);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا مخاطب را از لیست انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgContact.CurrentRow != null)
            {
                int contactId = int.Parse(dgContact.CurrentRow.Cells[0].Value.ToString());
                frmAddOrEdit frm = new frmAddOrEdit();
                frm.contactId = contactId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgContact.DataSource = contactRepository.Search(txtSearch.Text);
        }
    }
}
