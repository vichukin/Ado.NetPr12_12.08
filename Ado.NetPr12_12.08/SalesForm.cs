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
    public partial class SalesForm : Form
    {
        private  SalesModel sales;
        public bool isEdit = false;
        string ConnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Newsletter;Integrated Security=True;";
        public SalesForm(SalesModel sales)
        {
            InitializeComponent();
            if(sales == null)
            {
                this.sales = new SalesModel();
            }
            else
            {
                this.sales = sales;
                isEdit = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            sales.Start = dateTimePicker1.Value;
            sales.End = dateTimePicker2.Value;
            sales.ProductId = int.Parse(comboBox1.SelectedValue.ToString());
            sales.CountryId = int.Parse(comboBox2.SelectedValue.ToString());
            if(isEdit)
            {
                using (var connection = new SqlConnection(ConnStr))
                {
                    string query = "UPDATE Sales SET ProductId = @ProductId, CountryId = @CountryId, Start = @Start, [End] = @End WHERE Id = @Id";
                    await connection.ExecuteAsync(query, sales);
                }
            }
            else
            {
                using(var connection = new SqlConnection(ConnStr))
                {
                    string query = "Insert into Sales Values (@ProductId,@CountryId,@Start,@End)";
                    await connection.ExecuteAsync(query,sales);
                }
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sales = null;
            Close();
        }

        private async void SalesForm_Load(object sender, EventArgs e)
        {
            List<Country> list = new List<Country>();
            List<ProductVM> products = new List<ProductVM>();
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select * from Country";
                list = (await connection.QueryAsync<Country>(query)).ToList();
                comboBox2.DataSource = list;
                comboBox2.ValueMember = "Id";
                comboBox2.SelectedIndex = 0;
                comboBox2.DisplayMember = "Name";

                query = "Select Id,Name from Product";
                products = (await connection.QueryAsync<ProductVM>(query)).ToList();
                comboBox1.DataSource = products;
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedIndex = 0;
                comboBox1.DisplayMember = "Name";
            }

            if(isEdit)
            {
                dateTimePicker1.Value = sales.Start;
                dateTimePicker2.Value = sales.End;
                comboBox2.SelectedIndex = list.IndexOf(list.First(t => t.Id == sales.CountryId));
                comboBox1.SelectedIndex = products.IndexOf(products.First(t => t.Id == sales.ProductId));
            }
        }
    }
}
