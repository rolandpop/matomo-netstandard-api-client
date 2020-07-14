// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;

using Piwik.Analytics.Date;

namespace Piwik.Analytics.Parameters
{
    class PeriodParameter : Parameter
    {
        private PiwikPeriod period;

        public PeriodParameter(string name, PiwikPeriod period) : base(name)
        {
            this.period = period;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.period != null)
            {
                parameter = "&" + this.name + "=" + urlEncode(this.period.getPeriod());
            }

            return parameter;
        }
    }
}
