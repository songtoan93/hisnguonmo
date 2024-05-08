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
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SAR.DAO.SarForm
{
    public partial class SarFormDAO : EntityBase
    {
        public List<V_SAR_FORM> GetView(SarFormSO search, CommonParam param)
        {
            List<V_SAR_FORM> result = new List<V_SAR_FORM>();

            try
            {
                result = GetWorker.GetView(search, param);
            }
            catch (Exception ex)
            {
                param.HasException = true;
                Inventec.Common.Logging.LogSystem.Error(ex);
                result.Clear();
            }

            return result;
        }

        //public SAR_FORM GetByCode(string code, SarFormSO search)
        //{
        //    SAR_FORM result = null;

        //    try
        //    {
        //        result = GetWorker.GetByCode(code, search);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Error(ex);
        //        result = null;
        //    }

        //    return result;
        //}
        
        public V_SAR_FORM GetViewById(long id, SarFormSO search)
        {
            V_SAR_FORM result = null;

            try
            {
                result = GetWorker.GetViewById(id, search);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }

            return result;
        }

        //public V_SAR_FORM GetViewByCode(string code, SarFormSO search)
        //{
        //    V_SAR_FORM result = null;

        //    try
        //    {
        //        result = GetWorker.GetViewByCode(code, search);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Error(ex);
        //        result = null;
        //    }
        //    return result;
        //}

        //public Dictionary<string, SAR_FORM> GetDicByCode(SarFormSO search, CommonParam param)
        //{
        //    Dictionary<string, SAR_FORM> result = new Dictionary<string, SAR_FORM>();
        //    try
        //    {
        //        result = GetWorker.GetDicByCode(search, param);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Error(ex);
        //        result.Clear();
        //    }

        //    return result;
        //}

        //public bool ExistsCode(string code, long? id)
        //{
        //    try
        //    {
        //        return CheckWorker.ExistsCode(code, id);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Error(ex);
        //        throw;
        //    }
        //}
    }
}