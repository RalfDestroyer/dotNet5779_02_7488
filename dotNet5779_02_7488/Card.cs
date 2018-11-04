using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5779_02_7488
{
    class Card: IComparable
    {
        public enum E_Color { Black, Red };

        #region fields
        private E_Color _color;
        private int _num;
        #endregion

        #region ctor
        public Card(E_Color clr, int number)
        {
            _color = clr;
            _num = number;
        }
    #endregion

    #region property
    
        public E_Color Color { get {return _color; } set {_color = value; } }

        public int Num { get { return _num; }
            set
            {
                if ((value >= 2) && (value <= 14))
                    _num = value;
            }
        }

        public string CardName
        {
            get
            {
                switch (_num)
                {
                    case (11): return "\"Jack " + Color.ToString() + "\" "; 
                    case (12): return "\"Queen " + Color.ToString() + "\" ";
                    case (13): return "\"King " + Color.ToString() + "\" ";
                    case (14): return "\"Ace " + Color.ToString() + "\" ";
                    default: return  "\"" + _num + " " + Color.ToString() + "\" ";
                }
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return CardName + Color.ToString();
        }

        public int CompareTo(object obj)
        {
            //sort by color, after then by number
            if (_color.CompareTo((obj as Card)._color) == 0)
                return _num.CompareTo((obj as Card)._num);
            else
                return _color.CompareTo((obj as Card)._color);
        }
        #endregion
    }
}
