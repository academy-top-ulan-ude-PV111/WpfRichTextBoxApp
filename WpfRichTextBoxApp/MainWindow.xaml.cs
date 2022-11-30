using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfRichTextBoxApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialogSave = new();
            if(dialogSave.ShowDialog() == true)
            {
                TextRange rangeDoc = new(richText.Document.ContentStart, richText.Document.ContentEnd);
                using(FileStream file = File.Create(dialogSave.FileName))
                {
                    rangeDoc.Save(file, DataFormats.Rtf);
                }
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogOpen = new();
            
            if(dialogOpen.ShowDialog() == true)
            {
                TextRange rangeDoc = new TextRange(richText.Document.ContentStart, richText.Document.ContentEnd);
                using(FileStream file = File.Open(dialogOpen.FileName, FileMode.Open))
                {
                    rangeDoc.Load(file, DataFormats.Rtf);
                }
            }
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            richText.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
            //richText.Selection.ApplyPropertyValue(FontWeightProperty, "Bold");
        }

        private void Size_Click(object sender, RoutedEventArgs e)
        {
            richText.Selection.ApplyPropertyValue(FontSizeProperty, "26");

            richText.Selection.ApplyPropertyValue(ForegroundProperty, "Red");
        }
        
    }
}
