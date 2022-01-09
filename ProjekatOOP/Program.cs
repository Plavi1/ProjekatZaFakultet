using System;
using System.Collections.Generic;

namespace ProjekatOOP
{
    class Program
    {
        static void Main()
        {
            Datum datumIspita = new Datum();
            Datum pocetniDatumPrijaveIspita = new Datum(), krajnjiDatumPrijaveIspita = new Datum();
            Datum krajnjiDatumKasnjenjaPrijaveIspita = new Datum();

            bool LOOP = false;

            while (LOOP == false)
            {
                KorisnikAplikacije.PrikaziInformacije(pocetniDatumPrijaveIspita, krajnjiDatumKasnjenjaPrijaveIspita, datumIspita);

                int odabrano = KorisnikAplikacije.Izabrao();
    

                // 1- Postavi datum pocetka prijave ispita
                if(odabrano == 1)
                {
                    pocetniDatumPrijaveIspita = KorisnikAplikacije.UnosiDatum("pocetka prijave ispita");
                    krajnjiDatumPrijaveIspita = pocetniDatumPrijaveIspita.Add(3);
                    krajnjiDatumKasnjenjaPrijaveIspita = krajnjiDatumPrijaveIspita.Add(9);
                    datumIspita = new Datum();  //Ako podesimo 1 pa 2, pa onda opet udjemo u 1 a datum ispita nam bude manji od pocetnog
                }
              

                // 2- Postavi datum ispita
                else if(odabrano == 2)
                {
                    if(pocetniDatumPrijaveIspita.Godina != 0001)
                    {
                        datumIspita = Datum.PodesiDatumIspita(krajnjiDatumKasnjenjaPrijaveIspita);
                    }
                    else
                    {
                        Error.Poruka("Prvo moras da postavis pocetak prijave ispita!");
                    }
                }


                // 3- Udji kao student
                else if(odabrano == 3)
                {
                    Console.WriteLine("*SIMULACIJA ULASKA STUDENTA*");                                                       // Ovaj korak moze
                    Datum datumLogovanjaStudentaNaServis = KorisnikAplikacije.UnosiDatum("ulaska studenta na servis");    // da se zanmari u produkciji DateTime.Now

                    Student student = Student.PronadjiStudenta();
              
                    if(student.BrIndeksa != null)
                    {
                        bool vratiNaPocetak = false;
                        while(vratiNaPocetak == false)
                        {
                            Student.PrikaziInformacije(student, datumLogovanjaStudentaNaServis);

                            bool studentMozeDaPrijaviIspit = Student.MozeDaPrijaviIspit(datumLogovanjaStudentaNaServis, pocetniDatumPrijaveIspita, krajnjiDatumKasnjenjaPrijaveIspita, datumIspita);

                            int studentOdabrao = KorisnikAplikacije.Izabrao();

                            // 1- vrati na pocetak
                            if(studentOdabrao == 1)
                            {
                                vratiNaPocetak = true;
                            } 

                            // 2= prijavi ispit
                            else if(studentMozeDaPrijaviIspit == true && studentOdabrao == 2)
                            {
                                int brojDanaKasnjenja = Datum.IzracunajBrojDanaKasnjenja(krajnjiDatumPrijaveIspita, datumLogovanjaStudentaNaServis);

                                Student.PrikaziUplatnicu(student.NaBudzetu, brojDanaKasnjenja);

                                Izvestaj.Ubaci(student, datumLogovanjaStudentaNaServis, pocetniDatumPrijaveIspita, datumIspita, brojDanaKasnjenja);

                                vratiNaPocetak = true;
                            }
                        }
                    }
                }


                // 4- Obrisi Izvestaj
                else if(odabrano == 4 && Izvestaj.Postoji())
                {
                    Izvestaj.Obrisi();
                }


                // 0- izadji iz aplikacije
                else if(odabrano == 0)
                {
                    LOOP = true;
                }
            }
            //zvucni signal da je aplikacija iskljucena
            Console.Beep();
        }
    }
}
