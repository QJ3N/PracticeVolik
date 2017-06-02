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

namespace CaesarEncryptionPracticeWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
       
        //private char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private LetterAndCount[] alphabetLetterAndCount = { new LetterAndCount('a', 0), new LetterAndCount('b', 0), new LetterAndCount('c', 0), new LetterAndCount('d', 0), new LetterAndCount('e', 0),
                                             new LetterAndCount('f',0),new LetterAndCount('g',0),new LetterAndCount('h',0), new LetterAndCount('i', 0), new LetterAndCount('j', 0),
                                             new LetterAndCount('k', 0), new LetterAndCount('l', 0), new LetterAndCount('m', 0), new LetterAndCount('n', 0), new LetterAndCount('o', 0),
                                             new LetterAndCount('p', 0), new LetterAndCount('q', 0), new LetterAndCount('r', 0), new LetterAndCount('s', 0), new LetterAndCount('t', 0),
                                             new LetterAndCount('u', 0), new LetterAndCount('v', 0),new LetterAndCount('w', 0), new LetterAndCount('x', 0), new LetterAndCount('y', 0),
                                             new LetterAndCount('z', 0)};
            
        private CaesarCode cc;
        
        public MainWindow()
        {
            cc = new CaesarCode(alphabetLetterAndCount);
            InitializeComponent();
            showColumnChart(alphabetLetterAndCount);
            //columnChart.DataContext = new List<KeyValuePair<string, int>>();
        }

        private void DecryptionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LetterAndCount[] mass = DeepCopy(alphabetLetterAndCount);
                cc = new CaesarCode(mass);
                cc.InputString = TextBoxFirst.Text;
                TextBoxSecond.Text = cc.CaesarDecode();
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
                LetterAndCount[] mass = DeepCopy(alphabetLetterAndCount);
                cc = new CaesarCode(mass);
                cc.InputString = TextBoxFirst.Text;
                if (Int32.Parse(TextBoxROT.Text) < 0) throw new Exception("Error: number ROT is negative");
                TextBoxSecond.Text = cc.InCaesarCode(Int32.Parse(TextBoxROT.Text));
                showColumnChart(cc.Alphabet);
            }
            catch (Exception ex)
            {  
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void showColumnChart(LetterAndCount[]alphabet)
        {
            
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            for (int i = 0; i < alphabetLetterAndCount.Length;i++ )
                valueList.Add(new KeyValuePair<string, int>(alphabet[i].letter.ToString(), alphabet[i].count));
            //Setting data for column chart
            columnChart.DataContext = valueList;           
        }
        private LetterAndCount[] DeepCopy(LetterAndCount[] alphabet)
        {
            LetterAndCount[] mass = new LetterAndCount[alphabet.Length];
            for (int i = 0; i < alphabet.Length; i++)
            {
                mass[i] = new LetterAndCount(alphabet[i].letter, alphabet[i].count);
            }
            return mass;
        }
        
    }
}
