﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tibialyzer {
    public class BaseHUD : Form {
        public virtual string GetHUD() { return ""; }
        public virtual void LoadHUD() { }

        protected bool alwaysShow = false;

        static int WS_EX_NOACTIVATE = 0x08000000;
        static int WS_EX_TOOLWINDOW = 0x00000080;
        static int WS_EX_COMPOSITED = 0x02000000;

        public BaseHUD() {
            this.ShowInTaskbar = Constants.OBSEnableWindowCapture;
            this.alwaysShow = SettingsManager.getSettingBool("AlwaysShowHUD");
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams baseParams = base.CreateParams;

                baseParams.ExStyle |= (int)(WS_EX_NOACTIVATE | WS_EX_COMPOSITED);
                if (!Constants.OBSEnableWindowCapture) {
                    baseParams.ExStyle |= WS_EX_TOOLWINDOW;
                }

                return baseParams;
            }
        }
    }
}
