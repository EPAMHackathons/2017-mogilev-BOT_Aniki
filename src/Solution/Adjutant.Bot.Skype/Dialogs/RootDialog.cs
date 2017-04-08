using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Text;
using System.Collections.Generic;
using Adjutant.Bot.Skype.Domain;

namespace Adjutant.Bot.Skype.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            StringBuilder answer = new StringBuilder();

            var activity = await result as Activity;

            var parser = new CommandParser();
            var model = parser.Parse(activity.Text);

            switch (model.Action)
            {
                case Models.ActionEnum.Connect:
                    break;
                case Models.ActionEnum.Status:
                    break;
                case Models.ActionEnum.PullRequest:
                    break;
                default:
                    //SendDefaultAnswer();
                    break;
            }

            

            //var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            //var replyMessage = incomingMessage.CreateReply("Yo, I heard you.", "en");
            //await connector.Conversations.ReplyToActivityAsync(replyMessage);

            //// return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was characters");

            //context.Wait(MessageReceivedAsync);
        }

        private async void SendDefaultAnswer(Activity activity)
        {
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            var message = activity.CreateReply("");
            message.Type = "message";
            message.Attachments = new List<Attachment>();
            message.Attachments.Add(new Attachment { ContentType = "image/png", ContentUrl = @"http://s.quickmeme.com/img/a8/a8022006b463b5ed9be5a62f1bdbac43b4f3dbd5c6b3bb44707fe5f5e26635b0.jpg" });
            await connector.Conversations.ReplyToActivityAsync(message);
        }
    }
}