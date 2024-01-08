using Ado.NetPr12_12._08.Models;
using Dapper;
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

namespace Ado.NetPr12_12._08
{
    public partial class PeopleForm : Form
    {
        string ConnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Newsletter;Integrated Security=True;";
        People people = null;
        bool isEdit = false;
        public PeopleForm(People people)
        {
            if (people == null)
                this.people = new People();
            else
            {
                this.people = people;
                isEdit = true;
            }

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            people = null;
            Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var email = textBox2.Text;
            var city = textBox3.Text;
            var date = dateTimePicker1.Value;
            int country = int.Parse(comboBox2.SelectedValue.ToString());
            string sex = comboBox1.SelectedItem.ToString();
            if(!isEdit)
            {
                var user = new { Name = name, DateOfBirth = date, Sex = sex, Email = email, CountryId = country, City = city };
                using (var connection = new SqlConnection(ConnStr))
                {

                    string query = "Insert into People Values (@Name,@DateOfBirth,@Sex,@Email,@CountryId,@City)";
                    await connection.ExecuteAsync(query, user);
                }
            }
            else
            {
                var user = new { Id =people.Id, Name = name, DateOfBirth = date, Sex = sex, Email = email, CountryId = country, City = city };
                using (var connection = new SqlConnection(ConnStr))
                {

                    string query = "UPDATE People SET Name = @Name, DateOfBirth = @DateOfBirth, Sex = @Sex, Email = @Email, CountryId = @CountryId, City = @City WHERE Id = @Id";
                    await connection.ExecuteAsync(query, user);
                }
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private async void PeopleForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            int index = 0;
            List<Country> list = new List<Country>();
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select * from Country C";
                list = (await connection.QueryAsync<Country>(query)).ToList();
                comboBox2.DataSource = list;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                comboBox2.SelectedIndex = 0;
            }
            if(isEdit)
            {
                textBox1.Text = people.Name;
                textBox2.Text = people.Email;
                textBox3.Text = people.City;
                dateTimePicker1.Value = people.DateOfBirth;
                comboBox1.SelectedItem = people.Sex;
                var country = list.Where(t => t.Name == people.CountryName).First();
                comboBox2.SelectedIndex =  list.IndexOf(country);
            }
        }
    }
}
