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
    public partial class search : Form
    {
        //объект класса Photo_List для принятия параметра типа Photo_List через конструктор из класса Form1 
        //object of class Photo_List for accepting a parameter of type Photo_List through the constructor from class Form1
        Photo_List NewLister;
        public search()
        {
            InitializeComponent();
        }
        public search(Photo_List obj)
        {
            InitializeComponent();
            //присвоение локальной переменной сылки на объект lister из класса Form1
            //assigning a local variable to a lister object from Form1
            NewLister = obj;
            
        }
        //событие кнопки "поиск"
        //search button event
        private void button1_Click(object sender, EventArgs e)
        {
            //очистка старых данных
            //clear old data
            dataGridView1.Rows.Clear();
            //если выбран флажок "название"
            //if the "название"
            if (radioButton1.Checked == true)
            {
                search_name();
            }
            //если выбран флажок "год"
            //if the "год"
            if (radioButton2.Checked == true)
            {
                search_year();
            }
            //если выбран флажок "месяц"
            //if the "месяц"
            if (radioButton3.Checked == true)
            {
                search_month();
            }
            // если выбран флажок "День"
            //if the "День"
            if (radioButton4.Checked == true)
            {
                search_day();
            }
            //если выбран флажок "Час"
            //if the "час"
            if (radioButton5.Checked == true)
            {
                search_hour();
            }
            //если выбран флажок "минута"
            //if the "минута"
            if (radioButton6.Checked == true)
            {
                search_minute();
            }
            //если выбран флажок "секунда"
            //if the "секунда"
            if (radioButton7.Checked == true)
            {
                search_second();
            }
        }
        //метод поиска и вывода по имени
        //method of searching and inference by name
        private void search_name()
        {
            //считываем количество элементов коллекции "List" в объекте типа Photo_List
            //we read the number of elements of the "List" collection in the object of type Photo_List
            int count = NewLister.COUNT_int;
            //просматриваем все элементы коллекции "List" в объекте типа Photo_List
            //we scan all the elements of the "List" collection in an object of the type Photo_List
            for (int i = 0; i < count; i++)
            {
                //если в строке имени фото есть подстрока из входных данных от пользователя, то выводим имя и дату этого фото
                //If the line name of the photo has a substring from the input data from the user, then we display the name and date of this photo
                if (NewLister.NAME_OF_PHOTO(i).Contains(textBox1.Text))
                {
                    dataGridView1.Rows.Add(NewLister.NAME_OF_PHOTO(i), NewLister.DATE_OF_PHOTO(i).ToString());
                }
                
            }
        }
        //метод поиска и вывода по году
        //method of search and output by year
        private void search_year()
        {
            try
            {
                //объявляем объект класса  FileInfo
                //declare an object of the FileInfo class
                FileInfo jack;
                //экземпляр структуры DateTime
                //an instance of the DateTime structure
                DateTime jessica;
                //считываем  ввод данных пользователя
                //read user input
                int comp = Convert.ToInt32(textBox1.Text);
                //считываем количество элементов коллекции "List" в объекте типа Photo_List
                //we read the number of elements of the "List" collection in the object of type Photo_List
                int count = NewLister.COUNT_int;
                //просматриваем все элементы коллекции "List" в объекте типа Photo_List
                //we scan all the elements of the "List" collection in an object of the type Photo_List
                for (int i = 0; i < count; i++)
                {
                    //получаем данные о фото через объект класса  FileInfo
                    //get photo data through an object of the FileInfo class
                    jack = new FileInfo(NewLister.PATH_OF_PHOTO(i));
                    //передаём экземпляру DateTime данные о создании файла(здесь фото)
                    //we pass to the instance DateTime the data about the creation of the file (here the photo)
                    jessica = jack.CreationTime;
                    //сравниваем год создания и введенные данные
                    //compare the year of creation and the data entered
                    if (comp == jessica.Year)
                    {
                        //если есть совпадения выводим эти файлы
                        //if there are matches, output these files
                        dataGridView1.Rows.Add(NewLister.NAME_OF_PHOTO(i), NewLister.DATE_OF_PHOTO(i).ToString());
                    }
                }
            }
            //если ловим екзепшн
            //if we catch exception
            catch (FormatException)
            {
                //то выводим данное сообщение
                //then output this message
                MessageBox.Show("Неверные входные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);//выводим данное сообщение
            }
        }
        //метод поиска и вывода по месяцу
        //method of search and output by month
        private void search_month()
        {
            try
            {   
                //объявляем объект класса  FileInfo
                //declare an object of the FileInfo class
                FileInfo jack;
                //экземпляр структуры DateTime
                //an instance of the DateTime structure
                DateTime jessica;
                //считываем  ввод данных пользователя
                //read user input
                int comp = Convert.ToInt32(textBox1.Text);
                //считываем количество элементов коллекции "List" в объекте типа Photo_List
                //we read the number of elements of the "List" collection in the object of type Photo_List
                int count = NewLister.COUNT_int;
                //просматриваем все элементы коллекции "List" в объекте типа Photo_List
                //we scan all the elements of the "List" collection in an object of the type Photo_List
                for (int i = 0; i < count; i++)
                {
                    //получаем данные о фото через объект класса  FileInfo
                    //get photo data through an object of the FileInfo class
                    jack = new FileInfo(NewLister.PATH_OF_PHOTO(i));
                    //передаём экземпляру DateTime данные о создании файла(здесь фото)
                    //we pass to the instance DateTime the data about the creation of the file (here the photo)
                    jessica = jack.CreationTime;
                    //сравниваем месяц создания и введенные данные
                    //compare the month of creation and the data entered
                    if (comp == jessica.Month)
                    {
                        //если есть совпадения выводим эти файлы
                        //if there are matches, output these files
                        dataGridView1.Rows.Add(NewLister.NAME_OF_PHOTO(i), NewLister.DATE_OF_PHOTO(i).ToString());
                    }
                }
            }
            //если ловим екзепшн
            //if we catch exception
            catch (FormatException)
            {
                //то выводим данное сообщение
                //then output this message
                MessageBox.Show("Неверные входные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //метод поиска и вывода по дню
        //method of search and output by day
        private void search_day()
        {
            try
            {
                //объявляем объект класса  FileInfo
                //declare an object of the FileInfo class
                FileInfo jack;
                //экземпляр структуры DateTime
                //an instance of the DateTime structure
                DateTime jessica;
                //считываем  ввод данных пользователя
                //read user input
                int comp = Convert.ToInt32(textBox1.Text);
                //считываем количество элементов коллекции "List" в объекте типа Photo_List
                //we read the number of elements of the "List" collection in the object of type Photo_List
                int count = NewLister.COUNT_int;
                //просматриваем все элементы коллекции "List" в объекте типа Photo_List
                //we scan all the elements of the "List" collection in an object of the type Photo_List
                for (int i = 0; i < count; i++)
                {
                    //получаем данные о фото через объект класса  FileInfo
                    //get photo data through an object of the FileInfo class
                    jack = new FileInfo(NewLister.PATH_OF_PHOTO(i));
                    //передаём экземпляру DateTime данные о создании файла(здесь фото)
                    //we pass to the instance DateTime the data about the creation of the file (here the photo)
                    jessica = jack.CreationTime;
                    //сравниваем день создания и введенные данные
                    //compare the day of creation and the data entered
                    if (comp == jessica.Day)
                    {
                        //если есть совпадения выводим эти файлы
                        //if there are matches, output these files
                        dataGridView1.Rows.Add(NewLister.NAME_OF_PHOTO(i), NewLister.DATE_OF_PHOTO(i).ToString());
                    }
                }
            }
            //если ловим екзепшн
            //if we catch exception
            catch (FormatException)
            {
                //то выводим данное сообщение
                //then output this message
                MessageBox.Show("Неверные входные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //метод поиска и вывода по часам
        //method of searching and displaying by hour
        private void search_hour()
        {
            try
            {
                //объявляем объект класса  FileInfo
                //declare an object of the FileInfo class
                FileInfo jack;
                //экземпляр структуры DateTime
                //an instance of the DateTime structure
                DateTime jessica;
                //считываем  ввод данных пользователя
                //read user input
                int comp = Convert.ToInt32(textBox1.Text);
                //считываем количество элементов коллекции "List" в объекте типа Photo_List
                //we read the number of elements of the "List" collection in the object of type Photo_List
                int count = NewLister.COUNT_int;
                //просматриваем все элементы коллекции "List" в объекте типа Photo_List
                //we scan all the elements of the "List" collection in an object of the type Photo_List               
                for (int i = 0; i < count; i++)
                {
                    //получаем данные о фото через объект класса  FileInfo
                    //get photo data through an object of the FileInfo class
                    jack = new FileInfo(NewLister.PATH_OF_PHOTO(i));
                    //передаём экземпляру DateTime данные о создании файла(здесь фото)
                    //we pass to the instance DateTime the data about the creation of the file (here the photo)
                    jessica = jack.CreationTime;
                    //сравниваем час создания и введенные данные
                    //compare the hour of creation and the data entered
                    if (comp == jessica.Hour)
                    {
                        //если есть совпадения выводим эти файлы
                        //if there are matches, output these files
                        dataGridView1.Rows.Add(NewLister.NAME_OF_PHOTO(i), NewLister.DATE_OF_PHOTO(i).ToString());
                    }
                }
            }
            //если ловим екзепшн
            //if we catch exception
            catch (FormatException)
            {
                //то выводим данное сообщение
                //then output this message
                MessageBox.Show("Неверные входные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //метод поиска и вывода по минутам
        //method of searching and displaying by minutes
        private void search_minute()
        {
            try
            {
                //объявляем объект класса  FileInfo
                //declare an object of the FileInfo class
                FileInfo jack;
                //экземпляр структуры DateTime
                //an instance of the DateTime structure
                DateTime jessica;
                //считываем количество элементов коллекции "List" в объекте типа Photo_List
                //we read the number of elements of the "List" collection in the object of type Photo_List
                int comp = Convert.ToInt32(textBox1.Text);
                //считываем количество элементов коллекции "List" в объекте типа Photo_List
                //we read the number of elements of the "List" collection in the object of type Photo_List
                int count = NewLister.COUNT_int;
                //просматриваем все элементы коллекции "List" в объекте типа Photo_List
                //we scan all the elements of the "List" collection in an object of the type Photo_List 
                for (int i = 0; i < count; i++)
                {
                    //получаем данные о фото через объект класса  FileInfo
                    //get photo data through an object of the FileInfo class
                    jack = new FileInfo(NewLister.PATH_OF_PHOTO(i));
                    //передаём экземпляру DateTime данные о создании файла(здесь фото)
                    //we pass to the instance DateTime the data about the creation of the file (here the photo)
                    jessica = jack.CreationTime;
                    //сравниваем минуту создания и введенные данные
                    //compare the minute of creation and the data entered
                    if (comp == jessica.Minute)
                    {
                        //если есть совпадения выводим эти файлы
                        //if there are matches, output these files
                        dataGridView1.Rows.Add(NewLister.NAME_OF_PHOTO(i), NewLister.DATE_OF_PHOTO(i).ToString());
                    }
                }
            }
            //если ловим екзепшн
            //if we catch exception
            catch (FormatException)
            {
                //то выводим данное сообщение
                //then output this message
                MessageBox.Show("Неверные входные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);//выводим данное сообщение
            }
        }
        //метод поиска и вывода по секундам
        //method of searching and displaying by secundes
        private void search_second()
        {
            try
            {
                //объявляем объект класса  FileInfo
                //declare an object of the FileInfo class
                FileInfo jack;
                //экземпляр структуры DateTime
                //an instance of the DateTime structure
                DateTime jessica;
                //считываем количество элементов коллекции "List" в объекте типа Photo_List
                //we read the number of elements of the "List" collection in the object of type Photo_List
                int comp = Convert.ToInt32(textBox1.Text);
                //считываем количество элементов коллекции "List" в объекте типа Photo_List
                //we read the number of elements of the "List" collection in the object of type Photo_List
                int count = NewLister.COUNT_int;
                //просматриваем все элементы коллекции "List" в объекте типа Photo_List
                //we scan all the elements of the "List" collection in an object of the type Photo_List 
                for (int i = 0; i < count; i++)
                {
                    //получаем данные о фото через объект класса  FileInfo
                    //get photo data through an object of the FileInfo class
                    jack = new FileInfo(NewLister.PATH_OF_PHOTO(i));
                    //передаём экземпляру DateTime данные о создании файла(здесь фото)
                    //we pass to the instance DateTime the data about the creation of the file (here the photo)
                    jessica = jack.CreationTime;
                    //сравниваем секунду создания и введенные данные
                    //compare the second of creation and the data entered
                    if (comp == jessica.Second)
                    {
                        //если есть совпадения выводим эти файлы
                        //if there are matches, output these files
                        dataGridView1.Rows.Add(NewLister.NAME_OF_PHOTO(i), NewLister.DATE_OF_PHOTO(i).ToString());
                    }
                }
            }
            //если ловим екзепшн
            //if we catch exception
            catch (FormatException)
            {
                //то выводим данное сообщение
                //then output this message
                MessageBox.Show("Неверные входные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //событие клика по хедеру строки которое выводит картинку в превью
        //click event on the header of the line that displays the picture in the preview
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //получаем индекс выбранного ряда
            //get the index of the selected row
            int ind = dataGridView1.CurrentRow.Index;
            //вытаскиваем имя файла выбранной строки
            //extract the file name of the selected line
            string name = (string)dataGridView1[0, ind].Value;
            string way_to_FILE;
            //находим через метод search путь к файлу и проверяем что путь существует
            //we find through the search method the path to the file and check that the path exists
            if ((way_to_FILE = NewLister.search(name)) != null)
            {
                //выводим новое фото в pictureBox       
                //output a new photo in the pictureBox
                pictureBox1.Image = new Bitmap(way_to_FILE);    
            }

        }
        //событие двойного клика по хедеру строки которое выводит картинку в новое окно
        //Double click event on the line header that displays the picture in a new window
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // получаем индекс выбранного ряда
            //get the index of the selected row
            int ind = dataGridView1.CurrentRow.Index;
            //вытаскиваем имя файла выбранной строки
            //extract the file name of the selected line
            string name = (string)dataGridView1[0, ind].Value;
            string way_to_FILE;
            //находим через метод search путь к файлу и проверяем что путь существует
            //we find through the search method the path to the file and check that the path exists
            if ((way_to_FILE = NewLister.search(name)) != null)
            {
                //инициализируем новую форму, передаем ей параметром путь к фото которе надо вывести
                //initialize a new form, pass it to the parameter path to the photo which should be output
                full_size ob = new full_size(way_to_FILE);
                //выводим форму на экран
                //display the form on the screen
                ob.Show();
            }
            //если путя к фото нет
            //if there is no way to the photo
            else
            {
                //выводим данное сообщение
                //output this message
                MessageBox.Show("Ошибка при открытии фото!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
