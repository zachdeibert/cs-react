using System;

namespace React.Language {
    class ExpectingClose : LanguageObject {
        protected override ILanguageObject AppendDiv(object arg) {
            throw new NotImplementedException();
        }

        protected override ILanguageObject AppendDivInv(object arg) {
            throw new NotImplementedException();
        }

        protected override ILanguageObject AppendGreater(object arg) {
            if (arg is TagContent) {
                Data.WriteString(((TagContent) arg).Content.ToString());
                return new Underscore();
            } else {
                throw new CSXSyntaxException("content", arg);
            }
        }

        protected override ILanguageObject AppendLess(object arg) {
            throw new NotImplementedException();
        }

        protected override ILanguageObject AppendPlus(object arg) {
            throw new NotImplementedException();
        }
    }
}
