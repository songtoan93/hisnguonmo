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
using Inventec.Common.Logging;
using Inventec.Core;
using ACS.API.Base;
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.AcsAuthenRequest;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ACS.API.Controllers
{
    public partial class AcsAuthenRequestController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<AcsAuthenRequestFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<AcsAuthenRequestFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<ACS_AUTHEN_REQUEST>> result = new ApiResultObject<List<ACS_AUTHEN_REQUEST>>(null);
                if (param != null)
                {
                    AcsAuthenRequestManager mng = new AcsAuthenRequestManager(param.CommonParam);
                    result = mng.Get(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
        
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Create(ApiParam<ACS_AUTHEN_REQUEST> param)
        {
            try
            {
                ApiResultObject<ACS_AUTHEN_REQUEST> result = new ApiResultObject<ACS_AUTHEN_REQUEST>(null);
                if (param != null)
                {
                    AcsAuthenRequestManager mng = new AcsAuthenRequestManager(param.CommonParam);
                    result = mng.Create(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("Update")]
        public ApiResult Update(ApiParam<ACS_AUTHEN_REQUEST> param)
        {
            try
            {
                ApiResultObject<ACS_AUTHEN_REQUEST> result = new ApiResultObject<ACS_AUTHEN_REQUEST>(null);
                if (param != null)
                {
                    AcsAuthenRequestManager mng = new AcsAuthenRequestManager(param.CommonParam);
                    result = mng.Update(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ApiResult Delete(ApiParam<long> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    AcsAuthenRequestManager mng = new AcsAuthenRequestManager(param.CommonParam);
                    result = mng.Delete(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
        
        [HttpPost]
        [ActionName("ChangeLock")]
        public ApiResult ChangeLock(ApiParam<long> param)
        {
            try
            {
                ApiResultObject<ACS_AUTHEN_REQUEST> result = new ApiResultObject<ACS_AUTHEN_REQUEST>(null);
                if (param != null)
                {
                    AcsAuthenRequestManager mng = new AcsAuthenRequestManager(param.CommonParam);
                    result = mng.ChangeLock(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
		
		[HttpPost]
        [ActionName("Lock")]
        public ApiResult Lock(ApiParam<long> param)
        {
            ApiResultObject<ACS_AUTHEN_REQUEST> result = null;
            if (param != null)
            {
                AcsAuthenRequestManager mng = new AcsAuthenRequestManager(param.CommonParam);
                result = mng.Lock(param.ApiData);
            }
            return new ApiResult(result, this.ActionContext);
        }
    }
}
