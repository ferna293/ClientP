using ClientP.DbContext;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ClientP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetList();
        }

        public void GetList()
        {
            using (pclientEntities db = new pclientEntities())
            {
                var listClient = from n in db.client
                                 select n;
                dataGridView1.DataSource = listClient.ToList();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ModelsForm.FormClient formClient = new ModelsForm.FormClient();
            formClient.ShowDialog();
            GetList();
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                ModelsForm.FormClient formClient = new ModelsForm.FormClient(id);
                formClient.ShowDialog();

                GetList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                using (pclientEntities db = new pclientEntities())
                {
                    client pclient = db.client.Find(id);
                    db.client.Remove(pclient);

                    db.SaveChanges();
                }
                GetList();
            }
        }
    }
}