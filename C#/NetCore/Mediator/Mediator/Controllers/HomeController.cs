﻿using Mediator.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly INotifierMediatorService _notifierMediatorService;

        public HomeController(INotifierMediatorService notifierMediatorService)
        {
            _notifierMediatorService = notifierMediatorService;
        }

        [HttpGet("")]
        public ActionResult<string> NotifyAll()
        {
            _notifierMediatorService.Notify();

            return "Completed";
        }
    }
}