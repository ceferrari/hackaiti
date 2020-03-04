using Scaffold.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffold.Application.AppServices
{
    public abstract class AbstractService
    {
        protected IBus Bus;

        public AbstractService(IBus bus)
        {
            Bus = bus;
        }
    }
}
