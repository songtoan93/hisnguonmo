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
using System;
using System.Data.Entity;
using ACS.EFMODEL.DataModels;

namespace ACS.DAO.Base
{
    class AppContext : Entities
    {
        public AppContext()
            : base()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet GetDbSet<RAW>() where RAW : class
        {
            DbSet result = null;
            Type typeRaw = typeof(RAW);

            var properties = typeof(AppContext).GetProperties();
            foreach (var pr in properties)
            {
                Type propertyType = pr.PropertyType.GenericTypeArguments != null
                    && pr.PropertyType.GenericTypeArguments.Length > 0 ? pr.PropertyType.GenericTypeArguments[0] : null;
                if (propertyType == typeRaw)
                {
                    result = (DbSet<RAW>)pr.GetValue(this);
                    break;
                }
            }
            return result;
        }
    }
}
