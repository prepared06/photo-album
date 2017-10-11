using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkNZ
{
    public class Photo
    {
        string name;//название фото//name of file
        string path;//ссылка на файл//the path to the file
        DateTime data;//дата и время создания фото//date and time of photo creation
        string path_description;//ссылка на файл с описанием(метаданные)//the path to the metadata
        //свойства полей//field properties
        public string Name { get { return name; } set { name = value; } }
        public string Path { get { return path; } set { path = value; } }
        public DateTime Data { get { return data; } set { data = value; } }
        public string Path_Description { get { return path_description; } set { path_description = value; } }
        //конструктора//constructors
        public Photo()//конструктор по умолчанию//default constructor
        {
            name = null;
            path = null;
            data = new DateTime(2010, 8, 18, 16, 32, 0);
            path_description = null;
        }
        //конструктор с параметрами//constructor with parameters
        public Photo(string N, string P, DateTime D,string PS)
        {
            name = N;
            path = P;
            data = D;
            path_description = PS;
        }


    }
}
