using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatOOP.UnitTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void MozeDaPrijaviIspit_StudentPrijavljujeIspitUValidnomRoku_IzbaciTrue()
        {
            //Arrange
            bool validnaPrijava;

            Datum datumLogovanjaStudentaNaServis = new Datum(7, 1, 2022);       
            Datum pocetniDatumPrijaveIspita = new Datum(1, 1, 2022);            
            Datum krajnjiDatumKasnjenjaPrijaveIspita = new Datum(13, 1, 2022);  
            Datum datumIspita = new Datum(16, 1, 2022);                         


            //Act
            //     1.1.2022 < 7.1.2022 < 13.1.2022 < 16.1.2022
            if (datumLogovanjaStudentaNaServis >= pocetniDatumPrijaveIspita 
                && datumLogovanjaStudentaNaServis <= krajnjiDatumKasnjenjaPrijaveIspita 
                && datumIspita.Godina != 0001)
            {
                validnaPrijava = true;
            }
            else
            {
                validnaPrijava = false;
            }

            Assert.IsTrue(validnaPrijava);
        }

        [TestMethod]
        public void PronadjiStudenta_ZadatomIndeksu_ZadatiIndeksJednakPronadjenom()
        {
            List<Student> studenti = GenerisiStudente();
            string brojIndeksa = "1203/21";

            Student student = studenti.Find(x => x.BrIndeksa == brojIndeksa);

            Assert.AreEqual(brojIndeksa, student.BrIndeksa);
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
                        new Student { Ime = "Nemanja", Prezime = "Plavsic", GodStudija = 1, BrIndeksa = "1203/21", NaBudzetu = true, ObrazovniProfil = "MIT" }
                    };
        }
    }
}
