using System;
using System.Collections.Generic;
using System.Text;

namespace Credentials.Data.Interfaces
{
    public interface IConnectionString
    {
        string GetDbConnectionString();
    }
}
