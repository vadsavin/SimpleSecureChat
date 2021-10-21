using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSecureChat.Chat
{
    public class Chat
    {
        public string Hash { get; }
        private static readonly string defaultChatFolder = "chats";
        public DateTime LastUpdate { get; private set; }
        private FileStream FileStream { get; private set; }

        public Chat(string hash)
        {
            Hash = hash;
        }

        private void openFileStream()
        {
            var path = Path.Combine(defaultChatFolder, Hash);
            FileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        private void disposeFileStream()
        {
            FileStream.Dispose();
        }
        

        /// <summary>
        /// Writes message to the end of the file.
        /// </summary>
        /// <param name="message">Bytes of message.</param>
        public void Write(byte[] message)
        {
            int length = (int)FileStream.Length;
            FileStream.Write(message, length, message.Length);
            byte[] size = BitConverter.GetBytes((UInt16)message.Length);
            FileStream.Write(size, length+message.Length, 2);
        }

        /// <summary>
        /// Reads one message with given index from the end.
        /// </summary>
        /// <param name="index">Index to read.</param>
        /// <returns>Bytes of read message.</returns>
        public byte[] Read(int index)
        {
            int lenght = (int)FileStream.Length;
            int offset = 0;
            UInt16 size = 0;
            for (int i = 0; i < index; i++)
            {
                byte[] plot = new byte[2];
                FileStream.Read(plot, lenght-offset-2, lenght-offset-1);
                size = BitConverter.ToUInt16(plot);
                offset += size + 2;
            }
            byte[] result = new byte[size];
            FileStream.Read(result, offset, offset+size);
            return result;
        }

        public void Update()
        {
            LastUpdate = DateTime.Now;
        }
    }
}
