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
using ACS.API.Base;
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Manager;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ACS.API.Controllers
{
    public partial class AcsActivityTypeController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<ACS.MANAGER.Core.AcsActivityType.Get.AcsActivityTypeFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<ACS.MANAGER.Core.AcsActivityType.Get.AcsActivityTypeFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<ACS_ACTIVITY_TYPE>> result = new ApiResultObject<List<ACS_ACTIVITY_TYPE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsActivityTypeManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<ACS_ACTIVITY_TYPE> resultData = managerContainer.Run<List<ACS_ACTIVITY_TYPE>>();
                    result = PackResult<List<ACS_ACTIVITY_TYPE>>(resultData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }
        
        //[HttpPost]
        //[ActionName("Create")]
        //public ApiResult Create(ApiParam<ACS_ACTIVITY_TYPE> param)
        //{
        //    try
        //    {
        //        ApiResultObject<ACS_ACTIVITY_TYPE> result = new ApiResultObject<ACS_ACTIVITY_TYPE>(null, false);
        //        if (param != null)
        //        {
        //            if (param.CommonParam == null) param.CommonParam = new CommonParam();
        //            this.commonParam = param.CommonParam;
        //            Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsActivityTypeManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
        //            ACS_ACTIVITY_TYPE resultData = managerContainer.Run<ACS_ACTIVITY_TYPE>();
        //            result = PackResult<ACS_ACTIVITY_TYPE>(resultData);
        //        }
        //        return new ApiResult(result, this.ActionContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Error(ex);
        //        return null;
        //    }
        //}

        //[HttpPost]
        //[ActionName("Update")]
        //public ApiResult Update(ApiParam<ACS_ACTIVITY_TYPE> param)
        //{
        //    try
        //    {
        //        ApiResultObject<ACS_ACTIVITY_TYPE> result = new ApiResultObject<ACS_ACTIVITY_TYPE>(null, false);
        //        if (param != null)
        //        {
        //            if (param.CommonParam == null) param.CommonParam = new CommonParam();
        //            this.commonParam = param.CommonParam;
        //            Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsActivityTypeManager), "Update", new object[] { param.CommonParam }, new object[] { param.ApiData });
        //            ACS_ACTIVITY_TYPE resultData = managerContainer.Run<ACS_ACTIVITY_TYPE>();
        //            result = PackResult<ACS_ACTIVITY_TYPE>(resultData);
        //        }
        //        return new ApiResult(result, this.ActionContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Error(ex);
        //        return null;
        //    }
        //}

        //[HttpPost]
        //[ActionName("ChangeLock")]
        //public ApiResult ChangeLock(ApiParam<ACS_ACTIVITY_TYPE> param)
        //{
        //    try
        //    {
        //        ApiResultObject<ACS_ACTIVITY_TYPE> result = new ApiResultObject<ACS_ACTIVITY_TYPE>(null, false);
        //        if (param != null)
        //        {
        //            if (param.CommonParam == null) param.CommonParam = new CommonParam();
        //            this.commonParam = param.CommonParam;
        //            Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsActivityTypeManager), "ChangeLock", new object[] { param.CommonParam }, new object[] { param.ApiData });
        //            ACS_ACTIVITY_TYPE resultData = managerContainer.Run<ACS_ACTIVITY_TYPE>();
        //            result = PackResult<ACS_ACTIVITY_TYPE>(resultData);
        //        }
        //        return new ApiResult(result, this.ActionContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Error(ex);
        //        return null;
        //    }
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //public ApiResult Delete(ApiParam<long> param)
        //{
        //    try
        //    {
        //        ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
        //        if (param != null)
        //        {
        //            if (param.CommonParam == null) param.CommonParam = new CommonParam();
        //            this.commonParam = param.CommonParam;
        //            ACS_ACTIVITY_TYPE data = new ACS_ACTIVITY_TYPE();
        //            data.ID = param.ApiData;
        //            Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(AcsActivityTypeManager), "Delete", new object[] { param.CommonParam }, new object[] { data });
        //            bool resultData = managerContainer.Run<bool>();
        //            result = PackResult<bool>(resultData);
        //        }
        //        return new ApiResult(result, this.ActionContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Error(ex);
        //        return null;
        //    }
        //}
    }
}
