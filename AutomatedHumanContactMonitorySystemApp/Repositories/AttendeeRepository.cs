﻿using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        public List<Attendee> GetAttendees()
        {
            var client = new RestClient("https://localhost:44385/");
            var request = new RestRequest("api/attendee/get");
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var attendees = JsonConvert.DeserializeObject<List<Attendee>>(response.Content);
            return attendees.ToList();
        }
    }
}
