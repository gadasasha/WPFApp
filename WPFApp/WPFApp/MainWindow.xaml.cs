using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32; //FileDialog
using WinForms = System.Windows.Forms; //FolderDialog
using System.IO; //Folder, Directory
using System.Diagnostics; //Debug.WriteLine
using System.Windows.Forms;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSelect_folder1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folder1 = new FolderBrowserDialog();
            DialogResult result = folder1.ShowDialog();
            if (result == WinForms.DialogResult.OK)
            {
                TextBoxPath1.Text = folder1.SelectedPath;
            }
        }

        public void BtnSelect_folder2(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folder2 = new FolderBrowserDialog();
            DialogResult result = folder2.ShowDialog();
            if (result == WinForms.DialogResult.OK)
            {
                TextBoxPath2.Text = folder2.SelectedPath;
            }
            
        }

       
    }

}
