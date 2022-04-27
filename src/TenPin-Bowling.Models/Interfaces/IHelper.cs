
namespace TenPin_Bowling.Domain.Interfaces
{
    using System.Collections.Generic;
    using TenPin_Bowling.Domain.Models;

    public interface IHelper
    {
        Frame CreateNode(Frame head, int numberOfRolls, bool createSpare = false, bool createStrike = false);
        Frame InsertNode(Frame head, List<Roll> rolls);
    }
}
