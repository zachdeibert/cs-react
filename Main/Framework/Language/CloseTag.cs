using System;

namespace React.Language {
    class CloseTag : LanguageObject {
        internal readonly string Name;

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
            throw new NotImplementedException();
        }

        internal CloseTag(string name) {
            Name = name;
        }
    }
}
