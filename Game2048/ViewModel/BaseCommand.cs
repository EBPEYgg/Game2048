using System;
using System.Windows.Input;

namespace Game2048.ViewModel
{
    /// <summary>
    /// Класс, описывающий команду для загрузку данных.
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Метод, который определяет, может ли 
        /// команда быть выполнена в текущем состоянии.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        /// <returns>True, если команда может быть выполнена; иначе false.</returns>
        public virtual bool CanExecute(object parameter)
            => true;

        /// <summary>
        /// Метод, который выполняет действие, связанное с командой.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        public abstract void Execute(object parameter);
    }
}