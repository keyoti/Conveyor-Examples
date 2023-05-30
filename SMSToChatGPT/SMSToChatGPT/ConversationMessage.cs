namespace SMSToChatGPT
{
    public class ConversationMessage
    {
        public MessageSender Sender { get; set; }
        public string Message { get; set; } = null!;
    }

    public enum MessageSender
    {
        User,
        System
    }

}
