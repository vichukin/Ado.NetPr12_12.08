using Ado.NetPr12_12._08.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ado.NetPr12_12._08
{
    public partial class CategoryForm : Form
    {
        private Category category;
        public bool isEdit = false;
        string ConnStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Newsletter;Integrated Security=True;";

        public CategoryForm(Category category)
        {
            InitializeComponent();
            if (category == null)
                this.category = new Category();
            else
            {
                this.category = category;
                isEdit = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string c = textBox1.Text;
            if (isEdit)
            {
                category.Name = c;
                using (var connection = new SqlConnection(ConnStr))
                {
                    string query = "Update Category Set Name=@Name where Id = @Id";
                    await connection.ExecuteAsync(query, category);
                }
            }
            else
            {
                category.Name = c;
                using (var connection = new SqlConnection(ConnStr))
                {
                    string query = "Insert into Category values (@Name)";
                    await connection.ExecuteAsync(query, category);
                }
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            category = null;
            Close();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            if (isEdit)
                textBox1.Text = category.Name;
        }
    }
}
