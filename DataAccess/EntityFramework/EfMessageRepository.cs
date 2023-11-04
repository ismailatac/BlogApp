﻿using DataAccess.Abstracts;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfMessageRepository : GenericRepository<Message>, IMessageDal
    {
        public Message GetByIdWithSender(int messageId)
        {
            using(var c = new Context())
            {
                return c.Messages.Include(x => x.Sender).Where(y => y.MessageId == messageId).FirstOrDefault();
            }
            
        }

        public List<Message> GetInboxListByWriterId(int receiverId)
        {
            using (var c = new Context())
            {
                return c.Messages.Include(x => x.Sender).Include(y => y.Receiver).Where(z => z.ReceiverId == receiverId).ToList();
            }
        }

        public List<Message> GetSendboxListByWriterId(int senderId)
        {
            using (var c = new Context())
            {
                return c.Messages.Include(x => x.Sender).Include(y => y.Receiver).Where(z => z.SenderId == senderId).ToList();
            }
        }
    }
}
