#region Using namespaces

using System.Collections.Generic;
using RSPO_UP_3.Models.EntityFramework.Models;
using RSPO_UP_3.Services;
using RSPO_UP_3.ViewModel.Base;

#endregion

namespace RSPO_UP_3.ViewModel
{
	internal class TeacherWindowViewModel : ViewModelBase
	{
		public TeacherWindowViewModel()
		{
			Entrances = UsersProvider.GetEntrancesList();
			HidePasswords();
		}

		public List<Entrance> Entrances { get; }

		private void HidePasswords()
		{
			for (var i = 0; i < Entrances.Count; i++)
				Entrances[i].User.Password = new string('*', Entrances[i].User.Password.Length);
		}
	}
}