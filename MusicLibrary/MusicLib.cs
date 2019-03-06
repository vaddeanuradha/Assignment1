using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MusicLibrary
{
    public class MusicLib
    {
        public string FileName { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public StorageFile MusicFile { get; set; }

    }
}
