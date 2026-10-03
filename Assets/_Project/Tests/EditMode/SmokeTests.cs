using NUnit.Framework;
using SnapRoyale.Core;

namespace SnapRoyale.Tests.EditMode
{
    /// <summary>
    /// テスト基盤そのものが動作することを確認するための最小テスト。
    /// </summary>
    public class SmokeTests
    {
        [Test]
        public void GameInfo_Title_IsSnapRoyale()
        {
            Assert.AreEqual("SnapRoyale", GameInfo.Title);
        }
    }
}
