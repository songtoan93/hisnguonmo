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
using ACS.MANAGER.AcsAuthorSystem;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ACS.API.Controllers
{
    public partial class AcsAuthorSystemController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<AcsAuthorSystemViewFilterQuery>), "param")]
        [ActionName("GetView")]
        public ApiResult Get(ApiParam<AcsAuthorSystemViewFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<V_ACS_AUTHOR_SYSTEM>> result = new ApiResultObject<List<V_ACS_AUTHOR_SYSTEM>>(null);
                if (param != null)
                {
                    AcsAuthorSystemManager mng = new AcsAuthorSystemManager(param.CommonParam);
                    result = mng.GetView(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
    }
}
