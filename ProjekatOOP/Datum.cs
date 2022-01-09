using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatOOP
{
    public class Datum
    {
        private int dan;
        private int mesec;
        private int godina;

        public Datum()
        {
            //default vrednosti
            dan = 01;
            mesec = 01;
            godina = 0001;
        }
        public Datum(int dan, int mesec, int godina)
        {
            Godina = godina;
            Mesec = mesec;
            Dan = dan;
        }

        public int Dan
        {
            get { return dan; }
            set
            {
                dan = ProveraUneteVrednostiDan(value);
            }
        }
        public int Mesec
        {
            get { return mesec; }
            set
            {
                mesec = ProveraUneteVrednostiMesec(value);
            }
        }
        public int Godina
        {
            get { return godina; }
            set
            {
                godina = ProveraUneteVrednostiGodina(value);
            }
        }
        public string CeoDatum
        {
            get
            {
                return TacnoFormatiranCeoDatum();
            }
        }

        private int ProveraUneteVrednostiDan(int unetDan)
        {
            if (unetDan < 1)
            {
                throw new Exception("Pogresno uneta vrednost za dan!");
            }

            return UnetaVrednostZadovoljavaUslove(unetDan, mesec, false);
        }
        private int ProveraUneteVrednostiMesec(int unetMesec)
        {
            if (unetMesec > 12 || unetMesec < 1)
            {
                throw new Exception("Pogresan uneta vrednost za mesec!");
            }

            return UnetaVrednostZadovoljavaUslove(dan, unetMesec, true);
        }
        private int ProveraUneteVrednostiGodina(int unetaGodina)
        {
            if (unetaGodina < 0001 || unetaGodina > 9999)
            {
                throw new Exception("Pogresan uneta vrednost za godinu!");
            }

            bool prestupnaGodina = PrestupnaGodina();

            if (prestupnaGodina == true && mesec == 2 && dan > 29)
            {
                throw new Exception("U prestupnoj godini ne moze u febraru da bude preko 29 dana!");
            }
            return unetaGodina;
        }
        private int UnetaVrednostZadovoljavaUslove(int dan, int mesec, bool returnMesec)
        {
            switch (mesec)
            {
                //januar
                case 1:
                    UnetoVeceOdBrojaDanaUMesecu(31, dan);
                    break;
                //februar
                case 2:
                    int brojDanaUMesecu = 28;
                    bool prestupnaGodina = PrestupnaGodina();

                    if (prestupnaGodina == true && ++brojDanaUMesecu < dan)
                    {
                        throw new Exception("Postavio si vise dana nego sto mesec moze da ima!");
                    }
                    else if (brojDanaUMesecu < dan)
                    {
                        throw new Exception("Postavio si vise dana nego sto mesec moze da ima!");
                    }
                    break;
                //mart
                case 3:
                    UnetoVeceOdBrojaDanaUMesecu(31, dan);
                    break;
                //april
                case 4:
                    UnetoVeceOdBrojaDanaUMesecu(30, dan);
                    break;
                //maj
                case 5:
                    UnetoVeceOdBrojaDanaUMesecu(31, dan);
                    break;
                //jun
                case 6:
                    UnetoVeceOdBrojaDanaUMesecu(30, dan);
                    break;
                //jul
                case 7:
                    UnetoVeceOdBrojaDanaUMesecu(31, dan);
                    break;
                //avgust
                case 8:
                    UnetoVeceOdBrojaDanaUMesecu(31, dan);
                    break;
                //septembar
                case 9:
                    UnetoVeceOdBrojaDanaUMesecu(30, dan);
                    break;
                //oktobar
                case 10:
                    UnetoVeceOdBrojaDanaUMesecu(31, dan);
                    break;
                //novembar
                case 11:
                    UnetoVeceOdBrojaDanaUMesecu(30, dan);
                    break;
                //decembar
                case 12:
                    UnetoVeceOdBrojaDanaUMesecu(31, dan);
                    break;
            }

            if (returnMesec == true)
            {
                return mesec;
            }
            else
            {
                return dan;
            }
        }
        private void UnetoVeceOdBrojaDanaUMesecu(int brojDanaUMesecu, int uneto)
        {
            if (uneto > brojDanaUMesecu)
            {
                throw new Exception("Postavio si vise dana nego sto mesec moze da ima!");
            }
        }
        private bool PrestupnaGodina()
        {
            if (godina % 400 == 0)
            {
                return true;
            }
            else if (godina % 100 != 0 && godina % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        private string PodesiStringFormatDatuma(int vrednost, bool podesiGodinu)
        {
            int brCifara = vrednost.ToString().Length;

            if (brCifara == 1 && podesiGodinu == false)
            {
                return $"0{vrednost}";
            }

            if (podesiGodinu == true)
            {
                switch (brCifara)
                {
                    case 1:
                        return $"000{vrednost}";
                    case 2:
                        return $"00{vrednost}";
                    case 3:
                        return $"0{vrednost}";
                    case 4:
                        return $"{vrednost}";
                    default:
                        break;
                }
            }

            return vrednost.ToString();

        }
        private string TacnoFormatiranCeoDatum()
        {
            string dd = PodesiStringFormatDatuma(dan, false),
                       mm = PodesiStringFormatDatuma(mesec, false),
                       yyyy = PodesiStringFormatDatuma(godina, true); ;

            return $"{dd}/{mm}/{yyyy}";
        }
        private int BrojDanaZaDatiMesec(int mesec)
        {
            switch (mesec)
            {
                //januar
                case 1:
                    return 31;
                //februar
                case 2:
                    bool prestupnaGodina = PrestupnaGodina();

                    if (prestupnaGodina == true)
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
                //mart
                case 3:
                    return 31;
                //april
                case 4:
                    return 30;
                //maj
                case 5:
                    return 31;
                //jun
                case 6:
                    return 30;
                //jul
                case 7:
                    return 31;
                //avgust
                case 8:
                    return 31;
                //septembar
                case 9:
                    return 30;
                //oktobar
                case 10:
                    return 31;
                //novembar
                case 11:
                    return 30;
                //decembar
                case 12:
                    return 31;
            }

            return 0;
        }
        private int IzracunajBrojDanaIzmedjuDveGodine(int unetaGodina)
        {
            int rezultat = 0;

            if (Godina > unetaGodina)
            {
                for (int g = Godina; g > unetaGodina; g--)
                {
                    if (PrestupnaGodina(g))
                    {
                        rezultat -= 366;
                    }
                    else
                    {
                        rezultat -= 365;
                    }
                }
            }
            else if (Godina < unetaGodina)
            {
                for (int g = Godina; g < unetaGodina; g++)
                {
                    if (PrestupnaGodina(g))
                    {
                        rezultat += 366;
                    }
                    else
                    {
                        rezultat += 365;
                    }
                }
            }

            return rezultat;
        }
        private int IzracunajBrojDanaIzmedjuDvaMeseca(int unetaMesec)
        {
            int rezultat = 0;

            if (Mesec > unetaMesec)
            {
                for (int m = Mesec; m > unetaMesec; m--)
                {
                    rezultat -= BrojDanaZaDatiMesec(m - 1);
                }

            }
            else if (Mesec < unetaMesec)
            {
                for (int m = Mesec; m < unetaMesec; m++)
                {
                    rezultat += BrojDanaZaDatiMesec(m);
                }
            }
            return rezultat;
        }
        private int IzracunajBrojDanaIzmedjuDvaDana(int unetDan)
        {
            int rezultat = 0;

            if (Dan > unetDan)
            {
                rezultat -= (Dan - unetDan);
            }
            else if (Dan < unetDan)
            {
                rezultat += (unetDan - Dan);
            }

            return rezultat;
        }


        public int BrojDanaDoDatuma(Datum datum)
        {
            int rezultat = 0;
            bool d1PrestupnojGodini = PrestupnaGodina(Godina);
            bool d2PrestupnojGodini = PrestupnaGodina(datum.Godina);

            if (d1PrestupnojGodini == true && d2PrestupnojGodini == true)
            {
                rezultat += IzracunajBrojDanaIzmedjuDveGodine(datum.Godina);

                rezultat += IzracunajBrojDanaIzmedjuDvaMeseca(datum.Mesec);

                rezultat += IzracunajBrojDanaIzmedjuDvaDana(datum.Dan);
            }

            else if (d1PrestupnojGodini == true && d2PrestupnojGodini == false)
            {
                rezultat += IzracunajBrojDanaIzmedjuDveGodine(datum.Godina);
                rezultat += IzracunajBrojDanaIzmedjuDvaMeseca(datum.Mesec);
                rezultat += IzracunajBrojDanaIzmedjuDvaDana(datum.Dan);

                if (Godina > datum.Godina)
                {
                    rezultat++;
                }

                if (Mesec < datum.Mesec || Mesec > datum.Mesec)
                {
                    rezultat--;
                }

                if (Mesec == 1 && datum.mesec == 2 && Mesec < datum.Mesec)
                {
                    rezultat++;
                }
                if (datum.mesec <= 2 && Mesec > datum.Mesec)
                {
                    rezultat++;
                }

            }

            else if (d1PrestupnojGodini == false && d2PrestupnojGodini == true)
            {
                rezultat += IzracunajBrojDanaIzmedjuDveGodine(datum.Godina);
                rezultat += IzracunajBrojDanaIzmedjuDvaMeseca(datum.Mesec);
                rezultat += IzracunajBrojDanaIzmedjuDvaDana(datum.Dan);

                if (Godina > datum.Godina)
                {
                    rezultat--;
                }
                if (Mesec < datum.Mesec || Mesec > datum.Mesec)
                {
                    rezultat++;
                }

                if (Mesec == 1 && datum.mesec == 2 && Mesec < datum.Mesec)
                {
                    rezultat--;
                }
                if (datum.mesec <= 2 && Mesec > datum.Mesec)
                {
                    rezultat--;
                }
            }

            else
            {
                rezultat += IzracunajBrojDanaIzmedjuDveGodine(datum.Godina);
                rezultat += IzracunajBrojDanaIzmedjuDvaMeseca(datum.Mesec);
                rezultat += IzracunajBrojDanaIzmedjuDvaDana(datum.Dan);
            }

            return rezultat;

        }
        public Datum Add(int brojDana)
        {
            int noviBrDana = Dan + brojDana;
            int brojMeseci = Mesec;
            int brojDanaZaTajMesec = BrojDanaZaDatiMesec(brojMeseci);

            if (noviBrDana > brojDanaZaTajMesec)
            {
                do
                {
                    noviBrDana -= brojDanaZaTajMesec;

                    if (brojMeseci == 12)
                    {
                        brojMeseci = 1;
                        ++Godina;
                    }
                    else
                    {
                        brojMeseci++;
                    }

                    brojDanaZaTajMesec = BrojDanaZaDatiMesec(brojMeseci);
                }
                while (noviBrDana > brojDanaZaTajMesec);

                return new Datum(noviBrDana, brojMeseci, Godina);
            }
            else
            {
                return new Datum(noviBrDana, brojMeseci, Godina);
            }

        }
        public static bool operator ==(Datum d1, Datum d2)
        {
            if (d1.CeoDatum == d2.CeoDatum)
                return true;
            else
                return false;
        }
        public static bool operator !=(Datum d1, Datum d2)
        {
            if (d1.CeoDatum != d2.CeoDatum)
                return true;
            else
                return false;
        }
        public static bool operator <(Datum d1, Datum d2)
        {
            if (d1.Godina < d2.Godina)
            {
                return true;
            }
            else if (d1.Godina == d2.Godina)
            {
                if (d1.Mesec < d2.Mesec)
                {
                    return true;
                }
                else if (d1.Mesec == d2.Mesec)
                {
                    if (d1.Dan < d2.Dan)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator >(Datum d1, Datum d2)
        {
            if (d1.Godina > d2.Godina)
            {
                return true;
            }
            else if (d1.Godina == d2.Godina)
            {
                if (d1.Mesec > d2.Mesec)
                {
                    return true;
                }
                else if (d1.Mesec == d2.Mesec)
                {
                    if (d1.Dan > d2.Dan)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator <=(Datum d1, Datum d2)
        {
            if (d1.Godina < d2.Godina)
            {
                return true;
            }
            else if (d1.Godina == d2.Godina)
            {
                if (d1.Mesec < d2.Mesec)
                {
                    return true;
                }
                else if (d1.Mesec == d2.Mesec)
                {
                    if (d1.Dan < d2.Dan || d1.Dan == d2.Dan)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator >=(Datum d1, Datum d2)
        {
            if (d1.Godina > d2.Godina)
            {
                return true;
            }
            else if (d1.Godina == d2.Godina)
            {
                if (d1.Mesec > d2.Mesec)
                {
                    return true;
                }
                else if (d1.Mesec == d2.Mesec)
                {
                    if (d1.Dan > d2.Dan || d1.Dan == d2.Dan)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public static bool PrestupnaGodina(int godina)
        {
            if (godina % 400 == 0)
            {
                return true;
            }
            else if (godina % 100 != 0 && godina % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Datum GenerisiDanasnjiDatum()
        {
            DateTime dt = DateTime.Now;

            return new Datum(dt.Day, dt.Month, dt.Year);
        }
        public static int IzracunajBrojDanaKasnjenja(Datum krajnjiDatumPrijaveIspita, Datum datumLogovanjaStudentaNaServis)
        {
            int brojDanaKasnjenja = krajnjiDatumPrijaveIspita.BrojDanaDoDatuma(datumLogovanjaStudentaNaServis);

            if (brojDanaKasnjenja <= 0)
            {
                brojDanaKasnjenja = 0;
            }
            
            return brojDanaKasnjenja;
        }
        public static Datum PodesiDatumIspita(Datum krajnjiDatumKasnjenjaPrijaveIspita)
        {
            Datum datumIspita = new Datum();

            bool tacnoPodesen = false;
            while (tacnoPodesen == false)
            {
                datumIspita = KorisnikAplikacije.UnosiDatum("ispita");

                if (datumIspita < krajnjiDatumKasnjenjaPrijaveIspita.Add(3))
                {
                    Error.PorukaPoredjenje("Datum ispita ne moze da bude manji od regularne prijave ispita + 3 dana!", datumIspita, krajnjiDatumKasnjenjaPrijaveIspita.Add(3));
                }
                else if (datumIspita > krajnjiDatumKasnjenjaPrijaveIspita.Add(30))
                {
                    Error.PorukaPoredjenje("Datum ispita ne moze da bude veci od 30 dana nakon regularne prijave ispita!", krajnjiDatumKasnjenjaPrijaveIspita, datumIspita);
                }
                else
                {
                    return datumIspita;
                }
            }
            return datumIspita;
        }
    }
}
