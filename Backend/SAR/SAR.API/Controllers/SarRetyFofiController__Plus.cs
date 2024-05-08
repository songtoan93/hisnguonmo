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
using SAR.API.Base;
using SAR.EFMODEL.DataModels;
using SAR.MANAGER.Manager;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SAR.API.Controllers
{
    public partial class SarRetyFofiController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SAR.MANAGER.Core.SarRetyFofi.Get.SarRetyFofiViewFilterQuery>), "param")]
        [ActionName("GetView")]
        public ApiResult GetView(ApiParam<SAR.MANAGER.Core.SarRetyFofi.Get.SarRetyFofiViewFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<V_SAR_RETY_FOFI>> result = new ApiResultObject<List<V_SAR_RETY_FOFI>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarRetyFofiManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<V_SAR_RETY_FOFI> resultData = managerContainer.Run<List<V_SAR_RETY_FOFI>>();
                    result = PackResult<List<V_SAR_RETY_FOFI>>(resultData);
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