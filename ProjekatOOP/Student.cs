using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatOOP
{
    public class Student
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrIndeksa { get; set; }
        public string ObrazovniProfil { get; set; }
        public int GodStudija { get; set; }
        public bool NaBudzetu { get; set; }

        public static bool MozeDaPrijaviIspit(Datum datumLogovanjaStudentaNaServis,Datum pocetniDatumPrijaveIspita,
                                              Datum krajnjiDatumKasnjenjaPrijaveIspita, Datum datumIspita)
        {
            if (datumLogovanjaStudentaNaServis >= pocetniDatumPrijaveIspita && datumLogovanjaStudentaNaServis <= krajnjiDatumKasnjenjaPrijaveIspita && datumIspita.Godina != 0001)
            {
                Console.WriteLine("2--> Prijavi ispit iz OOP");
                return true;
            }
            else if (datumLogovanjaStudentaNaServis > krajnjiDatumKasnjenjaPrijaveIspita && datumLogovanjaStudentaNaServis < datumIspita)
            {
                Console.WriteLine($"/--> Prijava ispita je prosla {krajnjiDatumKasnjenjaPrijaveIspita:dd/MM/yyyy} niste prijavili ispit!");
            }
            else if (datumLogovanjaStudentaNaServis > datumIspita && datumIspita.Godina != 0001)
            {
                Console.WriteLine($"/--> Ispit je prosao {datumIspita:dd/MM/yyyy}");
            }
            else if (datumLogovanjaStudentaNaServis == datumIspita)
            {
                Console.WriteLine("/--> Ne mozes da prijavis ispit na dan ispita");
            }
            else
            {
                Console.WriteLine("/--> Trenutno nema ispita koji mogu da se prijave!");
            }
            return false;
        }
        public static void PrikaziUplatnicu(bool naBudzetu, int brojDanaKasnjenja)
        {
            if (naBudzetu == true)
            {
                Console.Clear();
                Console.WriteLine("-----------------Uplatnica-----------------");
                Console.WriteLine("___________________________________________");
                Console.WriteLine("|    Cena prijave ispita se formira:      |");
                Console.WriteLine("|   Cena budzetski/samofinansirajuci      |");
                Console.WriteLine("|        1200din  /  1300din              |");
                Console.WriteLine("|                 +                       |");
                Console.WriteLine("|     (br. dana kasnjenja)*50din          |");
                Console.WriteLine("|                 =                       |");
                Console.WriteLine("|_________________________________________|\n");
                Console.WriteLine($"Student: Na budzetu (kasni sa prijavom: {brojDanaKasnjenja} dana)\n");
                Console.WriteLine($"Cena prijave ispita:{ 1200 + brojDanaKasnjenja * 50}rsd");
                Console.WriteLine("Racun primaoca: 840-1876666-10");
                Console.WriteLine("Primalac: Univerzitet u Beogradu");
                Console.WriteLine("          Masinski Fakultet");
                Console.WriteLine("          Kraljice Marije 16");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("KLIKNI ENTER");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-----------------Uplatnica-----------------");
                Console.WriteLine("___________________________________________");
                Console.WriteLine("|    Cena prijave ispita se formira:      |");
                Console.WriteLine("|   Cena budzetski/samofinansirajuci      |");
                Console.WriteLine("|        1200din  /  1300din              |");
                Console.WriteLine("|                 +                       |");
                Console.WriteLine("|     (br. dana kasnjenja)*50din          |");
                Console.WriteLine("|                 =                       |");
                Console.WriteLine("|_________________________________________|\n");
                Console.WriteLine($"Student: Na budzetu (kasni sa prijavom: {brojDanaKasnjenja})");
                Console.WriteLine($"Cena prijave ispita:{ 1300 + brojDanaKasnjenja * 50}rsd");
                Console.WriteLine("Racun primaoca: 840-1876666-10");
                Console.WriteLine("Primalac: Univerzitet u Beogradu");
                Console.WriteLine("          Masinski Fakultet");
                Console.WriteLine("          Kraljice Marije 16");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("KLIKNI ENTER");
                Console.ReadLine();
            }
        }
        public static void PrikaziInformacije(Student student, Datum datumLogovanja)
        {
            Console.Clear();
            Console.WriteLine($"----------------------DATUM LOGOVANJA {datumLogovanja.CeoDatum}----------------------");
            Console.WriteLine($"Student:{student.Ime} {student.Prezime}");
            Console.WriteLine($"Broj indeksa: {student.BrIndeksa}");
            Console.WriteLine($"Obrazovni profil: {student.ObrazovniProfil}");
            Console.WriteLine($"Godina studija: {student.GodStudija}.");
            Console.WriteLine("--------------------------------------------------------------------------------------\n");
            Console.WriteLine("1--> Vrati se na pocetak");

        }
        public static Student PronadjiStudenta()
        {
            List<Student> studenti = GenerisiStudente();

            bool studentPostojiUBazi = false;

            while (studentPostojiUBazi == false)
            {
                Console.Clear();
                Console.WriteLine("____________________________________");
                Console.WriteLine("Dostupni indeksi: \n1203/21\n1194/21\n1326/21\n308/11\n135/17\n1316/21\n1275/21");
                Console.WriteLine("____________________________________\n");
                Console.WriteLine("Unesi broj indeksa (u formi 123/21):");
                
                string brojIndeksa = Console.ReadLine();

                Student student = studenti.Find(x => x.BrIndeksa == brojIndeksa);

                if (student != null)
                {
                    return student;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"ERROR: Student sa indeksom {brojIndeksa} ne postoji!");
                    Console.WriteLine("Klikni enter da ponovo pokusas ili upisi 0 da se vratis na pocetak");
                    string izbor = Console.ReadLine();
                    if (izbor == "0")
                    {
                        return new Student();
                    }
                }
            }
            return new Student();
        }

        private static List<Student> GenerisiStudente()
        {
            return new List<Student>
                    {
                        new Student { Ime = "Vukoman", Prezime = "Radovic", GodStudija = 1, BrIndeksa = "1194/21", NaBudzetu = true, ObrazovniProfil = "MIT" },
                        new Student { Ime = "Sofija", Prezime = "Bekric", GodStudija = 1, BrIndeksa = "1326/21", NaBudzetu = true, ObrazovniProfil = "MIT" },
                        new Student { Ime = "Nikola", Prezime = "Milacic", GodStudija = 3, BrIndeksa = "308/11", NaBudzetu = false, ObrazovniProfil = "OAS" },
                        new Student { Ime = "Ana", Prezime = "Dakic", GodStudija = 3, BrIndeksa = "135/17", NaBudzetu = false, ObrazovniProfil = "OAS" },
                        new Student { Ime = "Harold", Prezime = "Selassee Komlah Kumahor", GodStudija = 1, BrIndeksa = "1316/21", NaBudzetu = true, ObrazovniProfil = "MIT" },
                        new Student { Ime = "Nemanja", Prezime = "Plavsic", GodStudija = 1, BrIndeksa = "1203/21", NaBudzetu = true, ObrazovniProfil = "MIT" },
                        new Student { Ime = "Strahinja", Prezime = "Vuckovic", GodStudija = 1, BrIndeksa = "1275/21", NaBudzetu = true, ObrazovniProfil = "MIT" }
                    };
        }
    }
}
