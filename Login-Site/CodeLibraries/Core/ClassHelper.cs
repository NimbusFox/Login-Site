using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AutoMapper.Impl;
using Microsoft.Ajax.Utilities;
using NimbusFox.Login_Site.Models.Core.AjaxForms;

namespace NimbusFox.Login_Site.CodeLibraries.Core {
    public static class ClassHelper {
        public static string CoreGetName<T, TP>(this object current, Expression<Func<T, TP>> action) where T : class {
            var expression = (MemberExpression)action.Body;
            return expression.Member.Name;
        }

        public static string GetName<TP>(this Register current, Expression<Func<Register, TP>> action) {
            return current.CoreGetName(action);
        }
    }
}