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
using SDA.DAO.StagingObject;
using SDA.EFMODEL.DataModels;
using SDA.Filter;
using SDA.MANAGER.Base;
using Inventec.Common.Logging;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.Core.SdaEventLog.Get
{
    public class SdaEventLogFilterQuery : SdaEventLogFilter
    {
        public SdaEventLogFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<SDA_EVENT_LOG, bool>>> listExpression = new List<System.Linq.Expressions.Expression<Func<SDA_EVENT_LOG, bool>>>();

        internal OrderProcessorBase OrderProcess = new OrderProcessorBase();

        internal SdaEventLogSO Query()
        {
            SdaEventLogSO search = new SdaEventLogSO();
            try
            {
                #region Abstract Base
                if (this.ID.HasValue)
                {
                    listExpression.Add(o => o.ID == this.ID.Value);
                }
                if (this.IS_ACTIVE.HasValue)
                {
                    listExpression.Add(o => o.IS_ACTIVE == this.IS_ACTIVE.Value);
                }
                if (this.CREATE_TIME_FROM.HasValue)
                {
                    listExpression.Add(o => o.CREATE_TIME.Value >= this.CREATE_TIME_FROM.Value);
                }
                if (this.CREATE_TIME_TO.HasValue)
                {
                    listExpression.Add(o => o.CREATE_TIME.Value <= this.CREATE_TIME_TO.Value);
                }
                if (this.MODIFY_TIME_FROM.HasValue)
                {
                    listExpression.Add(o => o.MODIFY_TIME.Value >= this.MODIFY_TIME_FROM.Value);
                }
                if (this.MODIFY_TIME_TO.HasValue)
                {
                    listExpression.Add(o => o.MODIFY_TIME.Value <= this.MODIFY_TIME_TO.Value);
                }
                if (!String.IsNullOrEmpty(this.CREATOR))
                {
                    listExpression.Add(o => o.CREATOR == this.CREATOR);
                }
                if (!String.IsNullOrEmpty(this.MODIFIER))
                {
                    listExpression.Add(o => o.MODIFIER == this.MODIFIER);
                }
                if (!String.IsNullOrEmpty(this.GROUP_CODE))
                {
                    listExpression.Add(o => o.GROUP_CODE == this.GROUP_CODE);
                }
                if (this.IDs != null && this.IDs.Count > 0)
                {
                    listExpression.Add(o => this.IDs.Contains(o.ID));
                }

                if (!String.IsNullOrEmpty(this.LOGIN_NAME))
                {
                    listExpression.Add(o => o.LOGIN_NAME == this.LOGIN_NAME);
                }
                if (!String.IsNullOrEmpty(this.KEY_WORD))
                {
                    this.KEY_WORD = this.KEY_WORD.ToLower().Trim();
                    listExpression.Add(o =>
                        o.CREATOR.ToLower().Contains(this.KEY_WORD) ||
                        o.MODIFIER.ToLower().Contains(this.KEY_WORD) ||
                        o.LOGIN_NAME.ToLower().Contains(this.KEY_WORD) ||
                        o.IP.ToLower().Contains(this.KEY_WORD) ||
                        o.DESCRIPTION.ToLower().Contains(this.KEY_WORD)
                        );
                }
                #endregion
                if (this.CREATE_DATE_FROM.HasValue)
                {
                    listExpression.Add(o => o.CREATE_DATE.Value >= this.CREATE_DATE_FROM.Value);
                }
                if (this.CREATE_DATE_TO.HasValue)
                {
                    listExpression.Add(o => o.CREATE_DATE.Value <= this.CREATE_DATE_TO.Value);
                }

                if (this.EVENT_TIME_FROM.HasValue)
                {
                    listExpression.Add(o => o.EVENT_TIME.Value >= this.EVENT_TIME_FROM.Value);
                }
                if (this.EVENT_TIME_TO.HasValue)
                {
                    listExpression.Add(o => o.EVENT_TIME.Value <= this.EVENT_TIME_TO.Value);
                }

                if (this.EVENT_DATE.HasValue)
                {
                    listExpression.Add(o => o.EVENT_DATE.Value == this.EVENT_DATE.Value);
                }

                if (this.EVENT_MONTH.HasValue)
                {
                    listExpression.Add(o => o.EVENT_MONTH.Value == this.EVENT_MONTH.Value);
                }

                if (!String.IsNullOrEmpty(this.DESCRIPTION))
                {
                    this.DESCRIPTION = this.DESCRIPTION.ToLower().Trim();
                    listExpression.Add(o => o.DESCRIPTION.ToLower().Contains(this.DESCRIPTION));
                }

                if (this.EVENT_DATE_FROM.HasValue)
                {
                    listExpression.Add(o => o.EVENT_DATE.Value >= this.EVENT_DATE_FROM.Value);
                }
                if (this.EVENT_DATE_TO.HasValue)
                {
                    listExpression.Add(o => o.EVENT_DATE.Value <= this.EVENT_DATE_TO.Value);
                }

                search.listSdaEventLogExpression.AddRange(listExpression);
                search.OrderField = OrderProcess.GetOrderField<SDA_EVENT_LOG>(ORDER_FIELD);
                search.OrderDirection = OrderProcess.GetOrderDirection(ORDER_DIRECTION);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listSdaEventLogExpression.Clear();
                search.listSdaEventLogExpression.Add(o => o.ID == NEGATIVE_ID);
            }
            return search;
        }
    }
}
