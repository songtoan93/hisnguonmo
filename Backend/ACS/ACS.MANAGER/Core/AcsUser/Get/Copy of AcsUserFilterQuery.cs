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
using ACS.DAO.StagingObject;
using ACS.EFMODEL.DataModels;
using ACS.Filter;
using ACS.MANAGER.Base;
using Inventec.Common.Logging;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Core.AcsUser.Get
{
    public class AcsUserFilterQuery : AcsUserFilter
    {
        public AcsUserFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<ACS_USER, bool>>> listExpression = new List<System.Linq.Expressions.Expression<Func<ACS_USER, bool>>>();

        internal OrderProcessorBase OrderProcess = new OrderProcessorBase();

        internal AcsUserSO Query()
        {
            AcsUserSO search = new AcsUserSO();
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

                if (this.LOGINNAMEs != null && this.LOGINNAMEs.Count > 0)
                {
                    listExpression.Add(o => this.LOGINNAMEs.Contains(o.LOGINNAME));
                }
                if (this.LOGINNAME__OR__SUB_LOGINNAMEs != null && this.LOGINNAME__OR__SUB_LOGINNAMEs.Count > 0)
                {
                    listExpression.Add(o => this.LOGINNAME__OR__SUB_LOGINNAMEs.Contains(o.LOGINNAME) || (!String.IsNullOrEmpty(o.SUB_LOGINNAME) && this.LOGINNAME__OR__SUB_LOGINNAMEs.Contains(o.SUB_LOGINNAME)));
                }
                if (!String.IsNullOrEmpty(this.LOGINNAME))
                {
                    listExpression.Add(o => o.LOGINNAME.ToLower() == this.LOGINNAME.ToLower());
                }
                if (!String.IsNullOrEmpty(this.LOGINNAME__OR__SUB_LOGINNAME))
                {
                    listExpression.Add(o => ((o.LOGINNAME.ToLower() == this.LOGINNAME__OR__SUB_LOGINNAME.ToLower()) || (!String.IsNullOrEmpty(o.SUB_LOGINNAME) && o.SUB_LOGINNAME.ToLower() == this.LOGINNAME__OR__SUB_LOGINNAME.ToLower())));
                }
                if (!String.IsNullOrEmpty(this.KEY_WORD))
                {
                    this.KEY_WORD = this.KEY_WORD.ToLower().Trim();
                    listExpression.Add(o => o.LOGINNAME.ToLower().Contains(this.KEY_WORD) || o.USERNAME.ToLower().Contains(this.KEY_WORD) || o.EMAIL.ToLower().Contains(this.KEY_WORD) || o.MOBILE.ToLower().Contains(this.KEY_WORD));
                }
                if (!String.IsNullOrEmpty(this.CN_WORD))
                {
                    this.CN_WORD = this.CN_WORD.ToLower().Trim();
                    listExpression.Add(o => o.LOGINNAME.ToLower().Contains(this.CN_WORD) || o.USERNAME.ToLower().Contains(this.CN_WORD));
                }
                #endregion

                search.listAcsUserExpression.AddRange(listExpression);
                search.OrderField = OrderProcess.GetOrderField<ACS_USER>(ORDER_FIELD);
                search.OrderDirection = OrderProcess.GetOrderDirection(ORDER_DIRECTION);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listAcsUserExpression.Clear();
                search.listAcsUserExpression.Add(o => o.ID == NEGATIVE_ID);
            }
            return search;
        }
    }
}
