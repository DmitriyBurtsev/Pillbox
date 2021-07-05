using Pillbox.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pillbox.Database
{
    public interface INotificationDatabase
    {
        Task<IEnumerable<Notification>> UpdateNotificationList();
        Task<Notification> GetNotification(int id);
        Task AddNotification(Notification notification);
        Task UpdateNotification(Notification notification);
        Task DeleteNotification(Notification notification);
    }
}
