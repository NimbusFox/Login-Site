using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public static string GetValue(this NameValueCollection collection, string key) {
            return collection.HasKey(key) ? collection[collection.AllKeys.First(x => string.Equals(x, key, StringComparison.CurrentCultureIgnoreCase))] : "";
        }

        public static bool HasKey(this NameValueCollection colleciton, string key) {
            if (colleciton.HasKeys()) {
                if (colleciton.AllKeys.Any(x => string.Equals(x, key, StringComparison.CurrentCultureIgnoreCase))) {
                    return true;
                }
            }
            return false;
        }

        public static bool HasExceptionOtherThan(this Exception exception, Type type) {
            var output = false;
            var child = false;

            if (exception.InnerException != null) {
                child = exception.InnerException.HasExceptionOtherThan(type);
            }

            if (exception.GetType() != type) {
                output = true;
            }

            return child || output;
        }
    }
}