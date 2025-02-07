using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA1
{
    public partial class AddLecturer : Form
    {
        public AddLecturer()
        {
            InitializeComponent();
            comboGender.Items.Add("Male");
            comboGender.Items.Add("Female");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name=txtName.Text;
            String address=txtAddress.Text;
            String county=txtCounty.Text;
            int age;
            int.TryParse(txtAge.Text, out age);
            String phone=txtPhone.Text;
            String email=txtEmail.Text;
            String gender=comboGender.Text;

            DbConnect db = new DbConnect();
            db.con.Open();
            String query = "insert into lecturer (name,address,county,age,phone,email,gender) values (@studentNumber,@name,@address,@county,@age,@phone,@email,@gender)";
            SqlCommand command = new SqlCommand(query, db.con);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@county", county);
            command.Parameters.AddWithValue("@age", age);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@gender", gender);
            command.ExecuteNonQuery();
            db.con.Close();
            MessageBox.Show("Lecturer added successfully");
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
