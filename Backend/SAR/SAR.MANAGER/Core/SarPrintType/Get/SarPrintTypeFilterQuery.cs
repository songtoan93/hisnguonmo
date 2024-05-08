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
using SAR.DAO.StagingObject;
using SAR.EFMODEL.DataModels;
using SAR.Filter;
using SAR.MANAGER.Base;
using Inventec.Common.Logging;
using System;
using System.Collections.Generic;

namespace SAR.MANAGER.Core.SarPrintType.Get
{
    public class SarPrintTypeFilterQuery : SarPrintTypeFilter
    {
        public SarPrintTypeFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<SAR_PRINT_TYPE, bool>>> listExpression = new List<System.Linq.Expressions.Expression<Func<SAR_PRINT_TYPE, bool>>>();

        internal OrderProcessorBase OrderProcess = new OrderProcessorBase();

        internal SarPrintTypeSO Query()
        {
            SarPrintTypeSO search = new SarPrintTypeSO();
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
                #endregion

                if (!String.IsNullOrEmpty(this.PRINT_TYPE_CODE))
                {
                    listExpression.Add(o => o.PRINT_TYPE_CODE == this.PRINT_TYPE_CODE);
                }
                if (!String.IsNullOrEmpty(this.FILE_PATTERN))
                {
                    listExpression.Add(o => o.FILE_PATTERN == this.FILE_PATTERN);
                }
                if (!String.IsNullOrEmpty(this.EMR_DOCUMENT_TYPE_CODE__EXACT))
                {
                    listExpression.Add(o => o.EMR_DOCUMENT_TYPE_CODE == this.EMR_DOCUMENT_TYPE_CODE__EXACT);
                }

                if (!String.IsNullOrEmpty(this.KEY_WORD))
                {
                    this.KEY_WORD = this.KEY_WORD.ToLower().Trim();
                    listExpression.Add(o =>
                        o.CREATOR.ToLower().Contains(this.KEY_WORD) ||
                        o.MODIFIER.ToLower().Contains(this.KEY_WORD) ||
                        o.PRINT_TYPE_CODE.ToLower().Contains(this.KEY_WORD) ||
                        o.PRINT_TYPE_NAME.ToLower().Contains(this.KEY_WORD) ||
                        o.FILE_PATTERN.ToLower().Contains(this.KEY_WORD));
                }

                search.listSarPrintTypeExpression.AddRange(listExpression);
                search.OrderField = OrderProcess.GetOrderField<SAR_PRINT_TYPE>(ORDER_FIELD);
                search.OrderDirection = OrderProcess.GetOrderDirection(ORDER_DIRECTION);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listSarPrintTypeExpression.Clear();
                search.listSarPrintTypeExpression.Add(o => o.ID == NEGATIVE_ID);
            }
            return search;
        }
    }
}
