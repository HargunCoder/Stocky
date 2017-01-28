//newly added
using System;  //old
using System.Threading.Tasks;  //old

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
//my basic class
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
          EntityRecommendation STOCK;

            if (result.TryFindEntity("Equity", out STOCK))
            {        public static async Task<double?> GetStockRateAsync(string STOCK)  
        {  
            try  
            {  
                string ServiceURL = $"http://finance.yahoo.com/d/quotes.csv?s={StockSymbol}&f=sl1d1nd";  
                string ResultInCSV;  
                using (WebClient client = new WebClient())  
                {  
                    ResultInCSV = await client.DownloadStringTaskAsync(ServiceURL).ConfigureAwait(false);  
                }  
                var FirstLine = ResultInCSV.Split('\n')[0];  
                var Price = FirstLine.Split(',')[1];  
                if (Price != null && Price.Length >= 0)  
                {  
                    double result;  
                    if (double.TryParse(Price, out result))  
                    {  
                        return result;  
                    }  
                }  
                return null;  
            }  
            catch (WebException ex)  
            {  
                //handle your exception here  
                throw ex;  
            }  
        }
        context.Wait(MessageReceived);
    }
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
                STOCK.Type = "Destination";
                        await context.PostAsync($"Stock being bought....\n{STOCK.Entity} shares added to profile."); 

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
