﻿using Nightingale.Core.Models;
using System.Collections.Generic;

namespace Nightingale.Core.Models
{
    public interface IWorkspaceResponse : IResponseStatus
    {
        string Body { get; set; }

        string ContentType { get; set; }

        IList<KeyValuePair<string, string>> Cookies { get; }

        IList<KeyValuePair<string, string>> Headers { get; }

        IList<ApiTestResult> TestResults { get; }
    }
}
