using Business.Abstracts;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            this._notificationDal = notificationDal;
        }

        public void Add(Notification notification)
        {
            _notificationDal.Insert(notification);
        }

        public void Delete(Notification notification)
        {
            _notificationDal.Delete(notification);
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> GetListAll()
        {
           return _notificationDal.GetListAll();
        }

        public void Update(Notification notification)
        {
            _notificationDal.Update(notification);
        }
    }
}
