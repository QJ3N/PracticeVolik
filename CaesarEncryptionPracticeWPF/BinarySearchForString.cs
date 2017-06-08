using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarEncryptionPracticeWPF
{
    class BinarySearchForString
    {
        public static bool Search(List<string> list, string search_value)
        {
            int first_index = 0,
                last_index = list.Count - 1,
                average_index = 0;
            while (first_index < last_index)
            {
                average_index = first_index + (last_index - first_index) / 2; // меняем индекс среднего значения

                if (search_value[0] <= list[average_index][0])
                {
                    last_index = average_index;
                }
                else first_index = average_index + 1;
                //search_value <= array_[average_index] ? last_index = average_index : first_index = average_index + 1;    // найден ключевой элемент или нет 
            }


            while (last_index < list.Count - 1 && search_value[0] == list[last_index][0])
            {
                if (list[last_index] == search_value)
                    return true;
                last_index++;
            }
            return false;

        }
    }
}
