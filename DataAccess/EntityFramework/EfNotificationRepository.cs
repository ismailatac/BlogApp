using DataAccess.Abstracts;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfNotificationRepository : GenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetListAllByWriterId(int id)
        {
            using (var context = new Context())
            return context.Notifications.Where(x => x.WriterId == id).ToList();
        }
    }
}
