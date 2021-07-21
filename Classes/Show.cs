using System;
using DIO.TVShows.Enums;

namespace DIO.TVShows.Classes {
    public class Show : BaseEntity {
        public Genres Genre { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Year { get; private set; }
        public bool Removed { get; private set; }

        public Show(int id, Genres genre, string title, string description, int year) {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Removed = false;
        }
        
        public override string ToString() {
            string ret = "";
            ret += "Genre: " + this.Genre + Environment.NewLine;
            ret += "Title: " + this.Title + Environment.NewLine;
            ret += "Description: " + this.Description + Environment.NewLine;
            ret += "Release Date: " + this.Year + Environment.NewLine;
            ret += "Removed: " + this.Removed + Environment.NewLine;

            return ret;
        }

        public void Remove() {
            this.Removed = true;
        }
    }
}