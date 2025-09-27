using System;
using System.Web;
using GameTaiXiuLibrary;

public partial class api : System.Web.UI.Page
{
    private static TaiXiuGame game = new TaiXiuGame(1000); // vốn khởi đầu

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "application/json";

        string choice = Request.Form["choice"];
        int money = 0;
        int.TryParse(Request.Form["money"], out money);

        string result = game.PlaceBet(choice, money);

        // tự build JSON string (ko dùng JavaScriptSerializer vì .NET 2.0 chưa có)
        string json = "{"
            + "\"Balance\":" + game.Balance + ","
            + "\"Message\":\"" + result.Replace("\"", "\\\"") + "\""
            + "}";

        Response.Write(json);
        Response.End();
    }
}
