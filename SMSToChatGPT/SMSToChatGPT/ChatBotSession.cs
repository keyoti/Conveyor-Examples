using Microsoft.SemanticKernel.AI.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AI.OpenAI.ChatCompletion;
using Microsoft.SemanticKernel;

namespace SMSToChatGPT
{
    public class ChatBotSession
    {
        public List<ConversationMessage> ConversationMessages { get; set; } = new List<ConversationMessage>();

        internal async Task<string> ForwardMessageFromUserAsync(ConversationMessage newMessage)
        {
            newMessage.Sender = MessageSender.User;
            ConversationMessages.Add(newMessage);
            return await SendMessagesToChatGPTAsync(ConversationMessages);
        }

        public async Task<string> SendMessagesToChatGPTAsync(List<ConversationMessage> conversationMessages)
        {
            IKernel kernel = KernelBuilder.Create();            
            kernel.Config.AddOpenAIChatCompletionService("gpt-3.5-turbo", Environment.GetEnvironmentVariable("OpenAI:Key")!, Environment.GetEnvironmentVariable("OpenAI:OrgId")!);

            var systemMessage = "You are a laundromat attendant who gives laundry advice in 20 words or less.";
            var chatGPT = kernel.GetService<IChatCompletion>();
            var chat = (OpenAIChatHistory)chatGPT.CreateNewChat(systemMessage);

            foreach (var message in conversationMessages)
            {
                switch (message.Sender)
                {
                    case MessageSender.User:
                        chat.AddUserMessage(message.Message);
                        break;
                    case MessageSender.System:
                        chat.AddSystemMessage(message.Message);
                        break;
                }
            }

            string assistantReply = await chatGPT.GenerateMessageAsync(chat, new ChatRequestSettings());
            chat.AddAssistantMessage(assistantReply);
            conversationMessages.Add(new ConversationMessage() { Sender = MessageSender.System, Message = assistantReply });
            return assistantReply;
        }
    }
}
