﻿using ImageIntegration.Application.Common.Models;
using System;

namespace ImageIntegration.Services.NasaApi.Models
{
    public class GetByEarthDateRequest : BaseGetRequest
    {
        public DateTime Date { get; set; }
        public string Camera { get; set; }
        public override string GetQueryString()
        {
            var queryString = $"earth_date={Date.ToString("yyyy-MM-dd")}";
            if (!string.IsNullOrEmpty(Camera))
            {
                queryString += $"&camera={Camera}";
            }
            return queryString;
        }
    }
}