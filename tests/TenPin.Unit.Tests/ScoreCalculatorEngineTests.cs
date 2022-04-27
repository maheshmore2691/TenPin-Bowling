
namespace TenPin.Unit.Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TenPin_Bowling.Domain.Interfaces;
    using TenPin_Bowling.Domain.Models;
    using TenPin_Bowling.Engines;

    [TestClass]
    public class ScoreCalculatorEngineTests
    {
        private readonly Mock<IHelper> _mockHelper;
        private readonly IScoreCalculatorEngine _scoreCalculatorEngine;

        public ScoreCalculatorEngineTests()
        {
            _mockHelper = new Mock<IHelper>();
            _scoreCalculatorEngine = new ScoreCalculatorEngine();
        }

        [TestInitialize]
        public void TestInit()
        {
            _mockHelper.Setup(x => x.CreateNode(It.IsAny<Frame>(), It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns(new Frame());
        }

        [TestMethod]
        public async Task ScoreEngine_ReturnScore()
        {
            int expectedScore = 14;

            var frame = new Frame()
            {
                Rolls = new List<Roll>
                {
                    new Roll { Sequence = 1, PinsKnockDownCount = 4 },
                    new Roll { Sequence = 2, PinsKnockDownCount = 5 }
                },
                Next = new Frame
                {
                    Rolls = new List<Roll>
                    {
                        new Roll { Sequence = 1, PinsKnockDownCount = 2 },
                        new Roll { Sequence = 2, PinsKnockDownCount = 3 }
                    }
                }
            };

            var result = await _scoreCalculatorEngine.CalculateScoreAsync(frame).ConfigureAwait(false);

            Assert.AreEqual(expectedScore, result, "Result does't match");
        }

        [TestMethod]
        public async Task ScoreEngine_IsSpere()
        {
            int expectedScore = 17;

            var frame = new Frame()
            {
                Rolls = new List<Roll>
                {
                    new Roll { Sequence = 1, PinsKnockDownCount = 4 },
                    new Roll { Sequence = 2, PinsKnockDownCount = 6 }
                },
                Next = new Frame
                {
                    Rolls = new List<Roll>
                    {
                        new Roll { Sequence = 1, PinsKnockDownCount = 2 },
                        new Roll { Sequence = 2, PinsKnockDownCount = 3 }
                    }
                }
            };

            var result = await _scoreCalculatorEngine.CalculateScoreAsync(frame).ConfigureAwait(false);

            Assert.AreEqual(expectedScore, result, "Result does't match");
        }

        [TestMethod]
        public async Task ScoreEngine_IsStrike()
        {
            int expectedScore = 20;

            var frame = new Frame()
            {
                Rolls = new List<Roll>
                {
                    new Roll { Sequence = 1, PinsKnockDownCount = 10 }
                },
                Next = new Frame
                {
                    Rolls = new List<Roll>
                    {
                        new Roll { Sequence = 1, PinsKnockDownCount = 2 },
                        new Roll { Sequence = 2, PinsKnockDownCount = 3 }
                    }
                }
            };

            var result = await _scoreCalculatorEngine.CalculateScoreAsync(frame).ConfigureAwait(false);

            Assert.AreEqual(expectedScore, result, "Result does't match");
        }
    }
}
