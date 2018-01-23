using System;
using System.Collections.Generic;
using System.Text;

namespace Teleta.Bari.XF.Auth
{
    public static class AuthEngine
    {
        public static bool Validate(string username, string password)
        {
            return username == "teleta" && password == "bari";
        }
    }
}