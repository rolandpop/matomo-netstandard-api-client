using Piwik.Analytics.Date;
using Piwik.Analytics.Parameters;
using System;
using System.Collections.Generic;

namespace Piwik.Analytics.Modules
{
    public class MarketingCampaignsReporting : PiwikAnalytics
    {
        public const string LABEL = "label";
        public const string NB_UNIQ_VISITORS = "nb_uniq_visitors";
        public const string NB_VISITS = "nb_visits";
        public const string NB_ACTIONS = "nb_actions";
        public const string NB_USERS = "nb_users";
        public const string MAX_ACTIONS = "max_actions";
        public const string SUM_VISIT_LENDTH = "sum_visit_length";
        public const string BOUNCE_COUNT = "bounce_count";
        public const string NB_VISITS_CONVERTED = "nb_visits_converted";
        //"goals": {
        //    "idgoal=2": {
        //        "nb_conversions": 3,
        //        "nb_visits_converted": 3,
        //        "revenue": 0
        //    }
        //},
        public const string NB_CONVERSIONS = "nb_conversions";
        public const string REVENUE = "revenue";
        public const string SEGMENT = "segment";

        private const string PLUGIN = "MarketingCampaignsReporting";

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        public Object getSource(int idSite, PiwikPeriod period, PiwikDate date, string segment = null)
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
                return this.sendRequest<Dictionary<string, List<object>>>("getSource", new List<Parameter>(parameters));
            }
            else
            {
                return this.sendRequest<List<object>>("getSource", new List<Parameter>(parameters));
            }
        }
    }
}
