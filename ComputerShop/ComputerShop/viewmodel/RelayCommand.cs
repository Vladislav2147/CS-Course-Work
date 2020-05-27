﻿using System;
using System.Windows.Input;

namespace ComputerShop.viewmodel
{
	public class RelayCommand : ICommand
	{

		readonly Action<object> _execute;
		readonly Predicate<object> _canExecute;

		public RelayCommand(Action<object> execute) : this(execute, null) { }
		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException("execute"); 
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
		public void Execute(object parameter) { _execute(parameter); }

	}
}
