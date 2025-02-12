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
using SDA.EFMODEL.DataModels;
using Inventec.Core;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SDA.DAO.SdaTranslate
{
    partial class SdaTranslateCheck : EntityBase
    {
        public SdaTranslateCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<SDA_TRANSLATE>();
        }

        private BridgeDAO<SDA_TRANSLATE> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }

        public bool IsExistsCreate(SDA_TRANSLATE data)
        {
            bool result = false;
            try
            {
                if (data != null)
                {
                    long count = 0;
                    using (var ctx = new AppContext())
                    {
                        count = ctx.SDA_TRANSLATE.AsQueryable().Where(p =>
                            p.ID != data.ID &&
                            (p.IS_DELETE.HasValue || p.IS_DELETE.Value != (short)1) &&
                            p.FIND_COLUMN_NAME_ONE.Equals(data.FIND_COLUMN_NAME_ONE) &&
                            p.FIND_COLUMN_NAME_TWO.Equals(data.FIND_COLUMN_NAME_TWO) &&
                            p.FIND_DATA_CODE_ONE.Equals(data.FIND_DATA_CODE_ONE) &&
                            p.FIND_DATA_CODE_TWO.Equals(data.FIND_DATA_CODE_TWO) &&
                            p.LANGUAGE_ID == data.LANGUAGE_ID &&
                            p.SCHEMA.Equals(data.SCHEMA) &&
                            p.TABLE_NAME.Equals(data.TABLE_NAME)).Count();
                    }
                    result = (count > 0);
                }
            }
            catch (Exception)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data), LogType.Error);
                throw;
            }
            return result;
        }

        public bool IsExistsUpdate(SDA_TRANSLATE data)
        {
            bool result = false;
            try
            {
                if (data != null)
                {
                    List<SDA_TRANSLATE> list = new List<SDA_TRANSLATE>();
                    using (var ctx = new AppContext())
                    {
                        list = ctx.SDA_TRANSLATE.AsQueryable().Where(p =>
                            (p.IS_DELETE.HasValue || p.IS_DELETE.Value != (short)1) &&
                            p.FIND_COLUMN_NAME_ONE.Equals(data.FIND_COLUMN_NAME_ONE) &&
                            p.FIND_COLUMN_NAME_TWO.Equals(data.FIND_COLUMN_NAME_TWO) &&
                            p.FIND_DATA_CODE_ONE.Equals(data.FIND_DATA_CODE_ONE) &&
                            p.FIND_DATA_CODE_TWO.Equals(data.FIND_DATA_CODE_TWO) &&
                            p.LANGUAGE_ID == data.LANGUAGE_ID &&
                            p.SCHEMA.Equals(data.SCHEMA) &&
                            p.TABLE_NAME.Equals(data.TABLE_NAME)).ToList();
                    }

                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            if (item.ID != data.ID)
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data), LogType.Error);
                throw;
            }
            return result;
        }
    }
}
