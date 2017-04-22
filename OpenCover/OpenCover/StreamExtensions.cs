using System.IO;
using System.Threading.Tasks;

namespace OpenCover
{
    public static class StreamExtensions
    {
        public static async Task<byte[]> ToArrayAsync(this Stream self)
        {
            byte[] buffer = new byte[self.Length];
            await self.ReadAsync(buffer, 0, buffer.Length);

            return buffer;
        }
    }
}
