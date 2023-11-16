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
    public partial class Form1 : Form
    {
        private PersonLibary personLibary;
        private AddForm addForm;
        private int index = 0;
        public Form1()
        {
            InitializeComponent();
            personLibary = new PersonLibary();
            addForm = new AddForm(personLibary);
            
            
        }
        private void UpdateInformation()
        {
            if (personLibary.Count > index)
            {
                lblName.Text = personLibary[index].FirstName;
                lblLastname.Text = personLibary[index].LastName;
                lblAge.Text = personLibary[index].Age.ToString();
                toolStripTextBoxNumber.Text = index.ToString();
            }
        }
        private void LoadInformation()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            { 
             personLibary.Load(openFileDialog.FileName);
            }
            UpdateInformation();
        }

        private void SaveInformation()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                personLibary.Save(saveFileDialog.FileName);
            }

        }

        private void toolStripMenuItemPrevious_Click(object sender, EventArgs e)
        {
            if (index - 1 >= 0)
            {
                index--;
            }
            UpdateInformation();
        }

        private void toolStripMenuItemNext_Click(object sender, EventArgs e)
        {
            if (personLibary.Count > index +1)
            {
                index++;
            }
            UpdateInformation();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveInformation();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadInformation();
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            addForm.ShowDialog();
        }
    }
}
