// #define DEBUG_CLASS

using System;
using System.Collections.Generic;
using React.Statics;

namespace React.Language {
    class LanguageData {
        internal LanguageElement CurrentElement;

        internal LanguageElement RootElement;

        internal void EnterElement(string name, IEnumerable<Property> properties) {
#if DEBUG_CLASS
            Console.WriteLine("Enter {0}", name);
            Console.WriteLine(this);
#endif
            LanguageElement cur = CurrentElement;
            CurrentElement = new LanguageElement(name, CurrentElement, properties);
            if (cur == null) {
                RootElement = CurrentElement;
            } else {
                cur.Add(CurrentElement);
            }
        }

        internal void CopyFrom(LanguageData other) {
#if DEBUG_CLASS
            Console.WriteLine("Copy {0}", other);
            Console.WriteLine(this);
#endif
            if (other.RootElement != null) {
                LanguageElement cur = CurrentElement;
                other.RootElement.Parent = CurrentElement;
                CurrentElement = other.RootElement;
                if (cur == null) {
                    RootElement = CurrentElement;
                } else {
                    cur.Add(CurrentElement);
                }
            }
        }

        internal void LeaveElement(string name) {
#if DEBUG_CLASS
            Console.WriteLine("Leave {0}", name);
            Console.WriteLine(this);
#endif
            CurrentElement = CurrentElement.Parent;
        }

        internal void WriteString(string text) {
            CurrentElement.Add(new LanguageText(text, CurrentElement));
        }

        public override string ToString() {
            return string.Format("[LanguageData CurrentElement={0} RootElement={1}]", CurrentElement, RootElement);
        }
    }
}
