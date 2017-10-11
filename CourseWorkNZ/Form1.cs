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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //разрешение редакции dataGridView
            //dataGridView edition permission
            this.dataGridView1.EditMode = DataGridViewEditMode.EditOnF2;
        }
        //объявляем новый список(точнее класс обертку с контейнером "лист")
        // declare a new list (more precisely, the wrapper class with the "list" container)
        Photo_List lister = new Photo_List();
        //кнопка добавления картинки
        //button of adding pictures
        private void button1_Click(object sender, EventArgs e)
        {
            /*
             *тут объявляются локальные переменные для захвата данных из формы "add_photo"
             * here local variables are declared to capture data from the form "add_photo"
            */
            //переменная для имени
            //variable for name
            string name;
            //переменная для сохранения пути к файлу
            //variable to save the path to the file
            string path;
            //переменная для хранения даты создания
            // variable to store the creation date
            DateTime data;
            //переменная для сохранения пути к файлу метаданных
            // variable to store the path to the metadata file
            string PD;
            //Запрос на открытие стандартного меню выбора файла "openFileDialog"
            //Request to open the standard file selection menu "openFileDialog"
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //создаем новую форму для возможности переименовать картинку
                //в качестве параметра передаем сылку на объект openFileDialog1, для получения пути к файлу
                // create a new form for the ability to rename the image
                //as a parameter, we pass the link to the openFileDialog1 object, to get the path to the file
                add_photo ob = new add_photo(openFileDialog1);
                try
                {
                    //если на форме "add_photo" нажали "ОК"
                    // if you clicked "OK" on the "add_photo" form
                    if (ob.ShowDialog() == DialogResult.OK)
                    {
                        //забираем ссылку на файл из формы
                        //we take the link to the file from the form
                        path = openFileDialog1.FileName;
                        //забираем имя файла, которое ввел пользователь или которое было у файла
                        //take the name of the file that the user entered or that was on the file
                        name = ob.name_of_file;
                        //берем дату создания
                        //we take the creation date
                        data = ob.DATA_CREATION;
                        //берем ссылку расположения файла
                        //we take the creation date
                        PD = openFileDialog1.FileName;
                        //удаляем из пути имя файла и вставляем шаблон имени метафайла                                                                
                        //remove the file name from the path and insert the metafile name template
                        PD = PD.Replace(openFileDialog1.SafeFileName, "meta" + lister.COUNT + ".txt");
                        //метод записи метаданных
                        //metadata recording method
                        metafile(name, data, PD);
                        //добавляем в колекцию "list" файл
                        //add to the collection "list" file
                        lister.add(name, path, data, PD, dataGridView1);
                    }
                }
                //если ловим эксепшн по причине неверно введенных данных
                //If we catch an error because of incorrectly entered data
                catch (FormatException)
                {
                    //то  выводим это сообщение
                    //then output this message
                    MessageBox.Show("Не верные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        //метод записи метаданных(реализация)
        //metadata recording method (implementation)
        private void metafile(string name, DateTime data, string PD)
        {
            //создаем поток данных для записи в метафайл
            //create a data stream to write to the metafile
            using (StreamWriter sw = new StreamWriter(PD, false, System.Text.Encoding.Default))
            {
                //имя файла пишем в файл
                //file name is written to file
                sw.WriteLine("Имя файла: " + name);
                //пишем дату создания в файл
                //write the creation date in a file
                sw.WriteLine("Дата и время создания: " + data.ToString());
                //закрываем поток
                //close thread
                sw.Close();
            }
        }
        //кнопка удаление из списка
        //button delete from the list
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //получаем индекс выбранного ряда
                //get the index of the selected row
                int i = dataGridView1.CurrentRow.Index;
                //удаляем выбранный ряд(объект коллекции "list" из объекта Photo_List) из списка
                //delete the selected row (the "list" collection object from the Photo_List object) from the list
                lister.del(i);
                //выводим новый список
                //output a new list
                lister.show(dataGridView1);
            }
            //если нечего удалять
            //if there is nothing to delete
            catch
            {
                //то  выводим это сообщение
                //then output this message
                MessageBox.Show("Нечего удолять", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //кнопка запись
        //button record
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //выбираем куда и как записать
                //choose where and how to write
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //вызываем метода записи, передаем ему путь
                    //We call the recording method, we pass it the path
                    lister.record(saveFileDialog1.FileName);
                }
            }
            //если ловим екзепшн
            //if we catch exception
            catch
            {
                //то выводим данное сообщение
                //then output this message
                MessageBox.Show("Ошибка при записи в файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //кнопка загрузка
        //button download
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //Запрос на открытие стандартного меню выбора файла "openFileDialog"
                //Request to open the standard file selection menu "openFileDialog"
                if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //вызываем метод чтения из файла, который заполняет коллекцию "list" внутри объекта Photo_List
                    //we call the read method from a file that fills the "list" collection inside the Photo_List object
                    lister.reading(openFileDialog2.FileName);
                    //выводим данные на экран
                    //display the data on the screen
                    lister.show(dataGridView1);
                }
            }
            //если ловим екзепшн
            //if we catch exception
            catch
            {
                //то выводим данное сообщение
                //then output this message
                MessageBox.Show("Ошибка при чтении из файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //событие клика по хедеру строки которое выводит картинку в превью
        //click event on the header of the line that displays the picture in the preview
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //получаем индекс выбранного ряда
                //get the index of the selected row
                int i = dataGridView1.CurrentRow.Index;
                //выводим новое фото в pictureBox 
                //print a new photo in the pictureBox
                pictureBox1.Image = new Bitmap(lister.PATH_OF_PHOTO(i));
            }
            //в случае клика по хедеру пустой строки ловим исключение
            //In the case of a click on an empty line, we catch the exception
            catch (ArgumentOutOfRangeException)
            {
                //выводим данное сообщение
                //output this message
                MessageBox.Show("Пустая строка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);//выводим данное сообщение
            }
        }
        //событие двойного клика по хедеру строки которое выводит картинку в новое окно
        //Double click event on the line header that displays the picture in a new window
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //получаем индекс выбранного ряда
            //get the index of the selected row
            int i = dataGridView1.CurrentRow.Index;
            //инициализируем новую форму, передаем ей параметром путь к фото которе надо вывести
            //initialize a new form, pass it a parameter to the path on the photo which should be output
            full_size ob = new full_size(lister.PATH_OF_PHOTO(i));
            //показываем форму
            //show the form
            ob.Show();
        }
        //нажатие на кнопку "Поиск"
        //click on the "Search" button
        private void button6_Click(object sender, EventArgs e)
        {
            //Объявляем экземпляр формы с параметром объекта класса Photo_List
            //Declare a form instance with the object's parameter of the Photo_List class
            search bob = new search(lister);
            //выводим форму
            //derive the form
            bob.Show();
        }
        //событие для окончание редакции ячейки
        //event to end the revision of the cell
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //получаем индекс выбранного ряда
                //get the index of the selected row
                int ind = dataGridView1.CurrentRow.Index;
                //вытаскиваем имя файла выбранной строки
                //extract the file name of the selected line
                string name = (string)dataGridView1[0, ind].Value;
                //метод для смены инкапсулированного поля имени
                //method for changing the encapsulated name field
                lister.NAME_OF_PHOTO(ind, name);
            }
            //исключения для случая попытки редактирования не существующей ячейки
            //Exceptions for an attempt to edit an existing cell
            catch (ArgumentOutOfRangeException)
            {
                //выводим данное сообщение
                //output this message
                MessageBox.Show("Пустуя строку недопустимо редактировать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
