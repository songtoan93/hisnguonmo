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
using SDA.API.Base;
using SDA.EFMODEL.DataModels;
using SDA.MANAGER.Manager;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SDA.API.Controllers
{
    public partial class SdaConfigAppController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SDA.MANAGER.Core.SdaConfigApp.Get.SdaConfigAppFilterQuery>), "param")]
        [ActionName("Get")]
        [AllowAnonymous]
        public ApiResult Get(ApiParam<SDA.MANAGER.Core.SdaConfigApp.Get.SdaConfigAppFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<SDA_CONFIG_APP>> result = new ApiResultObject<List<SDA_CONFIG_APP>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(SdaConfigAppManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<SDA_CONFIG_APP> resultData = managerContainer.Run<List<SDA_CONFIG_APP>>();
                    result = PackResult<List<SDA_CONFIG_APP>>(resultData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }
        
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Create(ApiParam<SDA_CONFIG_APP> param)
        {
            try
            {
                ApiResultObject<SDA_CONFIG_APP> result = new ApiResultObject<SDA_CONFIG_APP>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(SdaConfigAppManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDA_CONFIG_APP resultData = managerContainer.Run<SDA_CONFIG_APP>();
                    result = PackResult<SDA_CONFIG_APP>(resultData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("Update")]
        public ApiResult Update(ApiParam<SDA_CONFIG_APP> param)
        {
            try
            {
                ApiResultObject<SDA_CONFIG_APP> result = new ApiResultObject<SDA_CONFIG_APP>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(SdaConfigAppManager), "Update", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDA_CONFIG_APP resultData = managerContainer.Run<SDA_CONFIG_APP>();
                    result = PackResult<SDA_CONFIG_APP>(resultData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("ChangeLock")]
        public ApiResult ChangeLock(ApiParam<SDA_CONFIG_APP> param)
        {
            try
            {
                ApiResultObject<SDA_CONFIG_APP> result = new ApiResultObject<SDA_CONFIG_APP>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(SdaConfigAppManager), "ChangeLock", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDA_CONFIG_APP resultData = managerContainer.Run<SDA_CONFIG_APP>();
                    result = PackResult<SDA_CONFIG_APP>(resultData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ApiResult Delete(ApiParam<long> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    SDA_CONFIG_APP data = new SDA_CONFIG_APP();
                    data.ID = param.ApiData;
                    Inventec.Backend.MANAGER.ManagerContainer managerContainer = new Inventec.Backend.MANAGER.ManagerContainer(typeof(SdaConfigAppManager), "Delete", new object[] { param.CommonParam }, new object[] { data });
                    bool resultData = managerContainer.Run<bool>();
                    result = PackResult<bool>(resultData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                return null;
            }
        }
    }
}
