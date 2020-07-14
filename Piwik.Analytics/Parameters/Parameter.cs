// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System.Web;

namespace Piwik.Analytics.Parameters
{
    public abstract class Parameter
    {
        protected string name;

        abstract public string serialize();

        public Parameter(string name)
        {
            this.name = name;
        }

        protected static string urlEncode(string value)
        {
            return HttpUtility.UrlEncode(value);
        }
    }
}
