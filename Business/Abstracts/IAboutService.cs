using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAboutService
    {
        void Add(About category);
        void Delete(About category);
        void Update(About category);
        List<About> GetListAll();
        About GetById(int id);

    }
}
