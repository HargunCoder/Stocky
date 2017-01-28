using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {}
    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("StockPrice")]
    public async Task StockIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Hi.You want info of stocks. "); //
        context.Wait(MessageReceived);
    }
     [LuisIntent("Pleasentries")]
    public async Task HiIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Hi.Hope you are having a great day"); //
        context.Wait(MessageReceived);
    }
    [LuisIntent("AddNewStock")]
    public async Task AddNewStockIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Stock added.Your entity is ."); 
         EntityRecommendation STOCK;

            if (result.TryFindEntity(EntityGeographyCity, out STOCK))
            {
                STOCK.Type = "Destination";
                        await context.PostAsync($"Stock added.Your entity is" + STOCK); 

            }
        context.Wait(MessageReceived);
    }
    [LuisIntent("SellStock")]
    public async Task SellStockIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Stock sell"); //
        context.Wait(MessageReceived);
    }
    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the none intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }

}
