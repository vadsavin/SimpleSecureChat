using SimpleSecureChatAPI.Enums;
using SimpleSecureChatAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSecureChatAPI.Packets
{
    public class ChatConnetionPacket<TChatConnetionPacket> : JsonSerializable<TChatConnetionPacket> where TChatConnetionPacket : ChatConnetionPacket<TChatConnetionPacket>
    {
        public ConnectionInfo ActionType { get; set; }
    }
}
