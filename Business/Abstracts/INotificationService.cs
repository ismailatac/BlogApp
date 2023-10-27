using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetListAllByWriterId(int id);

    }
}
