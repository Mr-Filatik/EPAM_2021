using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Security.Cryptography;

namespace Task_1
{
    class Program
    {
        // для начала работы нужно создать папку (mainDir) с подпапкой (dir) (в подпапке создавать и изменять файлы)
        static string mainDir = "C:/TipoGit/"; // общая директория
        static string dir = "TipoGit/"; // отслеживаемая папка 
        static string gitInfo = ".gitInfo"; // фаил хранения изменений  (создаётся сам)
        static string gitVersion = "gitVersion/"; // папка хранения изменений (создаётся сама)

        static void Main(string[] args)
        {
            Console.WriteLine("1 - наблюдать");
            Console.WriteLine("2 - откатить");
            Console.WriteLine("0 - выйти");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.D1)
            {
                Console.Clear();
                Observation();
            }
            if (key == ConsoleKey.D2)
            {
                Console.Clear();
                RollBack();
            }
            if (key == ConsoleKey.D0)
            {
                Console.Clear();
            }
        }

        private static void Observation()
        {
            if (File.Exists(mainDir + gitInfo))
            {
                if (CheckSize(mainDir + gitInfo) != 0)
                {
                    Console.WriteLine("После окончания работы нажмите любую клавишу для сохранения");
                    Console.ReadKey();
                    string str_context = "";
                    string str_name = "";
                    string[] allFoundFiles = Directory.GetFiles(mainDir + dir, "*.txt", SearchOption.AllDirectories);
                    foreach (string item in allFoundFiles)
                    {
                        str_context += CheckSum(item);
                        str_name += item;
                    }
                    string hash_context = CheckSumString(str_context);
                    string hash_name = CheckSumString(str_name);
                    string info = CheckContentString(mainDir + gitInfo);
                    string[] mini_info = info.Split('\n');
                    string hash_context_old = mini_info[mini_info.Length - 1].Substring(0, 32);
                    string hash_name_old = mini_info[mini_info.Length - 1].Substring(32, 32);
                    if ((hash_context != hash_context_old) && (hash_name == hash_name_old))
                    {
                        /*for(int i = 0; i < allFoundFiles.Length; i++)
                        {
                            if (CheckSum(allFoundFiles[i]) != mini_info[i].Substring(0, 32))
                            {

                            }
                        }*/
                        str_context = "";
                        str_name = "";
                        string output = "";
                        foreach (string item in allFoundFiles)
                        {
                            str_context += CheckSum(item);
                            str_name += item;
                            output += CheckSum(item);
                            output += item;
                            output += '\n';
                        }
                        output += CheckSumString(str_context);
                        output += CheckSumString(str_name);
                        FileStream fs = File.OpenWrite(mainDir + gitInfo);
                        fs.Write(Encoding.Default.GetBytes(output), 0, output.Length);
                        fs.Close();

                        string new_folder = mainDir + gitVersion + Convert.ToString(DateTime.Now).Replace(":", ".") + "/";
                        Directory.CreateDirectory(new_folder);
                        foreach (string item in allFoundFiles)
                        {
                            byte[] bytes = CheckContentByte(item);
                            string a = item.Replace(mainDir + dir, "");
                            string[] folders = a.Split('\\');
                            output = "";
                            for (int i = 0; i < folders.Length - 1; i++)
                            {
                                output += folders[i] + "/";
                                Directory.CreateDirectory(new_folder + output);
                            }
                            fs = File.OpenWrite(new_folder + item.Replace(mainDir + dir, ""));
                            fs.Write(bytes, 0, bytes.Length);
                            fs.Close();
                        }
                        Console.WriteLine("Изменения содержимого сохранены");
                    }
                    if ((hash_context != hash_context_old) && (hash_name != hash_name_old))
                    {
                        Console.WriteLine("Изменения сохранены");
                    }
                    if ((hash_context == hash_context_old) && (hash_name != hash_name_old))
                    {
                        Console.WriteLine("Изменения наименований сохранены");
                    }
                    if ((hash_context == hash_context_old) && (hash_name == hash_name_old))
                    {
                        Console.WriteLine("Изменений не внесено");
                    }
                }
                else
                {
                    string str_context = "";
                    string str_name = "";
                    string output = "";
                    string[] allFoundFiles = Directory.GetFiles(mainDir + dir, "*.txt", SearchOption.AllDirectories);
                    foreach (string item in allFoundFiles)
                    {
                        str_context += CheckSum(item);
                        str_name += item;
                        output += CheckSum(item);
                        output += item;
                        output += '\n';
                    }
                    output += CheckSumString(str_context);
                    output += CheckSumString(str_name);
                    FileStream fs = File.OpenWrite(mainDir + gitInfo);
                    fs.Write(Encoding.Default.GetBytes(output), 0, output.Length);
                    fs.Close();

                    string new_folder = mainDir + gitVersion + Convert.ToString(DateTime.Now).Replace(":", ".") + "/";
                    Directory.CreateDirectory(new_folder);
                    foreach (string item in allFoundFiles)
                    {
                        byte[] bytes = CheckContentByte(item);
                        string a = item.Replace(mainDir + dir, "");
                        Console.WriteLine(a);
                        string[] folders = a.Split('\\');
                        output = "";
                        for (int i = 0; i < folders.Length - 1; i++)
                        {
                            output += folders[i] + "/";
                            Directory.CreateDirectory(new_folder + output);
                        }
                        fs = File.OpenWrite(new_folder + item.Replace(mainDir + dir, ""));
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();
                    }
                    Console.WriteLine("ТипоГит заполнен начальными данными. Перезагрузите приложение");
                }
            }
            else
            {
                File.Create(mainDir + gitInfo);
                Directory.CreateDirectory(mainDir + gitVersion);
                Console.WriteLine("ТипоГит создан. Перезагрузите приложение");
            }
            Console.ReadKey();
        }

        private static void RollBack()
        {
            Console.WriteLine("Время захода в сеанс");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Введите дату и время для отката");
            string[] allFoundFiles = Directory.GetDirectories(mainDir + gitVersion, "*", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < allFoundFiles.Length; i++)
            {
                Console.WriteLine(allFoundFiles[allFoundFiles.Length - i - 1].Replace(mainDir + gitVersion, ""));
                if (i != allFoundFiles.Length - 1) { Console.WriteLine("({0})", i + 1); }
            }
            int n = 0;
            do
            {
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    n = 0;
                }
            } while (n < 1);
            if (n > allFoundFiles.Length - 1)
            {
                n = allFoundFiles.Length - 1;
            }
            for (int i = allFoundFiles.Length - 1; i >= 0; i--)
            {
                if (n == 0)
                {
                    string[] allFoundFilesIn = Directory.GetFiles(allFoundFiles[i], "*.txt", SearchOption.AllDirectories);
                    foreach (string item in allFoundFilesIn)
                    {
                        byte[] bytes = CheckContentByte(item);
                        string a = item.Replace(allFoundFiles[i] + '\\', "");
                        string[] folders = a.Split('\\');
                        string output = "";
                        for (int ii = 0; ii < folders.Length - 1; ii++)
                        {
                            output += folders[ii] + "/";
                            Directory.CreateDirectory(mainDir + dir + output);
                        }
                        File.Delete(mainDir + dir + item.Replace(allFoundFiles[i] + '\\', ""));
                        FileStream fs = File.OpenWrite(mainDir + dir + item.Replace(allFoundFiles[i] + '\\', ""));
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();
                    }
                    break;
                }
                else
                {
                    Directory.Delete(allFoundFiles[i], true);
                    n--;
                }
            }
        }

        private static void CheckFile(string path)
        {
            /*Console.WriteLine(path);
            Console.WriteLine(CheckSize(path));
            Console.WriteLine(CheckSum(path));
            Console.WriteLine(CheckContentString(path));
            foreach (byte i in CheckContentByte(path))
            {
                Console.Write(i);
            }
            Console.WriteLine();*/
        }

        private static long CheckSize(string path)
        {
            return new FileInfo(path).Length;
        }

        private static string CheckSumString(string str)
        {
            MD5 md5 = MD5.Create();
            return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", String.Empty);
        }

        private static string CheckSum(string path)
        {
            FileStream fs = File.OpenRead(path);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(fs);
            fs.Close();
            return BitConverter.ToString(checkSum).Replace("-", String.Empty);
        }

        private static byte[] CheckContentByte(string path)
        {
            FileStream fs = File.OpenRead(path);
            byte[] checkContent = new byte[CheckSize(path)];
            int i = fs.Read(checkContent, 0, checkContent.Length);
            fs.Close();
            return checkContent;
        }

        private static string CheckContentString(string path)
        {
            return Encoding.Default.GetString(CheckContentByte(path));
        }
    }
}
