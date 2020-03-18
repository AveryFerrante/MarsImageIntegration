using ImageIntegration.Application.Common.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ImageIntegration.Services.NasaApi.Models
{
    public class GetByEarthDateRequest : BaseGetRequest
    {
        [Required]
        public DateTime Date { get; set; }
        public string Camera { get; set; }
        public string GetQueryString()
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
