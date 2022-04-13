using MyUserBook.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUserBook.Controller
{
    public class LogsController
    {

        public List<Model.Log> logs { get; private set; }

        public LogsController ()
        {
            logs = Run();
        }

        private List<Log> Run()
        {
          
            try
            {
                using (FileStream fs = new FileStream("logs.Json", FileMode.OpenOrCreate))
                {
                    // выделяем массив для считывания данных из файла
                    byte[] buffer = new byte[fs.Length];
                    // считываем данные
                     fs.Read(buffer, 0, buffer.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(buffer);

                    if(textFromFile != null)
                    {
                        var logsObj = JsonConvert.DeserializeObject<List<Model.Log>>(textFromFile);
                      
                        if (logsObj != null)
                        {
                            return logsObj.ToList();
                        }
                        else
                            return new List<Log>();
                    }
                    else
                    {
                        return new List<Log>();
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<Log>();
            }
        }


        public void Save()
        {
            try
            {
                using (FileStream fs = new FileStream("logs.Json", FileMode.OpenOrCreate))
                {
                    string jsLogs = JsonConvert.SerializeObject(logs);
                    byte[] buffer = Encoding.Default.GetBytes(jsLogs);
                    // запись массива байтов в файл
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddLog (Log log)
        {
            int id = 0;
            if(logs.Count >0)
            {
                id = logs.Max(x => x.Id);
            }
            id++;
            log.Id = id;
            logs.Add(log);
            Save();
        }
    }
}
