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
using SDA.DAO.Base;
using SDA.DAO.StagingObject;
using SDA.EFMODEL.DataModels;
using Inventec.Common.Logging;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SDA.DAO.SdaEventLog
{
    partial class SdaEventLogGet : EntityBase
    {
        public List<SDA_EVENT_LOG> Get(SdaEventLogSO search, CommonParam param)
        {
            List<SDA_EVENT_LOG> list = new List<SDA_EVENT_LOG>();
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                if (valid)
                {
                    using (var ctx = new AppContext())
                    {
                        var query = ctx.SDA_EVENT_LOG.AsQueryable();
                        if (search.listSdaEventLogExpression != null && search.listSdaEventLogExpression.Count > 0)
                        {
                            foreach (var item in search.listSdaEventLogExpression)
                            {
                                query = query.Where(item);
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(search.OrderField) && !string.IsNullOrWhiteSpace(search.OrderDirection))
                        {
                            if (!param.Start.HasValue || !param.Limit.HasValue)
                            {
                                list = query.OrderByProperty(search.OrderField, search.OrderDirection).ToList();
                            }
                            else
                            {
                                //param.Count = (from r in query select r).Count();
                                //query = query.OrderByProperty(search.OrderField, search.OrderDirection);
                                //if (param.Count <= param.Limit.Value && param.Start.Value == 0)
                                //{
                                //    list = query.ToList();
                                //}
                                //else
                                //{
                                //    list = query.Skip(param.Start.Value).Take(param.Limit.Value).ToList();
                                //}

                                List<SDA_EVENT_LOG> listData = query.OrderByProperty(search.OrderField, search.OrderDirection).ToList();
                                param.Count = listData.Count();
                                if (param.Count <= param.Limit.Value && param.Start.Value == 0)
                                {
                                    list = listData;
                                }
                                else
                                {
                                    list = listData.Skip(param.Start.Value).Take(param.Limit.Value).ToList();
                                }
                            }
                        }
                        else
                        {
                            list = query.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => search), search) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => param), param), LogType.Error);
                LogSystem.Error(ex);
                list.Clear();
            }
            return list;
        }

        public SDA_EVENT_LOG GetById(long id, SdaEventLogSO search)
        {
            SDA_EVENT_LOG result = null;
            try
            {
                bool valid = true;
                valid = valid && IsGreaterThanZero(id);
                if (valid)
                {
                    using (var ctx = new AppContext())
                    {
                        var query = ctx.SDA_EVENT_LOG.AsQueryable().Where(p => p.ID == id);
                        if (search.listSdaEventLogExpression != null && search.listSdaEventLogExpression.Count > 0)
                        {
                            foreach (var item in search.listSdaEventLogExpression)
                            {
                                query = query.Where(item);
                            }
                        }
                        result = query.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => id), id) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => search), search), LogType.Error);
                LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}