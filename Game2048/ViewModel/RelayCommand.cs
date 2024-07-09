using System;

namespace Game2048.ViewModel
{
    public class RelayCommand : BaseCommand
    {
        private readonly Action _execute;

        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        public override void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}