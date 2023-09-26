using Business.Abstracts;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            this._commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(id);
        }

		public List<Comment> GetCommentsById(int id)
		{
			return _commentDal.GetListAll(x => x.BlogId == id);
		}

		public List<Comment> GetListAll()
        {
           return _commentDal.GetListAll();
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}
