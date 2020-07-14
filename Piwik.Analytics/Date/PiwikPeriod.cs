// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;

namespace Piwik.Analytics.Date
{
    public class PiwikPeriod
    {
        private string period;

        public static readonly PiwikPeriod DAY = new PiwikPeriod("day");
        public static readonly PiwikPeriod WEEK = new PiwikPeriod("week");
        public static readonly PiwikPeriod MONTH = new PiwikPeriod("month");
        public static readonly PiwikPeriod YEAR = new PiwikPeriod("year");
        public static readonly PiwikPeriod RANGE = new PiwikPeriod("range");

        private PiwikPeriod(string period)
        {
            this.period = period;
        }

        public string getPeriod() {
            return this.period;
        }

        public static Boolean isMultipleDates(PiwikPeriod period, PiwikDate date)
        {
            return 
                !String.Equals(PiwikPeriod.RANGE.getPeriod(), period.getPeriod()) &&
                (date is AbsoluteRangeDate || date is RelativeRangeDate);
        }
    }
}
