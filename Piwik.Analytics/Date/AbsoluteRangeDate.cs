// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;

using Piwik.Analytics.Parameters;

namespace Piwik.Analytics.Date
{
    public class AbsoluteRangeDate : PiwikDate
    {
        private DateTimeOffset dateStart;
        private DateTimeOffset dateEnd;

        public AbsoluteRangeDate(DateTimeOffset dateStart, DateTimeOffset dateEnd)
        {
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
        }

        public string serialize()
        {
            return DateParameter.formatDate(this.dateStart) + "," + DateParameter.formatDate(this.dateEnd);
        }
    }
}
