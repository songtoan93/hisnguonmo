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
using Inventec.Common.Repository;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SAR.DAO.SarPrintTypeCfg
{
    public partial class SarPrintTypeCfgDAO : EntityBase
    {
        private SarPrintTypeCfgCreate CreateWorker
        {
            get
            {
                return (SarPrintTypeCfgCreate)Worker.Get<SarPrintTypeCfgCreate>();
            }
        }
        private SarPrintTypeCfgUpdate UpdateWorker
        {
            get
            {
                return (SarPrintTypeCfgUpdate)Worker.Get<SarPrintTypeCfgUpdate>();
            }
        }
        private SarPrintTypeCfgDelete DeleteWorker
        {
            get
            {
                return (SarPrintTypeCfgDelete)Worker.Get<SarPrintTypeCfgDelete>();
            }
        }
        private SarPrintTypeCfgTruncate TruncateWorker
        {
            get
            {
                return (SarPrintTypeCfgTruncate)Worker.Get<SarPrintTypeCfgTruncate>();
            }
        }
        private SarPrintTypeCfgGet GetWorker
        {
            get
            {
                return (SarPrintTypeCfgGet)Worker.Get<SarPrintTypeCfgGet>();
            }
        }
        private SarPrintTypeCfgCheck CheckWorker
        {
            get
            {
                return (SarPrintTypeCfgCheck)Worker.Get<SarPrintTypeCfgCheck>();
            }
        }

        public bool Create(SAR_PRINT_TYPE_CFG data)
        {
            bool result = false;
            try
            {
                result = CreateWorker.Create(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool CreateList(List<SAR_PRINT_TYPE_CFG> listData)
        {
            bool result = false;
            try
            {
                result = CreateWorker.CreateList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Update(SAR_PRINT_TYPE_CFG data)
        {
            bool result = false;
            try
            {
                result = UpdateWorker.Update(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool UpdateList(List<SAR_PRINT_TYPE_CFG> listData)
        {
            bool result = false;
            try
            {
                result = UpdateWorker.UpdateList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Delete(SAR_PRINT_TYPE_CFG data)
        {
            bool result = false;
            try
            {
                result = DeleteWorker.Delete(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool DeleteList(List<SAR_PRINT_TYPE_CFG> listData)
        {
            bool result = false;

            try
            {
                result = DeleteWorker.DeleteList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Truncate(SAR_PRINT_TYPE_CFG data)
        {
            bool result = false;
            try
            {
                result = TruncateWorker.Truncate(data);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool TruncateList(List<SAR_PRINT_TYPE_CFG> listData)
        {
            bool result = false;
            try
            {
                result = TruncateWorker.TruncateList(listData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public List<SAR_PRINT_TYPE_CFG> Get(SarPrintTypeCfgSO search, CommonParam param)
        {
            List<SAR_PRINT_TYPE_CFG> result = new List<SAR_PRINT_TYPE_CFG>();
            try
            {
                result = GetWorker.Get(search, param);
            }
            catch (Exception ex)
            {
                param.HasException = true;
                Inventec.Common.Logging.LogSystem.Error(ex);
                result.Clear();
            }
            return result;
        }

        public SAR_PRINT_TYPE_CFG GetById(long id, SarPrintTypeCfgSO search)
        {
            SAR_PRINT_TYPE_CFG result = null;
            try
            {
                result = GetWorker.GetById(id, search);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }

            return result;
        }

        public bool IsUnLock(long id)
        {
            try
            {
                return CheckWorker.IsUnLock(id);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                throw;
            }
        }
    }
}
