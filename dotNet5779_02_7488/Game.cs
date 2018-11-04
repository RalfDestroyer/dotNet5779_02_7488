using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5779_02_7488
{
    public partial class Game
    {
        private CardStock kupa = new CardStock();
        private Player plr1, plr2;
        #region property
        internal CardStock Kupa {
            get { return kupa; }
            set { kupa = value; } }
        internal Player Plr1 { get { return plr1; } set { plr1 = value; } }
        internal Player Plr2 { get { return plr2; } set { plr2 = value; } }
        #endregion

        public Game(string name1, string name2)
        {
            plr1 = new Player(name1);
            plr2 = new Player(name2);
        }

        public void startGame()
        {
            kupa.interfere();
            kupa.distribute(plr1, plr2);
        }
        public bool endGame()
        {
            if (!(plr1.lose()) || !(plr2.lose()))
                return true;
            else
                return false;
        }
        public void step()//pops 2 cards, one from each player, and compare between them
        {
            Card[] war = new Card[2];
            war[0] = plr1.pop();
            war[1] = plr2.pop();
            if (war[0].Num > war[1].Num)
            {
                plr1.addCard(war);
                Console.WriteLine(plr1);
                Console.WriteLine(plr2);
            }
            else if (war[1].Num > war[0].Num)
            {
                plr2.addCard(war);
                Console.WriteLine(plr1);
                Console.WriteLine(plr2);
            }
            else
            {
                evenCards(war);//function that check the next pair of cards in a reccursive way until someone is winning

            }
        }

        private void evenCards(Card[] war)
        {
            Card[] bigWar = new Card[war.Count() + 4];//define array that bigger then the last one, for insert all the cards
            int index = war.Count();
            for (int i = 0; i < index; i++)
                bigWar[i] = war[i];
            bigWar[index] = plr1.pop();
            bigWar[index + 1] = plr1.pop();
            bigWar[index + 2] = plr2.pop();
            bigWar[index + 3] = plr2.pop();
            if (!plr1.lose())
            {
                foreach (var item in bigWar)
                {
                    if (item != null)
                        plr2.addCard(item);
                }
                return;
            }
            if (!plr2.lose())
            {
                foreach (var item in bigWar)
                {
                    if (item != null)
                        plr1.addCard(item);
                }
                return;
            }
            if (bigWar[index + 1].Num > bigWar[index + 3].Num)
            {
                plr1.addCard(bigWar);
                Console.WriteLine(plr1);
                Console.WriteLine(plr2);
            }
            else if (bigWar[index + 3].Num > bigWar[index + 1].Num)
            {
                plr2.addCard(bigWar);
                Console.WriteLine(plr1);
                Console.WriteLine(plr2);
            }
            else evenCards(bigWar);//if the second couple of cards is still evevn, we get into reccursive method that stops when someone win
        }

        public string checkVictory()
        {
            if (!Plr1.lose())
                return "\nThe winner is " + Plr2.Name + "\n";
            else
                return "\nThe winner is " + Plr1.Name + "\n";
        }
               
        public override string ToString()
        {
            return Plr2.Name + ' ' + Plr2.PlayerCards.Count() + '\n' + Plr1.Name + ' ' + Plr1.PlayerCards.Count();
        }
    }
}