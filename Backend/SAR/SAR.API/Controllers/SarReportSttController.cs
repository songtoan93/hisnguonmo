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
    public partial class SarReportSttController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<SAR.MANAGER.Core.SarReportStt.Get.SarReportSttFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<SAR.MANAGER.Core.SarReportStt.Get.SarReportSttFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<SAR_REPORT_STT>> result = new ApiResultObject<List<SAR_REPORT_STT>>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarReportSttManager), "Get", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    List<SAR_REPORT_STT> resultData = managerContainer.Run<List<SAR_REPORT_STT>>();
                    result = PackResult<List<SAR_REPORT_STT>>(resultData);
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
        //public ApiResult Create(ApiParam<SAR_REPORT_STT> param)
        //{
        //    try
        //    {
        //        ApiResultObject<SAR_REPORT_STT> result = new ApiResultObject<SAR_REPORT_STT>(null, false);
        //        if (param != null)
        //        {
        //            if (param.CommonParam == null) param.CommonParam = new CommonParam();
        //            this.commonParam = param.CommonParam;
        //            ManagerContainer managerContainer = new ManagerContainer(typeof(SarReportSttManager), "Create", new object[] { param.CommonParam }, new object[] { param.ApiData });
        //            SAR_REPORT_STT resultData = managerContainer.Run<SAR_REPORT_STT>();
        //            result = PackResult<SAR_REPORT_STT>(resultData);
        //        }
        //        return new ApiResult(result, this.ActionContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Error(ex);
        //        return null;
        //    }
        //}

        [HttpPost]
        [ActionName("Update")]
        public ApiResult Update(ApiParam<SAR_REPORT_STT> param)
        {
            try
            {
                ApiResultObject<SAR_REPORT_STT> result = new ApiResultObject<SAR_REPORT_STT>(null, false);
                if (param != null)
                {
                    if (param.CommonParam == null) param.CommonParam = new CommonParam();
                    this.commonParam = param.CommonParam;
                    ManagerContainer managerContainer = new ManagerContainer(typeof(SarReportSttManager), "Update", new object[] { param.CommonParam }, new object[] { param.ApiData });
                    SAR_REPORT_STT resultData = managerContainer.Run<SAR_REPORT_STT>();
                    result = PackResult<SAR_REPORT_STT>(resultData);
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
        //[ActionName("ChangeLock")]
        //public ApiResult ChangeLock(ApiParam<SAR_REPORT_STT> param)
        //{
        //    try
        //    {
        //        ApiResultObject<SAR_REPORT_STT> result = new ApiResultObject<SAR_REPORT_STT>(null, false);
        //        if (param != null)
        //        {
        //            if (param.CommonParam == null) param.CommonParam = new CommonParam();
        //            this.commonParam = param.CommonParam;
        //            ManagerContainer managerContainer = new ManagerContainer(typeof(SarReportSttManager), "ChangeLock", new object[] { param.CommonParam }, new object[] { param.ApiData });
        //            SAR_REPORT_STT resultData = managerContainer.Run<SAR_REPORT_STT>();
        //            result = PackResult<SAR_REPORT_STT>(resultData);
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
        //public ApiResult Delete(ApiParam<SAR_REPORT_STT> param)
        //{
        //    try
        //    {
        //        ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
        //        if (param != null)
        //        {
        //            if (param.CommonParam == null) param.CommonParam = new CommonParam();
        //            this.commonParam = param.CommonParam;
        //            ManagerContainer managerContainer = new ManagerContainer(typeof(SarReportSttManager), "Delete", new object[] { param.CommonParam }, new object[] { param.ApiData });
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