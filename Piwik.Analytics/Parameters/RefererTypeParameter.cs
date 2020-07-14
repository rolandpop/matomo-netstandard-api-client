// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;

namespace Piwik.Analytics.Parameters
{
    public class RefererTypeParameter : Parameter
    {
        private RefererType refererType;

        public RefererTypeParameter(string name, RefererType refererType)
            : base(name)
        {
            this.refererType = refererType;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.refererType != null)
            {
                parameter = "&" + this.name + "=" + urlEncode(this.refererType.getType().ToString());
            }

            return parameter;
        }
    }
}
