using System.Text.Json;

namespace AP2.W2017.A3Console
{
    internal class Program
    {
        static bool[,] kino = new bool[0, 0];

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("AP2 I - Winter 2017 - Aufgabe 3 \n");
            Console.ForegroundColor = ConsoleColor.Gray;

            KinoSitzplan ks = new();
            kino = ks.Seats;

            int anzahl = 6;
            int sitzNr = FreieSitze(anzahl);

            Console.WriteLine($"{anzahl} freie Sitze ab Platz: {sitzNr} \n");
            ks.ToConsole(sitzNr, anzahl);

            Console.WriteLine("\nPress [ENTER] to exit...");
            Console.ReadLine();
        }

        public static int FreieSitze(int anzahlSitze)
        {
            int firstSeat = 0;

            for (int r = 0; r < 7; r++)
            {
                int count = 0;
                int row = (r + 1) * 100;

                for (int i = 0; i < 30; i++)
                {
                    if (kino[r, i])
                    {
                        if (count == 0)
                        {
                            firstSeat = row + i + 1;
                        }
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }

                    if (count >= anzahlSitze)
                    {
                        return firstSeat;
                    }
                }
            }

            return 0;
        }
    }
}
