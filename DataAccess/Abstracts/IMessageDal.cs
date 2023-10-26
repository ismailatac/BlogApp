using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IMessageDal : IGenericDal<Message>
    {
        List<Message> GetInboxListByWriterId(int receiverId);
    }
}
