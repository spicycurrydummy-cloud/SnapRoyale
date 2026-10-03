using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace SnapRoyale.Tests.PlayMode
{
    /// <summary>
    /// PlayModeテスト基盤そのものが動作することを確認するための最小テスト。
    /// </summary>
    public class SmokePlayModeTests
    {
        [UnityTest]
        public IEnumerator Frame_Advances()
        {
            int start = Time.frameCount;
            yield return null;
            Assert.Greater(Time.frameCount, start);
        }
    }
}
