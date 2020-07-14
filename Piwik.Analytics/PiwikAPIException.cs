// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;

namespace Piwik.Analytics
{
    public class PiwikAPIException: Exception
    {
        public PiwikAPIException(string message) : base(message)
        {
        }
    }
}
