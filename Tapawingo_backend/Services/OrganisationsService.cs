﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tapawingo_backend.Dtos;
using Tapawingo_backend.Interface;

namespace Tapawingo_backend.Services
{
    public class OrganisationsService
    {
        private readonly IOrganisationsRepository _organisationsRepository;
        private readonly IMapper _mapper;

        public OrganisationsService(IOrganisationsRepository organisationsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _organisationsRepository = organisationsRepository;
        }

        public OrganisationDto CreateOrganisation(CreateOrganisationDto organisationName)
        {
            return _mapper.Map<OrganisationDto>(_organisationsRepository.CreateOrganisation(organisationName));
        }

        public OrganisationDto GetOrganisationById(int id)
        {
            return _mapper.Map<OrganisationDto>(_organisationsRepository.GetOrganisationById(id));
        }
    }
}