﻿using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.CustomerDto;
using MongoDbProject.Dtos.CustomerServices;
using MongoDbProject.Services.CustomerServices;

namespace MongoDbProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> CustomerList()
        {
            var values = await _customerService.GetAllCustomerAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            await _customerService.CreateCustomerAsync(createCustomerDto);
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public async Task<IActionResult> RemoveCustomer(string id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(string id)
        {
            var value = await _customerService.GetByIdCustomerAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            await _customerService.UpdateCustomerAsync(updateCustomerDto);
            return RedirectToAction("CustomerList");
        }
    }
}
