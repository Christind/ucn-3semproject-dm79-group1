using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class ClientApplicationRepository
    {
        private BPDbContext db;

        public ClientApplicationRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<ClientApplication> GetAllClientApps()
        {
            return db.ClientApplications;
        }

        public ClientApplication GetClientAppById(int value)
        {
            return db.ClientApplications.FirstOrDefault(x => x.ID == value);
        }

        public void Insert(ClientApplication clientApplication)
        {
            db.ClientApplications.Add(clientApplication);
            db.SaveChanges();
        }

        public void Update(ClientApplication clientApplication)
        {
            ClientApplication rClientApplication = GetClientAppById(clientApplication.ID);

            if (rClientApplication == null)
                return;

            rClientApplication.Title = clientApplication.Title;
            rClientApplication.Description = clientApplication.Description;
            rClientApplication.AppKey = clientApplication.AppKey;
            rClientApplication.CryptoKey = clientApplication.CryptoKey;
            db.SaveChanges();
        }

        public void Disable(int value)
        {
            ClientApplication rClientApplication = GetClientAppById(value);

            if (rClientApplication == null)
                return;

            rClientApplication.IsActive = false;
            db.SaveChanges();
        }
    }
}