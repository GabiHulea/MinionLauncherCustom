using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.CustomEventArgs;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Interfaces.Objects;

namespace MinionLauncherGUI.CustomControls
{
    internal class AccountControl
    {
        private readonly Account _account;
        //private readonly MetroStyleManager _formStyleManager;

        internal MetroButton BtnKill = new MetroButton();
        internal MetroButton BtnManage = new MetroButton();
        internal MetroButton BtnSetDirectory = new MetroButton();
        internal MetroButton BtnSettings = new MetroButton();
        internal MetroButton BtnStart = new MetroButton();
        internal MetroButton BtnResetTime = new MetroButton();
        internal MetroComboBox CmbSettings = new MetroComboBox();
        internal MetroLabel LblAccountName = new MetroLabel();
        internal MetroLabel LblStatus = new MetroLabel();

        internal AccountControl(MetroTabControl tabControl, int totalCount, int activeCount, int newSet,
            MetroStyleManager styleManager, Account account)
        {
            _account = account;
            FixControls(newSet, styleManager, account);
            AddControlsToForm(tabControl, styleManager, activeCount, newSet);
            ID = totalCount;
            BindEvents();
        }

        internal int ID { get; set; }


        internal string LoginName
        {
            get { return LblAccountName.Text; }
            set { LblAccountName.Text = value; }
        }

        internal string Status
        {
            get { return LblStatus.Text; }
            set { LblStatus.Text = value; }
        }

        private void BindEvents()
        {
            BtnStart.Click += OnStartClick;
            BtnKill.Click += OnKillClick;
            BtnManage.Click += OnManageClick;
            BtnSettings.Click += OnSettingsClick;
            BtnResetTime.Click += OnResetClick;
        }

        private void AddControlsToForm(MetroTabControl tabControl, MetroStyleManager styleManager, int activeCount,
            int newSet)
        {
            TabPage page = tabControl.TabPages[tabControl.TabPages.Count - 1];
            var newPage = new MetroTabPage
            {
                BackColor = Color.Transparent,
                Text = string.Format("{0}-{1}", activeCount + 2, activeCount + 11),
            };
            if (newSet == 10 && tabControl.TabPages.Count < 10)
                tabControl.TabPages.Add(newPage);
            newPage.Controls.Add(new MetroLabel
            {
                FontWeight = MetroFontWeight.Bold,
                Text = LanguageManager.Singleton.GetTranslation(ETranslations.AccountControlLoginName),
                Theme = styleManager.Theme,
                Style = styleManager.Style,
                Location = new Point(3, 10),
                BackColor = Color.Transparent,
            });
            newPage.Controls.Add(new MetroLabel
            {
                FontWeight = MetroFontWeight.Bold,
                Text = LanguageManager.Singleton.GetTranslation(ETranslations.AccountControlStatus),
                Theme = styleManager.Theme,
                Style = styleManager.Style,
                Location = new Point(490, 10),
                BackColor = Color.Transparent,
            });

            page.Controls.Add(LblAccountName);
            page.Controls.Add(BtnStart);
            page.Controls.Add(BtnKill);
            page.Controls.Add(BtnManage);
            page.Controls.Add(LblStatus);
            page.Controls.Add(CmbSettings);
            page.Controls.Add(BtnSettings);
            page.Controls.Add(BtnResetTime);
        }

        private void FixControls(int newSet, MetroStyleManager styleManager, Account account)
        {
            LblAccountName.Theme = styleManager.Theme;
            LblAccountName.Style = styleManager.Style;
            LblAccountName.Text = account.LoginName;
            LblAccountName.Width = 280;
            LblAccountName.BackColor = Color.Transparent;
            BtnStart.Theme = styleManager.Theme;
            BtnStart.Style = styleManager.Style;
            BtnStart.Text = LanguageManager.Singleton.GetTranslation(ETranslations.AccountControlStart);
            BtnKill.Theme = styleManager.Theme;
            BtnKill.Style = styleManager.Style;
            BtnKill.Text = LanguageManager.Singleton.GetTranslation(ETranslations.AccountControlStop);
            BtnManage.Theme = styleManager.Theme;
            BtnManage.Style = styleManager.Style;
            BtnManage.Text = LanguageManager.Singleton.GetTranslation(ETranslations.AccountControlManage);
            BtnSettings.Theme = styleManager.Theme;
            BtnSettings.Style = styleManager.Style;
            BtnSettings.Text = LanguageManager.Singleton.GetTranslation(ETranslations.AccountControlSettings);
            BtnResetTime.Theme = styleManager.Theme;
            BtnResetTime.Style = styleManager.Style;
            BtnResetTime.Text = "Reset Delay";
            LblStatus.Theme = styleManager.Theme;
            LblStatus.Style = styleManager.Style;
            LblStatus.Text =
                LanguageManager.Singleton.GetTranslation(account.ShouldBeRunning
                    ? ETranslations.AccountControlEnabled
                    : ETranslations.AccountControlDisabled);
            LblStatus.BackColor = Color.Transparent;
            CmbSettings.Theme = styleManager.Theme;
            CmbSettings.Style = styleManager.Style;
            int heightPosition = (newSet)*40;
            LblAccountName.Location = new Point(3, heightPosition + 3);
            BtnStart.Width = 53;
            BtnStart.Height = 23;
            BtnKill.Width = 46;
            BtnKill.Height = 23;
            BtnResetTime.Height = 23;
            BtnSettings.Width = 75;
            BtnSettings.Height = 23;
            CmbSettings.Width = 153;
            CmbSettings.Height = 29;
            LblStatus.Width = 70;
            BtnStart.Location = new Point(290, heightPosition);
            BtnKill.Location = new Point(349, heightPosition);
            BtnManage.Location = new Point(402, heightPosition);
            LblStatus.Location = new Point(490, heightPosition);
            BtnResetTime.Location = new Point(563, heightPosition);
            CmbSettings.Location = new Point(650, heightPosition - 3);
            BtnSettings.Location = new Point(817, heightPosition);
            BtnSettings.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            CmbSettings.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
        }

        internal event ReloggerHandler StartClick;
        internal event ReloggerHandler KillClick;
        internal event ReloggerHandler ManageClick;
        internal event ReloggerHandler SettingsClick;
        internal event ReloggerHandler ResetTimeClick;

        private void OnManageClick(object sender, EventArgs eventArgs)
        {
            if (ManageClick != null)
                ManageClick(this, new ReloggerEventArgs(this, _account, ERelogEventArgsType.OnManage));
        }

        private void OnSettingsClick(object sender, EventArgs eventArgs)
        {
            if (SettingsClick != null)
                SettingsClick(this, new ReloggerEventArgs(this, _account, ERelogEventArgsType.OnSettings));
        }

        private void OnKillClick(object sender, EventArgs eventArgs)
        {
            if (KillClick != null)
                KillClick(this, new ReloggerEventArgs(this, _account, ERelogEventArgsType.OnKill));
        }

        private void OnStartClick(object sender, EventArgs eventArgs)
        {
            if (StartClick != null)
                StartClick(this, new ReloggerEventArgs(this, _account, ERelogEventArgsType.OnStart));
        }

        private void OnResetClick(object sender, EventArgs e)
        {
            if (ResetTimeClick != null)
                ResetTimeClick(this, new ReloggerEventArgs(this, _account, ERelogEventArgsType.OnResetTime));
        }
    }
}