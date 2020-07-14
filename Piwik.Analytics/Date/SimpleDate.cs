// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;

using Piwik.Analytics.Parameters;

namespace Piwik.Analytics.Date
{
    public class SimpleDate : PiwikDate
    {
        private DateTimeOffset date;

        public SimpleDate(DateTimeOffset date)
        {
            this.date = date;
        }

        public string serialize()
        {
            return DateParameter.formatDate(this.date);
        }
    }
}
