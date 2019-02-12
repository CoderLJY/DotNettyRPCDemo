using System;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using NettyRPCDemo.Protocol.AddressBook;

namespace NettyRPCDemo.Client
{
    public class RPCDemoClientHandler : ChannelHandlerAdapter
    {
        public override void ChannelActive(IChannelHandlerContext context)
        {
            AddressBook addressBook = new AddressBook()
            {
                People =
                {
                    new Person()
                    {
                        Name = "linsir",
                        Id = 12,
                        Email = "linsir84@gmail.com",
                        Phones =
                        {
                            new Person.Types.PhoneNumber() {Number = "1572926230", Type = Person.Types.PhoneType.Home}
                        },
                        LastUpdated = DateTime.Now.ToString("h:mm:ss tt zz")
                    }
                }
            };

            IByteBuffer addressBookRPCMessage = Unpooled.Buffer();
            addressBookRPCMessage.WriteBytes(addressBook.ToByteArray());
            context.WriteAndFlushAsync(addressBookRPCMessage);
            addressBookRPCMessage.Clear();
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine($"Client Exception: {exception}");
            context.CloseAsync();
        }
    }
}