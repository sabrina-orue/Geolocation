using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Domain.Models.Configuration
{
    public class ConfigurationService
    { 
        public string ConnStringDataBase { get; set; }
        public string ConnStringServiceBus { get; set; }
    }
}
