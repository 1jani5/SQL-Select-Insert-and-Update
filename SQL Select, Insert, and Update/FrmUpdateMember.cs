using System;
using System.Collections;
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
    public partial class FrmUpdateMember : Form
    {
        ClubRegistrationQuery query = new ClubRegistrationQuery();
        long selectedID;
        public FrmUpdateMember()
        {
            InitializeComponent();
        }
        bool isLoaded = false;


        private void button1_Click(object sender, EventArgs e)
        {
            query.UpdateStudent(
           selectedID,
           txtBoxFName.Text,
           TxtBoxMName.Text,
           txtBoxLName.Text,
           int.Parse(txtBoxAge.Text),
           cbGender.Text,
           cbProgram.Text);

            MessageBox.Show("Updated Successfully!");
            this.Close();
        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            query.DisplayList();

            cbStud.DisplayMember = "StudentId";
            cbStud.ValueMember = "StudentId";
            cbStud.DataSource = query.dataTable;

            isLoaded = true;
        }

        private void cbStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            if (cbStud.SelectedValue == null) return;

            long id;
            if (!long.TryParse(cbStud.SelectedValue.ToString(), out id))
                return; // avoid crash

            selectedID = id;

            foreach (DataRow row in query.dataTable.Rows)
            {
                if ((long)row["StudentId"] == selectedID)
                {
                    txtBoxFName.Text = row["FirstName"].ToString();
                    TxtBoxMName.Text = row["MiddleName"].ToString();
                    txtBoxLName.Text = row["LastName"].ToString();
                    txtBoxAge.Text = row["Age"].ToString();
                    cbGender.Text = row["Gender"].ToString();
                    cbProgram.Text = row["Program"].ToString();
                    break;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
