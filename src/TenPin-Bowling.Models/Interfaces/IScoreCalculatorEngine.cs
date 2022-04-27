
namespace TenPin_Bowling.Domain.Interfaces
{
    using System.Threading.Tasks;
    using TenPin_Bowling.Domain.Models;

    public interface IScoreCalculatorEngine
    {
        Task<int> CalculateScoreAsync(Frame head);
    }
}
