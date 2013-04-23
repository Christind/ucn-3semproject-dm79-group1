using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    public class MaintenanceTypeService : IMaintenanceTypeService
    {
        private MaintenanceTypeRepository _maintenanceTypeRepository;

        public MaintenanceTypeService()
        {
            _maintenanceTypeRepository = new MaintenanceTypeRepository();
        }

        public List<MaintenanceType> GetAllMaintenanceTypes()
        {
            return _maintenanceTypeRepository.GetAllMaintenanceTypes().ToList();
        }

        public MaintenanceType GetMaintenanceTypeById(string id)
        {
            return _maintenanceTypeRepository.GetMaintenanceTypeById(Convert.ToInt32(id));
        }

        public bool EditMaintenanceType(MaintenanceType maintenanceType)
        {
            try
            {
                if (maintenanceType == null)
                    return false;

                _maintenanceTypeRepository.Update(maintenanceType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertMaintenanceType(MaintenanceType maintenanceType)
        {
            try
            {
                if (maintenanceType == null)
                    return false;

                _maintenanceTypeRepository.Insert(maintenanceType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
