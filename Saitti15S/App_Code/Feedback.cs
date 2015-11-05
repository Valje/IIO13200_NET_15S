using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class Feedback
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Learned { get; set; }
        public string WantToLearn { get; set; }
        public string Good { get; set; }
        public string Improvements { get; set; }
        public string Others { get; set; }


        public Feedback(string name, string date, string learned, string wantToLearn, string good, string improvements, string others)
        {
            this.Name = name;
            this.Date = date;
            this.Learned = learned;
            this.WantToLearn = wantToLearn;
            this.Good = good;
            this.Improvements = improvements;
            this.Others = others;
        }

    }