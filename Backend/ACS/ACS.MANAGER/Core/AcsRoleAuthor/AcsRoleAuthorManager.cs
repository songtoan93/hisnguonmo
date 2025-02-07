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
using Inventec.Core;
using Inventec.Common.Logging;
using ACS.EFMODEL.DataModels;
using ACS.MANAGER.Base;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.AcsRoleAuthor
{
    public partial class AcsRoleAuthorManager : BusinessBase
    {
        public AcsRoleAuthorManager()
            : base()
        {

        }
        
        public AcsRoleAuthorManager(CommonParam param)
            : base(param)
        {

        }
		
		[Logger]
        public ApiResultObject<List<ACS_ROLE_AUTHOR>> Get(AcsRoleAuthorFilterQuery filter)
        {
            ApiResultObject<List<ACS_ROLE_AUTHOR>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<ACS_ROLE_AUTHOR> resultData = null;
                if (valid)
                {
                    resultData = new AcsRoleAuthorGet(param).Get(filter);
                }
                result = this.PackSuccess(resultData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

		[Logger]
        public ApiResultObject<ACS_ROLE_AUTHOR> Create(ACS_ROLE_AUTHOR data)
        {
            ApiResultObject<ACS_ROLE_AUTHOR> result = new ApiResultObject<ACS_ROLE_AUTHOR>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ACS_ROLE_AUTHOR resultData = null;
				bool isSuccess = false;
                if (valid)
                {
					isSuccess = new AcsRoleAuthorCreate(param).Create(data);
                    resultData = isSuccess ? data : null;
                }
                result = this.PackResult(resultData, isSuccess);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
            }
            return result;
        }

		[Logger]
        public ApiResultObject<ACS_ROLE_AUTHOR> Update(ACS_ROLE_AUTHOR data)
        {
            ApiResultObject<ACS_ROLE_AUTHOR> result = new ApiResultObject<ACS_ROLE_AUTHOR>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ACS_ROLE_AUTHOR resultData = null;
				bool isSuccess = false;
                if (valid)
                {
					isSuccess = new AcsRoleAuthorUpdate(param).Update(data);
                    resultData = isSuccess ? data : null;
                }
                result = this.PackResult(resultData, isSuccess);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
            }
            
            return result;
        }

		[Logger]
        public ApiResultObject<ACS_ROLE_AUTHOR> ChangeLock(long id)
        {
            ApiResultObject<ACS_ROLE_AUTHOR> result = new ApiResultObject<ACS_ROLE_AUTHOR>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                ACS_ROLE_AUTHOR resultData = null;
				bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsRoleAuthorLock(param).ChangeLock(id, ref resultData);
                }
                result = this.PackResult(resultData, isSuccess);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
            }
            
            return result;
        }
		
		[Logger]
        public ApiResultObject<ACS_ROLE_AUTHOR> Lock(long id)
        {
            ApiResultObject<ACS_ROLE_AUTHOR> result = null;
            
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                ACS_ROLE_AUTHOR resultData = null;
				bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsRoleAuthorLock(param).Lock(id, ref resultData);
                }
                result = this.PackResult(resultData, isSuccess);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }

            return result;
        }
		
		[Logger]
        public ApiResultObject<ACS_ROLE_AUTHOR> Unlock(long id)
        {
            ApiResultObject<ACS_ROLE_AUTHOR> result = null;
            
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                ACS_ROLE_AUTHOR resultData = null;
				bool isSuccess = false;
                if (valid)
                {
                    isSuccess = new AcsRoleAuthorLock(param).Unlock(id, ref resultData);
                }
                result = this.PackResult(resultData, isSuccess);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }

            return result;
        }

		[Logger]
        public ApiResultObject<bool> Delete(long id)
        {
            ApiResultObject<bool> result = new ApiResultObject<bool>(false);

            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                bool resultData = false;
                if (valid)
                {
                    resultData = new AcsRoleAuthorTruncate(param).Truncate(id);
                }
                result = this.PackSingleResult(resultData);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
            }
            
            return result;
        }
    }
}
