using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
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
            var activity = await result as Activity;

            var parser = new CommandParser();
            var model = parser.Parse(activity.Text);

            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was characters");

            context.Wait(MessageReceivedAsync);
        }
    }
}