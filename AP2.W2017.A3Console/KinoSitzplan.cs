namespace AP2.W2017.A3Console
{
    public class KinoSitzplan
    {
        public bool[,] Seats { get; set; } = new bool[7, 30];
        public KinoSitzplan()
        {
            Random rand = new();

            for (int r = 0; r < Seats.GetLength(0); r++)
            {
                for (int i = 0; i < Seats.GetLength(1); i++)
                {
                    Seats[r, i] = rand.NextDouble() >= 0.5;
                }
            }
        }

        public void ToConsole(int seatNo, int count)
        {
            Console.WriteLine("Reihe | Sitz-Nummer");
            Console.WriteLine("------|------------------------------------------------------------------------------------------------------------------------");

            int seatRow = seatNo / 100 - 1;
            int seatIndex = seatNo % 100 - 1;
            
            for (int r = 0; r < Seats.GetLength(0); r++)
            {

                ConsoleColor(1);
                Console.Write($"  {r + 1}   | ");

                for (int i = 0; i < Seats.GetLength(1); i++)
                {
                    if (r == seatRow && i >= seatIndex && i < seatIndex + count)
                        Console.BackgroundColor = System.ConsoleColor.DarkGray;
                    
                    if (Seats[r, i])
                        ConsoleColor(2);
                    else 
                        ConsoleColor(3);

                    Console.Write($"{r + 1}{i + 1:D2} ");
                    Console.BackgroundColor = System.ConsoleColor.Black;
                }
                Console.WriteLine();
                ConsoleColor(1);
            }
        }

        private static void ConsoleColor(int c)
        {
            Console.ForegroundColor = c switch
            {
                1 => System.ConsoleColor.Gray,
                2 => System.ConsoleColor.Green,
                3 => System.ConsoleColor.Red,
                4 => System.ConsoleColor.Cyan,
                _ => System.ConsoleColor.Gray,
            };
        }
    }
}
