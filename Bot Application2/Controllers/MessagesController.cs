using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Microsoft.Bot_Application2
{
    
    [LuisModel("df2b06d4-695b-4e6f-85a6-f79b8ed698d7", "9dd6e44f6081aa2eb78dece49d")]
    [Serializable]
    public class MessagesController: LuisDialog<object>
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        
         [LuisIntent("get together")]
        public async Task GetTogether(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sure! Lets plan something");
            // if (TryFindAlarm(result, out this.turnOff))
            // {
            //     PromptDialog.Confirm(context, AfterConfirming_TurnOffAlarm, "Are you sure?");
            // }
            // else
            // {
                
            //     context.Wait(MessageReceived);
            // }
        }
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                // return our reply to the user
                
                if (message.Intent == "get together")
                return message.CreateReplyMessage($"Sure! Lets plan something!");
                
                else
                return;
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}
