using System;
using System.Text;

namespace React.Language {
    class TagContent : LanguageObject {
        internal StringBuilder Content = new StringBuilder();

        protected override ILanguageObject AppendDiv(object arg) {
            throw new NotImplementedException();
        }

        protected override ILanguageObject AppendDivInv(object arg) {
            throw new NotImplementedException();
        }

        protected override ILanguageObject AppendGreater(object arg) {
            throw new NotImplementedException();
        }

        protected override ILanguageObject AppendLess(object arg) {
            throw new NotImplementedException();
        }

        protected override ILanguageObject AppendPlus(object arg) {
            if (arg is string) {
                Content.Append(arg);
                return this;
            } else {
                throw new CSXSyntaxException("string", arg);
            }
        }
    }
}
