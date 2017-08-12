using System;

namespace React.Language {
    class LanguageText : LanguageNode {
        public LanguageElement Parent {
            get;
            set;
        }

        public readonly string Text;

        public override string ToString() {
            return Text;
        }

        internal LanguageText(string text, LanguageElement parent) {
            Text = text;
            Parent = parent;
        }
    }
}
