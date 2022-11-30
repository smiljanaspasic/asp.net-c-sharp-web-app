using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Credentials.Data
{
    public class Base
    {
        [IgnoreInsert]
        [IgnoreUpdate]
        public int Id { get; set; }

        [IgnoreUpdate]
        public DateTime DatumKreiranja { get; set; }

        public DateTime DatumPromene { get; set; }
    }
}
