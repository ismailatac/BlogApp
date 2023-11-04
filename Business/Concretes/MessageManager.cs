using Business.Abstracts;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this._messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> GetListAll()
        {
            return _messageDal.GetListAll();
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
        public List<Message> GetInboxListByWriterId(int receiverId)
        {
            return _messageDal.GetInboxListByWriterId(receiverId);

        }

        public Message GetByIdWithSender(int messageId)
        {
            return _messageDal.GetByIdWithSender(messageId);
        }

        public List<Message> GetSendboxListByWriterId(int senderId)
        {
            return _messageDal.GetSendboxListByWriterId(senderId);
        }
    }
}
