using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace OpenCover.Tests
{
    [TestClass]
    public class StreamExtensionsTests
    {
        [TestMethod]
        public async Task TestToArrayAsync()
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                byte[] data = new byte[4] { 68, 73, 82, 75 };

                memStream.Write(data, 0, data.Length);
                memStream.Position = 0;

                byte[] bytes = await memStream.ToArrayAsync();

                Assert.IsNotNull(bytes);
                Assert.AreEqual(4, bytes.Length);
            }
        }
    }
}
