using ClientP.DbContext;
using System;
using System.Windows.Forms;

namespace ClientP.ModelsForm
{
    public partial class FormClient : Form
    {
        public int? id;
        public client pclient { get; set; }

        public FormClient(int? id = null)
        {
            InitializeComponent();

            this.id = id;
            if (id != null)
            {
                Data_Load();
            }
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
        }

        private void Data_Load()
        {
            using (pclientEntities db = new pclientEntities())
            {
                pclient = db.client.Find(id);
                textBox1.Text = pclient.first_name;
                textBox2.Text = pclient.second_name;
                textBox3.Text = pclient.last_name;
                textBox4.Text = pclient.second_last_name;
                textBox5.Text = pclient.address;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (pclientEntities db = new pclientEntities())
            {
                if (id == null)
                    pclient = new client();

                pclient.first_name = textBox1.Text;
                pclient.second_name = textBox2.Text;
                pclient.last_name = textBox3.Text;
                pclient.second_last_name = textBox4.Text;
                pclient.address = textBox5.Text;

                if (id == null)
                    db.client.Add(pclient);
                else
                {
                    db.Entry(pclient).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
                Close();
            }
        }
    }
}