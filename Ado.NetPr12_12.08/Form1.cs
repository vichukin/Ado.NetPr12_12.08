using Ado.NetPr12_12._08.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ado.NetPr12_12._08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string ConnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Newsletter;Integrated Security=True;";
        private async void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select P.Id,P.Name,P.DateOfBirth,P.Sex,P.Email,P.City,C.Name as 'CountryName' from People P join Country C on P.CountryId= C.Id";
                var buf = await connection.QueryAsync<People>(query);
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select P.Email from People P";
                var buf = await connection.QueryAsync<EmailAddress>(query);
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select * from Category C";
                var buf = await connection.QueryAsync<Category>(query);
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select P.Name from Sales S join Product P on P.Id = S.ProductId";
                var buf = await connection.QueryAsync(query);
                buf = buf.Select(t => new { Name = t.Name });
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select P.City from People P";
                var buf = (await connection.QueryAsync(query)).Select(t => new { City = t.City });
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select * from Country C";
                var buf = await connection.QueryAsync<Country>(query);
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = $"Select P.Id,P.Name,P.DateOfBirth,P.Sex,P.Email,P.City,C.Name as 'CountryName' from People P join Country C on P.CountryId= C.Id where P.City = N'{textBox1.Text}'";
                var buf = await connection.QueryAsync<People>(query);
                dataGridView1.DataSource = buf.ToList();
            }

        }

        private async void button8_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = $"Select P.Id,P.Name,P.DateOfBirth,P.Sex,P.Email,P.City,C.Name as 'CountryName' from People P join Country C on P.CountryId= C.Id where C.Name = N'{textBox2.Text}'";
                var buf = await connection.QueryAsync<People>(query);
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = $"Select S.Id, P.Name as 'ProductName', C.Name as 'CountryName', S.Start,S.[End] from Sales S join Country C on S.CountryId = C.Id join Product P on S.ProductId = P.Id where C.Name = N'{textBox3.Text}'";
                var buf = await connection.QueryAsync<Sales>(query);
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select P.Id,P.Name,P.DateOfBirth,P.Sex,P.Email,P.City,C.Name as 'CountryName' from People P join Country C on P.CountryId= C.Id";
                var buf = await connection.QueryAsync<People>(query);

                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select * from Country C";
                var buf = await connection.QueryAsync<Country>(query);
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button22_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select * from Category C";
                var buf = await connection.QueryAsync<Category>(query);
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = $"Select S.Id, P.Name as 'ProductName', C.Name as 'CountryName', S.Start,S.[End] from Sales S join Country C on S.CountryId = C.Id join Product P on S.ProductId = P.Id";
                var buf = await connection.QueryAsync<Sales>(query);
                dataGridView1.DataSource = buf.ToList();
            }
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            using (var connection = new SqlConnection(ConnStr))
            {
                foreach (DataGridViewRow row in rows)
                {
                    var id = row.Cells[0].Value;
                    string query = $"Delete from People where id={id}";
                    await connection.ExecuteAsync(query);
                }
                button13_Click(sender, e);
            }
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            using (var connection = new SqlConnection(ConnStr))
            {
                foreach (DataGridViewRow row in rows)
                {
                    var id = row.Cells[0].Value;
                    string query = $"Delete from Country where id={id}";
                    await connection.ExecuteAsync(query);
                }
                button14_Click(sender, e);
            }
        }

        private async void button19_Click(object sender, EventArgs e)
        {

            var rows = dataGridView1.SelectedRows;
            using (var connection = new SqlConnection(ConnStr))
            {
                foreach (DataGridViewRow row in rows)
                {
                    var id = row.Cells[0].Value;
                    string query = $"Delete from Sales where id={id}";
                    await connection.ExecuteAsync(query);
                }
                button18_Click(sender, e);
            }
        }

        private async void button23_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var rows = dataGridView1.SelectedRows;
                using (var connection = new SqlConnection(ConnStr))
                {
                    foreach (DataGridViewRow row in rows)
                    {
                        var id = row.Cells[0].Value;
                        string query = $"Delete from Category where id={id}";
                        await connection.ExecuteAsync(query);
                    }
                    button22_Click(sender, e);
                }
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            PeopleForm form = new PeopleForm(null);
            form.ShowDialog();
            button13_Click(sender, e);
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                var id = row.Cells[0].Value;


                using (var connection = new SqlConnection(ConnStr))
                {
                    string query = "Select P.Id,P.Name,P.DateOfBirth,P.Sex,P.Email,P.City,C.Name as 'CountryName' from People P join Country C on P.CountryId= C.Id where P.Id = @id";
                    var buf = new { id = id };
                    People peop = (await connection.QueryAsync<People>(query, buf)).First();
                    PeopleForm form = new PeopleForm(peop);
                    form.ShowDialog();
                    button13_Click(sender, e);
                }
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            CountryForm form = new CountryForm(null);
            form.ShowDialog();
            button14_Click(sender, e);
        }

        private async void button16_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                var id = row.Cells[0].Value;




                using (var connection = new SqlConnection(ConnStr))
                {
                    string query = "Select * from Country Where Id = @Id";
                    var buf = new { Id = id };
                    Country count = (await connection.QueryAsync<Country>(query, buf)).First();
                    CountryForm form = new CountryForm(count);
                    form.ShowDialog();
                }
                button14_Click(sender, e);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            CategoryForm form = new CategoryForm(null);
            form.ShowDialog();
            button22_Click(sender, e);
        }

        private async void button24_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                var id = row.Cells[0].Value;

                using (var connection = new SqlConnection(ConnStr))
                {
                    string query = "Select * from Category Where Id = @Id";
                    var buf = new { Id = id };
                    Category cat = (await connection.QueryAsync<Category>(query, buf)).First();
                    CategoryForm form = new CategoryForm(cat);
                    form.ShowDialog();
                }
                button22_Click(sender, e);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SalesForm form = new SalesForm(null);
            form.ShowDialog();
            button18_Click(sender, e);
        }

        private async void button20_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                var id = row.Cells[0].Value;

                using (var connection = new SqlConnection(ConnStr))
                {
                    string query = "Select * from Sales Where Id = @Id";
                    var buf = new { Id = id };
                    SalesModel sales = (await connection.QueryAsync<SalesModel>(query, buf)).First();
                    SalesForm form = new SalesForm(sales);
                    form.ShowDialog();
                }
                button18_Click(sender, e);
            }
        }

        private async void button27_Click(object sender, EventArgs e)
        {
            string text = textBox5.Text;
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select C.Name From PeopleCategory PC join Category C on PC.CategoryId = C.Id join People P on PC.PeopleId = P.Id where P.Name=@Name";
                var buf = new { Name = text };
                var list = await connection.QueryAsync(query, buf);
                list = list.Select(x => new { Name = x.Name }).ToList();
                dataGridView1.DataSource = list;
            }
        }

        private async void button26_Click(object sender, EventArgs e)
        {
            string text = textBox4.Text;
            using (var connection = new SqlConnection(ConnStr))
            {
                string query = "Select  S.Id, P.Name as 'ProductName', C.Name as 'CountryName', S.Start,S.[End] from Sales S join Product P on S.ProductId = P.Id join Category C on P.CategoryId = C.Id Where C.Name = @Name";
                var buf = new { Name = text };
                var list = await connection.QueryAsync<Sales>(query, buf);
                dataGridView1.DataSource= list.ToList();
            }

        }
    }
}