using System;
using System.Collections.Generic;
using CodeBase.UI.Services;
using CodeBase.UI.Services.Windows;

namespace CodeBase.Infrastructure.Data.PlayerData
{
    [Serializable]
    public class TutorialData
    {
        public List<WindowType> TutorialsPassed = new List<WindowType>();
    }
}