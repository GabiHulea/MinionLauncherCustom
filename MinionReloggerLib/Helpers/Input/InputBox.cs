/*****************************************************************************
*                                                                            *
*  MinionReloggerLib 0.x Beta  -- https://github.com/Vipeax/MinionRelogger   *
*  Copyright (C) 2013, Robert van den Boorn                                  *
*                                                                            *
*  This program is free software: you can redistribute it and/or modify      *
*   it under the terms of the GNU General Public License as published by     *
*   the Free Software Foundation, either version 3 of the License, or        *
*   (at your option) any later version.                                      *
*                                                                            *
*   This program is distributed in the hope that it will be useful,          *
*   but WITHOUT ANY WARRANTY; without even the implied warranty of           *
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the            *
*   GNU General Public License for more details.                             *
*                                                                            *
*   You should have received a copy of the GNU General Public License        *
*   along with this program.  If not, see <http://www.gnu.org/licenses/>.    *
*                                                                            *
******************************************************************************/

/*****************************************************************************
*                                                                            *
*   Copyright (C) 2008, Jan Slama                                            *
*   source: http://www.csharp-examples.net/inputbox/                         *
*                                                                            *
******************************************************************************/

using System;
using System.Drawing;
using System.Windows.Forms;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;

namespace MinionReloggerLib.Helpers.Input
{
    public static class InputBox
    {
        public static DialogResult ShowInputBox(string title, string promptText, ref string value)
        {
            Label label;
            TextBox textBox;
            Button buttonOk;
            Button buttonCancel;
            Form form = CreateControls(out label, out textBox, out buttonOk, out buttonCancel);

            SetTextValues(title, promptText, value, form, label, textBox, buttonOk, buttonCancel);
            SetDialogResults(buttonOk, buttonCancel);

            FixControlSizes(label, textBox, buttonOk, buttonCancel);

            FixLocationOfControls(label, textBox, buttonOk, buttonCancel);

            FixFormFields(form, label, textBox, buttonOk, buttonCancel);

            DialogResult dialogResult = Execute(form);
            value = textBox.Text;
            return dialogResult;
        }

        private static DialogResult Execute(Form form)
        {
            DialogResult dialogResult = form.ShowDialog();
            form.BringToFront();
            return dialogResult;
        }

        private static void FixFormFields(Form form, Label label, TextBox textBox, Button buttonOk, Button buttonCancel)
        {
            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] {label, textBox, buttonOk, buttonCancel});
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            form.BringToFront();
        }

        private static void FixLocationOfControls(Label label, TextBox textBox, Button buttonOk, Button buttonCancel)
        {
            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private static void FixControlSizes(Label label, TextBox textBox, Button buttonOk, Button buttonCancel)
        {
            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);
        }

        private static void SetDialogResults(Button buttonOk, Button buttonCancel)
        {
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
        }

        private static void SetTextValues(string title, string promptText, string value, Form form, Label label,
            TextBox textBox,
            Button buttonOk, Button buttonCancel)
        {
            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = LanguageManager.Singleton.GetTranslation(ETranslations.InputBoxOk);
            buttonCancel.Text = LanguageManager.Singleton.GetTranslation(ETranslations.InputBoxCancel);
            ;
        }

        private static Form CreateControls(out Label label, out TextBox textBox, out Button buttonOk,
            out Button buttonCancel)
        {
            var form = new Form();
            label = new Label();
            textBox = new TextBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            return form;
        }
    }
}