using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.API.Services
{
    public class ParentService1
    {
        public static int CreationCount { get; private set; }

        private readonly ChildService _myChildService;

        public ParentService1(ChildService myChildService)
        {
            _myChildService = myChildService;
            CreationCount++;
        }
    }
    public class ParentService2
    {
        public static int CreationCount { get; private set; }

        private readonly ChildService _myChildService;

        public ParentService2(ChildService myChildService)
        {
            _myChildService = myChildService;
            CreationCount++;
        }
    }
}
