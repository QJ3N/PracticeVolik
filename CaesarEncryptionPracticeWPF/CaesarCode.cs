using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarEncryptionPracticeWPF
{
    
    class CaesarCode
    {
        //private char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
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
            int indexletter;
            if (shiftROT > alphabet.Length)
                shiftROT = shiftROT % alphabet.Length;

            for (int i = 0; i < inputString.Length; i++)
            {
                indexletter = IndexOfALetter(inputString[i]);
                if (indexletter == -1) outputString += inputString[i];
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
            string[] wordmas;
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
                wordmas = str.Split(' ',',','!','?','.',';',':');
                
                string bigword = SearchingLargestWord(wordmas);
                if (dictionary.Contains(bigword))
                    return str;
                shiftROT++;
            }
            shiftROT = -1;
            return "error:";
            
        }
        private string SearchingLargestWord(string[]mas)
        {
            int maxlength = -9999999;
            int index = -1;
            for (int i = 0; i < mas.Length; i++)
            {
                if (maxlength < mas[i].Length)
                {
                    index = i;
                    maxlength = mas[i].Length;
                }
            }
            return mas[index];
        }
        //fcjjm, kw lykc gq tmjgi qcpecw
    }
}
