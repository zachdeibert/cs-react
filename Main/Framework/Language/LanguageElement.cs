using System;
using System.Collections.Generic;
using System.Text;
using React.Statics;
using System.Linq;

namespace React.Language {
    class LanguageElement : List<LanguageNode>, LanguageNode {
        public LanguageElement Parent {
            get;
            set;
        }

        public readonly string Name;
        public readonly Dictionary<string, object> Properties;

        public override string ToString() {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("<{0}", Name);
            foreach (KeyValuePair<string, object> property in Properties) {
                str.AppendFormat(" {0}={2}{1}{2}", property.Key, property.Value, property.Value is string ? "\"" : "");
            }
            if (Count > 0) {
                str.Append(">");
                foreach (LanguageNode node in this) {
                    str.Append(node);
                }
                str.AppendFormat("</{0}>", Name);
            } else {
                str.Append(" />");
            }
            return str.ToString();
        }

        public LanguageElement(string name, LanguageElement parent, IEnumerable<Property> properties) {
            Name = name;
            Parent = parent;
            Properties = properties.ToDictionary(p => p.Name, p => p.Value);
        }
    }
}
