using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
namespace XMLStudentManSystem
{
    public class XMLManager
    {
        XmlDocument xmldoc;
        //构造函数
        public XMLManager()
        {
            xmldoc = new XmlDocument();
            //如果存在就导入 不存在就创建
            if (!File.Exists("data.xml"))
            {
                CreateRoot();
            }
            else {
                xmldoc = new XmlDocument();
                xmldoc.Load("data.xml");
            }
            
        }
        //创建root结点
        public void CreateRoot()
        {

            XmlElement rootElm = xmldoc.CreateElement("root");
            xmldoc.AppendChild(rootElm);
            xmldoc.Save("data.xml");
        }
        //添加结点
        public void addStudent(Student stu)
        {
            //创建学生元素结点
            XmlElement stuelem= this.xmldoc.CreateElement("Student");
            //创建子元素结点
            XmlElement nameelem = this.xmldoc.CreateElement("Name");
            XmlElement sexeelem = this.xmldoc.CreateElement("Sex");
            XmlElement ageeelem = this.xmldoc.CreateElement("Age");
            //设置属性结点
            stuelem.SetAttribute("ID", Convert.ToString(stu.Id));
            //设置各个元素结点的innnerText
            nameelem.InnerText = stu.Name;
            sexeelem.InnerText = stu.Sex == 1 ? "男" : "女";
            ageeelem.InnerText = Convert.ToString(stu.Age);
            //把子元素结点加在学生元素结点上
            stuelem.AppendChild(nameelem);
            stuelem.AppendChild(sexeelem);
            stuelem.AppendChild(ageeelem);
            //把学生结点加在根结点上
            xmldoc.DocumentElement.AppendChild(stuelem);
            xmldoc.Save("data.xml");

        }
        //查询所有学生
        public List<Student> selectAll()
        {
            XmlElement elem = null;
            List<Student> liststu = new List<Student>();
            XmlElement rootElem = xmldoc.DocumentElement;
            XmlNodeList nodelist=  rootElem.GetElementsByTagName("Student");
            for (int i = 0; i < nodelist.Count; i++)
            {
                Student stu = new Student();
                string strid= nodelist[i].Attributes["ID"].Value;
                stu.Id = Convert.ToInt32(strid);
                XmlElement childs = (XmlElement)nodelist[i];//XmlElement是XMLNode的子类 (注意)
                stu.Name = childs.GetElementsByTagName("Name")[0].InnerText;
                stu.Age = Convert.ToInt32(childs.GetElementsByTagName("Age")[0].InnerText);
                stu.Sex = childs.GetElementsByTagName("Sex")[0].InnerText == "男" ? 1 : 0;
                liststu.Add(stu);
            }
            return liststu;
        }
        //删除
        public bool delete(int id)
        {
            XmlElement elem = null;
            List<Student> liststu = new List<Student>();
            XmlElement rootElem = xmldoc.DocumentElement;
            XmlNodeList nodelist = rootElem.GetElementsByTagName("Student");
            for (int i = 0; i < nodelist.Count; i++)
            {
                int idattr = Convert.ToInt32(nodelist[i].Attributes["ID"].Value);
                if (idattr == id)
                {
                    xmldoc.DocumentElement.RemoveChild(nodelist[i]);
                    xmldoc.Save("data.xml");
                    return true;
                }
            }
            return false;
        }
    }
}
