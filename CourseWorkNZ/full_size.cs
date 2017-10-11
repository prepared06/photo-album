using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWorkNZ
{
    public partial class full_size : Form
    {
        public full_size()
        {
            InitializeComponent();
        }
        public full_size(string path)
        {
            InitializeComponent();
            //используем класс FileInfo для того чтобы узнать имя файла
            //Use the FileInfo class to find out the file name
            FileInfo checkThis = new FileInfo(path);
            //имя файла выводим в название формы
            //he name of the file is output in the form name
            this.Text = checkThis.Name;
            //передаем в pictureBox путь к файлу
            //we pass in the pictureBox path to the file
            this.pictureBox1.ImageLocation = path;
        }
    }
}
