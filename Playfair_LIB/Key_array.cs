using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfair_LIB
{
    public class Key_array
    {

        /// <summary>
        /// funkcja przygotowująca tabele do szyfrowania na podstawie podanego klucza
        /// </summary>
        /// <param name="klucz"> klucz do szyfrowania </param>
        /// <returns>przygotowana tablica do szyfrowania</returns>
        static public List<List<char>> build(string klucz)
        {
            
            string alpha = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            List<List<char>> tablica = new List<List<char>>();


            for (int i = 0; i < klucz.Length - 1; i++)
                for (int j = i + 1; j < klucz.Length; j++)
                    if (klucz[i].Equals(klucz[j])) klucz = klucz.Remove(j, 1);

            int dlugosc = klucz.Length;
            char ost_litera = klucz[dlugosc - 1];
            int ost_index = alpha.IndexOf(ost_litera);
            int klucz_y = klucz.Length / 5;
            int klucz_x = klucz.Length % 5;

            for (int i = 0; i < 5; i++)
            {

                List<char> temp = new List<char>();
                for (int j = 0; j < 5; j++)
                {
                    temp.Add(';');
                }

                tablica.Add(temp);

            }

            for (int i = 0; i < klucz.Length; i++)
            {
                int y = i / 5;
                int x = i % 5;
                tablica[y][x] = klucz[i];


            }

            int ilosc_liter = klucz.Length;
            int pos_x = klucz_x;
            int pos_y = klucz_y;

            for (int i = 0; i < alpha.Length; i++)
            {
                bool powtorka = false;

                if (ost_index + i >= alpha.Length)
                    ost_index = -i;

                for (int j = 0; j < tablica.Count; j++)
                    if (tablica[j].Contains(alpha[i + ost_index]))
                    {
                        powtorka = true;
                        break;
                    }

                if (powtorka == false)
                {
                    ilosc_liter++;

                    tablica[pos_y][pos_x] = alpha[i + ost_index];
                    pos_x++;

                    if (pos_x % 5 == 0)
                    {
                        pos_x = 0;
                        pos_y += 1;
                    }
                }
            }
            return tablica;
        }

    }
}
