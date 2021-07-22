using System;
using DIO.TVShows.Enums;

namespace DIO.TVShows.Classes {
    public class Menu {
        public ShowRepository Repository { get; private set; }

        public Menu(ShowRepository repository) {
            this.Repository = repository;
        }

        private void PrintShow() {
            int showId = InputShowId();
            Console.WriteLine(Repository.GetById(showId));
        }

        private void InsertShow() {
            Show newShow = InputNewShow();
            Repository.Insert(newShow);
        }

        private void RemoveShow() {
            int showId = InputShowId();
            Repository.Remove(showId);
        }

        private void UpdateShow() {
            int showId = InputShowId();
            Show newShow = InputNewShow(showId);

            Repository.Update(showId, newShow);
        }

        private void ListShows() {
            var list = Repository.List();

            if (list.Count == 0) {
                Console.WriteLine("No shows found");
                return;
            }

            foreach (var show in list) {
                Console.WriteLine($"#ID {show.Id}: - {show.Title} { (show.Removed ? "*Removed*" : "") }");
            }
        }

        private string InputMenu() {
            Console.WriteLine();
            Console.WriteLine("DIO Shows");
            Console.WriteLine("Select an option: ");

            Console.WriteLine("1 - List Shows");
            Console.WriteLine("2 - Insert Show");
            Console.WriteLine("3 - Update Show");
            Console.WriteLine("4 - Remove Show");
            Console.WriteLine("5 - View Show");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Exit program");
            Console.WriteLine();

            return (Console.ReadLine().ToUpper());
        }

        private Show InputNewShow() {
            foreach (int i in Enum.GetValues(typeof(Genres))) {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genres), i)}");
            }

            Console.WriteLine("Insert the Show's Genre from the options above: ");
            if (!int.TryParse(Console.ReadLine(), out int showGenre)) {
                throw new ArgumentException("Invalid input");
            }
            else if (showGenre < 1 || showGenre >= Enum.GetNames(typeof(Genres)).Length) {
                throw new ArgumentException("Invalid input");
            }

            Console.WriteLine("Insert the Show's Title: ");
            string showTitle = Console.ReadLine();

            Console.WriteLine("Insert the Show's Release Year: ");
            if (!int.TryParse(Console.ReadLine(), out int showYear)) {
                throw new ArgumentException("Invalid input");
            }

            Console.WriteLine("Insert the Show's Description: ");
            string showDescription = Console.ReadLine();

            Show newShow = new Show(Repository.NextId(), (Genres)showGenre, showTitle, showDescription, showYear);

            return newShow;
        }

        private Show InputNewShow(int id) {
            foreach (int i in Enum.GetValues(typeof(Genres))) {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genres), i)}");
            }

            Console.WriteLine("Insert the Show's Genre from the options above: ");
            if (!int.TryParse(Console.ReadLine(), out int showGenre)) {
                throw new ArgumentException("Invalid input");
            }
            else if (showGenre < 1 || showGenre >= Enum.GetNames(typeof(Genres)).Length) {
                throw new ArgumentException("Invalid input");
            }

            Console.WriteLine("Insert the Show's Title: ");
            string showTitle = Console.ReadLine();

            Console.WriteLine("Insert the Show's Release Year: ");
            if (!int.TryParse(Console.ReadLine(), out int showYear)) {
                throw new ArgumentException("Invalid input");
            }

            Console.WriteLine("Insert the Show's Description: ");
            string showDescription = Console.ReadLine();

            Show newShow = new Show(id, (Genres)showGenre, showTitle, showDescription, showYear);
            return newShow;
        }

        private int InputShowId() {
            Console.WriteLine("Insert the show's ID: ");

            if (!int.TryParse(Console.ReadLine(), out int showId)) {
                throw new ArgumentException("Invalid input");
            }
            else if (showId < 0 || showId >= Repository.List().Count) {
                throw new ArgumentException("Invalid input");
            }

            return showId;
        }

        public void MainLoop() {
            string input = "";
            while (true) {
                input = InputMenu();

                switch (input) {
                    case "1":
                        ListShows();
                        break;
                    case "2":
                        try {
                            InsertShow();
                        }
                        catch (System.Exception e) {
                            System.Console.WriteLine(e.Message);
                        }
                        break;
                    case "3":
                        try {
                            UpdateShow();
                        }
                        catch (System.Exception e) {
                            System.Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        try {
                            RemoveShow();
                        }
                        catch (System.Exception e) {
                            System.Console.WriteLine(e.Message);
                        }
                        break;
                    case "5":
                        try {
                            PrintShow();
                        }
                        catch (System.Exception e) {
                            System.Console.WriteLine(e.Message);
                        }
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}