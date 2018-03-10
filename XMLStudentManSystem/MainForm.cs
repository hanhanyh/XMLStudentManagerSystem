using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace XMLStudentManSystem
{
    public partial class MainForm : Form
    {
  
        public MainForm()
        {
            InitializeComponent();
          
            //  xm.addStudent(new Student("邱宇涵", 20, 1, 11000));
            // xm.selectAll();
            //xm.delete(11000);
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void 新增学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new addForm(this).Show();
        }
        public void Bind()
        {
            this.dataGridView1.Rows.Clear();
           XMLManager xmr = new XMLManager();
            List<Student> stus= xmr.selectAll();
            for (int i =0; i < stus.Count; i++)
            {
               int index= this.dataGridView1.Rows.Add();
               this.dataGridView1.Rows[index].Cells[0].Value=Convert.ToString( stus[i].Id);
               this.dataGridView1.Rows[index].Cells[1].Value = Convert.ToString(stus[i].Name);
              this.dataGridView1.Rows[index].Cells[2].Value = Convert.ToString(stus[i].Age);
              this.dataGridView1.Rows[index].Cells[3].Value = Convert.ToString(stus[i].Sex==1?"男":"女");

            }
        }

     
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           int index= this.dataGridView1.CurrentRow.Index;
           int id=Convert.ToInt32( this.dataGridView1.Rows[index].Cells[0].Value);
            XMLManager xmr = new XMLManager();
            xmr.delete(id);
            Bind();
        }
    }
}
