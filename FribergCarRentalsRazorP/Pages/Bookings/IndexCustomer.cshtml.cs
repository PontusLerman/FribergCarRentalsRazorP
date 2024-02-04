﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Pages.Bookings
{
    public class IndexCustomerModel : PageModel
    {
        private readonly IVehicle vehicleRepository;

        public IndexCustomerModel(IVehicle vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public IEnumerable<Vehicle> Vehicles { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Vehicles = vehicleRepository.GetAll();
        }
    }
}