using Prism.Mvvm;

namespace Toic.Demos
{
    public partial class DemoViewModel : BindableBase
    {
        public string Message { get; set; } = "Demo";

        public DemoViewModel()
        {
        }

    }
}
