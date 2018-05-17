using Lands.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Infrastructure
{
    public class InstanceLocator
    {
        #region Properties

        public MainViewModel Main { get; set; }

        #endregion

        #region Constructor

        public InstanceLocator() => Main = new MainViewModel();

        #endregion
    }
}
