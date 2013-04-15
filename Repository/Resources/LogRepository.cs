using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class LogRepository
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
            rLog.ExceptionLocation = log.ExceptionLocation;
            rLog.ClientInformation = log.ClientInformation;
            db.SaveChanges();
        }
    }
}