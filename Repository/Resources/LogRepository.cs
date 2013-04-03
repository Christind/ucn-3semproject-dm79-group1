using System.Linq;
using Repository.Models;
using Logging;

namespace Repository.Resources
{
    class LogRepository
    {
        private BPDbContext db;

        public LogRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<Log> GetAllLogs()
        {
            return db.Logs;
        }

        public Log GetLogById(int value)
        {
            return db.Logs.FirstOrDefault(x => x.ID == value);
        }

        public void Insert(Log log)
        {
            db.Logs.Add(log);
            db.SaveChanges();
        }

        public void Update(Log log)
        {
            Log rLog = GetLogById(log.ID);

            if (rLog == null)
                return;

            rLog.Exception = log.Exception;
            rLog.LogType = log.LogType;
            rLog.PageName = log.PageName;
            db.SaveChanges();
        }

        public void Disable(int value)
        {
            Log rLog = GetLogById(value);

            if (rLog == null)
                return;

            rLog.IsActive = false;
            db.SaveChanges();
        }
    }
}