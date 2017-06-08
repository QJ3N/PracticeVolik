using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarEncryptionPracticeWPF
{
    
    class CaesarCode
    {
        
        private char [] alphabet;
        private string inputString;
        private string outputString;
        public string InputString { get { return inputString; } set { inputString = value; } }
        public char [] Alphabet { get { return alphabet; } set { alphabet = value; } }
        public CaesarCode(char[] alphabet)
        {
            this.alphabet = alphabet;
            this.inputString = "";
            this.outputString = "";
        }       
        public int IndexOfALetter(char letter)
        {
            for (int i = 0; i < alphabet.Length; i++)
                if (alphabet[i] == letter)
                    return i;
            return -1;
        }
        public string InCaesarCode(int shiftROT)
        {
            outputString = "";
            string str = inputString.ToLower();
            int indexletter;
            if (shiftROT > alphabet.Length)
                shiftROT = shiftROT % alphabet.Length;

            for (int i = 0; i < str.Length; i++)
            {
                indexletter = IndexOfALetter(str[i]);
                if (indexletter == -1) outputString += str[i];
                else
                {                    
                    //alphabet[indexletter].count++;
                    int newIndex = (indexletter + shiftROT) % (alphabet.Length);
                    outputString += alphabet[newIndex];
                }
                
            }
            return outputString;
        }
        public string CaesarDecode(List<string> dictionary, out int shiftROT)
        {            
            string[] wordsmasnonull,words;
            shiftROT = 0;
            int indexletter;
            for (int i = 0; i < alphabet.Length; i++)
            {
                string str = "";
                for (int j = 0; j < inputString.Length; j++)
                {
                    indexletter = IndexOfALetter(inputString[j]);
                    if (indexletter == -1) str += inputString[j];
                    else
                    {                      
                        int newIndex = (indexletter + shiftROT) % (alphabet.Length);
                        str += alphabet[newIndex];
                    }                  
                }
                words = str.Split(' ', ',', '!', '?', '.', ';', ':');                
                wordsmasnonull = ClearNullStrings(words);
                //foreach (var w in wordsmasnonull)
                //    w.ToLower();
                
                
                int truecounter = 0;
                for (int k = 0; k < wordsmasnonull.Length; k++)
                {
                    if (BinarySearchForString.Search(dictionary, wordsmasnonull[k]))
                        truecounter++;
                }
                if (((double)truecounter / wordsmasnonull.Length) >= 0.5)
                {
                    if(shiftROT!=0)
                    shiftROT = alphabet.Length - shiftROT;
                    return str;
                }

                shiftROT++;
            }
            shiftROT = -1;
            return "error:";
            
        }
        private string[] ClearNullStrings(string[] str)        
        {
            List<string> list = str.ToList<string>();
            list.RemoveAll(thislist => thislist == "");
            str = list.ToArray();
            return str;
        }
    }
}
