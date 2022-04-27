
namespace TenPin_Bowling.Domain.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Frame
    {
        public List<Roll> Rolls { get; set; }

        public int TotalPinsKnockDownCount
        {
            get
            {
                return Rolls.Sum(x => x.PinsKnockDownCount);
            }
        }

        public bool IsSpere 
        {
            get
            {
                return (TotalPinsKnockDownCount == 10 && Rolls.Count == 2);
            }
        }

        public bool IsStrike
        {
            get
            {
                return (TotalPinsKnockDownCount == 10 && Rolls.Count == 1);
            }
        }

        public Frame Next { get; set; }
    }
}
