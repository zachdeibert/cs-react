using System;
using System.Collections;
using System.Linq;
using React.Statics;

namespace React.Language {
    class Underscore : LanguageObject {
        protected override ILanguageObject AppendDiv(object arg) {
            if (arg is Element) {
                return new CloseTag(((Element) arg).Name);
            } else {
                throw new CSXSyntaxException("element", arg);
            }
        }

        protected override ILanguageObject AppendDivInv(object arg) {
            IEnumerable data = TupleToEnumerable(arg);
            if (data != null) {
                string name = data.OfType<Element>().First().Name;
                Data.EnterElement(name, data.OfType<Property>());
                return new CloseTag(name);
            } else if (arg is Element) {
                return ValueTuple.Create((Element) arg) / this;
            } else {
                throw new CSXSyntaxException("(element, ...) or element", arg);
            }
        }

        protected override ILanguageObject AppendGreater(object arg) {
            if (arg is Underscore) {
                return this;
            } else if (arg is TagContent) {
                Data.WriteString(((TagContent)arg).Content.ToString());
                return this;
            } else {
                throw new CSXSyntaxException("_", arg);
            }
        }

        protected override ILanguageObject AppendLess(object arg) {
            IEnumerable data = TupleToEnumerable(arg);
            if (data != null) {
                Data.EnterElement(data.OfType<Element>().First().Name, data.OfType<Property>());
                return new ExpectingClose();
            } else if (arg is Element) {
                return this < ValueTuple.Create((Element) arg);
            } else if (arg is CloseTag) {
                if (((CloseTag) arg).Data != Data) {
                    Data.CopyFrom(((CloseTag) arg).Data);
                }
                Data.LeaveElement(((CloseTag) arg).Name);
                return this;
            } else {
                throw new CSXSyntaxException("(element, ...) or element", arg);
            }
        }

        protected override ILanguageObject AppendPlus(object arg) {
            return new TagContent() + arg;
        }
    }
}
