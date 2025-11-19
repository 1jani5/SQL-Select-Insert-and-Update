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

        private long RegistrationID()
        {
            count++;
            return count;
        }
        private long StudentId;



        private void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }


        public FrmClubRegistration()
        {
            InitializeComponent();
            
    }


        private void button1_Click(object sender, EventArgs e)
        {
            ClubRegistrationQuery clubRegistrationQuery = new ClubRegistrationQuery();
            clubRegistrationQuery.RegisterStudent(
                ID,
                RegistrationID(),
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                int.Parse(textBox4.Text),
                comboBox1.Text,
                textBox5.Text
                );

            clubRegistrationQuery._FirstName = FirstName;
            clubRegistrationQuery._MiddleName = MiddleName;
            clubRegistrationQuery._LastName = LastName;
            clubRegistrationQuery._Age = Age;
            clubRegistrationQuery._Gender = Gender;
            clubRegistrationQuery._Program = Program;

            RefreshListOfClubMembers();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }
    }
}
