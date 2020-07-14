// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;

using Piwik.Analytics.Date;

namespace Piwik.Analytics.Parameters
{
    class PiwikDateParameter : Parameter
    {
        private PiwikDate piwikDate;

        public PiwikDateParameter(string name, PiwikDate date) : base(name)
        {
            this.piwikDate = date;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.piwikDate != null)
            {
                parameter = "&" + this.name + "=" + urlEncode(this.piwikDate.serialize());
            }

            return parameter;
        }
    }
}
