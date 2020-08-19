using Piwik.Analytics.Date;
using Piwik.Analytics.Parameters;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Piwik.Analytics.Modules
{
    public class Live : PiwikAnalytics
    {

        public const string ID_VISIT = "idVisit";
        public const string VISIT_IP = "visitIp";
        public const string VISITOR_ID = "visitorId";
        public const string GOAL_CONVERSIONS = "goalConversions";
        public const string VISIT_COUNT = "visitCount";
        public const string VISIT_DURATION = "visitDuration";
        public const string REFERRER_TYPE = "referrerType";
        public const string REFERRER_TYPE_NAME = "referrerTypeName";
        public const string REFERRER_NAME = "referrerName";
        public const string REFERRER_KEYWORD = "referrerKeyword";
        public const string REFERRER_KEYWORD_POSITION = "referrerKeywordPosition";
        public const string REFERRER_URL = "referrerUrl";
        public const string LANGUAGE_CODE = "languageCode";
        public const string DEVICE_TYPE = "deviceType";
        public const string DEVICE_BRAND = "deviceBrand";
        public const string DEVICE_MODEL = "deviceModel";
        public const string OS = "operatingSystem";
        public const string BROWSER_FAMILY = "browserFamily";
        public const string BROWSER = "browser";
        public const string CONTINENT = "continent";
        public const string COUNTRY = "country";
        public const string COUNTRY_CODE = "countryCode";
        public const string REGION = "region";
        public const string CITY = "city";
        public const string LOCATION = "location";
        public const string LATITUDE = "latitude";
        public const string LONGITUDE = "longitude";
        public const string RESOLUTION = "resolution";
        public const string CAMPAIGN_ID = "campaignId";
        public const string CAMPAIGN_CONTENT = "campaignContent";
        public const string CAMPAIGN_KEYWORD = "campaignKeyword";
        public const string CAMPAIGN_MEDIUM = "campaignMedium";
        public const string CAMPAIGN_NAME = "campaignName";
        public const string CAMPAIGN_SOURCE = "campaignSource";

        private const string PLUGIN = "Live";

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        public Object getLastVisitsDetails(int idSite, PiwikPeriod period, PiwikDate date, string segment = null, string countVisitorsToFetch = null, string minTimestamp = null, string flat = null, string doNotFetchActions = null, string enhanced = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter("period", period),
                new PiwikDateParameter("date", date),
                new SimpleParameter("segment", segment),
                new SimpleParameter("countVisitorsToFetch",countVisitorsToFetch),
                new SimpleParameter("minTimestamp",minTimestamp),
                new SimpleParameter("flat",flat),
                new SimpleParameter("doNotFetchActions",doNotFetchActions),
                new SimpleParameter("enhanced",enhanced)

            };

            return this.sendRequest<ArrayList>("getLastVisitsDetails", new List<Parameter>(parameters));
        }
    }
}
