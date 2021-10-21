using SimpleSecureChat.User;
using System;

namespace SimpleSecureChatAPI.Packets
{
    public class ChatMessagePacket : Packet<ChatMessagePacket>
    {
        public byte[] Message { get; }
        public DateTime DateTimeUTC { get; }
        public UserInfo UserInfo { get; }
        public const string Route = "message";
        public const uint Id = 0x02;

        public ChatMessagePacket(byte[] message, DateTime dateTimeUTC, UserInfo userInfo)
        {
            Message = message;
            DateTimeUTC = dateTimeUTC == default ? DateTime.UtcNow : dateTimeUTC;
            UserInfo = userInfo;
        }
    }
}
