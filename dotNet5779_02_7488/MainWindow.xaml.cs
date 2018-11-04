using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// RAFAEL LERMAN t.z. 327367488
namespace dotNet5779_02_7488
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Game nGame = new Game("name1", "name2");
        
        private void b_result_Click(object sender, RoutedEventArgs e)
        {
            while (nGame.endGame() != true)
                nGame.step();
            tb_finish.Text = nGame.checkVictory();
        }

        private void b_steps_Click(object sender, RoutedEventArgs e)
        {
            if (nGame.endGame() != true)
            {
                nGame.step();
                //update view of the cardstock of players
                tbl_startGame.Text = "Hello, welcome to the game, the players: \n" + nGame.Plr1 + "\nand\n" + nGame.Plr2 + "\n" +
                         "Take your decision: \n To run the game and see end result \n Or \n To run the game by steps";
            }
            else
                tb_finish.Text = nGame.checkVictory();
        }

        private void b_submit_Click(object sender, RoutedEventArgs e)
        {
            //initilize names of player`s and display it
            nGame.startGame();
            nGame.Plr1.Name = tb_plr1.Text;
            nGame.Plr2.Name = tb_plr2.Text;

            #region visibility of window
            tb_plr1.Visibility = Visibility.Hidden;
            tb_plr2.Visibility = Visibility.Hidden;
            tbl_welcome.Visibility = Visibility.Hidden;
            b_submit.Visibility = Visibility.Hidden;

            b_result.Visibility = Visibility.Visible;
            b_steps.Visibility = Visibility.Visible;
            #endregion

            tbl_startGame.Text = "Hello, welcome to the game, the players: \n" + nGame.Plr1 + "\nand\n" + nGame.Plr2 + "\n" +
                "Take your decision: \n To run the game and see end result \n Or \n To run the game by steps";


        }
    }
}
