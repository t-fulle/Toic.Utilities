using Prism.Commands;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Toic.Demos
{
    public partial class DemoViewModel
    {
        public ICommand FirstAsyncCommand { get; private set; }
        public ICommand SecondAsyncCommand { get; private set; }
        public ICommand ThirdAsyncCommand { get; private set; }
        public ICommand FourthAsyncCommand { get; private set; }

        private void InitializeAsyncCommands()
        {
            FirstAsyncCommand = new AsyncDelegateCommand(FirstAsyncAction);
            //SecondAsyncCommand = new AsyncDelegateCommand(Task.Run(() => SecondAsyncAction()));
        }

        private async Task FirstAsyncAction()
        {
            await Task.Delay(1000);
            // print message
        }

        private async Task SecondAsyncAction()
        {
            await Task.Delay(1000);
            // print message
        }

        //private void InitializeAsyncCommands()
        //{
        //    FirstAsyncCommand = new DelegateCommand(async () =>
        //    {
        //        await Task.Delay(1000);
        //        MessageBox.Show("FirstAsyncCommand executed");
        //    });

        //    SecondAsyncCommand = new DelegateCommand(async () =>
        //    {
        //        await Task.Delay(1000);
        //        MessageBox.Show("SecondAsyncCommand executed");
        //    });

        //    ThirdAsyncCommand = new DelegateCommand(async () =>
        //    {
        //        await Task.Delay(1000);
        //        MessageBox.Show("ThirdAsyncCommand executed");
        //    });

        //    FourthAsyncCommand = new DelegateCommand(async () =>
        //    {
        //        await Task.Delay(1000);
        //        MessageBox.Show("FourthAsyncCommand executed");
        //    });
        //}


    }
}
