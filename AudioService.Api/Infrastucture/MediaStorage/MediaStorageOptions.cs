using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.MediaStorage
{
    public sealed class MediaStorageOptions
    {
        public string AudioContainerName { get; set; }
        public string CoverContainerName { get; set; }
    }
}
