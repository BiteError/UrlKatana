using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlKatana.Business.Services.DataAccess
{
    public interface IRepository<T>
    {
        T Get(int id);
        void Save(T item);
    }
}
