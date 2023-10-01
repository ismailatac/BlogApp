using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBlogService
    {
        void Add(Blog blog);
        void Delete(Blog blog);
        void Update(Blog blog);
        List<Blog> GetListAll();
        Blog GetById(int id);
        List<Blog> GetListWithCategory();
        List<Blog> GetBlogsById(int id);
        List<Blog> GetListByWriterId(int id);
        List<Blog> GetLastThreeBlog();

    }
}
