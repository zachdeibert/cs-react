// #define DEBUG_CLASS

using System;

namespace React.Language {
    public abstract class ILanguageObject {
        protected abstract ILanguageObject AppendDiv(object arg);

        protected abstract ILanguageObject AppendDivInv(object arg);

        protected abstract ILanguageObject AppendGreater(object arg);

        protected abstract ILanguageObject AppendLess(object arg);

        protected abstract ILanguageObject AppendPlus(object arg);

        protected abstract void PreProcess();

        protected abstract ILanguageObject PostProcess(ILanguageObject obj);

        private static void Check(ILanguageObject obj, object arg) {
            if (obj == null) {
                throw new ArgumentNullException(nameof(obj));
            }
            if (arg == null) {
                throw new ArgumentNullException(nameof(arg));
            }
            obj.PreProcess();
        }

        public static ILanguageObject operator /(ILanguageObject obj, object arg) {
#if DEBUG_CLASS
            Console.WriteLine("{0} / {1}", obj, arg);
#endif
            Check(obj, arg);
            return obj.PostProcess(obj.AppendDiv(arg));
        }

        public static ILanguageObject operator /(object arg, ILanguageObject obj) {
#if DEBUG_CLASS
            Console.WriteLine("{0} / {1}", arg, obj);
#endif
            Check(obj, arg);
            return obj.PostProcess(obj.AppendDivInv(arg));
        }

        public static ILanguageObject operator >(ILanguageObject obj, object arg) {
#if DEBUG_CLASS
            Console.WriteLine("{0} > {1}", obj, arg);
#endif
            Check(obj, arg);
            return obj.PostProcess(obj.AppendGreater(arg));
        }

        public static ILanguageObject operator <(ILanguageObject obj, object arg) {
#if DEBUG_CLASS
            Console.WriteLine("{0} < {1}", obj, arg);
#endif
            Check(obj, arg);
            return obj.PostProcess(obj.AppendLess(arg));
        }

        public static ILanguageObject operator +(ILanguageObject obj, object arg) {
#if DEBUG_CLASS
            Console.WriteLine("{0} + {1}", obj, arg);
#endif
            Check(obj, arg);
            return obj.PostProcess(obj.AppendPlus(arg));
        }
    }
}
