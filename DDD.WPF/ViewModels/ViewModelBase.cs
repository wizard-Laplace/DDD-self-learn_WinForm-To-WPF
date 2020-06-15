using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WPF.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
