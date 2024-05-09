﻿using MediatR;
using registerAPI.Services;

namespace registerAPI.Query.GetBike.GetAllBikes
{
    using registerAPI.Entity;

    public class GetAllBikesQueryHandler : IRequestHandler<GetAllBikesQuery, IEnumerable<BikeRegister>>
    {
        private readonly BikeService _bikeService;
        private readonly ILogger<GetAllBikesQueryHandler> _logger;
        public GetAllBikesQueryHandler(BikeService bikeService, ILogger<GetAllBikesQueryHandler> logger)
        {
            _bikeService = bikeService;
            _logger = logger;

        }

        public async Task<IEnumerable<BikeRegister>> Handle(GetAllBikesQuery request, CancellationToken cancellationToken)
        {

            try
            {
                _logger.LogInformation("Start Get All Motorcycles");

                var listBike = await _bikeService.GetAsync();

                _logger.LogInformation("Ended Get All Motorcycles");

                return listBike;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            throw new NotImplementedException();
        }
    }
}
