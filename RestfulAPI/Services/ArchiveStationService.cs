using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    public class ArchiveStationService : IArchiveStationService
    {
        private readonly ArchiveStationRepository _archiveStationRepository;

        public ArchiveStationService()
        {
            _archiveStationRepository = new ArchiveStationRepository();
        }

        public List<ArchiveStation> GetAllArchiveStation()
        {
            return _archiveStationRepository.GetAllArchiveStations().ToList();
        }

        public ArchiveStation GetArchiveStationById(string id)
        {
            return _archiveStationRepository.GetArchiveStationById(Convert.ToInt32(id));
        }

        public bool EditArchiveStation(ArchiveStation archiveStation)
        {
            try
            {
                if (archiveStation == null)
                    return false;

                _archiveStationRepository.Update(archiveStation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertArchiveStation(ArchiveStation archiveStation)
        {
            try
            {
                if (archiveStation == null)
                    return false;

                _archiveStationRepository.Update(archiveStation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ArchiveStation> GetArchiveStationByArchive(string id)
        {
            throw new NotImplementedException();
        }
    }
}
