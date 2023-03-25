using System;
using System.Collections.Generic;
using System.Linq;

namespace Wisielec
{
    class Program
    {
        static bool sprawdzenieWygranej(string haslo, List<char> listaLiter)
        {
            foreach (char litera in haslo)
            {
                if (!listaLiter.Contains(litera) && litera != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        static void pokazUzyteLitery(List<char> listaLiter)
        {
            Console.Write("Użyte litery to: ");
            foreach (char litera in listaLiter)
            {
                Console.Write(litera + ", ");
            }
            Console.WriteLine();
        }

        static void pokazHaslo(string haslo, List<char> listaLiter)
        {
            foreach (var litera in haslo)
            {
                if (listaLiter.Contains(litera))
                {
                    Console.Write(litera);
                }
                else if (litera == ' ')
                {
                    Console.Write("  ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
        }

        static void Main(string[] args)
        {
            List<string> listaHasel = new List<string>();

            listaHasel.Add("hogwarts legacy");
            listaHasel.Add("god of war");
            listaHasel.Add("fortnite");
            listaHasel.Add("minecraft");
            listaHasel.Add("animal crossing");
            listaHasel.Add("cs");

            Random generatorLiczb = new Random();
            int iloscHasel = listaHasel.Count;
            int wylosowanyIndexHasla = generatorLiczb.Next(iloscHasel);
            string haslo = listaHasel[wylosowanyIndexHasla];
            List<char> listaUzytychLiter = new List<char>();


            int szanse = 5;
            bool czyWygrana = false;


            while (szanse > 0 && czyWygrana == false)
            {

                pokazHaslo(haslo, listaUzytychLiter);
                pokazUzyteLitery(listaUzytychLiter);

                Console.WriteLine("pozostało ci " + szanse + "szans");

                Console.Write("podaj literę:  ");
                char wpisanalitera = Console.ReadLine()[0];
                Console.Clear();

                if (listaUzytychLiter.Contains(wpisanalitera))
                {
                    Console.WriteLine("ta litera została już użyta");
                }
                else if (haslo.Contains(wpisanalitera))
                {
                    listaUzytychLiter.Add(wpisanalitera);
                    czyWygrana = sprawdzenieWygranej(haslo, listaUzytychLiter);
                }
                else
                {
                    listaUzytychLiter.Add(wpisanalitera);
                    szanse--;
                }


            }
            if (czyWygrana)
            {
                Console.WriteLine("Wygrałeś brawo");
            }
            else
            {
                Console.WriteLine("przegrałeś niestety hasło to: " + haslo);
            }

        }
    }
}