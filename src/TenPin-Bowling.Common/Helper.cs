

namespace TenPin_Bowling.Common
{
    using System;
    using System.Collections.Generic;
    using TenPin_Bowling.Domain.Interfaces;
    using TenPin_Bowling.Domain.Models;

    public class Helper : IHelper
    {
        private Random randomGenerator = new Random();

        public Frame CreateNode(Frame head, int numberOfRolls, bool createSpare = false, bool createStrike = false)
        {
            var rolls = new List<Roll>();

            int sequence = 1;
            int prevPinsCount = 0;

            for (int i = 0; i < numberOfRolls; i++)
            {
                var maxValue = prevPinsCount > 0 ? (10 - prevPinsCount) : 10;
                var randomValue = randomGenerator.Next(1, maxValue);

                if (createStrike)
                {
                    randomValue = 10;
                }
                else if (createSpare && sequence == 2)
                {
                    randomValue = 10 - prevPinsCount;
                }

                rolls.Add(new Roll
                {
                    Sequence = sequence,
                    PinsKnockDownCount = randomValue
                });

                sequence++;
                prevPinsCount = randomValue;

                if (createStrike)
                {
                    break;
                }
            }

            return InsertNode(head, rolls);
        }

        public Frame InsertNode(Frame head, List<Roll> rolls)
        {
            var node = new Frame
            {
                Rolls = rolls
            };

            if (head == null)
            {
                head = node;
            }
            else
            {
                Frame tmp = head;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = node;
            }
            return head;
        }
    }
}
