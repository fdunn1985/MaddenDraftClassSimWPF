using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaddenDraftClassGeneratorWPF
{
    class PlayerGenerator
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public static int RandomNumber(int range) {
            lock (syncLock) {
                return random.Next(range);
            }
        }

        public static Player GeneratePlayer(Player player) {
            player.Pos = GenerateInitialPosition();
            player.JerseyNumber = GeneratePlayerNumber(player.Pos);
            GenerateInitialAttributeValues(player);
            GeneratePersonalDetails(player);

            switch (player.Pos) {
                case Position.QB:
                    GenerateQBAttributes(player);
                    break;
                default: break;
            }

            return player;
        }

        private static Position GenerateInitialPosition() {
            Position temp = new Position();

            // QB - 6%
            // RB - 10%
            // WR - 15%
            // TE - 5%
            // OL - 17%
            // DL - 17%
            // LB - 13%
            // DB - 15%
            // K - 2%

            const int QB_MAX = 6;
            const int RB_MAX = 10;
            const int WR_MAX = 15;
            const int TE_MAX = 5;
            const int OL_MAX = 17;
            const int DL_MAX = 17;
            const int LB_MAX = 13;
            const int DB_MAX = 15;
            //const int K_MAX = 2;


            int num = RandomNumber(100);

            if (num < QB_MAX) {
                temp = Position.QB;
            } else if (num < (QB_MAX + RB_MAX)) {
                num = RandomNumber(5);
                if (num < 4) {
                    temp = Position.RB;
                } else {
                    temp = Position.FB;
                }
            } else if (num < (QB_MAX + RB_MAX + WR_MAX)) {
                temp = Position.WR;
            } else if (num < (QB_MAX + RB_MAX + WR_MAX + TE_MAX)) {
                temp = Position.TE;
            } else if (num < (QB_MAX + RB_MAX + WR_MAX + TE_MAX + OL_MAX)) {
                num = RandomNumber(5);
                switch (num) {
                    case 0:
                        temp = Position.LT;
                        break;
                    case 1:
                        temp = Position.LG;
                        break;
                    case 2:
                        temp = Position.C;
                        break;
                    case 3:
                        temp = Position.RG;
                        break;
                    default:
                        temp = Position.RT;
                        break;
                }
            } else if (num < (QB_MAX + RB_MAX + WR_MAX + TE_MAX + OL_MAX + DL_MAX)) {
                num = RandomNumber(4);
                switch (num) {
                    case 0:
                    case 1:
                        temp = Position.DT;
                        break;
                    case 2:
                        temp = Position.LE;
                        break;
                    default:
                        temp = Position.RE;
                        break;
                }
            } else if (num < (QB_MAX + RB_MAX + WR_MAX + TE_MAX + OL_MAX + DL_MAX + LB_MAX)) {
                num = RandomNumber(4);
                switch (num) {
                    case 0:
                    case 1:
                        temp = Position.MLB;
                        break;
                    case 2:
                        temp = Position.LOLB;
                        break;
                    default:
                        temp = Position.ROLB;
                        break;
                }

            } else if (num < (QB_MAX + RB_MAX + WR_MAX + TE_MAX + OL_MAX + DL_MAX + LB_MAX + DB_MAX)) {
                num = RandomNumber(4);
                switch (num) {
                    case 0:
                    case 1:
                        temp = Position.CB;
                        break;
                    case 2:
                        temp = Position.FS;
                        break;
                    default:
                        temp = Position.SS;
                        break;
                }
            } else {
                num = RandomNumber(2);
                if (num < 1) {
                    temp = Position.K;
                } else {
                    temp = Position.P;
                }
            }

            return temp;
        }

        private static int GeneratePlayerNumber(Position pos) {
            int num = 0;
            int temp = 0;

            switch (pos) {
                case Position.QB:
                case Position.K:
                case Position.P: num = RandomNumber(19) + 1;
                    break;
                case Position.RB:
                case Position.FB: num = RandomNumber(29) + 20;
                    break;
                case Position.WR: temp = RandomNumber(19) + 10;
                    num = (temp > 19) ? temp + 60 : temp;
                    break;
                case Position.TE: temp = RandomNumber(19) + 40;
                    num = (temp > 49) ? temp + 30 : temp;
                    break;
                case Position.LT:
                case Position.LG:
                case Position.C:
                case Position.RG:
                case Position.RT: num = RandomNumber(29) + 50;
                    break;
                case Position.LE:
                case Position.RE:
                case Position.DT: temp = RandomNumber(19) + 60;
                    num = (temp > 69) ? temp + 20 : temp;
                    break;
                case Position.LOLB:
                case Position.ROLB:
                case Position.MLB: temp = RandomNumber(39) + 40;
                    num = (temp > 69) ? temp + 20 : temp;
                    break;
                case Position.CB:
                case Position.FS:
                case Position.SS: num = RandomNumber(29) + 20;
                    break;

                default: num = 0;
                    break;
            }

            return num;
        }

        private static void GenerateInitialAttributeValues(Player p) {
            p.Speed = 30;
            p.Acceleration = 30;
            p.Agility = 30;
            p.Strength = 30;
            p.Awareness = 30;

            p.ThrowPower = 30;
            p.ShortAccuracy = 30;
            p.MediumAccuracy = 30;
            p.DeepAccuracy = 30;
            p.ThrowOnRun = 30;
            p.ThrowUnderPressure = 30;
            p.PlayAction = 30;
            p.BreakSack = 30;

            p.Carrying = 30;
            p.BcVision = 30;
            p.BreakTackle = 30;
            p.Trucking = 30;
            p.StiffArm = 30;
            p.Elusiveness = 30;
            p.SpinMove = 30;
            p.JukeMove = 30;

            p.Catching = 30;
            p.CatchInTraffic = 30;
            p.SpectacularCatch = 30;
            p.ShortRouteRunning = 30;
            p.MediumRouteRunning = 30;
            p.DeepRouteRunning = 30;
            p.Release = 30;
            p.Jumping = 30;

            p.PassBlocking = 30;
            p.PassBlockPower = 30;
            p.PassBlockFinesse = 30;
            p.RunBlocking = 30;
            p.RunBlockPower = 30;
            p.RunBlockFinesse = 30;
            p.LeadBlock = 30;
            p.ImpactBlock = 30;

            p.PlayRecognition = 30;
            p.Tackling = 30;
            p.HitPower = 30;
            p.BlockShedding = 30;
            p.FinesseMoves = 30;
            p.Pursuit = 30;
            p.ManCoverage = 30;
            p.ZoneCoverage = 30;
            p.Press = 30;

            p.KickReturn = 30;
            p.KickPower = 30;
            p.KickAccuracy = 30;
            p.Stamina = 30;
            p.Toughness = 30;
            p.Injury = 30;
        }

        private static void GeneratePersonalDetails(Player p) {
            // Generate Name
            // Generate College

            p.IsLeftHanded = ((RandomNumber(10)) + 1 == 1);

            int num = RandomNumber(100);
            if (num < 35) {
                p.Age = 21;
            } else if (num < 65) {
                p.Age = 20;
            } else if (num < 85) {
                p.Age = 22;
            } else if (num < 95) {
                p.Age = 23;
            } else {
                p.Age = 24;
            }

            // Generate Height
            double[] heightArr = new double[] { 5.06, 5.07, 5.08, 5.09, 5.10, 5.11, 6.00, 6.01, 6.02,
                                       6.03, 6.04, 6.05, 6.06, 6.07, 6.08, 6.09 };

            switch (p.Pos) {
                case Position.QB:
                    p.Height = heightArr[RandomNumber(12)+4];
                    break;
                case Position.K:
                case Position.P:
                    p.Height = heightArr[RandomNumber(10)];
                    break;
                case Position.RB:
                case Position.FB:
                    p.Height = heightArr[RandomNumber(9)];
                    break;
                case Position.WR:
                    p.Height = heightArr[RandomNumber(10)+2];
                    break;
                case Position.TE:
                    p.Height = heightArr[RandomNumber(8) + 7];
                    break;
                case Position.LT:
                case Position.LG:
                case Position.C:
                case Position.RG:
                case Position.RT:
                    p.Height = heightArr[RandomNumber(8) + 8];
                    break;
                case Position.LE:
                case Position.RE:
                case Position.DT:
                    p.Height = heightArr[RandomNumber(8) + 8];
                    break;
                case Position.LOLB:
                case Position.ROLB:
                case Position.MLB:
                    p.Height = heightArr[RandomNumber(8) + 5];
                    break;
                case Position.CB:
                case Position.FS:
                case Position.SS:
                    p.Height = heightArr[RandomNumber(9) + 2];
                    break;
                default:
                    p.Height = 0.0;
                    break;
            }

            // Generate Weight
            switch (p.Pos) {
                case Position.QB:
                    p.Weight = RandomNumber(60) + 185;
                    break;
                case Position.K:
                case Position.P:
                    p.Weight = RandomNumber(40) + 170;
                    break;
                case Position.RB:
                case Position.FB:
                    p.Weight = RandomNumber(45) + 185;
                    break;
                case Position.WR:
                    p.Weight = RandomNumber(45) + 180;
                    break;
                case Position.TE:
                    p.Weight = RandomNumber(30) + 240;
                    break;
                case Position.LT:
                case Position.LG:
                case Position.C:
                case Position.RG:
                case Position.RT:
                    p.Weight = RandomNumber(70) + 260;
                    break;
                case Position.LE:
                case Position.RE:
                case Position.DT:
                    p.Weight = RandomNumber(65) + 250;
                    break;
                case Position.LOLB:
                case Position.ROLB:
                case Position.MLB:
                    p.Weight = RandomNumber(55) + 205;
                    break;
                case Position.CB:
                case Position.FS:
                case Position.SS:
                    p.Weight = RandomNumber(50) + 170;
                    break;
                default:
                    p.Weight = 0;
                    break;
            }

            // Generate Development
            const string NORMAL_DEV = "Normal";
            const string STAR_DEV = "Star";
            const string SUPERSTAR_DEV = "SuperStar";
            const string XFACTOR_DEV = "XFactor";
            if (p.PlayerType == "Sleeper") {
                num = RandomNumber(2);
                if (num < 1) {
                    p.Development = SUPERSTAR_DEV;
                } else {
                    p.Development = XFACTOR_DEV;
                }
            } else if (p.PlayerType == "Bust") {
                p.Development = NORMAL_DEV;
            } else {
                num = RandomNumber(100);
                switch(p.DraftRound) {
                    case 1: 
                        if (num < 30) { p.Development = XFACTOR_DEV; } 
                        else if (num < 80) { p.Development = SUPERSTAR_DEV; }
                        else { p.Development = STAR_DEV; }
                        break;
                    case 2:
                        if (num < 20) { p.Development = XFACTOR_DEV; } 
                        else if (num < 60) { p.Development = SUPERSTAR_DEV; } 
                        else if (num < 90) { p.Development = STAR_DEV; }
                        else { p.Development = NORMAL_DEV; }
                        break;
                    case 3:
                        if (num < 10) { p.Development = XFACTOR_DEV; } 
                        else if (num < 40) { p.Development = SUPERSTAR_DEV; } 
                        else if (num < 70) { p.Development = STAR_DEV; } 
                        else { p.Development = NORMAL_DEV; }
                        break;
                    case 4:
                        if (num < 5) { p.Development = XFACTOR_DEV; } 
                        else if (num < 20) { p.Development = SUPERSTAR_DEV; } 
                        else if (num < 50) { p.Development = STAR_DEV; } 
                        else { p.Development = NORMAL_DEV; }
                        break;
                    case 5:
                        if (num < 1) { p.Development = XFACTOR_DEV; } 
                        else if (num < 10) { p.Development = SUPERSTAR_DEV; } 
                        else if (num < 30) { p.Development = STAR_DEV; } 
                        else { p.Development = NORMAL_DEV; }
                        break;
                    case 6:
                        if (num < 1) { p.Development = XFACTOR_DEV; } 
                        else if (num < 4) { p.Development = SUPERSTAR_DEV; } 
                        else if (num < 10) { p.Development = STAR_DEV; } 
                        else { p.Development = NORMAL_DEV; }
                        break;
                    case 7:
                        if (num < 1) { p.Development = XFACTOR_DEV; } 
                        else if (num < 2) { p.Development = SUPERSTAR_DEV; } 
                        else if (num < 5) { p.Development = STAR_DEV; } 
                        else { p.Development = NORMAL_DEV; }
                        break;
                    default: break;


                }
            }


        }
    
        private static void GenerateQBAttributes(Player p) {
            string[] archetypes = new string[] { "Improvisor", "Scrambler", "FieldGeneral", "StrongArm" };
            string arch = archetypes[RandomNumber(4)];

            string[] sensePressureTraits = new string[] { "Paranoid", "TriggerHappy", "Ideal", "Average", "Oblivious" };
            string[] forcePassesTraits = new string[] { "Conservative", "Ideal", "Aggressive" };

            string[] customQbStyles = new string[] { };

            // find out attributes by archetype

            if (arch == "StrongArm") {
                p.ThrowPower = RandomNumber(15) + 85;

                switch(p.DraftRound) {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    default:
                        p.ShortAccuracy = 0;
                        p.MediumAccuracy = 0;
                        p.DeepAccuracy = 0;
                        p.ThrowOnRun = 0;
                        p.ThrowUnderPressure = 0;
                        p.PlayAction = 0;
                        p.BreakSack = 0;
                        p.ThrowBallAway = false;
                        p.ThrowTightSpiral = false;
                        p.SensePressure = sensePressureTraits[0];
                        p.ForcesPasses = forcePassesTraits[2];
                        break;
                }

                // affected by draft round
                p.ShortAccuracy = 0;
                p.MediumAccuracy = 0;
                p.DeepAccuracy = 0;
            }
        }
    }
}
