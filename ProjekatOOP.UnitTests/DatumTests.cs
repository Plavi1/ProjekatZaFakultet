using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProjekatOOP.UnitTests
{
    [TestClass]
    public class DatumTests
    {
        [TestMethod]
        public void IzracunajBrojDanaKasnjenja_AkoSeDatumiOduzimajuPriKrajuMeseca_IzbaciDevet()
        {
            //Arrange
            Datum krajnjiDatumPrijaveIspita = new Datum(27, 1, 2022);
            Datum datumLogovanjaStudentaNaServis = new Datum(5, 2, 2022);

            int brojDanaKasnjenja = krajnjiDatumPrijaveIspita.BrojDanaDoDatuma(datumLogovanjaStudentaNaServis);

            //Act
            if (brojDanaKasnjenja <= 0)
            {
                brojDanaKasnjenja = 0;
            }
            

            //Assert
            Assert.AreEqual(brojDanaKasnjenja, 9);
        }
        [TestMethod]
        public void GenerisiDanasnjiDatum_ZaBiloKojiDan_IzbaciTacan()
        {
            //Arrange
            Datum danasnjiDatum = new Datum();
            DateTime dt = DateTime.Now;
            string dtString = $"{dt:dd/MM/yyyy}";

            //Act
            try
            {
                danasnjiDatum = new Datum(dt.Day, dt.Month, dt.Year);
            }
            catch (Exception)
            {
                
            }


            //Assert
            Assert.AreEqual(dtString, danasnjiDatum.CeoDatum);
        }
        [TestMethod]
        public void Add_DodajStoDana_IzbaciTacnuVrednost()
        {
            //Arrange
            DateTime datumTacan = new DateTime(2022, 2, 2);
            string datumTacanString;
            Datum datumZaPoredjenje = new Datum(2, 2, 2022);

            //Act
            datumTacan = datumTacan.AddDays(100);
            datumTacanString = $"{datumTacan:dd/MM/yyyy}";
            datumZaPoredjenje = datumZaPoredjenje.Add(100);

            //Assert
            Assert.AreEqual(datumTacanString, datumZaPoredjenje.CeoDatum);

        }
        [TestMethod]
        public void PrestupnaGodina_Proveri4PrestupneGodine_IzbaciTrue()
        {
            bool prva = Datum.PrestupnaGodina(2016);
            bool druga = Datum.PrestupnaGodina(2020);
            bool treca = Datum.PrestupnaGodina(2100); //Izbacice jednu false vrednost!
            bool cetvrta = Datum.PrestupnaGodina(2028);

            List<bool> lista = new List<bool>
            {
                prva,
                druga,
                treca,
                cetvrta
            };

            int falseVrednosti = 0;

            foreach(bool vrednost in lista)
            {
                if(vrednost == false)
                {
                    falseVrednosti++;
                }
            }

            Assert.AreEqual(1, falseVrednosti);
        }

        

    }
}
