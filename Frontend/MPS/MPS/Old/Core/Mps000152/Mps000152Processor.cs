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
using SAR.EFMODEL.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexCel.Report;
using Inventec.Common.Logging;

namespace MPS.Core.Mps000152
{
    class Mps000152Processor : ProcessorBase, IProcessorPrint
    {
        Mps000152RDO rdo;
        Inventec.Common.FlexCellExport.Store store;
        string fileName;

        internal Mps000152Processor(SAR_PRINT_TYPE config, string fileName, object data, MPS.Printer.PreviewType previewType, string printerName)
            : base(config, (RDOBase)data, previewType, printerName)
        {
            rdo = (Mps000152RDO)data;
            this.fileName = fileName;
            store = new Inventec.Common.FlexCellExport.Store();
        }

        bool IProcessorPrint.Run()
        {
            bool result = false;
            bool valid = true;
            try
            {
                SetCommonSingleKey();
                rdo.SetSingleKey();
                SetSingleKey();

                store.SetCommonFunctions();

                //Ham xu ly cac doi tuong su dung trong thu vien flexcelexport
                valid = valid && ProcessData();
                if (valid)
                {
                    using (MemoryStream streamResult = store.OutStream())
                    {
                        //Print preview
                        result = PrintPreview(streamResult, this.fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        private bool ProcessData()
        {
            bool result = false;
            try
            {
                    Inventec.Common.FlexCellExport.ProcessSingleTag singleTag = new Inventec.Common.FlexCellExport.ProcessSingleTag();
                    Inventec.Common.FlexCellExport.ProcessObjectTag objectTag = new Inventec.Common.FlexCellExport.ProcessObjectTag();

                    store.ReadTemplate(System.IO.Path.GetFullPath(fileName));
                    singleTag.ProcessData(store, singleValueDictionary);

                    objectTag.AddObjectData(store, "sereServGroups1", rdo._listInvoiceDetailsADOs);
                    objectTag.AddObjectData(store, "sereServGroups2", rdo._listInvoiceDetailsADOs);

                    objectTag.AddObjectData(store, "PayForm1", rdo._payForm);
                    objectTag.AddObjectData(store, "PayForm2", rdo._payForm);

                    objectTag.AddObjectData(store, "totalNextPages", rdo._totalNextPageSdos);
                    objectTag.AddObjectData(store, "totalNextPages1", rdo._totalNextPageSdos);
                    store.SetCommonFunctions();
                    objectTag.AddRelationship(store, "totalNextPages", "sereServGroups1", "Id", "PageId");
                    objectTag.AddRelationship(store, "totalNextPages1", "sereServGroups2", "Id", "PageId");
                    result = true;
            }
            catch (Exception ex)
            {
                result = false;
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

            return result;
        }
    }

  
}