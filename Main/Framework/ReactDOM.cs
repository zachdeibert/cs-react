using System;
using React.Language;

namespace React {
    public class ReactDOM {
        public static void render(ILanguageObject obj) {
            Console.WriteLine(((LanguageObject) obj).Data.RootElement);
        }
    }
}
