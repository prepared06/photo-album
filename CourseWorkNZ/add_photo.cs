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
    public partial class add_photo : Form
    {
        public add_photo()
        {
            InitializeComponent();
        }
        //конструктор с параметрами, передаем в конструктор сылку на объект класса OpenFileDialog
        //constructor with parameters, pass it to the constructor on the object of the class OpenFileDialog
        public add_photo(OpenFileDialog ob)//
        {
            InitializeComponent();
            //используем экземпляр класса FileInfo для того чтобы узнать  данные о файле, 
            //имя с путем и расширением которого передали ему параметром
            //use an instance of the FileInfo class to find out information about the file, 
            //the name with the path and extension of which was passed to it by the parameter
            FileInfo checkThis = new FileInfo(ob.FileName);
            //в свойство даты передаем ссылку на данные о дате создания файла
            //in the date property, we pass a link to the date of the file creation
            DATA_CREATION = checkThis.CreationTime;
            //имя файла с расширением передаем в первое поле
            //the file name with the extension is passed to the first field
            textBox1.Text = checkThis.Name;
            //год создания файла передается во второе поле
            //the year the file is created is passed to the second field
            textBox2.Text = Convert.ToString(DATA_CREATION.Year);
            //месяц создание файла передается в третье поле
            //month the creation of the file is transferred to the third field
            textBox3.Text = Convert.ToString(DATA_CREATION.Month);
            //день создание файла передается в четвёртое поле
            //day the file creation is transferred to the fourth field
            textBox4.Text = Convert.ToString(DATA_CREATION.Day);
            //час создание файла передается в пятое поле
            //hour the creation of the file is transferred to the fifth field
            textBox5.Text = Convert.ToString(DATA_CREATION.Hour);
            //минута создание файла передается в шестое поле
            //minute the creation of the file is transferred to the sixth field
            textBox6.Text = Convert.ToString(DATA_CREATION.Minute);
            //секунда создание файла передается в седьмое поле
            //second the creation of the file is transferred to the seventh field
            textBox7.Text = Convert.ToString(DATA_CREATION.Second);
        }
        //свойство даты создания файла
        // the property of the date the file was created
        public DateTime DATA_CREATION { get; set; }
        //свойство имени для возможности переименовать поле имени и возврата данных из формы
        //name property for the ability to rename the name field and return data from the form
        public string name_of_file { get; set; }
        //кнопка ОТМЕНА
        //CANCEL button
        private void button2_Click(object sender, EventArgs e)
        {
            //закрываем форму
            //close the form
            this.Close();//закрываем форму
        }
        //кнопка ОК
        //OK button
        private void button1_Click(object sender, EventArgs e)
        {
            //строка, которая отвечает за возможность поменять имя файла или же оставить его прежним
            //a string that is responsible for the ability to change the name of the file or leave it as before
            name_of_file = textBox1.Text;
            //закрываем форму
            //close the form
            this.Close();
        }
    }
}
