using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HackathonXAMLApp
{
    public class User : INotifyPropertyChanged
    {

		public event PropertyChangedEventHandler PropertyChanged;

		#region Properties
		private string _barcode;
		public string Barcode
		{
			get
			{
				return _barcode;
			}
			set
			{
				_barcode = value;
				OnPropertyChanged(nameof(Barcode));
			}
		}
		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
                _name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
		private string _allergies;
		public string Allergies
		{
			get
			{
				return _allergies;
			}
			set
			{
				_allergies = value;
				OnPropertyChanged(nameof(Allergies));
			}
		}
		private bool _vegan;
		public bool Vegan
		{
			get
			{
				return _vegan;
			}
			set
			{
				_vegan = value;
				OnPropertyChanged(nameof(Vegan));
			}
		}
		private bool _vegetarian;
		public bool Vegetarian
		{
			get
			{
				return _vegetarian;
			}
			set
			{
				_vegetarian = value;
				OnPropertyChanged(nameof(Vegetarian));
			}
		}
		private bool _glutenFree;
		public bool GlutenFree
		{
			get
			{
				return _glutenFree;
			}
			set
			{
				_glutenFree = value;
				OnPropertyChanged(nameof(GlutenFree));
			}
		}
		private bool _dairyFree;
		public bool DairyFree
		{
			get
			{
				return _dairyFree;
			}
			set
			{
				_dairyFree = value;
				OnPropertyChanged(nameof(DairyFree));
			}
		}
		private bool _crohns;
		public bool Crohns
		{
			get
			{
				return _crohns;
			}
			set
			{
				_crohns = value;
				OnPropertyChanged(nameof(Crohns));
			}
		}
		private bool _keto;
		public bool Keto
		{
			get
			{
				return _keto;
			}
			set
			{
				_keto = value;
				OnPropertyChanged(nameof(Keto));
			}
		}
		#endregion
		protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
