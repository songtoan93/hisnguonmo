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
using ACS.EFMODEL.Decorator;
using Inventec.Backend.EFMODEL;
using Inventec.Common.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace ACS.DAO.Base
{
    /// <summary>
    /// CREATE
    /// - Thanh cong khi co du lieu duoc insert vao DB thuc (savechange > 0 && == so luong can insert)
    /// UPDATE
    /// - Thanh cong khi tim thay du lieu, cap nhat & savechange ma khong co exception gi. Khong quan tam toi viec thuc te du lieu trong database co thay doi gi hay khong (truong hop du lieu update giong het du lieu dang ton tai).
    /// - That bai khi khong tim duoc du lieu, hoac savechange co exception
    /// DELETE
    /// - Tuong tu nhu update, can phai tim thay du lieu (can delete), thuc hien set IS_DELETE = 1 & savechange thanh cong
    /// - That bai khi khong tim duoc du lieu, hoac savechange co exception
    /// - Tuong tu truong hop can delete 1 list danh sach, chi can 1 du lieu trong list khong duoc tim thay, return false khong thuc hien xoa
    /// TRUNCATE
    /// - Tuong tu delete
    /// </summary>
    /// <typeparam name="DTO"></typeparam>
    /// <typeparam name="RAW"></typeparam>
    class BridgeDAO<RAW> : Inventec.Core.EntityBase
        where RAW : class
    {
        const string APP_CODE = "ACS";

        public BridgeDAO()
        {

        }

        public bool Delete(long id)
        {
            bool result = false;
            try
            {
                if (IsGreaterThanZero(id))
                {
                    using (var ctx = new AppContext())
                    {
                        RAW raw = (RAW)ctx.GetDbSet<RAW>().Find(id);
                        if (raw != null)
                        {
                            Type t = raw.GetType();
                            PropertyInfo p = t.GetProperty("IS_DELETE"); //Chuan thiet ke CSDL khong bao gio thay doi
                            p.SetValue(raw, (short)1, null); //Chuan thiet ke CSDL khong bao gio thay doi
                            ctx.SaveChanges();
                            result = true;
                        }
                        else
                        {
                            Logging("Khong tim duoc ban ghi trong CSDL theo data.id de xoa (set is_delete = 1)." + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => id), id), LogType.Error);
                        }
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => id), id), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => id), id), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }

            return result;
        }

        public bool DeleteListRaw(List<RAW> listRaw)
        {
            bool result = false;
            try
            {
                if (IsNotNullOrEmpty(listRaw))
                {
                    Type t = listRaw[0].GetType();
                    PropertyInfo p = t.GetProperty("IS_DELETE"); //Chuan thiet ke CSDL khong bao gio thay doi
                    using (var ctx = new AppContext())
                    {
                        foreach (var raw in listRaw)
                        {
                            p.SetValue(raw, (short)1, null); //Chuan thiet ke CSDL khong bao gio thay doi
                            ctx.Entry(raw).State = System.Data.EntityState.Modified; //reference System.Data.Entity
                        }
                        ctx.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listRaw), listRaw), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listRaw), listRaw), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }

            return result;
        }

        public bool DeleteListRaw(List<RAW> listRaw, AppContext ctx)
        {
            bool result = false;
            try
            {
                if (IsNotNullOrEmpty(listRaw))
                {
                    Type t = listRaw[0].GetType();
                    PropertyInfo p = t.GetProperty("IS_DELETE"); //Chuan thiet ke CSDL khong bao gio thay doi
                    foreach (var raw in listRaw)
                    {
                        p.SetValue(raw, (short)1, null); //Chuan thiet ke CSDL khong bao gio thay doi
                        //ModifyTimeDecorator.Set<RAW>(raw);
                        ctx.Entry(raw).State = System.Data.EntityState.Modified; //reference System.Data.Entity
                    }
                    ctx.SaveChanges();
                    result = true;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listRaw), listRaw), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listRaw), listRaw), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }

            return result;
        }

        public bool Truncate(long id)
        {
            bool result = false;
            try
            {
                if (IsGreaterThanZero(id))
                {
                    using (var ctx = new AppContext())
                    {
                        var dbSet = ctx.GetDbSet<RAW>();
                        RAW raw = (RAW)dbSet.Find(id);
                        if (raw != null)
                        {
                            dbSet.Remove(raw);
                            ctx.SaveChanges();
                            result = true;
                        }
                        else
                        {
                            Logging("Khong tim duoc ban ghi trong cSDL theo id de truncate." + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => id), id), LogType.Error);
                        }
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => id), id), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => id), id), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }

            return result;
        }

        public bool TruncateListRaw(List<RAW> listRaw)
        {
            bool result = false;
            try
            {
                if (IsNotNullOrEmpty(listRaw))
                {
                    using (var ctx = new AppContext())
                    {
                        System.Data.Entity.DbSet dbSet = ctx.GetDbSet<RAW>();
                        foreach (var raw in listRaw)
                        {
                            dbSet.Attach(raw);
                            dbSet.Remove(raw);
                        }
                        ctx.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listRaw), listRaw), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listRaw), listRaw), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }

            return result;
        }

        public bool IsUnLock(long id)
        {
            bool result = false;
            using (var ctx = new AppContext())
            {
                ContextUtil<RAW, AppContext> ctxUtil = new ContextUtil<RAW, AppContext>(ctx);
                result = ctxUtil.CheckIsActive(id);
            }
            return result;
        }

        public bool Create(RAW data)
        {
            bool result = false;
            try
            {
                if (IsNotNull(data))
                {
                    AppCreatorDecorator.Set<RAW>(data, APP_CODE);
                    CreatorDecorator.Set<RAW>(data, Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName());
                    GroupCodeDecorator.Set<RAW>(data, Inventec.Token.ResourceSystem.ResourceTokenManager.GetGroupCode());
                    DummyDecorator.Set<RAW>(data);
                    IsActiveDecorator.Set<RAW>(data);
                    IsDeleteDecorator.Set<RAW>(data);

                    using (var ctx = new AppContext())
                    {
                        ctx.GetDbSet<RAW>().Add(data);
                        result = (ctx.SaveChanges() > 0);
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }

            return result;
        }

        public bool CreateList(List<RAW> listData)
        {
            bool result = false;
            try
            {
                if (IsNotNullOrEmpty(listData))
                {
                    string loginName = Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName();
                    string groupCode = Inventec.Token.ResourceSystem.ResourceTokenManager.GetGroupCode();

                    using (var ctx = new AppContext())
                    {
                        var dbSet = ctx.GetDbSet<RAW>();
                        foreach (var data in listData)
                        {
                            AppCreatorDecorator.Set<RAW>(data, APP_CODE);
                            CreatorDecorator.Set<RAW>(data, loginName);
                            GroupCodeDecorator.Set<RAW>(data, groupCode);
                            DummyDecorator.Set<RAW>(data);
                            IsActiveDecorator.Set<RAW>(data);
                            IsDeleteDecorator.Set<RAW>(data);

                            dbSet.Add(data);
                        }
                        result = (ctx.SaveChanges() > 0);
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Newtonsoft.Json.JsonConvert.SerializeObject(listData), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Newtonsoft.Json.JsonConvert.SerializeObject(listData), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Update(RAW data)
        {
            bool result = false;
            try
            {
                if (IsNotNull(data))
                {
                    using (var ctx = new AppContext())
                    {
                        IsActiveDecorator.Set<RAW>(data);
                        IsDeleteDecorator.Set<RAW>(data);
                        Inventec.Backend.EFMODEL.AppModifierDecorator.Set<RAW>(data, APP_CODE);
                        ModifierDecorator.Set<RAW>(data, Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName());
                        var entry = ctx.Entry<RAW>(data);
                        ctx.GetDbSet<RAW>().Attach(data);
                        //entry.State = EntityState.Modified;
                        ctx.Entry<RAW>(data).State = System.Data.EntityState.Modified;

                        List<string> notChangeFields = DenyUpdateDecorator.Get<RAW>();
                        if (notChangeFields != null && notChangeFields.Count > 0)
                        {
                            foreach (string field in notChangeFields)
                            {
                                entry.Property(field).IsModified = false;
                            }
                        }

                        ctx.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool UpdateList(List<RAW> listData)
        {
            bool result = false;
            try
            {
                if (IsNotNullOrEmpty(listData))
                {
                    using (var ctx = new AppContext())
                    {
                        var dbSet = ctx.GetDbSet<RAW>();
                        string loginName = Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName();
                        List<string> notChangeFields = DenyUpdateDecorator.Get<RAW>();

                        foreach (RAW data in listData)
                        {
                            IsActiveDecorator.Set<RAW>(data);
                            IsDeleteDecorator.Set<RAW>(data);
                            Inventec.Backend.EFMODEL.AppModifierDecorator.Set<RAW>(data, APP_CODE);
                            ModifierDecorator.Set<RAW>(data, loginName);
                            ctx.Entry(data).State = EntityState.Detached;
                            dbSet.Attach(data);

                            var entry = ctx.Entry(data);
                            entry.State = EntityState.Modified;

                            if (notChangeFields != null && notChangeFields.Count > 0)
                            {
                                foreach (string field in notChangeFields)
                                {
                                    entry.Property(field).IsModified = false;
                                }
                            }
                        }
                        ctx.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => listData), listData), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool ExecuteSql(string sql)
        {
            bool result = false;
            try
            {
                if (!String.IsNullOrEmpty(sql))
                {
                    using (var ctx = new AppContext())
                    {
                        var count = ctx.Database.ExecuteSqlCommand(sql);
                        if (count == 0)
                        {
                            Inventec.Common.Logging.LogSystem.Info("SQL thuc hien thanh cong tuy nhien khong co du lieu duoc tac dong." + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => sql), sql));
                        }
                        result = true;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => sql), sql), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => sql), sql), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
