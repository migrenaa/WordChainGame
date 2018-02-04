using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordChainGame.Data.Entities;

namespace WordChainGame.Data.Mappings
{
    public class UserMappings : EntityTypeConfiguration<User>
    {
        public UserMappings()
        {

        }
    }
}
