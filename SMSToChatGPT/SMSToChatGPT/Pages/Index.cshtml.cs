using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SMSToChatGPT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public ConversationMessage NewMessage { get; set; }
        [BindProperty]
        public List<ConversationMessage> ConversationMessages
        {
            get { return ChatBotSession.ConversationMessages; }
        }
        public ChatBotSession ChatBotSession { get; set; } = new ChatBotSession();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }



        public async Task OnPostAsync()
        {
            await ChatBotSession.ForwardMessageFromUserAsync(NewMessage);
        }
    }
}