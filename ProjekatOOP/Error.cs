using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatOOP
{
    public class Error
    {
        public static void Poruka(string poruka)
        {
            Console.Clear();
            Console.WriteLine($"ERROR: {poruka}");
            Console.WriteLine("KLIKNI ENTER DA PONOVIS UNOS");
            Console.ReadLine();
            Console.Clear();
        }
        public static void Poruka(string poruka, Datum datum)
        {
            Console.Clear();
            Console.WriteLine($"ERROR: {poruka}");
            Console.WriteLine($"Upisan datum: {datum.CeoDatum}");
            Console.WriteLine("KLIKNI ENTER DA PONOVIS UNOS");
            Console.ReadLine();
            Console.Clear();
        }
        public static void PorukaPoredjenje(string poruka, Datum manjiDatum, Datum veciDatum)
        {
            Console.Clear();
            Console.WriteLine($"ERROR: {poruka}");
            Console.WriteLine($"{manjiDatum.CeoDatum} < {veciDatum.CeoDatum}");
            Console.WriteLine("KLIKNI ENTER DA PONOVIS UNOS");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
