namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Cosa vuoi fare?\n");
                    Console.WriteLine($"1) Inserire un videogioco\n" +
                        $"2) Ricercare un videogioco per ID\n" +
                        $"3) Ricercare un videogioco per nome\n" +
                        $"4) Eliminare un videogioco\n" +
                        $"5) Esci");

                    ConsoleKey tastoUtente = Console.ReadKey(true).Key;

                    switch (tastoUtente)
                    {
                        case ConsoleKey.D1:

                            Console.WriteLine("Inserisci il nome del videogioco:");
                            string name = Console.ReadLine();

                            Console.WriteLine("Inserisci la descrizione del videogioco:");
                            string overview = Console.ReadLine();

                            Console.WriteLine("Inserisci la data di rilascio del videogioco:");
                            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Le scelte possibili per la Software House sono: \n" +
                                "1) Nintendo \n" +
                                "2) Rockstar Games \n" +
                                "3) Valve Corporation \n" +
                                "4) Electronic Arts \n" +
                                "5) Ubisoft \n" +
                                "6) Konami \n");

                            long shId = long.Parse(Console.ReadLine());

                            Videogame newVideogame = new Videogame(name, overview, releaseDate, shId);

                            VideogameManager.InserisciVideogame(newVideogame);

                            break;

                        case ConsoleKey.D2:

                            Console.WriteLine("Inserisci l'id per cercare un videogioco:");
                            long id = long.Parse(Console.ReadLine());

                            Videogame videogame = VideogameManager.RicercaPerId(id);
                            Console.WriteLine(videogame.Name);

                            break;

                        case ConsoleKey.D3:

                            Console.WriteLine("Inserisci il nome per cercare un videogioco:");
                            string nome = Console.ReadLine();

                            List<Videogame> videogameList = VideogameManager.RicercaPerNome(nome);

                            foreach (Videogame videogameSearched in videogameList)
                            {
                                Console.WriteLine(videogameSearched.Name);
                            }

                            break;

                        case ConsoleKey.D4:

                            Console.WriteLine("Inserisci l'id del videogioco da cancellare:");
                            long idVideogame = long.Parse(Console.ReadLine());

                            VideogameManager.CancellaVideogioco(idVideogame);

                            break;

                        case ConsoleKey.D5:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }
    }
}