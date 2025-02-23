using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ConversacionesChatViewModel
    {
        public List<ConversacionViewModel> Conversaciones { get; set; }
        public ChatViewModel Chat { get; set; }
    }
}