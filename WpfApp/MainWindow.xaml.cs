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
using System.Windows.Xps;
using Microsoft.Win32;
using System.Windows.Xps.Packaging;
using System.IO;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveClik(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "xps(*.xps)| *.xps";
            bool ? isDone= save.ShowDialog();
            if (isDone !=null && isDone.Value)
            {
                using (XpsDocument document = new XpsDocument( save.FileName, FileAccess.Write))
                {
                    XpsDocumentWriter wrier = XpsDocument.CreateXpsDocumentWriter(document);
                    wrier.Write(fixedDocument);
                }
            }
        }

        private void LoadClik(object sender, RoutedEventArgs e)
        {
            SaveFileDialog open = new SaveFileDialog();
            open.Filter = "xps(*.xps)| *.xps";
            bool? isDone = open.ShowDialog();
            if (isDone != null && isDone.Value)
            {
                using (XpsDocument document = new XpsDocument(open.FileName, FileAccess.Read))
                {
                    documentConteiner.Document = document.GetFixedDocumentSequence();
                }
            }
        }
    }
}
