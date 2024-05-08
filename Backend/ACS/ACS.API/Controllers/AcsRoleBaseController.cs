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
using Inventec.Backend.MANAGER;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ACS.API.Controllers
{
    public partial class AcsRoleBaseController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<ACS.MANAGER.Core.AcsRoleBase.Get.AcsRoleBaseFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<ACS.MANAGER.Core.AcsRoleBase.Get.AcsRoleBaseFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<ACS_ROLE_BASE>> result = new ApiResultObject<List<ACS_ROLE_BASE>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(AcsRoleBaseManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<ACS_ROLE_BASE> resultData = managerContainer.Run<List<ACS_ROLE_BASE>>();
                    result = PackResult<List<ACS_ROLE_BASE>>(resultData);
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
        public ApiResult Create(ApiParam<ACS_ROLE_BASE> param)
        {
            try
            {
                ApiResultObject<ACS_ROLE_BASE> result = new ApiResultObject<ACS_ROLE_BASE>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(AcsRoleBaseManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    ACS_ROLE_BASE resultData = managerContainer.Run<ACS_ROLE_BASE>();
                    result = PackResult<ACS_ROLE_BASE>(resultData);
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
        public ApiResult Update(ApiParam<ACS_ROLE_BASE> param)
        {
            try
            {
                ApiResultObject<ACS_ROLE_BASE> result = new ApiResultObject<ACS_ROLE_BASE>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(AcsRoleBaseManager), "Update", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    ACS_ROLE_BASE resultData = managerContainer.Run<ACS_ROLE_BASE>();
                    result = PackResult<ACS_ROLE_BASE>(resultData);
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
        public ApiResult ChangeLock(ApiParam<ACS_ROLE_BASE> param)
        {
            try
            {
                ApiResultObject<ACS_ROLE_BASE> result = new ApiResultObject<ACS_ROLE_BASE>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(AcsRoleBaseManager), "ChangeLock", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    ACS_ROLE_BASE resultData = managerContainer.Run<ACS_ROLE_BASE>();
                    result = PackResult<ACS_ROLE_BASE>(resultData);
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
        public ApiResult Delete(ApiParam<ACS_ROLE_BASE> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(AcsRoleBaseManager), "Delete", new object[] { param.CommonParam }, new object[] { param.ApiData });
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