using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLStudentManSystem
{
    public partial class addForm : Form
    {
        MainForm _f;
        public addForm(MainForm f)
        {
            InitializeComponent();
            _f = f;
            this.comboBox1.SelectedIndex = 0;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (this.txtage.Text == "" || txtid.Text == "" || txtname.Text == "" )
            {
                MessageBox.Show("您还有什么没有填写！");
                return;
            }
            Student stu = new Student();
            stu.Age = Convert.ToInt32(this.txtage.Text);
            stu.Name = txtname.Text;
            stu.Sex = comboBox1.SelectedIndex;
            stu.Id = Convert.ToInt32(txtid.Text);
            XMLManager xm = new XMLManager();
            xm.addStudent(stu);
            _f.Bind();
            MessageBox.Show("添加成功");
            
            this.Close();
          //  stu.
        }
    }
}
