using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingToInvalidObject.ViewModels
{
	public class PersonViewModel : INotifyPropertyChanged
	{

		private bool _isDeleted = false;

		public bool IsDeleted { get { return _isDeleted; } }

		public void Delete()
		{
			if (!IsDeleted)
			{
				_isDeleted = true;
			}
			else
				throw new InvalidOperationException("Object is already deleted!");

		}

		public bool HasName
		{
			get
			{
				if (!IsDeleted)
				{
					return !string.IsNullOrWhiteSpace(_firstName);
				}
				else
					throw new InvalidOperationException("Object is deleted!");
			}

		}

		private string _firstName = string.Empty;

		public string FirstName
		{
			get
			{
				if (!IsDeleted)
					return _firstName;
				else
					throw new InvalidOperationException("Object is deleted!");
			}
			set
			{
				if (!IsDeleted)
				{
					if (_firstName != value)
					{
						_firstName = value;
						OnPropertyChanged();
						OnPropertyChanged(nameof(HasName));
					}
				}
				else
					throw new InvalidOperationException("Object is deleted!");
			}
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				// Raise the PropertyChanged event, passing the name of the property whose value has changed.
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate { };
	}
}
