﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        List<Notification> GetListAllByWriterId(int id);
    }
}
