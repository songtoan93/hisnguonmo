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
using SAR.DAO.Base;
using SAR.EFMODEL.DataModels;
using Inventec.Common.Logging;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAR.DAO.SarFormField
{
    partial class SarFormFieldDelete : EntityBase
    {
        public SarFormFieldDelete()
            : base()
        {
            bridgeDAO = new BridgeDAO<SAR_FORM_FIELD>();
        }

        private BridgeDAO<SAR_FORM_FIELD> bridgeDAO;

        public bool Delete(SAR_FORM_FIELD data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.ID) && bridgeDAO.Delete(data.ID);
        }

        public bool DeleteList(List<SAR_FORM_FIELD> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = valid && IsNotNullOrEmpty(listData);
                if (valid)
                {
                    List<SAR_FORM_FIELD> listIdNotFound = new List<SAR_FORM_FIELD>();
                    List<long> listId = new List<long>();
                    foreach (var data in listData)
                    {
                        if (data.ID > 0)
                        {
                            listId.Add(data.ID);
                        }
                        else
                        {
                            listIdNotFound.Add(data);
                        }
                    }
                    if (listIdNotFound.Count > 0)
                    {
                        Logging("Danh sach du lieu can delete co ton tai id <= 0." + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listIdNotFound), listIdNotFound), LogType.Warn);
                    }
                    else
                    {
                        using (var ctx = new AppContext())
                        {
                            List<SAR_FORM_FIELD> listRaw = ctx.SAR_FORM_FIELD.Where(o => listId.Contains(o.ID)).ToList();
                            if (listRaw != null && listRaw.Count == listData.Count)
                            {
                                result = bridgeDAO.DeleteListRaw(listRaw);
                            }
                            else
                            {
                                Logging("Danh sach du lieu truy van duoc de delete null hoac so luong khong bang danh sach dau vao (listRaw.Count <> listData.Count)." + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData) + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listRaw), listRaw), LogType.Warn);
                            }
                        }
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            
            return result;
        }
    }
}
