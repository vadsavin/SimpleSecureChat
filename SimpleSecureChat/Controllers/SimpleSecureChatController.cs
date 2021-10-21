using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleSecureChat.Server;
using SimpleSecureChatAPI.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSecureChat.Controllers
{
    [ApiController]
    public class SimpleSecureChatController : ControllerBase
    {
        public SimpleSecureChatServer Server { get; private set; }

        public SimpleSecureChatController(SimpleSecureChatServer server)
        {
            Server = server;
        }

        [Route(ChatConnetionPacket.Route)]
        [HttpPost]
        public void ChatConnectionHandler()
        {
            var json = ReadBody();
            ChatConnetionPacket packet = ChatConnetionPacket.Deserialize(json);
        }

        [Route(ChatMessagePacket.Route)]
        [HttpPost]
        public void ChatMessageHandler()
        {
            var json = ReadBody();
            ChatMessagePacket packet = ChatMessagePacket.Deserialize(json);
        }

        private IPEndPoint GetRemoteEndpoint()
        {
            var connection = HttpContext.Connection;
            return new IPEndPoint(connection.RemoteIpAddress, connection.RemotePort);
        }

        private string ReadBody()
        {
            byte[] bytes = new byte[(int)Request.ContentLength];
            Request.Body.ReadAsync(bytes, 0, bytes.Length).Wait();
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
