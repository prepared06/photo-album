using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

namespace CourseWorkNZ
{
    public class Photo_List
    {   //счётчик//counter for counting files 
        int count = 0;
        //сериализатор для записи данных, с целью их дальнейшего востановления
        //a serializer for writing data, in order to further restore it
        XmlSerializer ser = new XmlSerializer(typeof(List<Photo>));
        //колекция "лист" для сохранения данных о файлах
        //collection list for saving data about files
        List<Photo> album = new List<Photo>();
        //свойство счётчика, которое используют для названий метаданных(предоставления им индекса)
        //the property of the counter, which is used for metadata names (giving them an index)
        public string COUNT { get {return Convert.ToString(count); } }
        //целочисленное свойство счётчика
        //integer counter property
        public int COUNT_int { get { return count; } }
        //метод для добавления фото
        //method for adding photos
        public void add(string N, string P, DateTime D, string PS, DataGridView dg)
        {
            //сперва добавляем файл в колекцию "лист"
            //first add the file to the collection "list"
            album.Add(new Photo(N, P, D, PS));
            //потом выводим в форму(в dataGrigView) данные которые только что занесли в "список"
            // then output to the form(in dataGrigView) the data that has just been added to the "list"
            dg.Rows.Add(album[album.Count - 1].Name, album[album.Count - 1].Data.ToString() );
            //инкрементируем счётчик
            //increment the counter
            count++;
        }
        //метод для обновления dataGrigView
        //method for updating dataGridView
        public void show(DataGridView dg)
        {
            //очистка стырых данных
            // clear old data
            dg.Rows.Clear();
            for (int i = 0; i < album.Count; i++)
            {
                //выводим обновленные данные dataGridView
                // output updated dataGridView
                dg.Rows.Add(album[i].Name, album[i].Data.ToString());
            }
        }
        //метод удаления файла из колекции "лист"
        // method of deleting a file from the "list" collection
        public void del(int i)
        {
            album.RemoveAt(i);
            count--;
        }
        //метод записи в файл(в качестве параметра бёрет адрес к файлу)
        // method of writing to a file(the address to the file is lost as a parameter)
        public void record(string f)//берёт адресс
        {
            FileStream file;
            //открываем поток
            //open the stream
            file = new FileStream(f, FileMode.Create, FileAccess.Write, FileShare.None);
            //сериализация в файл из колекции "лист"
            // serialize to a file from the "list" collection
            ser.Serialize(file, album);
            //закрываем поток
            //close the stream
            file.Close();
        }
        //метод чтения из файла(в качестве параметра бёрет адрес к файлу)
        //method of reading from a file(the address to the file is lost as a parameter)
        public void reading(string f)
        {
            FileStream file;
            //открываем поток
            //open the stream
            file = new FileStream(f, FileMode.Open, FileAccess.Read, FileShare.None);
            //считываем данные из файла в "лист"
            // read the data from the file into the "list"
            album = (List<Photo>)ser.Deserialize(file);
            //закрываем поток
            //close the stream
            file.Close();
            //записываем количество элементов
            // write the number of elements
            count = album.Count;
        }
        //метод возвращает расположение файла картинки
        // method returns the location of the image file
        public string PATH_OF_PHOTO(int index)
        {
            return album[index].Path;
        }
        //метод возвращает название картинки
        // method returns the name of the picture
        public string NAME_OF_PHOTO(int index)
        {
            return album[index].Name;
        }
        //метод возвращает дату создания картинки
        // method returns the date the picture was created
        public DateTime DATE_OF_PHOTO(int index)
        {
            return album[index].Data;
        }
        //метод устанавливает новое имя картинки
        // the method sets the new name of the image
        public void NAME_OF_PHOTO(int index, string nam)
        {
            album[index].Name = nam;
        }
        //метод поиска пути к файлу по его имени
        // method to find the path to a file by its name
        public string search(string name_param)
        {
            // просматриваем все элементы контейнера List
            //browse all the items in the "List" container
            for (int i = 0; i < count; i++)
            {
                //сравниваем по именам
                //compare by name
                if (name_param == album[i].Name)
                {
                    return album[i].Path;//возвращаем находку//return the found file
                }
            }
            return null;//или нулл//or return null
        }

        
        
    }
}
