using SimpleSecureChatAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSecureChatAPI.Packets
{
    public abstract class Packet<T> : JsonSerializable<T>
    {

    }
}
