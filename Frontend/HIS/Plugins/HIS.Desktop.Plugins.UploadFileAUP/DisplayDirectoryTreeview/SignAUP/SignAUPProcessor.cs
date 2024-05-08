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
using Inventec.Desktop.Core;
using Inventec.Core;
using Inventec.Desktop.Common.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.UploadFileAUP.SignAUP
{
    class SignAUPProcessor
    {
        [ExtensionOf(typeof(DesktopRootExtensionPoint),
           "HIS.Desktop.Plugins.UploadFileAUP",
           "",
           "",
           0,
           "",
           "",
           Module.MODULE_TYPE_ID__FORM,
           true,
           true)
        ]
        public class SignedDocumentSProcessor : ModuleBase, IDesktopRoot
        {
            CommonParam param;
            public SignedDocumentSProcessor()
            {
                param = new CommonParam();
            }
            public SignedDocumentSProcessor(CommonParam paramBusiness)
            {
                param = (paramBusiness != null ? paramBusiness : new CommonParam());
            }

            public object Run(object[] args)
            {
                object result = null;
                try
                {
                    ISignAUP behavior = SignAUPFactory.MakeISignedDocument(param, args);
                    result = behavior != null ? (object)(behavior.Run()) : null;
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                    result = null;
                }
                return result;
            }
            public override bool IsEnable()
            {
                bool result = false;
                try
                {
                    result = true;
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                    result = false;
                }
                return result;
            }
        }
    }
}
