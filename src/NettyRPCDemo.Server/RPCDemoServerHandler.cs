using System;
using System.Linq;
using System.Text;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using Google.Protobuf;
using NettyRPCDemo.Protocol.AddressBook;

namespace NettyRPCDemo.Server
{
    public class RPCDemoServerHandler : ChannelHandlerAdapter
    {
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var buffer = message as IByteBuffer;
            if (buffer != null)
            {
                int length = buffer.ReadableBytes;
                ArraySegment<byte> bytes = buffer.GetIoBuffer(buffer.ReaderIndex, length);
                
                AddressBook addressBook = AddressBook.Parser.ParseFrom(bytes.ToArray());
                Console.WriteLine("Received from client: " + addressBook.ToString());
            }
        }
    }
}