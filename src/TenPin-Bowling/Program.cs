
namespace TenPin_Bowling
{
    using System;
    using System.Threading.Tasks;
    using TenPin_Bowling.Engines;
    using TenPin_Bowling.Common;
    using TenPin_Bowling.Domain.Interfaces;

    public class Program
    {

        public static async Task Main(string[] args)
        {
            IHelper helper = new Helper();

            var head = helper.CreateNode(null, 1, createStrike: true);
            head = helper.CreateNode(head, 2);
            head = helper.CreateNode(head, 2, createSpare: true);
            head = helper.CreateNode(head, 2);
            head = helper.CreateNode(head, 2);
            head = helper.CreateNode(head, 2);
            head = helper.CreateNode(head, 2);
            head = helper.CreateNode(head, 2);
            head = helper.CreateNode(head, 2);
            head = helper.CreateNode(head, 1, createStrike: true);
            head = helper.CreateNode(head, 1, createStrike: true);
            head = helper.CreateNode(head, 1, createStrike: true);

            var engine = new ScoreCalculatorEngine();

            var score = await engine.CalculateScoreAsync(head).ConfigureAwait(false);

            Console.WriteLine($"Total Score - {score}");
            Console.ReadKey();
        }


    }
}
