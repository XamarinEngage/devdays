using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers
{
    public class Speaker
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }
    }
}
