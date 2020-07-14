// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;

namespace Piwik.Analytics.Date
{
    public class MagicDate : PiwikDate
    {
        private string keyword;

        public static readonly MagicDate TODAY =  new MagicDate("today");
        public static readonly MagicDate YESTERDAY = new MagicDate("yesterday");

        private MagicDate(String keyword)
        {
            this.keyword = keyword;
        }

        public string serialize()
        {
            return this.keyword;
        }
    }
}
