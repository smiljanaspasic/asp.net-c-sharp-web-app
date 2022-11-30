using Credentials.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Credentials.Data.Mocks
{
    public class KredencijaliRepository : BaseRepository<Kredencijali>, IKredencijaliRepository
    {
        public KredencijaliRepository(IConnectionString connectionString) : base(connectionString)
        {

        }
    }
}
