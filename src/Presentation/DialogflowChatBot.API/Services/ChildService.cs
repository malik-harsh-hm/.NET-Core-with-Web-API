using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.API.Services
{
    public class ChildService
    {
        public static int CreationCount { get; private set; }

        public ChildService()
        {
            CreationCount++;
        }
    }
}
