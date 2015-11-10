﻿using DryIoc;
using SummitLog.UI.NameInput;

namespace SummitLog.UI.NameAndScoreInput.ViewCommands
{
    public class NameAndScoreInputViewCommand
    {
        /// <summary>
        /// Liefert oder setzt den eingegebenen Namen
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Liefert oder setzt die eingegebene Punktezahl
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Führt das View Command aus
        /// </summary>
        /// <returns></returns>
        public void Execute()
        {
            Name = string.Empty;
            Score = 0;
            NameInputView view = AppContext.Container.Resolve<NameInputView>();
            INameAndScoreInputViewModel vm = AppContext.Container.Resolve<INameAndScoreInputViewModel>();
            view.DataContext = vm;

            vm.RequestCloseAfterCancel += delegate { view.Close(); };
            vm.RequestCloseAfterOk += delegate
            {
                view.Close();
                Name = vm.Name;
                Score = vm.Score;
            };
            view.ShowDialog();
        }
    }
}