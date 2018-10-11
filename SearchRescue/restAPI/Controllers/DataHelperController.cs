﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GeoCoordinatePortable;
using System.Linq;
using restAPI.DataContext.Models;
using restAPI.DataContracts;
using Microsoft.Extensions.Caching.Memory;

namespace restAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatahelperController : ControllerBase
    {
        private DevicePositionContext _dataContext;
        private IMemoryCache _cache;

        public DatahelperController(DevicePositionContext dataContext, IMemoryCache memoryCache)
        {
            _dataContext = dataContext;
            _cache = memoryCache;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            DeviceMapPoint dmp = new DeviceMapPoint();
            //Fill properties
            _dataContext.DevicePositions.Add(dmp);
            _dataContext.SaveChanges();
            return "OK";
        }
    }
}
