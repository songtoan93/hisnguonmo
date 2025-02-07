/* IVT
 * @Project : hisnguonmo
 * Copyright (C) 2017 INVENTEC
 *  
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *  
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *  
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */
using Inventec.Common.Logging;
using Inventec.Core;
using PostSharp.Aspects;
using System;

namespace ACS.MANAGER.Base
{
    [Serializable]
    public class LoggerAttribute : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs args)
        {
            Result t = (Result)args.ReturnValue;
            BusinessBase b = (BusinessBase)args.Instance;
            string className = "";
            string loginName = "";
            if (b != null)
            {
                className = args.Instance.GetType().Name;
                loginName = b.UserName;
            }

            if (t == null || !t.Success || t.Param.HasException)
            {
                string parameterValues = "";

                foreach (object arg in args.Arguments)
                {
                    if (parameterValues.Length > 0)
                    {
                        parameterValues += ", ";
                    }

                    if (arg != null)
                    {
                        parameterValues += Newtonsoft.Json.JsonConvert.SerializeObject(arg);
                    }
                    else
                    {
                        parameterValues += "null";
                    }
                }
                string log = string.Format("\n--LoginName: {0} \n--Class: {1} \n--Method: {2} \n--Input: {3} \n--Output: {4}", loginName, className, args.Method.Name, parameterValues, Newtonsoft.Json.JsonConvert.SerializeObject(args.ReturnValue));
                LogSystem.Error(log);
            }

            if (t != null && t.Param != null && (t.Param.HasException || (t.Param.BugCodes != null && t.Param.BugCodes.Count > 0)))
            {
                string troubleTime = Inventec.Common.DateTime.Get.NowAsTimeString();
                TroubleCache.Add(string.Format("{0}__LoginName: {1}__{2}", troubleTime, loginName, (t.Param.HasException ? "param.HasException." : "") + t.Param.GetBugCode()));
            }
        }
    }
}
