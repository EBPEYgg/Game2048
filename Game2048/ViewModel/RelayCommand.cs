using System;

namespace Game2048.ViewModel
{
    public class RelayCommand : BaseCommand
    {
        /// <summary>
        /// Действие для команды.
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// Создает экземпляр класса <see cref="RelayCommand"/> 
        /// с указанным действием для выполнения.
        /// </summary>
        /// <param name="execute">Действие, которое должно быть 
        /// выполнено при выполнении команды.</param>
        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        /// <summary>
        /// Метод, который выполняет действие, связанное с командой.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        public override void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}