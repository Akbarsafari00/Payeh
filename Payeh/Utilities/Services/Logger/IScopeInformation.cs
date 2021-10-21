﻿using System.Collections.Generic;

namespace Payeh.Utilities.Services.Logger
{
    public interface IScopeInformation
    {
        Dictionary<string, string> HostScopeInfo { get; }
        Dictionary<string, string> RequestScopeInfo { get; }
    }
}
