using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    class TacoBell : ITrackable
    {
        private string name;
        private Point location;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Point Location 
        {
            get { return location; } 
            set { location = value; }
        }
    }
}
