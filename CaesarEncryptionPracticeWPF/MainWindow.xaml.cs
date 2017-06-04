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
using System.Windows.Threading;
namespace CaesarEncryptionPracticeWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {

        private char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
                                      'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private int[] mascounter;
        private CaesarCode cc;
        private myDictionary d;
        private DispatcherTimer timer;

        
        public MainWindow()
        {
            InitializeComponent();
            cc = new CaesarCode(alphabet);
            d = new myDictionary("dictionaryenglish.txt");
            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);           
            TextBoxFirst.TextChanged += text_TextChanged;
            int[] mascounter = new int[alphabet.Length];
            for (int i = 0; i < mascounter.Length; i++)
                mascounter[i] = 0;
            showColumnChart(alphabet, mascounter);
        }

        private void DecryptionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                int shiftROT;
                string str;
                cc = new CaesarCode(alphabet);
                cc.InputString = TextBoxFirst.Text;
                 str = cc.CaesarDecode(d.MyDictionary, out shiftROT);
                 if (shiftROT == -1)
                 {
                     TextBoxSecond.Text = "";
                     TextBlockNumberOfROT.Content = "The expected shift for this text: ";
                     throw new Exception("Error: Words do not exist!");

                 }
                 else
                 {
                     TextBoxSecond.Text = str;
                     TextBlockNumberOfROT.Content = "The expected shift for this text: " + shiftROT;
                 }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EncryptionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cc = new CaesarCode(alphabet);
                cc.InputString = TextBoxFirst.Text;
                if (Int32.Parse(TextBoxROT.Text) < 0) throw new Exception("Error: number ROT is negative");
                TextBoxSecond.Text = cc.InCaesarCode(Int32.Parse(TextBoxROT.Text));                
            }
            catch (Exception ex)
            {  
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
       
        private void text_TextChanged(object sender, EventArgs e)
        {
            timer.IsEnabled = false;
            TextBox tb = (TextBox)sender;
            int indexletter;           
            mascounter = new int[alphabet.Length];
            for (int i = 0; i < mascounter.Length; i++)
                mascounter[i] = 0;

            for (int i = 0; i < tb.Text.Length; i++)
            {
                indexletter = cc.IndexOfALetter(tb.Text[i]);
                if (indexletter == -1) continue;
                else mascounter[indexletter]++;                                   
            }
            timer.IsEnabled = true;                                          
             
                
        }
        private void showColumnChart(char[]alphabet,int[]mascounter)
        {            
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < alphabet.Length; i++)
                valueList.Add(new KeyValuePair<string, int>(alphabet[i].ToString(), mascounter[i]));
            //Setting data for column chart
            columnChart.DataContext = valueList;           
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            showColumnChart(alphabet, mascounter);
            timer.IsEnabled = false;
        }
    }
}
