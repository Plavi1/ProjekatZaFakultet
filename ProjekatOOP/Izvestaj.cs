using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjekatOOP
{
    class Izvestaj
    {
        static readonly string _lokacija = "../../../../Izvestaj/Izvestaj.txt";
        public static bool Postoji()
        { 
            return File.Exists(_lokacija);
        }
        public static void Obrisi()
        {
            Console.Clear();
            Console.WriteLine("Da potvrdite brisanje Izvestaja upisite 1, ako ne zelite ENTER");
            string odabrano = Console.ReadLine();
            if (odabrano == "1")
            {
                File.Delete(_lokacija);
            }
        }
        public static void Ubaci(Student student, 
                                 Datum datumLogovanjaStudentaNaServis,
                                 Datum pocetniDatumPrijaveIspita, 
                                 Datum datumIspita, 
                                 int brojDanaKasnjenja)
        {
            string tekst;
            string status;
            int cena;

            if (student.NaBudzetu == true)
            {
                status = "na budzetiu";
                cena = 1200;
            }
            else
            {
                status = "samofinansirajuci";
                cena = 1300;
            }

            //mora ovako
            if(brojDanaKasnjenja == 0)
            {
tekst = $@"
Student({status}): {student.Ime} {student.Prezime} 
Datum ispita: {datumIspita.CeoDatum}
Pocetni datum prijave ispita: {pocetniDatumPrijaveIspita.CeoDatum} 
Student prijavio ispit datuma: {datumLogovanjaStudentaNaServis.CeoDatum}
Cena prijave: {cena}rsd     


                          OPSEG PRIJAVE

           |-------|-------|---------------|---------------|
          Pocetni  |    Krajnji         Krajnji          Datum
          Datum    |    Datum           Datum            Ispita
          Prijave  |    Prijave         Kasnjenja
          Ispita   |    Ispit           Prijave
                   |                    Ispita
                   |
                   |
            Student usao na
           servis i prijavio
                 ispit

                 

xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


";   
            }
            else
            {
tekst = $@"
Student({status}): {student.Ime} {student.Prezime} 
Datum ispita: {datumIspita.CeoDatum}
Pocetni datum prijave ispita: {pocetniDatumPrijaveIspita.CeoDatum} 
Student prijavio ispit datuma: {datumLogovanjaStudentaNaServis.CeoDatum}
Cena prijave: {cena + brojDanaKasnjenja * 50}rsd  (kasni {brojDanaKasnjenja} dana od krajnjeg datuma p. i.)   


                          OPSEG PRIJAVE

           |---------------|--------|------|---------------|
          Pocetni       Krajnji     |   Krajnji          Datum
          Datum         Datum       |   Datum            Ispita
          Prijave       Prijave     |   Kasnjenja
          Ispita        Ispit       |   Prijave
                                    |   Ispita
                                    |
                                    |
                             Student usao na 
                            servis i prijavio 
                                  ispit
                   
                 

xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


";
            }

            if (File.Exists(_lokacija))
            {
                File.AppendAllText(_lokacija, tekst);
            }
            else
            {
                File.WriteAllText(_lokacija, tekst);
            }
        }
    }
}
