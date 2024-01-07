using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    public class User
    {
        //to hold the user's chosen:

        //language:
            //0 = english
            //1 = spanish
            //2 = japanese
        private int language;
        //colour blind
        private bool colourBlind;
        //font size:
            //0 = small
            //1 = medium
            //2 = large
        private int fontSize;

        //get and set methods for variables:
        public int Language { get => language; set => language = value; }
        public bool ColourBlind { get => colourBlind; set => colourBlind = value; }
        public int FontSize { get => fontSize; set => fontSize = value; }

        //constructor method
        public User()
        {
            //default settings:
            Language = 0;
            ColourBlind = false;
            FontSize = 1;
        }

    }
}
