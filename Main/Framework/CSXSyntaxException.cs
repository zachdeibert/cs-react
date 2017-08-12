using System;

namespace React {
    public class CSXSyntaxException : Exception {
        private static string FormatMessage(string expecting, object got) {
            return string.Format("Expecting {0}, but got {1}", expecting, got);
        }

        public CSXSyntaxException(string expecting, object got) : base(FormatMessage(expecting, got)) {
        }
    }
}
