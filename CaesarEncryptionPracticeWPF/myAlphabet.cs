using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarEncryptionPracticeWPF
{
    class myAlphabet
    {       
        public static LetterAndCount[] DeepCopy(LetterAndCount[] alphabet)
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
