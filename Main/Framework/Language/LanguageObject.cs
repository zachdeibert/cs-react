using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace React.Language {
    abstract class LanguageObject : ILanguageObject {
        private static readonly TypeInfo ITupleInternal = typeof(ValueTuple).GetTypeInfo().Assembly.GetType("System.ITupleInternal").GetTypeInfo();

        internal LanguageData Data {
            get;
            set;
        }

        private bool IsTopLevel;

        protected override void PreProcess() {
            if (Data == null || IsTopLevel) {
                IsTopLevel = true;
                Data = new LanguageData();
            }
        }

        protected override ILanguageObject PostProcess(ILanguageObject obj) {
            ((LanguageObject) obj).Data = Data;
            return obj;
        }

        protected static IEnumerable TupleToEnumerable(object obj) {
            TypeInfo objType = obj.GetType().GetTypeInfo();
            if (ITupleInternal.IsAssignableFrom(objType)) {
                return objType.DeclaredFields.Where(f => f.Name.StartsWith("Item", StringComparison.Ordinal)).Select(f => f.GetValue(obj));
            } else {
                return null;
            }
        }
    }
}
