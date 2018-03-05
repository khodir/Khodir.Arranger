using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khodir.Arranger.Interfaces
{
    interface CollectionInterface<T>
    {
        void Insert(T model);
        void Update(T model);
        T FindById(long Id);
        void Delete(long Id);
        void Delete(T model);
        IEnumerable<T> GetAll();
    }
}
