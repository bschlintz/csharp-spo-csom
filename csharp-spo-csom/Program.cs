using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_spo_csom
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://tenant.sharepoint.com";
            var creds = CredentialManager.GetSharePointOnlineCredential(url);

            using (ClientContext ctx = new ClientContext(url))
            {
                ctx.Credentials = creds;

                Web web = ctx.Web;
                ctx.Load(web, w => w.Title);
                ctx.ExecuteQuery();

                Console.WriteLine($"Web Title: {web.Title}");
                Console.ReadLine();
            }
        }
    }
}
