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
    public partial class CountryForm : Form
    {
        private Country country;
        public bool isEdit = false;
        string ConnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Newsletter;Integrated Security=True;";

        public CountryForm(Country country)
        {
            InitializeComponent();
            if (country == null)
                this.country = new Country();
            else
            {
                this.country = country;
                isEdit = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string c = textBox1.Text;
            if (isEdit)
            {
                country.Name = c;
                using (var connection = new SqlConnection(ConnStr))
                {
                    string query = "Update Country Set Name=@Name where Id = @Id";
                    await connection.ExecuteAsync(query, country);
                }
            }
            else
            {
                Country buf = new Country() { Name = c };
                using (var connection = new SqlConnection(ConnStr))
                {
                    string query = "Insert into Country values (@Name)";
                    await connection.ExecuteAsync(query, buf);
                }
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            country = null;
            Close();
        }

        private void CountryForm_Load(object sender, EventArgs e)
        {
            if(isEdit)
            {
                textBox1.Text = country.Name;
            }
        }
    }
}
