using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair_LIB
{
    public class Szyfrowanie
    {

        /// <summary>
        /// Funkcja szyfrująca 
        /// </summary>
        /// <param name="jawne"> słowo poddawane szyfrowaniu</param>
        /// <param name="tablica">tablica z kluczem do szyfrowania</param>
        /// <returns>zaszyfrowane słowo</returns>
        static public string Cipher(string jawne, List<List<char>> tablica) 
        {

            StringBuilder zaszyfrowane = new StringBuilder("");

            for (int i = 0; i < jawne.Length; i += 2)
            {
                int pos_1_x = -1;
                int pos_2_x = -1;
                int pos_1_y = -1;
                int pos_2_y = -1;
                char first;
                char sec;

                for (int j = 0; j < tablica.Count; j++)
                {
                    pos_1_x = tablica[j].FindIndex(x => x.Equals(jawne[i]));
                    if (pos_1_x > -1) { pos_1_y = j; break; }
                }

                for (int j = 0; j < tablica.Count; j++)
                {
                    pos_2_x = tablica[j].FindIndex(x => x.Equals(jawne[i + 1]));
                    if (pos_2_x > -1) { pos_2_y = j; break; }
                }

                if (pos_2_y == pos_1_y)
                {
                    if (pos_1_x == 4) { pos_1_x = -1; }
                    if (pos_2_x == 4) { pos_2_x = -1; }

                    first = tablica[pos_1_y][pos_1_x + 1];
                    sec = tablica[pos_2_y][pos_2_x + 1];
                    zaszyfrowane.Append(first);
                    zaszyfrowane.Append(sec);
                }
                else if (pos_2_x == pos_1_x)
                {
                    if (pos_1_y == 4) { pos_1_y = -1; }
                    if (pos_2_y == 4) { pos_2_y = -1; }

                    first = tablica[pos_1_y + 1][pos_1_x];
                    sec = tablica[pos_2_y + 1][pos_2_x];
                    zaszyfrowane.Append(first);
                    zaszyfrowane.Append(sec);
                }
                else
                {
                    first = tablica[pos_1_y][pos_2_x];
                    sec = tablica[pos_2_y][pos_1_x];
                    zaszyfrowane.Append(first);
                    zaszyfrowane.Append(sec);
                }
            }
            return zaszyfrowane.ToString();
        }
    }
}
