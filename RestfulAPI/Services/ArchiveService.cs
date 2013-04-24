using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    public class ArchiveService : IArchiveService
    {
        private readonly ArchiveRepository _archiveRepository;

        public ArchiveService()
        {
            _archiveRepository = new ArchiveRepository();
        }

        public List<Archive> GetAllArchives()
        {
            return _archiveRepository.GetAllArchives().ToList();
        }

        public Archive GetArchiveById(string id)
        {
            return _archiveRepository.GetArchiveById(Convert.ToInt32(id));
        }

        public bool InsertArchive(Archive archive)
        {
            try
            {
                if (archive == null)
                    return false;

                _archiveRepository.Insert(archive);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Archive> GetArchivesByUserId(string id)
        {
            return _archiveRepository.GetArchivesByUserId(Convert.ToInt32(id)).ToList();
        }
    }
}
