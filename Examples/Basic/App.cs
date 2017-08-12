using System;
using static React.Static;
using React.Language;

namespace React.Examples.Basic {
    public class App : Component {
        public override ILanguageObject render() {
            return (_
                <(div, className="myDiv")>_
                    + "Hello, world!"
                    <(div, className="myInnerDiv")>_
                        + "Hi"
                    <_/div>_
                    + "Afterwards?"
                    <(div) /_>_
                <_/div>_
            );
        }

        public static void Main(string[] args) {
            ReactDOM.render(new App().render());
        }
    }
}
