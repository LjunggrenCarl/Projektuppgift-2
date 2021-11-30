using System;
using System.IO;

namespace Uppgift_5._20
{
    class Program
    {
        static void Main(string[] args)
        {

            string Menyval = "0";
            string filename = "songs.txt";

            while (Menyval != "5")
            {

                Console.WriteLine("Välj ett alternativ");
                Console.WriteLine("1. Skriv din topplista");
                Console.WriteLine("2. Visa hela topplistan och ändra topplistan");
                Console.WriteLine("3. Sök efter låtnamn");
                Console.WriteLine("4. Hur det funkar");
                Console.WriteLine("5. Avsluta programmet");
                Console.WriteLine();
                Menyval = Console.ReadLine();

                Console.WriteLine();

                switch (Menyval)
                {

                    case "1":

                        Console.WriteLine("I detta program får du skriva in din låt topplista");
                        Console.WriteLine("Hur många låtar vill du skriva in?");
                        Console.WriteLine();
                        int antallåtar;
                        bool valid = int.TryParse(Console.ReadLine(),out antallåtar);

                        while (!valid)
                        {

                            Console.WriteLine("Du skrev inte in en siffra");
                            Console.WriteLine();
                            valid = int.TryParse(Console.ReadLine(), out antallåtar);

                        }
                        
                        string[] favoritlåtar = new string[antallåtar];

                        for (int i = 0; i < antallåtar; i++)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Skriv in namnet på låt {i + 1} av {antallåtar}");
                            Console.WriteLine();
                            favoritlåtar[i] = Console.ReadLine().ToLower();
                        }
                        Console.WriteLine();


                        File.WriteAllLines(filename,favoritlåtar);

                        break;

                    case "2":

                        string[] sparadelåtar = File.ReadAllLines(filename);

                        for (int i = 0; i < sparadelåtar.Length; i++)
                        {

                            Console.WriteLine($"{i+1}.{sparadelåtar[i]}");


                            Console.WriteLine();

                        }

                        Console.WriteLine();
                        Console.WriteLine("Vill du ändra en låt i topplistan? j/n");
                        Console.WriteLine();
                        string svar = Console.ReadLine();
                        Console.WriteLine();

                        while (svar !="n")
                        {

                            if (svar == "j")
                            {

                                Console.WriteLine("Vilket nummer på topplistan vill du ändra?");
                                Console.WriteLine();
                                int låtändring = int.Parse(Console.ReadLine());
                                Console.WriteLine();

                                if (låtändring <= 0 || låtändring > sparadelåtar.Length)
                                {

                                    Console.WriteLine($"{låtändring} är inte ett giltigt låtnummer");
                                    break;

                                }

                                string[] newsonginfo = new string[2];

                                Console.WriteLine("Skriv in den nya låtens namn");
                                newsonginfo[1] = Console.ReadLine().ToLower();

                                sparadelåtar[låtändring - 1] = string.Join("", newsonginfo);

                                File.WriteAllLines(filename, sparadelåtar);

                                break;


                            }
                            else if (svar == "n")
                            {

                                break;

                            }
                            else
                            {

                                Console.WriteLine("Det är inte en giltig svar");
                                Console.WriteLine();
                                break;
                            }

                        }

                        break;

                    case "3":

                        string[] söklåtar = File.ReadAllLines(filename);

                        Console.WriteLine("Sök efter din låt");
                        Console.WriteLine();
                        string sök = Console.ReadLine().ToLower();
                        Console.WriteLine();

                        int räknare = 0;

                        for (int i = 0; i < söklåtar.Length; i++)
                        {

                            if (söklåtar[i].Contains(sök))
                            {

                                Console.WriteLine($"{söklåtar[i]} är en låt som innehåler {sök}");
                                Console.WriteLine();

                                räknare++;

                            }

                        }

                        if (räknare == 0)
                        {

                            Console.WriteLine($"Det finns inga låtar som innehåler {sök}");
                            Console.WriteLine();

                        }

                        break;

                    case "4":

                        Console.WriteLine("Välkommen till Musiktopplistan, här kan du skriva in och hålla koll på dina favoritlåtar. ");
                        Console.WriteLine("Skriv in vilka låtar, sedan kan du ändra lägga till eller söka efter låtarna på din topplista.");
                        Console.WriteLine();

                        break;

                    case "5":

                        Console.WriteLine("Du avslutade programmet, ha det bra!");

                        break;

                }
            }
        }
    }
}