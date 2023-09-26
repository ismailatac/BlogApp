using Business.Abstracts;
using DataAccess.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            this._blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

		public List<Blog> GetBlogsById(int id)
		{
            return _blogDal.GetListAll(x => x.BlogId == id);
		}

		public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetListAll()
        {
           return _blogDal.GetListAll();
        }

		public List<Blog> GetListWithCategory()
		{
           return _blogDal.GetListWithCategory();
		}

		public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
