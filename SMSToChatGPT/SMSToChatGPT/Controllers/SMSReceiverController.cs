using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.TwiML.Messaging;
using Twilio.TwiML;

namespace SMSToChatGPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSReceiverController : TwilioController
    {

        Dictionary<string, ChatBotSession> sessions = new Dictionary<string, ChatBotSession>();

        [HttpPost]
        public async Task<TwiMLResult> ReceiveSMS([FromForm] string From, [FromForm] string Body)
        {
            if (From != null)
            {

                var chatBotSession = GetOrCreateChatBotSession(From);

                ConversationMessage message = new ConversationMessage() { Message = Body, Sender = MessageSender.User };

                var reply = await chatBotSession.ForwardMessageFromUserAsync(message);

                var messagingResponse = new MessagingResponse();
                messagingResponse.Message(reply);

                return TwiML(messagingResponse);
            }
            else
            {
                return null!;
            }
        }

        private ChatBotSession GetOrCreateChatBotSession(string from)
        {
            if (!sessions.ContainsKey(from))
            {
                sessions[from] = new ChatBotSession();
            }
            return sessions[from];
        }
    }
}
