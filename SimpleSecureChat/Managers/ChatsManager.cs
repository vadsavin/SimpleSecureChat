using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSecureChat.Managers
{
    public static class ChatsManager
    {
        public static List<FileStream> OpendChatStreams { get; private set; }

        private static void DisposeUnusedChats()
        {
            
        }
    }
}
