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

namespace MaddenDraftClassGeneratorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }

        private void GenerateDraftClass_Clicked(object sender, RoutedEventArgs e) {
            string sleepers = sleepersTxt.Text;
            //Console.WriteLine("Sleepers percentage: " + sleepersTxt.Text);
            GenerateDraft(Int32.Parse(sleepersTxt.Text), Int32.Parse(bustsTxt.Text), 
                           Int32.Parse(roundOneTxt.Text), Int32.Parse(roundTwoTxt.Text), Int32.Parse(roundThreeTxt.Text), 
                           Int32.Parse(roundFourTxt.Text), Int32.Parse(roundFiveTxt.Text), Int32.Parse(roundSixTxt.Text), 
                           Int32.Parse(roundSevenTxt.Text));
        }

        private List<Player> GenerateDraft(int sleepers, int busts, int r1, int r2, int r3, int r4, int r5, int r6, int r7) {
            Random random = new Random();

            const int PLAYER_GEN_COUNT = 100;
            List<string> stringList = new List<string>();
            List<Player> playerList = new List<Player>();

            for (int i=0; i < PLAYER_GEN_COUNT; i++) {
                Player genPlayer = new Player();
                int typeNum = random.Next(100);

                string typeOfPlayer = "";

                if (typeNum < sleepers) {
                    typeOfPlayer = "Sleeper";
                    genPlayer.PlayerType = "Sleeper";
                } else if (typeNum < (sleepers + busts)) {
                    typeOfPlayer = "Bust";
                    genPlayer.PlayerType = "Bust";
                } else {
                    typeOfPlayer = "Regular";
                    genPlayer.PlayerType = "Regular";
                }

                int roundPickNum = random.Next(100);
                int pickNum = random.Next(32) + 1;

                if (typeOfPlayer == "Sleeper" || typeOfPlayer == "Bust") {
                    if (typeOfPlayer == "Sleeper") {
                        if (roundPickNum / 25 < 1) {
                            typeOfPlayer += $" R4:P{pickNum}";
                            genPlayer.DraftRound = 4;
                            genPlayer.DraftPick = pickNum;
                        } else if (roundPickNum / 25 < 2) {
                            typeOfPlayer += $" R5:P{pickNum}";
                            genPlayer.DraftRound = 5;
                            genPlayer.DraftPick = pickNum;
                        } else if (roundPickNum / 25 < 3) {
                            typeOfPlayer += $" R6:P{pickNum}";
                            genPlayer.DraftRound = 6;
                            genPlayer.DraftPick = pickNum;
                        } else {
                            typeOfPlayer += $" R7:P{pickNum}";
                            genPlayer.DraftRound = 7;
                            genPlayer.DraftPick = pickNum;
                        }
                    } else {
                        if (roundPickNum % 2 == 0) {
                            typeOfPlayer += $" R1:P{pickNum}";
                            genPlayer.DraftRound = 1;
                            genPlayer.DraftPick = pickNum;
                        } else {
                            typeOfPlayer += $" R2:P{pickNum}";
                            genPlayer.DraftRound = 2;
                            genPlayer.DraftPick = pickNum;
                        }
                    }
                } else {
                    if (roundPickNum < r1) {
                        typeOfPlayer += $" R1:P{pickNum}";
                        genPlayer.DraftRound = 1;
                        genPlayer.DraftPick = pickNum;
                    } else if (roundPickNum < (r1 + r2)) {
                        typeOfPlayer += $" R2:P{pickNum}";
                        genPlayer.DraftRound = 2;
                        genPlayer.DraftPick = pickNum;
                    } else if (roundPickNum < (r1 + r2 + r3)) {
                        typeOfPlayer += $" R3:P{pickNum}";
                        genPlayer.DraftRound = 3;
                        genPlayer.DraftPick = pickNum;
                    } else if (roundPickNum < (r1 + r2 + r3 + r4)) {
                        typeOfPlayer += $" R4:P{pickNum}";
                        genPlayer.DraftRound = 4;
                        genPlayer.DraftPick = pickNum;
                    } else if (roundPickNum < (r1 + r2 + r3 + r4 + r5)) {
                        typeOfPlayer += $" R5:P{pickNum}";
                        genPlayer.DraftRound = 5;
                        genPlayer.DraftPick = pickNum;
                    } else if (roundPickNum < (r1 + r2 + r3 + r4 + r5 + r6)) {
                        typeOfPlayer += $" R6:P{pickNum}";
                        genPlayer.DraftRound = 6;
                        genPlayer.DraftPick = pickNum;
                    } else {
                        typeOfPlayer += $" R7:P{pickNum}";
                        genPlayer.DraftRound = 7;
                        genPlayer.DraftPick = pickNum;
                    }
                }
                stringList.Add(typeOfPlayer);
                playerList.Add(PlayerGenerator.GeneratePlayer(genPlayer));
                //Console.WriteLine(typeOfPlayer);
            }

            drafteeListView.ItemsSource = playerList;

            return null;
        }

        private void drafteeListView_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            Player p = drafteeListView.SelectedItem as Player;
            //Console.WriteLine("MainWindow -- \n" + p);
            PlayerDetailsWindow playerDetailsWindow = new PlayerDetailsWindow(p);
            playerDetailsWindow.ShowDialog();
        }
    }
}
