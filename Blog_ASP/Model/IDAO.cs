using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_ASP.Model {
    interface IDAO<T> {
        void Create(T ob);
        List<T> Read();
        void Update(T ob);
        void Delete(Object id);
    }
}
