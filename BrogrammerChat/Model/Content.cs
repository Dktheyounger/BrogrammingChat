using System;
using System.Collections.Generic;

namespace BrogrammerChat.Model
{
    public partial class Content
    {
        public int ContentId { get; set; }
        public string? TextAttachments { get; set; }
        public byte[]? BinaryAttachments { get; set; }
    }
}
