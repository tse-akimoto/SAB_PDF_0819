using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SettingForm
{
    public partial class PDFPreview : Form
    {
        #region <定数定義>

        /// <summary>
        /// CSVファイル内の項目数
        /// </summary>
        public const int FORM_HEIGHT = 700;

        /// <summary>
        /// 複数キーワード最大数
        /// </summary>
        public const int FORM_WIDTH = 950;
        #endregion

        #region <内部変数>

        /// <summary>
        /// プレビュー用PDFファイルパス
        /// </summary>
        public string strPdfPath;
        #endregion

        #region <フォームイベント>
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PDFPreview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PDFPreview_Load(object sender, EventArgs e)
        {
            // フォームサイズ変更
            this.Height = FORM_HEIGHT;
            this.Width = FORM_WIDTH;

            // ファイル読み込み
            axAcroPDFPreview.LoadFile(strPdfPath);

            // 100%表示設定
            axAcroPDFPreview.setZoom(100);

        }

        /// <summary>
        /// フォームクローズ時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PDFPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            // リソースの破棄
            axAcroPDFPreview.Dispose();

            // 作成したPDFを削除する
            if (System.IO.File.Exists(strPdfPath))
            {
                try
                {
                    System.IO.File.Delete(strPdfPath);
                }
                catch
                {
                    MessageBox.Show(SABPdf.Properties.Resources.msgPreviewDeleteError, SABPdf.Properties.Resources.msgConfirmation, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            } 
        }
        #endregion
    }
}
