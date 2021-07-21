using System.Collections.Generic;

namespace DIO.TVShows.Interfaces {
    public interface IRepository<T> {
        List<T> List();
        T GetById(int id);
        void Insert(T record);
        void Remove(int id);
        void Update(int id, T record);
        int NextId();
    }
}