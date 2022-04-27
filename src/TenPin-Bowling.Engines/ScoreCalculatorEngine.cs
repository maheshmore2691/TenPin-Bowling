
namespace TenPin_Bowling.Engines
{
    using System.Linq;
    using System.Threading.Tasks;
    using TenPin_Bowling.Domain.Interfaces;
    using TenPin_Bowling.Domain.Models;

    public class ScoreCalculatorEngine : IScoreCalculatorEngine
    {
        public Task<int> CalculateScoreAsync(Frame head)
        {
            int framesCount = 1;
            int score = 0;

            while (head != null && framesCount <= 10)
            {
                var frameScore = head.TotalPinsKnockDownCount;

                if (head.IsSpere)
                {
                    var tempHead = head.Next;

                    if (tempHead != null)
                    {
                        frameScore += tempHead.Rolls.First().PinsKnockDownCount;
                    }
                }
                else if (head.IsStrike)
                {
                    var tempHead = head.Next;
                    var maxAllowedRolls = 2;

                    while (tempHead != null && maxAllowedRolls > 0)
                    {
                        foreach (var roll in tempHead.Rolls)
                        {
                            frameScore += roll.PinsKnockDownCount;
                            maxAllowedRolls--;

                            if (maxAllowedRolls <= 0)
                            {
                                break;
                            }
                        }
                        tempHead = tempHead.Next;
                    }
                }

                score += frameScore;
                framesCount++;
                head = head.Next;
            }

            return Task.FromResult(score);
        }
    }
}
