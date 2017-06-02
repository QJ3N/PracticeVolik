using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaesarEncryptionPracticeWPF
{
    class myDictionary
    {
        private static List<string> mydictionary;
        public List<string> MyDictionary { get { return mydictionary; } }
        public myDictionary(string filename)
        {
            mydictionary = new List<string>();
            ReadFile(filename);
        }
        static void ReadFile(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            
            while(!sr.EndOfStream)
            {
                mydictionary.Add(sr.ReadLine());
            }           
            sr.Close();
        }
    }
}
