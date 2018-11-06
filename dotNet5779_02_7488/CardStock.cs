using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace dotNet5779_02_7488
{
    class CardStock: IEnumerable
    {
        #region fields
        private List<Card> Cards = new List<Card>();
        #endregion

        #region ctor
        public CardStock()
        {
            //cards in card stock from [i] up to 15
            //building cardstock
            for (int i = 2, upTo = 15; i < upTo; i++)
            {
                Cards.Add(new Card(Card.E_Color.Red, i));
                Cards.Add(new Card(Card.E_Color.Black, i));
            }
            return;
        }
        #endregion

        #region metods
        public override string ToString()
        {

            string str = null;
            foreach (Card klaf in Cards)
            {
                str += klaf;
            }
            return str;
        }

        //swap between to card
        private void swap(int first, int secend)
        {
            Card temp = Cards[first];
            Cards[first] = Cards[secend];
            Cards[secend] = temp;
            return;
        }

        public CardStock interfere()
        {
            Random rNumInterfere = new Random();
            // Generate and initilizate to len random integer between 0 and 26
            int len = rNumInterfere.Next(26);
            for (int i = 0; i < len; i++)
            {
                // Swap random cards
                int index1 = rNumInterfere.Next(26);
                int index2 = rNumInterfere.Next(26);
                if (index1 != index2)
                    swap(index1, index2);
            }
            return this;
        }

        //distribute the deck between the player
        public void distribute(params Player[] players)
        {
            List<Card> temp;
            foreach (Player p in players)
            {
                temp = Cards.GetRange(0, (26 / players.Length));
                p.addCard(temp.ToArray());
                Cards.RemoveRange(0, 26 / (players.Length));
            }
            return;
        }

        public void sort()
        {
            this.sort();
            return;
        }

        public CardStock addCard(Card nCard)
        {
            this.Cards.Add(nCard);
            return this;
        }

        public void removeCard(Card exCard)
        {
            this.Cards.Remove(exCard);
            return;
        }

        //overloding itrator for the foreach
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(Cards);
        }

        public class MyEnumerator : IEnumerator
        {
            private List<Card> _Cards;
            private int index = -1;
            public MyEnumerator(List<Card> temp) { _Cards = temp; }
            object IEnumerator.Current
            {
                get
                {
                    return _Cards[index];
                }
            }

            bool IEnumerator.MoveNext()
            {
                index++;
                if (index >= _Cards.Count)
                {
                    index = -1;
                    return false;
                }
                return true;
            }

            void IEnumerator.Reset()
            {
                index = -1;
            }
        }
        #endregion

    }
}
