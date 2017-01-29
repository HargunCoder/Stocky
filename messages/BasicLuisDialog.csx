//newly added
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Net;  
using System.Threading.Tasks;  
using System.Web; 

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
//my basic class
public class BasicLuisDialog : LuisDialog<object>
{
internal string[] companyNames = {""};
internal int[] nshares = new int[]{};
internal int n = 0;
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
        await context.PostAsync($"Hi.Hope you are having a great day.What can I do for you today?"); //
        context.Wait(MessageReceived);
    }
    [LuisIntent("AddNewStock")]
    public async Task AddNewStockIntent(IDialogContext context, LuisResult result)
    { 
         EntityRecommendation STOCK;

            if (result.TryFindEntity("Equity", out STOCK))
            {
                STOCK.Type = "Equity";
                        await context.PostAsync($"Stock being bought....\n{STOCK.Entity} shares added to profile."); 

            }
             for (int i = 0;i <= n;i++)
 {
 if ((Stock.Entity).Equals(companyNames[i]))
 {
    result.TryFindEntity("NumShares", out numberShares)
	numberShares.Type="NumShares";
    nshares[i] += numberShares;
 }
 else
 {
    result.TryFindEntity("NumShares", out numberShares)
	numberShares.Type="NumShares";
    
	nshares[n] = numberShares;
	companyNames[n] = entityName;
	n++;
 }
 }
        context.Wait(MessageReceived);
    }
    [LuisIntent("SellStock")]
    public async Task SellStockIntent(IDialogContext context, LuisResult result)
    {
       EntityRecommendation STOCK;

            if (result.TryFindEntity("Equity", out STOCK))
            {
                STOCK.Type = "Destination";
                        await context.PostAsync($"Stock being sold....\n{STOCK.Entity} shares removed from profile."); 

            }
        context.Wait(MessageReceived);
    }
    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"I didnt got you.Please explain clearly."); //
        context.Wait(MessageReceived);
    }

}
//basic class ends here
//jason template

//here ends jason template
//starts yahoobot
