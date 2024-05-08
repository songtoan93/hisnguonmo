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
using MOS.EFMODEL.DataModels;
using MPS.ProcessorBase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Processor.Mps000115.PDO
{
    public partial class Mps000115PDO : RDOBase
    {
        public const string printTypeCode = "Mps000115";

        public Mps000115PDO(V_HIS_INVOICE invoice, List<HIS_INVOICE_DETAIL> listInvoiceDetails)
        {
            try
            {
                _invoice = invoice;
                _listInvoiceDetails = listInvoiceDetails;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Debug(ex);
            }
        }
        
        public Mps000115PDO(V_HIS_INVOICE invoice, List<HIS_INVOICE_DETAIL> listInvoiceDetails, List<InvoiceDetailADO> listInvoiceDetailsADOs, List<TotalNextPage> totalNextPageSdos, string titles, List<HIS_PAY_FORM> payForm)
        {
            try
            {
                _invoice = invoice;
                _listInvoiceDetailsADOs = listInvoiceDetailsADOs;
                _totalNextPageSdos = totalNextPageSdos;
                _listInvoiceDetails = listInvoiceDetails;
                _titles = titles;
                _payForm = payForm;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Debug(ex);
            }
        }

        public Mps000115PDO(V_HIS_INVOICE invoice, List<HIS_INVOICE_DETAIL> listInvoiceDetails, List<InvoiceDetailADO> listInvoiceDetailsADOs, List<TotalNextPage> totalNextPageSdos, string titles, List<HIS_PAY_FORM> payForm, string creatorUN)
        {
            try
            {
                _invoice = invoice;
                _listInvoiceDetailsADOs = listInvoiceDetailsADOs;
                _totalNextPageSdos = totalNextPageSdos;
                _listInvoiceDetails = listInvoiceDetails;
                _titles = titles;
                _payForm = payForm;
                this.creatorUserName = creatorUN;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Debug(ex);
            }
        }

        public Mps000115PDO(V_HIS_INVOICE invoice, List<HIS_INVOICE_DETAIL> listInvoiceDetails, List<InvoiceDetailADO> listInvoiceDetailsADOs, List<TotalNextPage> totalNextPageSdos, List<HIS_PAY_FORM> payForm)
        {
            try
            {
                _invoice = invoice;
                _listInvoiceDetailsADOs = listInvoiceDetailsADOs;
                _totalNextPageSdos = totalNextPageSdos;
                _listInvoiceDetails = listInvoiceDetails;
                _payForm = payForm;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Debug(ex);
            }
        }

        public Mps000115PDO(V_HIS_INVOICE invoice, List<HIS_INVOICE_DETAIL> listInvoiceDetails, List<InvoiceDetailADO> listInvoiceDetailsADOs, List<TotalNextPage> totalNextPageSdos, List<HIS_PAY_FORM> payForm, string creatorUN)
        {
            try
            {
                _invoice = invoice;
                creatorUserName = creatorUN;
                _listInvoiceDetailsADOs = listInvoiceDetailsADOs;
                _totalNextPageSdos = totalNextPageSdos;
                _listInvoiceDetails = listInvoiceDetails;
                _payForm = payForm;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Debug(ex);
            }
        }
    }
}