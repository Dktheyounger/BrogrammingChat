using System;
using System.Collections.Generic;

namespace BrogrammerChat.Model
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int ContentId { get; set; }
    }
}
