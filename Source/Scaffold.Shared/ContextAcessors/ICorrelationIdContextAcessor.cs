using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffold.Shared.ContextAcessors
{
    public interface ICorrelationIdContextAcessor
    {
        string GetUid();
        string GetCid();
    }
}
