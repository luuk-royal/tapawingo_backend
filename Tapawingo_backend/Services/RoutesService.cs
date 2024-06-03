﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tapawingo_backend.Dtos;
using Tapawingo_backend.Interface;

namespace Tapawingo_backend.Services
{
    public class RoutesService
    {
        private readonly IRoutesRepository _routesRepository;
        private readonly IMapper _mapper;

        public RoutesService(IRoutesRepository routesRepository, IMapper mapper) {
            _routesRepository = routesRepository;
            _mapper = mapper;
        }

        public RouteDto GetRoutesById(int id)
        {
            return _routesRepository.GetRouteById(id);
        }
        
        public RouteDto CreateRoute(CreateRouteDto createRouteDto)
        {
            return _mapper.Map<RouteDto>(_routesRepository.CreateRoute(createRouteDto));
        }
    }
}
