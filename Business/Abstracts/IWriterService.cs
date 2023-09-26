using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IWriterService
    {
        void Add(Writer writer);
        void Delete(Writer writer);
        void Update(Writer writer);
        List<Writer> GetListAll();
        Writer GetById(int id);

    }
}
