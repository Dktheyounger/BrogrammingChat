using System;
using System.Collections.Generic;

namespace BrogrammerChatData.Models
{
    public partial class Content
    {
        public int ContentId { get; set; }
        public string? TextAttachments { get; set; }
        public byte[]? BinaryAttachments { get; set; }
    }
}
