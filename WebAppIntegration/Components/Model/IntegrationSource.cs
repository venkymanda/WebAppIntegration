using System;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppIntegration.Model
{

 public class IntegrationSource
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Path { get; set; }
        public string FileExtension { get; set; }
        public string UserId {get;set;}
    }
}