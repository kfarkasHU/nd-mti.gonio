using System.Windows.Forms;
using System.Collections.Generic;

namespace ND.MTI.Gonio.Forms.UIConfig
{
    public class UIConfigProvider
    {
        public UIConfigCollection OnFormShownConfig { get; private set; }

        public UIConfigProvider()
        {
            OnFormShownConfig = new UIConfigCollection();
        }
    }

    public class UIConfigCollection : List<UIConfigItem>
    {
        public void AddEnabled(string controlName) => this.Add(UIConfigItem.EnabledItem(controlName));
        public void AddDisabled(string controlName) => this.Add(UIConfigItem.DisabledItem(controlName));
    }

    public class UIConfigItem
    {
        public static UIConfigItem EnabledItem(string controlName) => new UIConfigItem(controlName, true, Cursors.Hand);
        public static UIConfigItem DisabledItem(string controlName) => new UIConfigItem(controlName, false, Cursors.No);

        private UIConfigItem(string controlName, bool enabled, Cursor cursor)
        {
            ControlName = controlName;
            Enabled = enabled;
            Cursor = cursor;
        }

        public string ControlName { get; private set; }
        public bool Enabled { get; private set; }
        public Cursor Cursor { get; private set; }
    }
}
