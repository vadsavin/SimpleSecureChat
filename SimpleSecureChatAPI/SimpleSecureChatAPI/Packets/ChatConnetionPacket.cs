using SimpleSecureChatAPI.Enums;
using SimpleSecureChatAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSecureChatAPI.Packets
{
    public class ChatConnetionPacket : Packet<ChatConnetionPacket>
    {
        public ConnectionInfo ActionType { get; set; }
        public string ChatHash { get; set; }
        public const string Route = "connect";
        public const uint Id = 0x01;
    }
}
