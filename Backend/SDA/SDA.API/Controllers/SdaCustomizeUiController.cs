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
    public partial class SdaCustomizeUiController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SDA.MANAGER.Core.SdaCustomizeUi.Get.SdaCustomizeUiFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<SDA.MANAGER.Core.SdaCustomizeUi.Get.SdaCustomizeUiFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<SDA_CUSTOMIZE_UI>> result = new ApiResultObject<List<SDA_CUSTOMIZE_UI>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaCustomizeUiManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<SDA_CUSTOMIZE_UI> resultData = managerContainer.Run<List<SDA_CUSTOMIZE_UI>>();
                    result = PackResult<List<SDA_CUSTOMIZE_UI>>(resultData);
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
        public ApiResult Create(ApiParam<SDA_CUSTOMIZE_UI> param)
        {
            try
            {
                ApiResultObject<SDA_CUSTOMIZE_UI> result = new ApiResultObject<SDA_CUSTOMIZE_UI>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaCustomizeUiManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDA_CUSTOMIZE_UI resultData = managerContainer.Run<SDA_CUSTOMIZE_UI>();
                    result = PackResult<SDA_CUSTOMIZE_UI>(resultData);
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
        public ApiResult Update(ApiParam<SDA_CUSTOMIZE_UI> param)
        {
            try
            {
                ApiResultObject<SDA_CUSTOMIZE_UI> result = new ApiResultObject<SDA_CUSTOMIZE_UI>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaCustomizeUiManager), "Update", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDA_CUSTOMIZE_UI resultData = managerContainer.Run<SDA_CUSTOMIZE_UI>();
                    result = PackResult<SDA_CUSTOMIZE_UI>(resultData);
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
        public ApiResult ChangeLock(ApiParam<SDA_CUSTOMIZE_UI> param)
        {
            try
            {
                ApiResultObject<SDA_CUSTOMIZE_UI> result = new ApiResultObject<SDA_CUSTOMIZE_UI>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaCustomizeUiManager), "ChangeLock", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SDA_CUSTOMIZE_UI resultData = managerContainer.Run<SDA_CUSTOMIZE_UI>();
                    result = PackResult<SDA_CUSTOMIZE_UI>(resultData);
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
                    SDA_CUSTOMIZE_UI data = new SDA_CUSTOMIZE_UI();
                    data.ID = param.ApiData;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SdaCustomizeUiManager), "Delete", new object[] { param.CommonParam }, new object[] { data });
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
