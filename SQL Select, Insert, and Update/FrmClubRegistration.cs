using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Select__Insert__and_Update
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;

        

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            ClubRegistrationQuery clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUpdateMember updateForm = new FrmUpdateMember();
            updateForm.ShowDialog();
            RefreshListOfClubMembers();
        }

        private int RegistrationID()
        {
            count++;
            return count;
        }
        private long StudentId;



        private void RefreshListOfClubMembers()
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }


        public FrmClubRegistration()
        {
            InitializeComponent();
            
    }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtBoxStudId.Text))
                    throw new Exception("Student ID is required.");

                if (!long.TryParse(txtBoxStudId.Text, out StudentId))
                    throw new Exception("Student ID must be a valid number.");

                if (string.IsNullOrWhiteSpace(txtBoxFName.Text))
                    throw new Exception("First name is required.");

                if (string.IsNullOrWhiteSpace(TxtBoxMName.Text))
                    throw new Exception("Middle name is required.");

                if (string.IsNullOrWhiteSpace(txtBoxLName.Text))
                    throw new Exception("Last name is required.");

                if (string.IsNullOrWhiteSpace(txtBoxAge.Text))
                    throw new Exception("Age is required.");

                if (!int.TryParse(txtBoxAge.Text, out Age))
                    throw new Exception("Age must be a valid number.");

                if (Age < 1 || Age > 120)
                    throw new Exception("Age must be between 1 and 120.");

                if (cbGender.SelectedIndex == -1)
                    throw new Exception("Please select a Gender.");

                Gender = cbGender.Text;

                if (cbProgram.SelectedIndex == -1)
                    throw new Exception("Please select a Program.");

                Program = cbProgram.Text;
                ID = RegistrationID();

                FirstName = txtBoxFName.Text;
                MiddleName = TxtBoxMName.Text;
                LastName = txtBoxLName.Text;

                clubRegistrationQuery.RegisterStudent(
                    ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program
                );

                MessageBox.Show("Successfully Registered!");

                RefreshListOfClubMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }
    }
}
