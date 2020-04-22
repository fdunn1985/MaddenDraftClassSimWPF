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
using System.Windows.Shapes;

namespace MaddenDraftClassGeneratorWPF
{
    /// <summary>
    /// Interaction logic for PlayerDetailsWindow.xaml
    /// </summary>
    public partial class PlayerDetailsWindow : Window
    {
        public PlayerDetailsWindow(Player p) {
            InitializeComponent();
            //Console.WriteLine(p);

            PosNumberLbl.Content = p.Pos.ToString() + " - #" + p.JerseyNumber;
            RoundPickLbl.Content = "Round " + p.DraftRound + " - Pick " + p.DraftPick;
            PlayerTypeLbl.Content = p.PlayerType;
            HandednessLbl.Content = (p.IsLeftHanded) ? "Left Handed" : "Right Handed";
            AgeLbl.Content = $"Age: {p.Age}";
            HeightWeightLbl.Content = $"{p.Height}, {p.Weight} lbs";
            DevelopmentLbl.Content = $"{p.Development} Dev";
        }
    }
}
