using DIO.TVShows.Interfaces;
using System.Collections.Generic;

namespace DIO.TVShows.Classes {
    public class ShowRepository : IRepository<Show> {
        private List<Show> showList = new List<Show>();

        public List<Show> List() {
            return showList;
        }

        public Show GetById(int id) {
            return showList[id];
        }

        public void Insert(Show record) {
            showList.Add(record);
        }

        public void Remove(int id) {
            showList[id].Remove();
        }

        public void Update(int id, Show record) {
            showList[id] = record;
        }

        public int NextId() {
            return showList.Count;
        }
    }
}