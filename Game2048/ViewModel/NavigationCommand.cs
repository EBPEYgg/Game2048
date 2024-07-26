using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game2048.ViewModel
{
    /// <summary>
    /// Класс, описывающий команду для навигации в игре.
    /// </summary>
    public class NavigationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Действие, которое должно быть выполнено при выполнении команды.
        /// </summary>
        private readonly Action<Page, Uri> _executeAction;

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        /// Создает экземпляр класса <see cref="MyCommand"/> 
        /// с указанным действием для выполнения.
        /// </summary>
        /// <param name="executeAction">Действие, которое должно быть 
        /// выполнено при выполнении команды.</param>
        public NavigationCommand(Action<Page, Uri> executeAction, Uri uri)
        {
            _executeAction = executeAction;
            _uri = uri;
        }

        /// <summary>
        /// Метод, который выполняет действие, связанное с командой.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        public void Execute(object parameter)
            => _executeAction.Invoke((Page) parameter, _uri);

        /// <summary>
        /// Метод, который определяет, может ли 
        /// команда быть выполнена в текущем состоянии.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        /// <returns>True, если команда может быть выполнена; иначе false.</returns>
        public bool CanExecute(object parameter)
            => true;
    }
}