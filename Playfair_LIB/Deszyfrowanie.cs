using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair_LIB
{
    public class Deszyfrowanie
    {
        /// <summary>
        /// Funckja odpowiedzialna za deszyfracje
        /// </summary>
        /// <param name="zaszyfrowane">zaszyfrowane słowo poddawane deszyfracji</param>
        /// <param name="tablica">tablic z kluczem użyta do wcześniejszego zaszyfrowania</param>
        /// <returns>odszyfrowane słowo</returns>
        static public string Decipher(string zaszyfrowane, List<List<char>> tablica)
        {

            StringBuilder odszyfrowane = new StringBuilder("");

            for (int i = 0; i < zaszyfrowane.Length; i += 2)
            {
                int pos_1_x = -1;
                int pos_2_x = -1;
                int pos_1_y = -1;
                int pos_2_y = -1;
                char first;
                char sec;

                for (int j = 0; j < tablica.Count; j++)
                {
                    pos_1_x = tablica[j].FindIndex(x => x.Equals(zaszyfrowane[i]));
                    if (pos_1_x > -1) { pos_1_y = j; break; }
                }

                for (int j = 0; j < tablica.Count; j++)
                {
                    pos_2_x = tablica[j].FindIndex(x => x.Equals(zaszyfrowane[i + 1]));
                    if (pos_2_x > -1) { pos_2_y = j; break; }
                }

                if (pos_2_y == pos_1_y)
                {
                    if (pos_1_x == 0) { pos_1_x = 5; }
                    if (pos_2_x == 0) { pos_2_x = 5; }

                    first = tablica[pos_1_y][pos_1_x - 1];
                    sec = tablica[pos_2_y][pos_2_x - 1];
                    odszyfrowane.Append(first);
                    odszyfrowane.Append(sec);
                }
                else if (pos_2_x == pos_1_x)
                {
                    if (pos_1_y == 0) { pos_1_y = 5; }
                    if (pos_2_y == 0) { pos_2_y = 5; }

                    first = tablica[pos_1_y - 1][pos_1_x];
                    sec = tablica[pos_2_y - 1][pos_2_x];
                    odszyfrowane.Append(first);
                    odszyfrowane.Append(sec);
                }
                else
                {
                    first = tablica[pos_1_y][pos_2_x];
                    sec = tablica[pos_2_y][pos_1_x];
                    odszyfrowane.Append(first);
                    odszyfrowane.Append(sec);
                }
            }

            return odszyfrowane.ToString();

        }
    }
}
