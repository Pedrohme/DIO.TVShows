using System;
using DIO.TVShows.Classes;

namespace DIO.TVShows {
    class Program {
        static void Main(string[] args) {
            ShowRepository repository = new ShowRepository();
            Menu menu = new Menu(repository);

            menu.MainLoop();
        }
    }
}
