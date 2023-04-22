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
                        $"5) Inserisci una nuova software house\n" +
                        $"6) Cerca tutti i videogiochi prodotti da una software house\n" +
                        $"7) Esci");

                    ConsoleKey tastoUtente = Console.ReadKey(true).Key;

                    switch (tastoUtente)
                    {
                        case ConsoleKey.D1:
                            {
                                Console.WriteLine("\nInserisci il nome del videogioco:");
                                string name = Console.ReadLine();

                                Console.WriteLine("Inserisci la descrizione del videogioco:");
                                string overview = Console.ReadLine();

                                Console.WriteLine("Inserisci la data di rilascio del videogioco: (DD/MM/YYYY)");
                                DateTime releaseDate = DateTime.Parse(Console.ReadLine());

                                List<SoftwareHouse> softwareHouses = VideogameManager.GetSoftwareHouseList();

                                Console.WriteLine("Scegli una software house:");


                                foreach (SoftwareHouse softwareHouse in softwareHouses)
                                {
                                    Console.WriteLine($"{softwareHouse.Id}) {softwareHouse.Name}");
                                }

                                long shId = long.Parse(Console.ReadLine());

                                Videogame newVideogame = new Videogame(name, overview, releaseDate, shId);

                                VideogameManager.InserisciVideogame(newVideogame);
                                Console.WriteLine($"\nIl videogioco '{name}' è stato aggiunto!\n");
                                break;
                            }

                        case ConsoleKey.D2:
                            {
                                Console.WriteLine("\nInserisci l'id per cercare un videogioco:");
                                long id = long.Parse(Console.ReadLine());

                                Videogame videogame = VideogameManager.RicercaPerId(id);
                                Console.WriteLine($"Trovato! Il videogioco con l'id '{id}' è '{videogame.Name}'\n");
                                Console.WriteLine(videogame.Name);

                                break;
                            }
                        case ConsoleKey.D3:
                            {
                                Console.WriteLine("\nInserisci il nome per cercare un videogioco:");
                                string name = Console.ReadLine();

                                List<Videogame> videogames = VideogameManager.RicercaPerNome(name);
                                Console.WriteLine($"\nEcco i videogiochi trovati con il nome '{name}':\n");
                                foreach (Videogame videogame in videogames)
                                {
                                    Console.WriteLine($"{videogame.Id}) {videogame.Name}");
                                }

                                Console.WriteLine(string.Empty);

                                break;
                            }
                        case ConsoleKey.D4:
                            {
                                Console.WriteLine("Inserisci l'id del videogioco da cancellare:");
                                long id = long.Parse(Console.ReadLine());

                                VideogameManager.CancellaVideogioco(id);
                                Console.WriteLine($"\nIl gioco con id '{id}' cancellato!\n");
                                break;
                            }
                        case ConsoleKey.D5:
                            {
                                Console.WriteLine("\nInserisci il nome della software house:");
                                string name = Console.ReadLine();

                                Console.WriteLine("Inserisci la città della software house:");
                                string city = Console.ReadLine();

                                Console.WriteLine("Inserisci la nazione della software house:");
                                string country = Console.ReadLine();

                                SoftwareHouse newSoftwareHouse = new SoftwareHouse(name, city, country);

                                VideogameManager.NuovaSoftwareHouse(newSoftwareHouse);

                                Console.WriteLine($"\nSoftware House '{name}' creata!\n");
                                break;
                            }
                        case ConsoleKey.D6:
                            {
                                List<SoftwareHouse> softwareHouses = VideogameManager.GetSoftwareHouseList();

                                Console.WriteLine("Scegli una software house:");


                                foreach (SoftwareHouse softwareHouse in softwareHouses)
                                {
                                    Console.WriteLine($"{softwareHouse.Id}) {softwareHouse.Name}");
                                }

                                long id = long.Parse(Console.ReadLine());

                                Console.WriteLine($"\nI videogiochi prodotti da '{softwareHouses[(int)id - 1].Name}' sono i seguenti:\n");

                                List<Videogame> videogames = VideogameManager.GetSoftwareHouseVideogames(id);

                                foreach (Videogame videogame in videogames)
                                {
                                    Console.WriteLine($"{videogame.Id}) {videogame.Name}");
                                }

                                Console.WriteLine(string.Empty);

                                break;
                            }
                        case ConsoleKey.D7:
                            {
                                Console.WriteLine("\nArrivederci!\n");
                                return;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n**************************************************************\n" +
                        $"**\n" +
                        $"** {ex.Message}\n" +
                        $"**\n" +
                        $"***************************************************************\n");
                }
            }


        }
    }
}