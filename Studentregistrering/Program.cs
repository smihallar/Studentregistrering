using Microsoft.IdentityModel.Tokens;
using System;

namespace Studentregistrering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FrontDesk theFrontDesk = new FrontDesk();
            theFrontDesk.Start();
        }
    }
}

