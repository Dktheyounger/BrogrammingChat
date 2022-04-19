namespace BrogrammerChat.Data
{
    public class Message
    {
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int ContentID { get; set; }
        public Content Content { get; set; }
    }

}
