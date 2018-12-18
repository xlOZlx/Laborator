using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lr_13
{
    internal class PDALog
    {
        ////    1111
        public void MethodLog()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(@"E:\\Laborator\PDAfileInfo.txt");
                fileInfo.Refresh();

                //var nameOfFile = fileInfo.Name;
                //var fullNameOfFile = fileInfo.FullName;
                //var timeOfCreate = fileInfo.CreationTime;
                //var timeOfAccess = fileInfo.LastAccessTime;
                //var existOfFile = fileInfo.Exists;

                using (StreamWriter streamWriter = new StreamWriter(@"E:\\Laborator\PDAlogfile.txt", false, Encoding.Default))
                {
                    streamWriter.WriteLine($"имя файла: {/*nameOfFile*/fileInfo.Name}");
                    streamWriter.WriteLine($"Полный путь к файлу: {/*fullNameOfFile*/fileInfo.FullName}");
                    streamWriter.WriteLine($"Дата и время создания файла пользователем: {/*timeOfCreate*/fileInfo.CreationTime}");
                    streamWriter.WriteLine($"Дата и время последнего изменения файла пользователем: {/*timeOfAccess*/fileInfo.LastAccessTime}");
                    streamWriter.WriteLine($"Существование файла: {/*existOfFile*/fileInfo.Exists}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
    ////    2222
    internal class PDADiskInfo
    {
        public void MethodDiskInfo()
        {
            DriveInfo[] drifeInfo = DriveInfo.GetDrives();

            foreach (DriveInfo drife in drifeInfo)
            {
                try
                {
                    Console.WriteLine($"Свободное место на диске:\n{drife.Name} {drife.AvailableFreeSpace}");
                    Console.WriteLine($"Общий объем памяти: {drife.TotalFreeSpace}");
                    Console.WriteLine($"Метка тома: {drife.VolumeLabel}");
                    Console.WriteLine($"Общий объем диска в байтах: {drife.TotalSize}");
                    Console.WriteLine($"Файловая система: {drife.DriveFormat}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
    ////    3333
    internal class PDAFileInfo
    {
        public void MethodFileInfo()
        {
            FileInfo fileInfo = new FileInfo(@"E:\\Laborator\PDAlogfile.txt");
            Console.WriteLine($"\n\nИмя файла: {fileInfo.Name}");
            Console.WriteLine($"Полный путь к файлу: {fileInfo.DirectoryName}");
            Console.WriteLine($"Размер файла: {fileInfo.Length}");
            Console.WriteLine($"Существование файла: {fileInfo.Extension}");
            Console.WriteLine($"Время создания файла: {fileInfo.CreationTime}");
        }
    }
    ////    4444
    internal class PDADirInfo
    {
        public void MethodDirInfo()
        {
            Console.WriteLine("Вывод списка под каталогов E:\\2 курс");
            string[] subDir = Directory.GetDirectories("E:\\2 курс");
            foreach(string s in subDir)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine("Файлы E:\\2 курс:");
            string[] files = Directory.GetFiles("E:\\2 курс");
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Кол-во подкаталогов E:\\2 курс:" + subDir.Length);

            Console.WriteLine("Время создания каталога:");
            var createDataTimeDir = Directory.GetCreationTime("E:\\2 курс");
            Console.WriteLine();

            var parent = Directory.GetParent("E:\\2 курс");
            Console.WriteLine("Родительский каталог Каталога E:\\2 курс: " + parent);
        }
    }
    ////    5555
    internal class PDAFileManager
    {
        public void MethodFileManager()
        {
            Console.WriteLine("\n");
            string[] listFiles = Directory.GetFiles("C:\\");
            string[] listDirectories = Directory.GetDirectories("C:\\");

            Console.WriteLine("\nСписок файлов каталога C");
            foreach (string i in listFiles)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\nСписок папок каталога C:");
            foreach (string j in listDirectories)
            {
                Console.WriteLine(j);
            }

            Console.WriteLine("\nКаталог создан.");
            Directory.CreateDirectory("E:\\Laborator\\PDAInspect");

            Console.WriteLine("Создание файла и запись в него.");

            using (StreamWriter streamWriter = new StreamWriter("E:\\Laborator\\PDAInspect\\PDAdirinfo.txt", true, Encoding.Default))
            {
                streamWriter.Write("Hello ''beautiful'' world!");
                streamWriter.Close();
            }

            Console.WriteLine("\nКопия файла создана.");
            File.Copy("E:\\Laborator\\PDAInspect\\PDAdirinfo.txt", "E:\\Laborator\\PDAInspect\\CopyPDAdirinfo.txt", false);

            Console.WriteLine("Исходный файл удален.");
            File.Delete("E:\\Laborator\\PDAInspect\\PDAdirinfo.txt");

            Directory.CreateDirectory("E:\\Laborator\\PDAFiles");

            File.Copy("E:\\Laborator\\PDAInspect\\CopyPDAdirinfo.txt", "E:\\Laborator\\PDAFiles\\NewCopyPDAdirinfo.txt", false);
        }
    }
    ////    6666
    internal class ViewPDAFiles
    {
        public void ViewPDALogFileMethod()
        {
            using (StreamReader streamReader = new StreamReader(@"E:\\Laborator\PDAlogfile.txt", Encoding.Default))
            {
                Console.WriteLine();
                string stroka = streamReader.ReadToEnd();
                Console.WriteLine(stroka);
            }
        }
    }




    class Program
    {
        public static void Main(string[] args)
        {
            // 1111
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ЗАДАНИЕ 1");
            Console.ResetColor();

            PDALog pdaLog = new PDALog();
            pdaLog.MethodLog();

            // 2222
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ЗАДАНИЕ 2");
            Console.ResetColor();

            PDADiskInfo pdaDiskInfo = new PDADiskInfo();
            pdaDiskInfo.MethodDiskInfo();

            // 3333
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ЗАДАНИЕ 3");
            Console.ResetColor();

            PDAFileInfo pdaFileInfo = new PDAFileInfo();
            pdaFileInfo.MethodFileInfo();

            // 4444
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ЗАДАНИЕ 4");
            Console.ResetColor();

            PDADirInfo pdaDirInfo = new PDADirInfo();
            pdaDirInfo.MethodDirInfo();

            // 5555
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ЗАДАНИЕ 5");
            Console.ResetColor();

            //PDAFileManager pdaFileManager = new PDAFileManager();
            //pdaFileManager.MethodFileManager();

            // 6666
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ЗАДАНИЕ 6");
            Console.ResetColor();

            ViewPDAFiles viewPDAFiles = new ViewPDAFiles();
            viewPDAFiles.ViewPDALogFileMethod();

            Console.ReadKey();
        }
    }
}
