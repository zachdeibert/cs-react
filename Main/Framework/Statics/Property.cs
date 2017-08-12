using System;

namespace React.Statics {
    public class Property {
        internal string Name;
        internal object Value;

        public void Set(string name) {
            Name = name;
        }

        public Property(object val) {
            Value = val;
        }

        public static implicit operator Property(string obj) {
            return new Property(obj);
        }
    }
}
