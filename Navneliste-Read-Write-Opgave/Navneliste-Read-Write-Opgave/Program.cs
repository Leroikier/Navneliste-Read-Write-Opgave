using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navneliste_Read_Write_Opgave
{
    namespace FredagsopgaveNavneListe
    {
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;


        class Program
        {
            struct Alias
            //Her oprettes en struct
            {
                //Strings
                public string AliNavn;
                public int AliNr;
            }

            static void Main(string[] args)
            {
                //String opret
                string line;
                //Der oprettes "lists"
                List<string> NyeBrugere = new List<string>();
                List<Alias> AliasList = new List<Alias>();
                List<string> navneliste = new List<string>();// opretter en string list der hedder navneliste.

                //Her oprettes et char array
                char[] schar = { ' ' };
                //String opret
                string indtastning;

                //Menu //Input fra brugerens side
                Console.WriteLine("Tast 1 for manuel indtastning \nTast 2 for indlæsning af Tekstdokument");
                indtastning = Console.ReadLine();

                //Hvis der bliver indtastet "1"
                if (indtastning == "1")
                {
                    Console.Clear();
                    string navn = "";
                    //Udfør dette
                    do
                    {
                        //Input fra brugerns side
                        Console.Write("Hvad hedder du? : ");
                        //variablen navn = indtastning + metoden StortOgSmåt plus trim(fjerner mellemrum)
                        navn = StortOgSmaat(Console.ReadLine().Trim()); 
                        //Her kaldes metoden "ListeMetode" på "navn"
                        ListeMetode(navn);
                    }
                    // kør min "do" imens variablen navn ikke er tom
                    while (navn != "");
                    Console.WriteLine("");
                    //Kald Metoden "IndlæsTilTxt"
                    IndlæsTilTxt();

                    //Udskrivning
                    Console.WriteLine("Dit data er gemt.\nTryk på en tast for at afslutte");
                    Console.ReadKey();

                }
                //Hvis der bliver tastet "2"
                else if (indtastning == "2")
                {
                    //Kald Metoden "LæsFraFil"
                    LæsFraFil();
                    //Kald Metoden "IndlæsTilTxt"
                    IndlæsTilTxt();

                    //Udskrivning
                    Console.WriteLine("Dit data er gemt.\nTryk på en tast for at afslutte");
                    Console.ReadKey();
                }
                //Ellers "Exit"
                else
                {
                    Environment.Exit(0);
                }


                // metode til at indlæse mine "navne" til en txt fil
                void IndlæsTilTxt()
                {
                    //String
                    string indtastning2;
                    //Input  //Udskrivning
                    Console.WriteLine("\nHvis du vil gemme de nyindtastede navne i en tekstfil, Så tryk 1 ");
                    indtastning2 = Console.ReadLine();
                    Console.Clear();

                    //Hvis input = "1"
                    if (indtastning2 == "1")
                    {
                        //Her oprettes en ny "TextWriter" // DirectoryNotFoundException catches af samme
                        TextWriter tw = new StreamWriter("C:\\NyTekst\\NyTekst.txt");   
                        //Foreach loop der kigger på navne i "navneliste"
                        foreach (string navne in navneliste)
                        {
                            //Skriv til Textwriteren/Streamwriter "navne"
                            tw.WriteLine(navne);
                        }
                        //Luk Textwriteren/Streamwriter //God programmerings skik
                        tw.Close();
                    }
                    //Ellers "Exit"
                    else
                    {
                        Environment.Exit(0);
                    }
                }

                // metode til at læse navne ind fra en txt fil
                void LæsFraFil()// min metode forventer at få min parameter args[0] som reference
                {
                    //Hvis "args" er støre/længere end 0 gør dette
                    if (args.Length > 0)
                    {
                        //Prøv dette
                        try
                        {
                            //Her oprettes en ny Textreader som tar udgangspunkt i args første input som i dette tilfælde er "stien" til tekst dokumentet
                            TextReader tr = new StreamReader(args[0]);
                            //Der læses en linjie og gemmer den i "line" vis linjien ikke er tom
                            while ((line = tr.ReadLine()) != null)
                            {
                                //line (den linjie den læser fra tekstdokumentet) indskrives til "Listemetoden" om og om igen indtil der er en tom linjie
                                ListeMetode(line);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        string IndtastAdr;
                        Console.WriteLine("Indtast den fulde sti på din fil");
                        IndtastAdr = Console.ReadLine();
                        try
                        {
                            TextReader tr = new StreamReader(IndtastAdr);
                            while ((line = tr.ReadLine()) != null)
                            {
                                ListeMetode(line);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            //throw;
                        }
                    }
                    navneliste.Sort();//sorter navneliste, når den udskrives vil den vises i alfabetisk rækkefølge

                    foreach (string fnavn in navneliste)// for hvert navn i min List gør: udskriv!
                    {
                        Console.WriteLine(fnavn);
                    }
                }

                // metode til addering af vores navne til vores navneliste
                void ListeMetode(string nnavn)
                {
                    //navn = StortOgSmaat(Console.ReadLine().Trim()); //variablen navn = indtastning + metoden StortOgSmåt plus trim(fjern mellemrum)
                    if (nnavn != "")
                    {



                        string[] delNavn = nnavn.Split(schar, StringSplitOptions.RemoveEmptyEntries); // opretter en ny string array "delnavn" og gemmer det indtastede navn, og splitter det ved alle mellemrum (schar)
                        string totalNavn = "";
                        foreach (string xnavn in delNavn)// for hvert navn gemt i vores array, kør metoden StortOgSmåt og gem navnet i totalNavn
                        {
                            totalNavn += StortOgSmaat(xnavn);
                        }
                        totalNavn = totalNavn.Trim();//fjerner alle mellemrum fra variablen totalNavn
                        string[] fnavn = totalNavn.Split(); // opretter en string array og gemmer indtastningen af navne, .split splitter alle navne op i seperate arrays
                        string Efternavn = fnavn[fnavn.Length - 1]; // opretter en variable Efternavn, og tjekker længden af fnavn arrayet og tager det sidste navn i arrayet og gemmer den under variablen Efternavn
                        string Fornavn = ""; // opretter en tom string variable kaldet Fornavn.
                        for (int i = 0; i < fnavn.Length - 1; i++)//
                            Fornavn += fnavn[i] + " ";

                        Alias A1;
                        A1.AliNavn = Fornavn.Substring(0, 2) + Efternavn.Substring(0, 2);// tag de første 2 bokstaver af første fornavn og efternavnet
                        A1.AliNr = 0001;
                        string alinavn = A1.AliNavn;


                        foreach (Alias DelAlias in AliasList)
                        {

                            if (DelAlias.AliNavn == alinavn)
                            {
                                A1.AliNr += 1;
                            }

                        }
                        AliasList.Add(A1);
                        navneliste.Add(Efternavn + ", " + Fornavn + ", " + A1.AliNavn + A1.AliNr);

                    }

                }
                // her er vores funktion (metode fordi den ligger i en kasse - main)
                string StortOgSmaat(string inavn) //tager de første bokstaver og laver dem store (capslock) og alle andre små.
                {
                    if (inavn.Length != 0)
                        return inavn.Substring(0, 1).ToUpper() + inavn.Substring(1).ToLower() + " ";
                    else
                        return "";
                }



            }

        }
    }
}
