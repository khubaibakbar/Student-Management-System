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
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();
        DbConnect db=new DbConnect();
        public Form1()
        {
            InitializeComponent();
            populateQueries();
            fetchAllData();
            
        }
        private void populateQueries()
        {
            comboQueries.Items.Add("All Students");
            comboQueries.Items.Add("All Lecturers");
            comboQueries.Items.Add("All Lecturers who are Male");
            comboQueries.Items.Add("Students above the age of 25");
            comboQueries.Items.Add("Lecturers Paid more than 100,000");
            comboQueries.Items.Add("All Students from oregon county");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddStudent().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddLecturer().ShowDialog();
        }

        public void fetchAllData()
        {
            people.Clear();
            fetchAllStudents();
            fetchAllLecturers();
        }

        private void fetchAllStudents()
        {
            db.con.Open();
            String query = "select * from student";
            SqlCommand command=new SqlCommand(query,db.con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.StudentNumber = reader.GetString(0);
                student.name = reader.GetString(1);
                student.Address = reader.GetString(2);
                student.County= reader.GetString(3);
                student.Age = reader.GetInt32(4);
                student.Phone = reader.GetString(5);
                student.Email = reader.GetString(6);
                student.gender=reader.GetString(7);
                people.Add(student);
            }
            db.con.Close();
        }

        private void fetchAllLecturers()
        {
            db.con.Open();
            String query = "select * from lecturer";
            SqlCommand command = new SqlCommand(query, db.con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Lecturer lec = new Lecturer();
                lec.name = reader.GetString(1);
                lec.Address = reader.GetString(2);
                lec.County = reader.GetString(3);
                lec.Age = reader.GetInt32(4);
                lec.Phone = reader.GetString(5);
                lec.Email = reader.GetString(6);
                lec.gender = reader.GetString(7);
                lec.Pay = (double)reader.GetDecimal(8);
                people.Add(lec);
            }
            db.con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboQueries.SelectedIndex < 0)
            {
                MessageBox.Show("Select a query to run");
            }else if(comboQueries.SelectedIndex == 0) {//all students
                dataGridView.DataSource = null;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                List<Student> students = new List<Student>();
                foreach(Person person in people)
                {
                    if(person is Student)
                    {
                        Student student = (Student)person;
                        students.Add(student);
                    }
                }
                dataGridView.DataSource = students;
                dataGridView.AutoGenerateColumns = true;
            }
            else if (comboQueries.SelectedIndex == 1)// all lecturers
            {
                dataGridView.DataSource = null;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();

                List<Lecturer> lecturers = new List<Lecturer>();
                foreach (Person person in people)
                {
                    if (person is Lecturer)
                    {
                        Lecturer lec = (Lecturer)person;
                        lecturers.Add(lec);
                    }
                }
                dataGridView.DataSource = lecturers;
                dataGridView.AutoGenerateColumns = true;
            }
            else if((comboQueries.SelectedIndex == 2)){//all lecturers who are male
                dataGridView.DataSource = null;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                List<Lecturer> lecturers = new List<Lecturer>();
                foreach (Person person in people)
                {
                    if (person is Lecturer && person.gender=="male")
                    {
                        Lecturer lec = (Lecturer)person;
                        lecturers.Add(lec);
                    }
                }
                dataGridView.DataSource = lecturers;
                dataGridView.AutoGenerateColumns = true;

            }
            else if ((comboQueries.SelectedIndex == 3))//students above age of 25
            {
                dataGridView.DataSource = null;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                List<Student> students = new List<Student>();
                foreach (Person person in people)
                {
                    if (person is Student && person.Age>=25)
                    {
                        Student student = (Student)person;
                        students.Add(student);
                    }
                }
                dataGridView.DataSource = students;
                dataGridView.AutoGenerateColumns = true;
            }
            else if (comboQueries.SelectedIndex == 4)//Lecturers Paid more than 100,000
            {
                dataGridView.DataSource = null;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                List<Lecturer> lecturers = new List<Lecturer>();
                foreach (Person person in people)
                {
                    if (person is Lecturer)
                    {
                        Lecturer lec = (Lecturer)person;
                        if (lec.Pay >= 100000)
                        {
                            lecturers.Add(lec);
                        }
                        
                    }
                }
                dataGridView.DataSource = lecturers;
                dataGridView.AutoGenerateColumns = true;
            }
            else if (comboQueries.SelectedIndex == 5)//all students from oregon county
            {
                dataGridView.DataSource = null;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                List<Student> students = new List<Student>();
                foreach (Person person in people)
                {
                    if (person is Student && person.County == "Oregon")
                    {
                        Student student = (Student)person;
                        students.Add(student);
                    }
                }
                dataGridView.DataSource = students;
                dataGridView.AutoGenerateColumns = true;
            }
        }
    }
}
