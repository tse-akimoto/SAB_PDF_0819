using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace SettingForm
{
    public partial class DisplayForm : Form
    {
        #region <内部変数>

        /// <summary>
        /// 機密区分
        /// </summary>
        public string strSecrecyLevel;

        /// <summary>
        /// 事業所コード
        /// </summary>
        public string strOfficeCode;

        #endregion

        #region <コンストラクタ>
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DisplayForm(string strCulture)
        {
            InitializeComponent();

            // 言語設定読込み
            CultureInfo culture = CultureInfo.GetCultureInfo(strCulture);
            Thread.CurrentThread.CurrentUICulture = culture;
        }
        #endregion

        #region <フォームイベント>
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayForm_Load(object sender, EventArgs e)
        {
            // 機密区分表示設定
            labelSecrecyLevel.Text = strSecrecyLevel;
        }
        #endregion
    }
}
