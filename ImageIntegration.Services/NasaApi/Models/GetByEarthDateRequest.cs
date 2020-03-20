using ImageIntegration.Application.Common.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ImageIntegration.Services.NasaApi.Models
{
    public class GetByEarthDateRequest
    {
        [Required]
        public DateTime? Date { get; set; }
        public string Camera { get; set; }
    }
}
