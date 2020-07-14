// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;

namespace Piwik.Analytics.Date
{
    public class RelativeRangeDate : PiwikDate
    {
        private string relativeRange;
        private int nbDays;

        public static RelativeRangeDate LAST(int nbDays)
        {
            return new RelativeRangeDate("last", nbDays);
        }

        public static RelativeRangeDate PREVIOUS(int nbDays)
        {
            return new RelativeRangeDate("previous", nbDays);
        }

        private RelativeRangeDate(String relativeRange, int nbDays)
        {
            this.relativeRange = relativeRange;
            this.nbDays = nbDays;
        }

        public string serialize()
        {
            return this.relativeRange + this.nbDays.ToString();
        }
    }
}
