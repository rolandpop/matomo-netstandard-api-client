// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.s

using System;

namespace Piwik.Analytics.Parameters
{
    class DateParameter : Parameter
    {
        private DateTimeOffset date;

        public DateParameter(string name, DateTimeOffset date) : base(name)
        {
            this.date = date;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.date != null && !this.date.Equals(default(DateTimeOffset)))
            {
                parameter = "&" + this.name + "=" + formatDate(this.date);
            }

            return parameter;
        }

        public static string formatDate(DateTimeOffset date)
        {
            return String.Format("{0:yyyy-MM-dd}", date);
        }
    }
}
