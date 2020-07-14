// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Piwik.Analytics.Parameters
{
    class DictionaryParameter : Parameter
    {

        private Dictionary<string, Object> values;

        public DictionaryParameter(string name, Dictionary<string, Object> values)
            : base(name)
        {
            this.values = values;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.values != null)
            {
                foreach (KeyValuePair<String, Object> kv in values)
                {
                    if (kv.Value == null)
                        continue;

                    if (kv.Value is String[])
                    {
                        String[] arr = (String[])kv.Value;
                        foreach (String s in arr)
                        {
                            parameter += "&" + this.name + "[" + kv.Key + "][]=" + urlEncode(s);
                        }
                    }
                    else
                    {
                        parameter += "&" + this.name + "[" + kv.Key + "]=" + urlEncode(kv.Value.ToString());
                    }
                }
            }
            return parameter;
        }
    }
}