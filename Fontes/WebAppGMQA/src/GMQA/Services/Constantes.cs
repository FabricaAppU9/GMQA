﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.Services
{
    public class Constantes
    {
       // public const string CONEXAO_BANCO_LOCAL = "Server=(localdb)\\mssqllocaldb;Database=GMQA;Trusted_Connection=True;MultipleActiveResultSets=true";
        //public const string CONEXAO_BANCO = "Server=tcp:fabricaappu9.database.windows.net,1433;Initial Catalog=GMQA;Persist Security Info=False;User ID=fabrica;Password=app@2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public const string CONEXAO_BANCO = "Server=tcp:gmqadbserver.database.windows.net,1433;Initial Catalog=GMQA;Persist Security Info=False;User ID=gmqa;Password=Gmq@2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

       // public const string CONEXAO_BANCO_LOCAL = "Server=localhost;port=306;Database=gmqa;Uid=root;Pwd=;";
        public const string CONEXAO_BANCO_LOCAL = "Server=localhost;Database=gmqa;Uid=root;Pwd=";
    }
}
