using System.ComponentModel;

namespace ComputerShop.model.kindofmagic
{
	[Magic]
	public abstract class PropertyChangedBase : INotifyPropertyChanged
	{
		protected virtual void RaisePropertyChanged(string propName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
