using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaddenDraftClassGeneratorWPF
{
    public class Player
    {
        public int Id { get; set; }
        public int DraftRound { get; set; }
        public int DraftPick { get; set; }
        public string PlayerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Pos { get; set; }
        public int JerseyNumber { get; set; }
        public string College { get; set; }
        public bool IsLeftHanded { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public int Weight { get; set; }
        public string Development { get; set; }


        // General Attributes
        public int Speed { get; set; }
        public int Acceleration { get; set; }
        public int Agility { get; set; }
        public int Strength { get; set; }
        public int Awareness { get; set; }


        // Passing Attributes
        public int ThrowPower { get; set; }
        public int ShortAccuracy { get; set; }
        public int MediumAccuracy { get; set; }
        public int DeepAccuracy { get; set; }
        public int ThrowOnRun { get; set; }
        public int ThrowUnderPressure { get; set; }
        public int PlayAction { get; set; }
        public int BreakSack { get; set; }
        public bool ThrowBallAway { get; set; }
        public bool ThrowTightSpiral { get; set; }
        public string SensePressure { get; set; }
        public string ForcesPasses { get; set; }
        public string QbStyle { get; set; }

        // Running Attributes
        public int Carrying { get; set; }
        public int BcVision { get; set; }
        public int BreakTackle { get; set; }
        public int Trucking { get; set; }
        public int StiffArm { get; set; }
        public int Elusiveness { get; set; }
        public int SpinMove { get; set; }
        public int JukeMove { get; set; }
        public bool FightForYards { get; set; }
        public string CoversBall { get; set; }


        // Receiving Attributes
        public int Catching { get; set; }
        public int CatchInTraffic { get; set; }
        public int SpectacularCatch { get; set; }
        public int ShortRouteRunning { get; set; }
        public int MediumRouteRunning { get; set; }
        public int DeepRouteRunning { get; set; }
        public int Release { get; set; }
        public int Jumping { get; set; }
        public bool AggressiveCatch { get; set; }
        public bool PossessionCatch { get; set; }
        public bool RunAfterCatch { get; set; }

        // Blocking Attributes
        public int PassBlocking { get; set; }
        public int PassBlockPower { get; set; }
        public int PassBlockFinesse { get; set; }
        public int RunBlocking { get; set; }
        public int RunBlockPower { get; set; }
        public int RunBlockFinesse { get; set; }
        public int LeadBlock { get; set; }
        public int ImpactBlock { get; set; }

        // Defensive Attributes
        public int PlayRecognition { get; set; }
        public int Tackling { get; set; }
        public int HitPower { get; set; }
        public int BlockShedding { get; set; }
        public int FinesseMoves { get; set; }
        public int Pursuit { get; set; }
        public int ManCoverage { get; set; }
        public int ZoneCoverage { get; set; }
        public int Press { get; set; }
        public string PlaysBallInAir { get; set; }
        public bool BigHitter { get; set; }
        public bool UtilizeFinesseMoves { get; set; }
        public bool UtilizePowerMoves { get; set; }
        public bool HighMotor { get; set; }
        public bool Predictability { get; set; }
        public string LbStyle { get; set; }
        public bool StripsBall { get; set; }

        // Other Attributes
        public int KickReturn { get; set; }
        public int KickPower { get; set; }
        public int KickAccuracy { get; set; }
        public int Stamina { get; set; }
        public int Toughness { get; set; }
        public int Injury { get; set; }


        public override string ToString() {
            return $"{PlayerType} - Round: {DraftRound}, Pick: {DraftPick}, ({Pos}) - #{JerseyNumber}";
        }
    }
}
