using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_mvc.Data.Base
{
    public interface IEntityBase
    {
        int Id { get; set; }
    }
}