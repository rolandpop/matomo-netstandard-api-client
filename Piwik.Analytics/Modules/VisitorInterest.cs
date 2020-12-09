// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using Piwik.Analytics.Date;
using Piwik.Analytics.Parameters;
using System;
using System.Collections.Generic;

namespace Piwik.Analytics.Modules
{
    public class VisitorInterest : PiwikAnalytics
    {
        public const string LABEL = "label";
        public const string NB_VISITS = "nb_visits";
        public const string NB_VISITS_PERCENTAGE = "nb_visits_percentage";

        private const string PLUGIN = "VisitorInterest";

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        public Object GetNumberOfVisitsPerPage(int idSite, PiwikPeriod period, PiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter("period", period),
                new PiwikDateParameter("date", date),
                new SimpleParameter("segment", segment),
            };

            if (PiwikPeriod.isMultipleDates(period, date))
            {
                return this.sendRequest<Dictionary<string, List<object>>>("getNumberOfVisitsPerPage", new List<Parameter>(parameters));
            }
            else
            {
                return this.sendRequest<List<object>>("getNumberOfVisitsPerPage", new List<Parameter>(parameters));
            }
        }

        public Object GetNumberOfVisitsByVisitCount(int idSite, PiwikPeriod period, PiwikDate date, string segment = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter("period", period),
                new PiwikDateParameter("date", date),
                new SimpleParameter("segment", segment),
            };

            if (PiwikPeriod.isMultipleDates(period, date))
            {
                return this.sendRequest<Dictionary<string, List<object>>>("getNumberOfVisitsByVisitCount ", new List<Parameter>(parameters));
            }
            else
            {
                return this.sendRequest<List<object>>("getNumberOfVisitsByVisitCount ", new List<Parameter>(parameters));
            }
        }
    }
}