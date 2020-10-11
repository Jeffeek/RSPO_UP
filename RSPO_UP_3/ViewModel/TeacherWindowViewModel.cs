using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_3.Models.EntityFramework.Models;
using RSPO_UP_3.Services;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    class TeacherWindowViewModel : ViewModelBase
    {
        public List<Entrance> Entrances { get; }

        public TeacherWindowViewModel()
        {
            Entrances = UsersProvider.GetEntrancesList();
            HidePasswords();
        }

        private void HidePasswords()
        {
            for (int i = 0; i < Entrances.Count; i++)
                Entrances[i].User.Password = new string('*', Entrances[i].User.Password.Length);
        }
    }
}
