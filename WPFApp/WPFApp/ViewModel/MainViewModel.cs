using DevExpress.Mvvm;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPFApp.Model;
using System.Windows;
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.Runtime.CompilerServices;

namespace WPFApp.ViewModel
{
    class MainViewModel : BaseVM
    {
        private string path1;
        private string path2;
        private ObservableCollection<Compare> compares;
        public ObservableCollection<Compare> Compares
        {
            get
            {
                if (compares == null)
                {

                    compares = new ObservableCollection<Compare>();
                }

                return compares;
            }
           
        }

        public string Path1
        {
            get
            {
                return this.path1;
            }
            set
            {
                this.path1 = value;

            }
        }
        public string Path2
        {
            get
            {
                return this.path2;
            }
            set
            {
                this.path2 = value;

            }
        }
        public ICommand CompareFolders
        {
            get
            {
                return new DelegateCommand(() =>
                {
                        
                    Compares.Clear();

                    if (!string.IsNullOrEmpty(path1) && !string.IsNullOrEmpty(path2))
                    {
                        Compare comparefolders;
                        DirectoryInfo dirInfo1 = new DirectoryInfo(path1);
                        DirectoryInfo dirInfo2 = new DirectoryInfo(path2);
                        FileInfo[] info1 = dirInfo1.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                        FileInfo[] info2 = dirInfo2.GetFiles("*.*", SearchOption.TopDirectoryOnly);

                        foreach (FileInfo f1 in info1)
                        {
                            comparefolders = new Compare
                            {
                                Name = f1.Name,
                                Size = f1.Length,
                                ChangeData = f1.LastWriteTime,
                                State = "Файл существует только в первой директории"
                            };
                            foreach (FileInfo f2 in info2)
                            {
                                if (f1.Name == f2.Name && f1.Extension == f2.Extension)
                                {
                                    comparefolders.State = "Файл найден в обеих директориях, но имеет разный размер";
                                    
                                    if (f1.Length == f2.Length)
                                    {
                                        comparefolders.State = "Файл найден в обеих директориях и имеет одинаковый размер";
                                    }
                                }
                            }
                            Compares.Add(comparefolders);
                        }
                        
                        foreach (FileInfo f2 in info2)
                        {
                            comparefolders = new Compare
                            {
                                Name = f2.Name,
                                Size = f2.Length,
                                ChangeData = f2.LastWriteTime,
                                State = "Файл существует только во второй директории"
                            };
                            bool isFound = false;
                            foreach (Compare item in Compares)
                            {
                                if (item.Name == comparefolders.Name)
                                {
                                    isFound = true;
                                }
                            }
                            if (!isFound)
                            {
                                Compares.Add(comparefolders);
                            }
                        }
                    }
                });
            }
        }
    }
}
