﻿using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IStationService
    {
        [OperationContract]
        List<Station> GetAllStations();

        [OperationContract]
        Station GetStationById(string id);

        [OperationContract]
        bool ReserveBattery(string stationId, string userId);
    }
}
