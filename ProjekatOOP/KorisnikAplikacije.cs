using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatOOP
{
    public class KorisnikAplikacije
    {
        public static void PrikaziInformacije(Datum pocetniDatumPrijaveIspita, Datum krajnjiDatumKasnjenjaPrijaveIspita,
                                              Datum datumIspita)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Datum pocetka prijave ispita:                 |{pocetniDatumPrijaveIspita.CeoDatum}");
            Console.WriteLine($"Krajnji datum prijave ispita (sa kasnjenjem): |{krajnjiDatumKasnjenjaPrijaveIspita.CeoDatum} ");
            Console.WriteLine($"Datum ispita iz OOP:                          |{datumIspita.CeoDatum}");
            Console.WriteLine("-----------------------------------------------------------------\n");
            Console.WriteLine("(1)--> Postavi datum pocetka prijave ispita");
            Console.WriteLine("(2)--> Postavi datum ispita iz OOP");
            Console.WriteLine("(3)--> Udji kao student");
            if (Izvestaj.Postoji())
            {
               Console.WriteLine("(4)--> Obrisi Izvestaj");
            }
            else
            {
                Console.WriteLine("(/)--> Trenutno nema Izvestaja prijavljenih ispita");
            }
            Console.WriteLine("(0)--> Iskljuci aplikaciju");
            Console.Write("UNESI BROJ OPCIJE KOJU ZELIS:");
        }
        public static int Izabrao()
        {
            int uneto = 0;
            int pokusaj = 0;
            bool tacanUnos = false;

            while (tacanUnos == false)
            {
                try
                {
                    uneto = Convert.ToInt32(Console.ReadLine());
                    if(uneto > 4 || uneto < 0)
                    {
                        throw new Exception();
                    }
                    tacanUnos = true;
                    Console.Clear();
                }
                catch (Exception)
                {
                    pokusaj = ++pokusaj;
                    if (pokusaj >= 3)
                    {
                        Console.WriteLine("Da li ste hendikepirani?");
                    }
                    else
                    {
                        Console.WriteLine("Uneli ste pogresno!");
                    }
                }
            }

            return uneto;
        }
        public static Datum UnosiDatum(string kojiDatum)
        {
            int dan, mesec, godina;
            Datum novDatum = new Datum();

            bool tacanFormatUnetogDatuma = false;

            while (tacanFormatUnetogDatuma == false)
            {
                Console.WriteLine($"Unesi datum {kojiDatum}:");
                Console.WriteLine("(dd/mm/yyyy)");
                dan = Unosi("dan");

                Console.WriteLine($"Unesi datum {kojiDatum}:");
                Console.WriteLine($"({dan}/mm/yyyy)");
                mesec = Unosi("mesec");

                Console.WriteLine($"Unesi datum {kojiDatum}:");
                Console.WriteLine($"({dan}/{mesec}/yyyy)");
                godina = Unosi("godinu");


                try
                {
                    novDatum = new Datum(dan,mesec,godina);
                }
                catch (Exception)
                {
                    novDatum = new Datum();
                }


                if (novDatum.Godina == 0001)
                {
                    Error.Poruka("Uneli ste pogresan format datuma!");
                }
                else if (novDatum.Godina < 2021)
                {
                    Error.PorukaPoredjenje("Uneti datum je manji od danasnjeg datuma!", novDatum, Datum.GenerisiDanasnjiDatum());
                }
                else
                {
                    tacanFormatUnetogDatuma = true;
                }
            }
            return novDatum;
        }
        private static int Unosi(string deoDatuma)
        {
            bool tacanUnos = false;
            int pokusaj = 0;
            int uneto = 0;

            while (tacanUnos == false)
            {
                try
                {
                    Console.Write($"Unesi {deoDatuma.ToUpper()}:");
                    uneto = Convert.ToInt32(Console.ReadLine());
                    tacanUnos = true;
                    Console.Clear();
                }
                catch (Exception)
                {
                    pokusaj = ++pokusaj;
                    if (pokusaj >= 3)
                    {
                        Console.WriteLine("Da li ste hendikepirani?");
                    }
                    else
                    {
                        Console.WriteLine("Uneli ste pogresno!");
                    }
                }
            }

            return uneto;
        }
       
    }
}
