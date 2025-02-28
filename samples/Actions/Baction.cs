using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions
{
    public class Baction : BindableBase
    {
        /// <summary>
        /// The task that is currently or was last executed in regard to this baction.<br/>
        /// Null if it was not executed yet.
        /// </summary>
        public Task? Task { get => _task; set => SetProperty(ref _task, value); }
        private Task? _task;

        public States State { get => _state; set => SetProperty(ref _state, value, RaisePropertiesChanged); }
        private States _state;

        public string Message { get => _message; set => SetProperty(ref _message, value); }
        private string _message = string.Empty;

        public bool IsExecuting => State == States.Executing;
        public bool IsNotExecuting => State != States.Executing;

        private void RaisePropertiesChanged()
        { 
            RaisePropertyChanged(nameof(IsExecuting));
            RaisePropertyChanged(nameof(IsNotExecuting));
        }

        public enum States
        { 
            Idle,
            Executing,
            Failure,
            Success,
            Canceled,
            Attention,
        }
    }
}
