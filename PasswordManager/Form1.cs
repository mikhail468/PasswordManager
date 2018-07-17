using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Manager;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = ((PWClass)listBox1.SelectedItem).Name.ToString();
            txtPW.Text = ((PWClass)listBox1.SelectedItem).Pw.ToString();
        }

        public void ReloadPWs()
        {
            List<PWClass> result = PWManager.getPWSerialization();
            result.Sort((x, y) => string.Compare(x.Name, y.Name));

            listBox1.DataSource = result;
                  
                
        }

        private void btnAddName_Click(object sender, EventArgs e)
        {
            bool success = PWManager.savePWSerialization(txtName.Text, txtPW.Text);
            if (success)
            {
                MessageBox.Show("Added");
                ReloadPWs();
                txtName.Text = "";
                txtPW.Text = "";
            }
            else MessageBox.Show("Could not add student");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("              Are you sure you want \n              to remove the item?", "Deleted", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                List<PWClass> result = PWManager.getPWSerialization();
                foreach (PWClass item in result)
                {
                    if (item.Name == txtName.Text)
                    {
                        result.Remove(item);
                        break;
                    }
                }

                bool success = PWManager.saveToXML(result);
                if (success)
                {
                    MessageBox.Show("Removed");
                    ReloadPWs();
                    txtName.Text = "";
                    txtPW.Text = "";
                }
                else MessageBox.Show("Could not remove the element");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadPWs();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPW.Text = "";
        }
    }
}
