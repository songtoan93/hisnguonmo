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
using Inventec.Common.XmlConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.DesktopConfig
{
    internal class ElementNodeADO : ElementNode
    {
        public bool isConfig { get; set; }
        public ConfigType ConfigType { get; set; }
        public long ID { get; set; }
        public string IP { get; set; }
        public string ConfigFileName { get; set; }
        public ElementNodeADO()
        {
        }
        public ElementNodeADO(string key)
        {
            this.Title = key;
            this.isConfig = true;
        }

    }
}