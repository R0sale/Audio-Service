using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Storage
{
    public sealed class MediaStorageOptions
    {
        public string AudioContainerName { get; set; }
        public string CoverContainerName { get; set; }
    }
}
