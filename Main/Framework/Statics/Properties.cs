using System;
using React.Statics;

namespace React {
    public static partial class Static {
        public static Property className {
            set => value.Set("class");
        }
    }
}
