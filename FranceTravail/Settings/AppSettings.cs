using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace FranceTravail.Settings
{
    public class AppSettings
    {
        public readonly string ClientId;
        public readonly string ClientSecret;

        public AppSettings()
        {
            Env.TraversePath().Load();

            ClientId = Env.GetString("client_id");
            ClientSecret = Env.GetString("client_secret");
        }
    }
}
