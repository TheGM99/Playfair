using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playfair_LIB;


namespace Playfair
{
    class Program
    {
        static void Main(string[] args)
        {
            string klucz;
            string jawne;
            string odp;

            do
            {

                Console.Write("Podaj wyraz do zaszyfrowania: ");
                jawne = Console.ReadLine();
                Console.Write("Podaj klucz : ");
                klucz = Console.ReadLine();
                
                jawne = jawne.ToUpper();
                
                klucz = klucz.ToUpper();
                klucz = klucz.Replace("J", "I");

                //------------------------PROCES TWORZENIA TABLICY Z KLUCZEM---------------------------//

                List<List<char>> tablica = Key_array.build(klucz);

                //------------------KONIEC | PROCES TWORZENIA TABLICY Z KLUCZEM | KONIEC----------------------//
                Console.WriteLine("\n TABLICA: \n");
                foreach (List<char> i in tablica)
                {
                    foreach (char j in i)
                        Console.Write(j + " ");
                    Console.Write('\n');
                }
                Console.Write('\n');

                //---------------------PRZYGOTOWYWANIE JAWNEGO SLOWA DO SZYFROWANIA--------------------//
                
                var temp = new StringBuilder();

                jawne = jawne.Replace(" ", "");
                jawne = jawne.Replace("J", "I");

                foreach (char c in jawne)
                {
                    if (!char.IsPunctuation(c))
                        temp.Append(c);
                }

                jawne = temp.ToString();

                for (int i = 0; i < jawne.Length - 1; i += 2)
                {
                    if (jawne[i].Equals(jawne[i + 1]))
                        jawne = jawne.Insert(i, "X");
                }

                if (jawne.Length % 2 != 0)
                    jawne += 'X';


                //--------------KONIEC | PRZYGOTOWYWANIE JAWNEGO SLOWA DO SZYFROWANIA | KONIEC ------------//

                //---------------------- SZYFROWANIE ---------------------------//

                string zaszyfrowane = Szyfrowanie.Cipher(jawne, tablica);

                //--------------------- KONIEC | SZYFROWANIE | KONIEC ---------------------//
                Console.WriteLine("Wyraz po zaszyfrowaniu: " + zaszyfrowane);

                string odszyfrowane = Deszyfrowanie.Decipher(zaszyfrowane, tablica); 

                Console.WriteLine("Wyraz po odszyfrowaniu: " + odszyfrowane);

                Console.Write("Czy chcesz kontynuowac ?: ");
                
                odp = Console.ReadLine();
                odp = odp.ToUpper();

            } while (odp.Equals("TAK"));
        }
    }
}
