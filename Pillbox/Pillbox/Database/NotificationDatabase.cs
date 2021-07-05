using Pillbox.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pillbox.Database
{
    public class NotificationDatabase : INotificationDatabase
    {
        private SQLiteAsyncConnection _connection;

        public NotificationDatabase(ISQLiteNotificationDb sQ)
        {
            _connection = sQ.GetConnection();
            //_connection.DropTableAsync<Notification>(); // удаление БД
            _connection.CreateTableAsync<Notification>();
        }        

        public async Task AddNotification(Notification notification)
        {
            await _connection.InsertAsync(notification);
        }

        public async Task DeleteNotification(Notification notification)
        {
            await _connection.DeleteAsync(notification);
        }

        public async Task<Notification> GetNotification(int id)
        {
            return await _connection.FindAsync<Notification>(id);
        }

        public async Task UpdateNotification(Notification notification)
        {
            await _connection.UpdateAsync(notification);
        }

        public async Task<IEnumerable<Notification>> UpdateNotificationList()
        {
            return await _connection.Table<Notification>().ToListAsync();
        }
    }
}
