// Copyright (c) Roland Pop All rights reserved.
// Licensed under the BSD 2-clause "Simplified" License. See License.txt in the project root for license information.

using System;

namespace Piwik.Analytics.Parameters
{
    class ArrayParameter : Parameter
    {
        private string[] values;
        private bool inline;

        public ArrayParameter(string name, string[] values, bool inline = false) : base (name)
        {
            this.values = values;
            this.inline = inline;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.values != null)
            {
                if (this.inline)
                {
                    parameter = "&" + this.name + "=";

                    for (int i = 0; i < this.values.Length; i++)
                    {
                        parameter += urlEncode(this.values[i]) + ",";
                    }
                }
                else
                {
                    for (int i = 0; i < this.values.Length; i++)
                    {
                        parameter += "&" + this.name + "[" + i + "]=" + urlEncode(this.values[i]);
                    }
                }

            }

            return parameter;
        }
    }
}
