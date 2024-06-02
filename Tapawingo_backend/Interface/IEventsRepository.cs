﻿using System.Collections;
using Tapawingo_backend.Models;

namespace Tapawingo_backend.Interface
{
    public interface IEventsRepository
    {
        ICollection<Event> GetEventsByOrganisationId(int organisationId);
        Event CreateEvent(Event newEvent);
        bool EventExistsForOrganisation(string eventName, int organisationId);
    }
}