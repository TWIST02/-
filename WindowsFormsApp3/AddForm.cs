using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class AddForm : Form
    {
        private PersonLibary personLibary;
        public AddForm(PersonLibary personLibary)
        {
            InitializeComponent();
            this.personLibary = personLibary;
        }
        private void Save()
        {
            if(txtBoxName.Text.Length < 0     || 
                txtBoxLastname.Text.Length <0 ||
                txtBoxAge.Text.Length < 0)
            {
                MessageBox.Show("Введитье все данные");
                return;
            }
            personLibary.AddPerson(new Person()
            {
             FirstName = txtBoxName.Text,
             LastName = txtBoxLastname.Text,
             Age = Convert.ToInt32(txtBoxAge.Text),
            });
            Refresh();
        }
        private void Refresh()
        {
            txtBoxName.Text= string.Empty;
            txtBoxLastname.Text = string.Empty;
            txtBoxAge.Text= string.Empty;
        }
        private void btnOkay_Click(object sender, EventArgs e)
        {
            Save();
            if (MessageBox.Show("Добавить еще одного?", "Добавление", MessageBoxButtons.OKCancel)
             == DialogResult.OK)
            {
                Refresh();
            }
            else
            {
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
