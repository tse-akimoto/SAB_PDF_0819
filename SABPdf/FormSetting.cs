
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Microsoft.Win32;
using System.Reflection;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using SABPdf.Properties;
using System.Globalization;
using System.Threading;
using SABPdf;

namespace SettingForm
{
    public partial class FormSettings : Form
    {
        #region <定数定義>

        // ファイルプロパティ関連

        /// <summary>
        /// プロパティに書き込むSAB秘 S秘
        /// </summary>
        public const string SECRECY_PROPERTY_S = "SecrecyS";

        /// <summary>
        /// プロパティに書き込むSAB秘 A秘
        /// </summary>
        public const string SECRECY_PROPERTY_A = "SecrecyA";

        /// <summary>
        /// プロパティに書き込むSAB秘 B秘
        /// </summary>
        public const string SECRECY_PROPERTY_B = "SecrecyB";

        /// <summary>
        /// プロパティに書き込むSAB秘 NONE
        /// </summary>
        public const string SECRECY_PROPERTY_NONE = "SecrecyNone";

        /// <summary>
        /// スタンプのファイル名 SAB秘 S秘
        /// </summary>
        public const string SECRECY_FILENAME_S = "Secrecy_S";

        /// <summary>
        /// スタンプのファイル名 SAB秘 A秘
        /// </summary>
        public const string SECRECY_FILENAME_A = "Secrecy_A";

        /// <summary>
        /// スタンプのファイル名 SAB秘 B秘
        /// </summary>
        public const string SECRECY_FILENAME_B = "Secrecy_B";            // スタンプのファイル名 SAB秘 B秘

        // 共通設定関連

        /// <summary>
        /// 共通設定格納フォルダ名
        /// </summary>
        public const string COMMON_SETFOLDERNAME = "SAB";

        /// <summary>
        /// ファイル名
        /// </summary>
        public const string COMMON_SETFILENAME = "common_setting.config";

        /// <summary>
        /// 共通設定事業所コード
        /// </summary>
        public const string COMMON_SETDEF_OFFICECODE = "HLI";

        /// <summary>
        /// デフォルト秘密区分
        /// </summary>
        public const string COMMON_SETDEF_SECLV = SECRECY_PROPERTY_S;

        // ユーザー設定関連

        /// <summary>
        /// ユーザー設定格納フォルダ名
        /// </summary>
        public const string USER_SETFOLDERNAME = "SAB";

        /// <summary>
        /// ユーザー設定ファイル名
        /// </summary>
        public const string USER_SETFILENAME = "user_setting.config";

        // スタンプ関連

        /// <summary>
        /// スタンプ倍率
        /// </summary>
        public const float STAMP_MAGNIFICATION = 1.3331f;

        /// <summary>
        /// スタンプ透過最大
        /// </summary>
        public const int STAMP_OPACITY_MAX = 95;

        /// <summary>
        /// スタンプ透過最小
        /// </summary>
        public const int STAMP_OPACITY_MIN = 0;

        /// <summary>
        /// スタンプ範囲テキスト
        /// </summary>
        public const string STAMP_OPACITY_TEXT = "%　（{0:D}～{1:D}）";

        /// <summary>
        /// スタンプ貼り付けない
        /// </summary>
        public const int STAMP_OVERWRITE_NO = 0;

        /// <summary>
        /// スタンプ貼り付ける
        /// </summary>
        public const int STAMP_OVERWRITE_YES = 1;

        /// <summary>
        /// スタンプサイズ大
        /// </summary>
        public const int STAMP_SIZE_LARGE = 0;

        /// <summary>
        /// スタンプサイズ中
        /// </summary>
        public const int STAMP_SIZE_MIDDLE = 1;

        /// <summary>
        /// スタンプサイズ小
        /// </summary>
        public const int STAMP_SIZE_SMALL = 2;

        /// <summary>
        /// スタンプサイズ値大
        /// </summary>
        public const float STAMP_SIZE_LARGE_VALUE = 1.5f;

        /// <summary>
        /// スタンプサイズ値中
        /// </summary>
        public const float STAMP_SIZE_MIDDLE_VALUE = 1.0f;

        /// <summary>
        /// スタンプサイズ値小
        /// </summary>
        public const float STAMP_SIZE_SMALL_VALUE = 0.5f;

        /// <summary>
        /// スタンプ位置:左上
        /// </summary>
        public const int STAMP_POSITION_UPPER_LEFT = 0;

        /// <summary>
        /// スタンプ位置:右上
        /// </summary>
        public const int STAMP_POSITION_UPPER_RIGHT = 1;

        /// <summary>
        /// スタンプ位置:左下
        /// </summary>
        public const int STAMP_POSITION_UNDER_LEFT = 2;

        /// <summary>
        /// スタンプ位置:右下
        /// </summary>
        public const int STAMP_POSITION_UNDER_RIGHT = 3;

        /// <summary>
        /// スタンプ名
        /// </summary>
        public const string STAMP_TEMP_FILENAME = "PDF_ADDINS_STAMP_TMP.PNG";

        /// <summary>
        /// スタンプ画像拡張子
        /// </summary>
        public const string STAMP_EXTENSION = ".gif";

        // プロパティ関連

        /// <summary>
        /// ファイル名位置
        /// </summary>
        public const int FILENAME_COUNT = 0;

        // PDFユーザー設定関連

        /// <summary>
        /// PDFユーザー設定ファイル名
        /// </summary>
        public const string USER_SETFILENAME_PDF = "user_setting_PDF.config";

        /// <summary>
        /// 機密スタンプ上書きオプション
        /// </summary>
        public const int USER_SETDEF_OVERWRITE = STAMP_OVERWRITE_YES;

        /// <summary>
        /// 機密スタンプの場所
        /// </summary>
        public const int USER_SETDEF_LOCATION = STAMP_SIZE_LARGE;

        /// <summary>
        /// スタンプの大きさ
        /// </summary>
        public const int USER_SETDEF_SIZE = STAMP_SIZE_LARGE;

        /// <summary>
        /// スタンプの透かし度
        /// </summary>
        public const int USER_SETDEF_WATERMARK = 50;

        // プレビュー関連

        /// <summary>
        /// プレビューファイル名
        /// </summary>
        public const string PREVIEW_FILENAME = "_Preview.pdf";

        // 書き込み関連

        /// <summary>
        /// 書き込み一時ファイル名
        /// </summary>
        public const string WRITE_FILENAME = "_Rename.pdf";

        /// <summary>
        /// スタンプ登録ファイル名
        /// </summary>
        public const string STAMP_FILENAME = "_stamp.pdf";


        /// <summary>
        /// 機密区分
        /// </summary>
        public enum Secrecy
        {
            S,
            A,
            B,
            None
        }


        /// <summary>
        /// 形式
        /// </summary>
        [Flags]
        private enum AssocF
        {
            None = 0,
            Init_NoRemapCLSID = 0x1,
            Init_ByExeName = 0x2,
            Open_ByExeName = 0x2,
            Init_DefaultToStar = 0x4,
            Init_DefaultToFolder = 0x8,
            NoUserSettings = 0x10,
            NoTruncate = 0x20,
            Verify = 0x40,
            RemapRunDll = 0x80,
            NoFixUps = 0x100,
            IgnoreBaseClass = 0x200,
            Init_IgnoreUnknown = 0x400,
            Init_FixedProgId = 0x800,
            IsProtocol = 0x1000,
            InitForFile = 0x2000,
        }


        /// <summary>
        /// 種別
        /// </summary>
        private enum AssocStr
        {
            Command = 1,
            Executable,
            FriendlyDocName,
            FriendlyAppName,
            NoOpen,
            ShellNewValue,
            DDECommand,
            DDEIfExec,
            DDEApplication,
            DDETopic,
            InfoTip,
            QuickTip,
            TileInfo,
            ContentType,
            DefaultIcon,
            ShellExtension,
            DropTarget,
            DelegateExecute,
            SupportedUriProtocols,
            Max,
        }


        /// <summary>
        /// 保存位置
        /// </summary>
        private enum SaveExec
        {
            Not = 0,
            Sa,
            Bnone
        }

        #endregion


        #region <内部変数>

        /// <summary>
        /// 共通設定クラス
        /// </summary>
        public CommonSettings clsCommonSettting;

        /// <summary>
        /// ユーザー設定クラス
        /// </summary>
        private UserSettingsPdf clsUserSettingPdf;

        /// <summary>
        /// 処理対象ファイルパス
        /// </summary>
        static public string strTargetFilePath;

        /// <summary>
        /// ファイル情報
        /// </summary>
        static public DateTime LastWriteTime;

        /// <summary>
        /// プレビュー画面クラス
        /// </summary>
        public PDFPreview frmPre;

        /// <summary>
        /// プレビュープロセス(PDFの関連付けが別アプリの場合に使用)
        /// </summary>
        public Process pPreview;

        /// <summary>
        /// 初期化エラーフラグ
        /// </summary>
        public Boolean bInitErrorFlg;

        /// <summary>
        /// ファイルプロパティ情報 機密区分
        /// </summary>
        public string strFilePropertySecrecyLevel;

        /// <summary>
        /// テンポラリファイルリスト
        /// </summary>
        private List<string> tempFileList = new List<string>();

        /// <summary>
        /// 共通設定ファイルに不足項目がないかチェック
        /// </summary>
        bool CommonSetttingFlg = true;

        /// <summary>
        /// 共通設定ファイルで不足している項目を表示するメッセージ
        /// </summary>
        string CommonSetttingMessage = null;

        #endregion


        #region <コンストラクタ>

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormSettings()
        {
            // 初期化エラーフラグOFF
            bInitErrorFlg = false;

            // 共通設定エラー時処理
            if (CommonSettingRead() == false)
            {
                MessageBox.Show(Resources.msgFailedReadCommonFile, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);

                // 初期化エラーフラグON
                bInitErrorFlg = true;
                return;
            }

            if (clsCommonSettting == null)
            {
                CommonSetttingFlg = false;
                CommonSetttingMessage += Resources.msgCommonSettingNothing + Environment.NewLine;
            }
            else
            {
                CommonSetttingMessage = Resources.msgCommonSettingError + Environment.NewLine;
                // 共通設定ファイルに不足項目がないかチェック
                if (string.IsNullOrEmpty(clsCommonSettting.strDefaultSecrecyLevel))   // デフォルト機密区分
                {
                    CommonSetttingFlg = false;
                    CommonSetttingMessage += Resources.msgDefaultSecure + Environment.NewLine;
                }
                if (string.IsNullOrEmpty(clsCommonSettting.strOfficeCode))   // 事業所コード
                {
                    CommonSetttingFlg = false;
                    CommonSetttingMessage += Resources.msgOfficeCode + Environment.NewLine;
                }
                if (string.IsNullOrEmpty(clsCommonSettting.strCulture))   // 言語設定
                {
                    CommonSetttingFlg = false;
                    CommonSetttingMessage += Resources.msgSettingLanguage + Environment.NewLine;
                }
                if (string.IsNullOrEmpty(clsCommonSettting.strSABListLocalPath))   // 文書のローカルパス
                {
                    CommonSetttingFlg = false;
                    CommonSetttingMessage += Resources.msgLocalPath + Environment.NewLine;
                }
                if (string.IsNullOrEmpty(clsCommonSettting.strSABListServerPath))   // 文書のサーバーパス
                {
                    CommonSetttingFlg = false;
                    CommonSetttingMessage += Resources.msgServerPath + Environment.NewLine;
                }
                if (string.IsNullOrEmpty(clsCommonSettting.strTempPath))   // zip一時解凍先
                {
                    CommonSetttingFlg = false;
                    CommonSetttingMessage += Resources.msgTempZipPath + Environment.NewLine;
                }
                if (clsCommonSettting.lstSecureFolder.Count == 0)   // 保存可能フォルダリスト
                {
                    CommonSetttingFlg = false;
                    CommonSetttingMessage += Resources.msgFolderList + Environment.NewLine;
                }
                if (clsCommonSettting.lstFinal.Count == 0)   // 「最終版」を表す文字列
                {
                    CommonSetttingFlg = false;
                    CommonSetttingMessage += Resources.msgFinal + Environment.NewLine;
                }
            }

            if (!CommonSetttingFlg)
            {
                // 共通設定ファイルに不足項目あり
                MessageBox.Show(CommonSetttingMessage,
                    Resources.msgError,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);

                // 強制終了
                Environment.Exit(0x8020);
            }

            // 言語設定読込み
            CultureInfo culture = CultureInfo.GetCultureInfo(clsCommonSettting.strCulture);
            Thread.CurrentThread.CurrentUICulture = culture;

            // ユーザー設定読み込み
            clsUserSettingPdf = new UserSettingsPdf();

            if (UserSetting_PDFRead() == false)
            {
                MessageBox.Show(Resources.msgFailedReadPDF, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            // 各コンポーネント初期化
            InitializeComponent();
        }
        #endregion


        #region <フォームイベント>
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
#if DEBUG
            // テストを行う時にはこの時点でプロセスにアタッチする
            MessageBox.Show("デバッグ版");
#endif

            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            if (!args.Any())
            {
                MessageBox.Show(Resources.msgNotPDFPath, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            FormSettings frmSet = new FormSettings();
            DisplayForm frmDisp = new DisplayForm(frmSet.clsCommonSettting.strCulture);

            // step2
            // 最新の機密文書一覧表を取得
            frmSet.UpdateDocument();

            // 設定画面初期化にてエラーの場合は抜ける
            if (frmSet.bInitErrorFlg == true)
            {
                return;
            }

            try
            {
                // ファイル名取得
                strTargetFilePath = args[FILENAME_COUNT];

                // ファイル情報読み取り
                LastWriteTime = System.IO.File.GetLastWriteTime(strTargetFilePath);

                // PDFの情報取得
                PdfReader reader = new PdfReader(strTargetFilePath);

                // プロパティ情報をリスト化
                List<string> name = new List<string>(reader.Info.Keys);
                List<string> val = new List<string>(reader.Info.Values);

                // KeyWordsのインデックスを取得
                int Property_Count = name.IndexOf("Keywords");

                // PDFを閉じる
                reader.Close();


                // 取得したPDFにタグ情報が存在しない場合
                if (!name.Contains("Keywords"))
                {
                    // 設定画面表示
                    frmSet.ShowDialog();

                    return;
                }

                // プロパティ読み込み
                string strBuf = val[Property_Count];
                string[] stBuf = strBuf.Split(';');

                // タグ情報が存在するかつ4項目の場合(空欄含む)
                if (stBuf.Count() == 4)
                {
                    string strClassNo = stBuf[0].Trim();
                    string tProperty = stBuf[1].Trim();

                    // 事業所コード取得
                    string strOfficeCode = (stBuf.Count() >= 3) ? stBuf[2].Trim() : frmSet.clsCommonSettting.strOfficeCode;

                    // 機密区分設定
                    switch (strClassNo)
                    {
                        case FormSettings.SECRECY_PROPERTY_S:
                            frmDisp.strSecrecyLevel = Resources.TypeS;
                            break;
                        case FormSettings.SECRECY_PROPERTY_A:
                            frmDisp.strSecrecyLevel = Resources.TypeA;
                            break;
                        case FormSettings.SECRECY_PROPERTY_B:
                            frmDisp.strSecrecyLevel = Resources.TypeB;
                            break;
                        case FormSettings.SECRECY_PROPERTY_NONE:
                            frmDisp.strSecrecyLevel = Resources.TypeElse;
                            break;
                        default:
                            frmDisp.strSecrecyLevel = Resources.TypeElse;
                            break;
                    }

                    // 事業所コード
                    frmDisp.strOfficeCode = strOfficeCode;

                    // 照会画面を表示
                    if (frmDisp.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        //　修正以外の場合は終了
                        return;
                    }

                    // ファイルプロパティ情報 機密区分
                    frmSet.strFilePropertySecrecyLevel = frmDisp.strSecrecyLevel.Trim();

                    // 設定画面表示
                    frmSet.ShowDialog();
                }
                else
                {
                    // 4項目以外の場合
                    // 設定画面表示
                    frmSet.ShowDialog();

                    return;
                }
            }
            catch
            {
                // 設定ができない場合
                MessageBox.Show(Resources.msgFailedFileInformation, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingForm_Load(object sender, EventArgs e)
        {
            System.Diagnostics.FileVersionInfo ver =
            System.Diagnostics.FileVersionInfo.GetVersionInfo(
            System.Reflection.Assembly.GetExecutingAssembly().Location);

            // タイトル
            string AssemblyName = ver.FileVersion;
            this.Text = this.Text + " " + AssemblyName;


            // 一時ファイルを全て削除
            this.DeleteTempFiles();

            // プレビュープロセスクリア
            pPreview = null;

            // configファイルのSAB機密区分のテキストからSAB機密区分の列挙体を取得
            Secrecy selectedSecrecy = this.GetSecrecyEnumeration(clsCommonSettting.strDefaultSecrecyLevel);

            // 取得したSAB機密区分の列挙体から設定値を設定
            this.lblSettei.Text = this.GetSABText(selectedSecrecy);

            // 取得したSAB機密区分の列挙体からSAB機密区分のラジオボタンの選択場所を設定
            if (selectedSecrecy == Secrecy.S)
            {
                rdoS.Checked = true;
            }
            else if (selectedSecrecy == Secrecy.A)
            {
                rdoA.Checked = true;
            }
            else if (selectedSecrecy == Secrecy.B)
            {
                rdoB.Checked = true;
            }
            else
            {
                rdoElse.Checked = true;
            }

            // スタンプ上書き設定
            switch (clsUserSettingPdf.intStampOverwrite)
            {
                case STAMP_OVERWRITE_YES:
                    // 右上
                    radioButtonSubstitute.Checked = true;
                    break;
                case STAMP_OVERWRITE_NO:
                default:
                    // 上記以外は左上
                    radioButtonNotSubstitute.Checked = true;
                    break;
            }

            // スタンプの場所設定
            switch (clsUserSettingPdf.intStampLocation)
            {
                case STAMP_POSITION_UPPER_RIGHT:
                    // 右上
                    radioButtonUpperRight.Checked = true;
                    break;
                case STAMP_POSITION_UPPER_LEFT:
                default:
                    // 上記以外は左上
                    radioButtonUpperLeft.Checked = true;
                    break;
            }

            // スタンプの大きさ設定
            switch (clsUserSettingPdf.intStampSize)
            {
                case STAMP_SIZE_MIDDLE:
                    // スタンプサイズ中
                    radioButtonMiddle.Checked = true;
                    break;
                case STAMP_SIZE_SMALL:
                    // スタンプサイズ小
                    radioButtonSmall.Checked = true;
                    break;
                case STAMP_SIZE_LARGE:
                default:
                    // 上記以外はスタンプサイズ大
                    radioButtonLarge.Checked = true;
                    break;
            }

            // スタンプの透かし度設定
            if ((clsUserSettingPdf.intStampWatermark <= 100) && (0 <= clsUserSettingPdf.intStampWatermark))
            {
                txtBoxStampOpacity.Text = clsUserSettingPdf.intStampWatermark.ToString();
            }
            else
            {
                txtBoxStampOpacity.Text = USER_SETDEF_WATERMARK.ToString();
            }

            // スタンプの透かし度のパーセント表示設定
            labelPercent.Text = string.Format(STAMP_OPACITY_TEXT, STAMP_OPACITY_MIN, STAMP_OPACITY_MAX);
        }

        /// <summary>
        /// 選択したSAB区分のラジオボタンの背景色を変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSAB_CheckedChanged(object sender, EventArgs e)
        {
            // SAB区分のテキスト変更
            Secrecy selectedSecrecy = this.GetSelectedSecrecyLevel();
            this.lblSettei.Text = this.GetSABText(selectedSecrecy);

            // SAB区分ラジオボタン 背景色変更
            this.ChangeBackColor(ref this.rdoS);
            this.ChangeBackColor(ref this.rdoA);
            this.ChangeBackColor(ref this.rdoB);
            this.ChangeBackColor(ref this.rdoElse);
        }

        /// <summary>
        /// 選択した表示ラジオボタンの背景色を変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStamp_CheckedChanged(object sender, EventArgs e)
        {
            // 表示ラジオボタン 背景色変更
            this.ChangeBackColor(ref this.radioButtonSubstitute);
            this.ChangeBackColor(ref this.radioButtonNotSubstitute);
        }

        /// <summary>
        /// 選択した位置ラジオボタンの背景色を変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPosition_CheckedChanged(object sender, EventArgs e)
        {
            // 位置ラジオボタン 背景色変更
            this.ChangeBackColor(ref this.radioButtonUpperLeft);
            this.ChangeBackColor(ref this.radioButtonUpperRight);
        }

        /// <summary>
        /// 選択した大きさラジオボタンの背景色を変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSize_CheckedChanged(object sender, EventArgs e)
        {
            // 大きさラジオボタン 背景色変更
            this.ChangeBackColor(ref this.radioButtonLarge);
            this.ChangeBackColor(ref this.radioButtonMiddle);
            this.ChangeBackColor(ref this.radioButtonSmall);
        }

        /// <summary>
        /// 登録ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSecrecyLevel;                                 // 機密区分
            Boolean bStamp = true;                                  // スタンプ有無フラグ
            string strImageFilePath = "";                           // イメージファイルパス
            string strOutLocation;                                  // 新規ファイル名
            string Renamefile;                                      // ターゲットファイルパス
            SaveFileDialog sfd = new SaveFileDialog();              // 書き込みに失敗した場合の保存ダイアログ
            string strSecrecyFileName;                              // スタンプファイル名
            string strSaveFilePath = strTargetFilePath;
            // step2
            SaveExec _saveExec;
            string _refStrServerPath = "";
            _saveExec = CheckSaveDir(ref _refStrServerPath);
            if (_saveExec == SaveExec.Not) return;

            // 同名ファイルが存在する場合、メッセージダイアログを表示し保存ダイアログを表示
            if (System.IO.File.Exists(_refStrServerPath))
            {
                MessageBox.Show(Resources.msgSameFilePDF, Resources.msgConfirmation, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                SaveFileDialog refSfd = new SaveFileDialog();

                refSfd.OverwritePrompt = false;

                // 初期フォルダを指定する
                refSfd.InitialDirectory = Path.GetDirectoryName(_refStrServerPath);

                // タイトルを設定する
                refSfd.Title = Resources.msgSelectFile;

                // [ファイルの種類]に表示される選択肢を指定する
                refSfd.Filter = Resources.msgPDFfile;


                while (true)
                {
                    // 初期ファイル名を指定する
                    refSfd.FileName = System.IO.Path.GetFileNameWithoutExtension(_refStrServerPath);

                    if (refSfd.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    _refStrServerPath = refSfd.FileName;
                    if (System.IO.File.Exists(_refStrServerPath))
                    {
                        MessageBox.Show(Resources.msgSameFilePDF, Resources.msgConfirmation, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return;
                    }

                    // step2
                    if (_saveExec == SaveExec.Sa)
                    {
                        if (CheckSecurePath(_refStrServerPath) == false)
                        {
                            return;
                        }
                    }
                    break;
                }
            }

            if (_saveExec == SaveExec.Sa)
            {
                File.Copy(strTargetFilePath, _refStrServerPath);
                strSaveFilePath = _refStrServerPath;
            }

            // 機密区分スタンプの選択チェック
            if (CheckStampOption() == false) return;

            #region <入力値取得>
            // 機密区分設定
            strSecrecyLevel = this.GetSelectedSABCode();

            // スタンプ上書き設定を登録する
            int iStampOverwrite = (radioButtonNotSubstitute.Checked == true) ? STAMP_OVERWRITE_NO : STAMP_OVERWRITE_YES;

            // スタンプの場所設定を登録する
            int iStampLocation = (radioButtonUpperLeft.Checked == true) ? STAMP_POSITION_UPPER_LEFT : STAMP_POSITION_UPPER_RIGHT;

            // スタンプの大きさ設定を登録する
            int iStampSize = (radioButtonLarge.Checked == true) ? STAMP_SIZE_LARGE : (radioButtonMiddle.Checked == true) ? STAMP_SIZE_MIDDLE : STAMP_SIZE_SMALL;

            // スタンプの大きさの値を登録する
            float fStampSize = (radioButtonLarge.Checked == true) ? STAMP_SIZE_LARGE_VALUE : (radioButtonMiddle.Checked == true) ? STAMP_SIZE_MIDDLE_VALUE : STAMP_SIZE_SMALL_VALUE;

            // スタンプの透かし度設定
            int iStampOpacity = int.Parse(txtBoxStampOpacity.Text);

            // スタンプの方向
            RotateFlipType rftRotate = RotateFlipType.RotateNoneFlipNone;

            // 上書きしないが選択されている場合はスタンプを押さない（スタンプ無しの場合）
            if (radioButtonNotSubstitute.Checked == true) bStamp = false;

            #endregion

            #region <プロパティ情報チェック>
            // プロパティ情報が登録されている場合は確認ダイアログを表示する
            PdfReader reader = new PdfReader(strSaveFilePath);
            List<string> name = new List<string>(reader.Info.Keys);
            List<string> val = new List<string>(reader.Info.Values);
            int Property_Count = name.IndexOf("Keywords");

            if (name.Contains("Keywords"))
            {
                string strBuf = val[Property_Count];

                if (name.Contains("Keywords") & strBuf != "")
                {
                    if (MessageBox.Show(Resources.msgAlreadyRegistered, Resources.msgConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            reader.Close();
            #endregion

            #region <選択したスタンプのファイルパスを取得する>
            // 選択中の機密区分のファイル名を取得
            strSecrecyFileName = this.GetSelectedSTAMPFILE();

            //ファイルパスがない場合はパスをセットしない
            if (!string.IsNullOrEmpty(strSecrecyFileName))
            {
                strImageFilePath = @System.AppDomain.CurrentDomain.BaseDirectory + strSecrecyFileName;
                strImageFilePath += STAMP_EXTENSION;
            }
            #endregion

            #region <ターゲットファイルスタンプ貼付け処理>
            // スタンプ貼付け処理
            try
            {
                // 別名保管用PDF作成
                string OutputFail = System.IO.Path.GetFileNameWithoutExtension(strSaveFilePath);
                string dir = Path.GetTempPath();
                string NewFailPath = dir;
                NewFailPath += NewFailPath.EndsWith("\\") ? "" : "\\";
                NewFailPath += OutputFail;

                // 貼り付けするファイルパス作成
                Renamefile = NewFailPath + WRITE_FILENAME;
                // 別名保管用PDF作成
                strOutLocation = NewFailPath + STAMP_FILENAME;

                // スタンプ貼付け処理(但しスタンプは付与せずOfficeプロパティのみ書き込み)
                SetStamp(strSaveFilePath, Renamefile, @strImageFilePath, "", clsCommonSettting.strOfficeCode, strSecrecyLevel, false, iStampOpacity, iStampLocation, fStampSize, rftRotate);
            }
            catch
            {
                MessageBox.Show(Resources.msgFailedStampPaste, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            #endregion

            #region <ターゲットファイルファイル情報を変更する>
            System.IO.File.SetLastWriteTime(Renamefile, LastWriteTime);
            #endregion

            #region <スタンプ登録ファイルスタンプ貼付け処理>
            // 貼り付ける選択時
            if (radioButtonSubstitute.Checked == true)
            {
                bStamp = true;
                // スタンプ貼付け処理
                SetStamp(strSaveFilePath, strOutLocation, strImageFilePath, "", clsCommonSettting.strOfficeCode, strSecrecyLevel, bStamp, iStampOpacity, iStampLocation, fStampSize, rftRotate);
            }
            #endregion

            #region <ターゲットファイルコピー処理>
            string copyfile;
            string DefoltName = System.IO.Path.GetFileNameWithoutExtension(strSaveFilePath);
            DefoltName += ".pdf";
            copyfile = strSaveFilePath;

            // 初期フォルダを指定する
            sfd.InitialDirectory = System.IO.Path.GetDirectoryName(strSaveFilePath);

            // 初期ファイル名を指定する
            sfd.FileName = DefoltName;

            // タイトルを設定する
            sfd.Title = Resources.msgSelectFile;

            // [ファイルの種類]に表示される選択肢を指定する
            sfd.Filter = Resources.msgPDFfile;

            // 元のファイルにコピーする
            while (true)
            {
                Boolean bResult;
                bResult = true;

                // スタンプ登録処理
                try
                {
                    File.Copy(Renamefile, copyfile, true);
                }
                catch
                {
                    // コピーできない場合エラーを返す
                    bResult = false;
                }
                if (bResult == true) break;

                // エラーダイアログを表示する
                MessageBox.Show(Resources.msgFailedPDFwrite, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);

                // 初期フォルダを指定する
                sfd.InitialDirectory = System.IO.Path.GetDirectoryName(copyfile);

                // 初期ファイル名を指定する
                sfd.FileName = System.IO.Path.GetFileName(copyfile);

                // 保存ダイアログを表示する
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                copyfile = sfd.FileName;
            }
            #endregion

            #region <スタンプ登録ファイルコピー処理>


            // ファイルが作成できるか確認する。
            while (true)
            {
                Boolean bResult;
                bResult = true;

                // ファイルをコピー
                try
                {
                    File.Copy(strOutLocation, strSaveFilePath, true);
                }
                catch
                {
                    bResult = false;
                }

                // ファイルのコピーに成功したら処理を抜ける。
                if (bResult == true) break;

                // エラーダイアログを表示する
                MessageBox.Show(Resources.msgFailedPDFwritePaste, Resources.msgConfirmation, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // 初期フォルダを指定する
                sfd.InitialDirectory = System.IO.Path.GetDirectoryName(strSaveFilePath);

                // 初期ファイル名を指定する
                sfd.FileName = System.IO.Path.GetFileName(strSaveFilePath);

                // 保存ダイアログを表示する。
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                strSaveFilePath = sfd.FileName;
            }

            #endregion


            #region <PDF設定書き込み>
            // スタンプ上書き設定を登録する
            clsUserSettingPdf.intStampOverwrite = iStampOverwrite;

            // スタンプの場所設定を登録する
            clsUserSettingPdf.intStampLocation = iStampLocation;

            // スタンプの大きさ設定を登録する
            clsUserSettingPdf.intStampSize = iStampSize;

            // スタンプの透かし度設定を登録する
            clsUserSettingPdf.intStampWatermark = iStampOpacity;

            // スタンプ上書きオプション書き込み
            if (UserSetting_PDFWrite() == false)
            {
                MessageBox.Show(Resources.msgFailedPDFUserSettingWrite, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            #endregion

            // ダイアログを閉じる
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        ///<summary>
        /// プレビューボタンクリック時
        /// </summary>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            string strSecrecyLevel;                   // 機密区分
            Boolean bStamp = true;                    // スタンプ有無フラグ
            string strImageFilePath = "";             // イメージファイルパス
            string strOutLocation = "";               // 新規ファイル名
            string strSecrecyFileName;                // スタンプファイル名

            // 機密区分スタンプの選択チェック
            if (CheckStampOption() == false) return;

            // スタンプ上書き設定を登録する
            int iStampOverwrite = (radioButtonNotSubstitute.Checked == true) ? STAMP_OVERWRITE_NO : STAMP_OVERWRITE_YES;

            // スタンプの場所設定を登録する
            int iStampLocation = (radioButtonUpperLeft.Checked == true) ? STAMP_POSITION_UPPER_LEFT : STAMP_POSITION_UPPER_RIGHT;

            // スタンプの大きさ設定を登録する
            int iStampSize = (radioButtonLarge.Checked == true) ? STAMP_SIZE_LARGE : (radioButtonMiddle.Checked == true) ? STAMP_SIZE_MIDDLE : STAMP_SIZE_SMALL;

            // スタンプの大きさの値を登録する
            float fStampSize = (radioButtonLarge.Checked == true) ? STAMP_SIZE_LARGE_VALUE : (radioButtonMiddle.Checked == true) ? STAMP_SIZE_MIDDLE_VALUE : STAMP_SIZE_SMALL_VALUE;

            // スタンプの透かし度設定
            int iStampOpacity = int.Parse(txtBoxStampOpacity.Text);

            // スタンプの方向
            RotateFlipType rftRotate = RotateFlipType.RotateNoneFlipNone;

            // 選択中の機密区分を取得
            strSecrecyLevel = this.GetSelectedSABCode();

            // 選択中の機密区分のファイル名を取得
            strSecrecyFileName = this.GetSelectedSTAMPFILE();

            //ファイルパスがない場合はパスをセットしない
            if (!string.IsNullOrEmpty(strSecrecyFileName))
            {
                strImageFilePath = @System.AppDomain.CurrentDomain.BaseDirectory + strSecrecyFileName;
                strImageFilePath += STAMP_EXTENSION;
            }


            // 上書きしないが選択されている場合はスタンプを押さない（スタンプ無しの場合）
            if (radioButtonNotSubstitute.Checked == true) bStamp = false;

            // プレビュー画面が表示されている場合はクローズ処理を行う。
            if (frmPre != null)
            {
                frmPre.Close();
                frmPre.Dispose();
            }

            // プロセスが残っている場合はプロセスを閉じる
            if (pPreview != null)
            {
                if (!pPreview.HasExited)
                {
                    pPreview.Kill();
                    pPreview.Dispose();
                }
                pPreview = null;
            }
            #region <プレビューファイルスタンプ貼付け処理>
            // スタンプ貼り付け処理
            try
            {
                // ファイル名を拡張子を付けずに取得
                string OutputFail = System.IO.Path.GetFileNameWithoutExtension(strTargetFilePath);

                // ファイルのディレクトリ情報を取得
                string dir = Path.GetTempPath();

                string tempFilePath = Path.GetTempFileName();
                strOutLocation = tempFilePath + ".sab.pdf";
                File.Move(tempFilePath, strOutLocation);

                tempFileList.Add(strOutLocation);

                // スタンプ登録処理
                SetStamp(strTargetFilePath, strOutLocation, strImageFilePath, "", clsCommonSettting.strOfficeCode, strSecrecyLevel, bStamp, iStampOpacity, iStampLocation, fStampSize, rftRotate);
            }
            catch
            {
                // スタンプが貼り付けできない場合
                MessageBox.Show(Resources.msgFailedStampPaste, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            #endregion

            #region <プレビュー表示>

            // 実行EXEファイル名を取得
            string appPath;                                         // 実行EXEファイル名
            appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            appPath = Path.GetFileName(appPath);

            // 関連付けられたアプリケーションパスを取得
            string strRegVal;
            strRegVal = FindAssociatedExecutable(strTargetFilePath);

            // 関連付けられたアプリケーションが自分自身の場合はプレビュー画面を表示する。それ以外は外部アプリを実行
            if (0 < strRegVal.IndexOf(appPath))
            {
                try
                {
                    // プレビュー画面を作成
                    frmPre = new PDFPreview();

                    // PDF内容を表示する
                    frmPre.strPdfPath = strOutLocation;

                    // プレビュー画面表示
                    frmPre.ShowDialog();

                    frmPre.Dispose();

                    // 最前面に表示
                    this.Activate();
                    this.TopMost = true;
                    this.TopMost = false;
                }
                catch
                {
                    // プレビュー画面表示にエラーが発生
                    MessageBox.Show(Resources.msgErrAcrobatReader, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                // 既定のPDFビューワーで開く
                pPreview = System.Diagnostics.Process.Start(strOutLocation);
            }
            #endregion
        }

        /// <summary>
        /// フォームキーダウン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSettings_KeyDown(object sender, KeyEventArgs e)
        {
            // ESCキーが押された場合
            if (e.KeyData == Keys.Escape)
            {
                // SAB画面を終了
                this.Close();
            }
            // Enterキーが押された場合
            else if (e.KeyData == Keys.Enter)
            {
                // 登録ボタンクリック処理
                btnSave_Click(sender, e);
            }
        }

        /// <summary>
        /// SAB画面を終了する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // SAB画面を終了
            this.Close();
        }
        
        /// <summary>
        /// フォームクローズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            // プレビュー画面が表示されている場合はクローズ処理を行う。
            if (frmPre != null)
            {
                frmPre.Close();
                frmPre.Dispose();
            }

            // プロセスが残っている場合
            if (pPreview != null)
            {
                if (!pPreview.HasExited)
                {
                    pPreview.Kill();
                    pPreview.Dispose();
                }
                pPreview = null;
            }

            // プレビューファイルの削除
            bool deleteFileResult = DeleteTempFiles(this.tempFileList);
            if(deleteFileResult == false)
            {
                e.Cancel = true;
                MessageBox.Show(Resources.msgNotDeletePreviewTemporary, Resources.msgConfirmation, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // スタンプ貼り付けファイル削除
            string OutputFail = Path.GetFileNameWithoutExtension(strTargetFilePath);
            string dir = Path.GetTempPath();
            string NewFailPath = dir;
            NewFailPath += NewFailPath.EndsWith("\\") ? "" : "\\";
            NewFailPath += OutputFail;
            string strDeleteFile = NewFailPath + STAMP_FILENAME;
            if (File.Exists(strDeleteFile))
            {
                try
                {
                    File.Delete(strDeleteFile);
                }
                catch
                {
                    // 削除できない場合
                    MessageBox.Show(Resources.msgNotDeleteStampTemporary, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            // ターゲット更新用ファイル作成
            string RenameFailPath = dir;
            RenameFailPath += NewFailPath.EndsWith("\\") ? "" : "\\";
            RenameFailPath += OutputFail;
            RenameFailPath = NewFailPath + WRITE_FILENAME;
            if (File.Exists(RenameFailPath))
            {
                try
                {
                    File.Delete(RenameFailPath);
                }
                catch
                {
                    // 削除できない場合
                    MessageBox.Show(Resources.msgNotDeleteTemporary, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }
        #endregion


        #region メソッド
        /// <summary>
        /// 共通設定読み込み
        /// </summary>
        private Boolean CommonSettingRead()
        {
            Boolean bResult = false;

            clsCommonSettting = new CommonSettings();

            try
            {
                // 共通設定ファイルパス作成
                string strCommonSettingFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    COMMON_SETFOLDERNAME,
                    COMMON_SETFILENAME
                    );

                // 共通設定ファイルが存在しない場合はデフォルト設定を書き込む
                if (!File.Exists(strCommonSettingFilePath))
                {
                    if (!CommonSettingWrite())
                    {
                        return bResult;
                    }
                }

                //XmlSerializerオブジェクトの作成
                System.Xml.Serialization.XmlSerializer serXmlCommonRead = new System.Xml.Serialization.XmlSerializer(typeof(CommonSettings));

                //ファイルを開く
                System.IO.StreamReader stmCommonReader = new System.IO.StreamReader(strCommonSettingFilePath, Encoding.GetEncoding("shift_jis"));

                //XMLファイルから読み込み、逆シリアル化する
                clsCommonSettting = (CommonSettings)serXmlCommonRead.Deserialize(stmCommonReader);

                //閉じる
                stmCommonReader.Close();

                bResult = true;
            }
            catch
            {
                // 読み込み出来ない場合はエラーを返す
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// 共通設定設定書き込み
        /// </summary>
        private Boolean CommonSettingWrite()
        {
            Boolean bResult = false;

            try
            {
                // 共通設定ファイルパス作成
                string strCommonSettingFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    COMMON_SETFOLDERNAME
                    );

                if (!Directory.Exists(strCommonSettingFilePath))
                {
                    // フォルダ作成
                    System.IO.Directory.CreateDirectory(strCommonSettingFilePath);
                }
                strCommonSettingFilePath = Path.Combine(strCommonSettingFilePath,
                        COMMON_SETFILENAME
                        );

                //XmlSerializerオブジェクトの作成
                System.Xml.Serialization.XmlSerializer serXmlCommonWrite = new System.Xml.Serialization.XmlSerializer(typeof(CommonSettings));

                //ファイルを開く
                System.IO.StreamWriter stmCommonWrite = new System.IO.StreamWriter(strCommonSettingFilePath, false, Encoding.GetEncoding("shift_jis"));

                //シリアル化し、XMLファイルに保存する
                serXmlCommonWrite.Serialize(stmCommonWrite, clsCommonSettting);

                //閉じる
                stmCommonWrite.Close();

                bResult = true;
            }
            catch
            {
                // 更新できない場合はエラーを返す
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// ユーザー設定読み込み
        /// </summary>
        /// <returns></returns>
        private Boolean UserSetting_PDFRead()
        {
            Boolean bResult = false;

            try
            {
                // ユーザー設定ファイルパス作成
                string strUserSettingPdfFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    USER_SETFOLDERNAME,
                    USER_SETFILENAME_PDF
                );

                // ユーザー設定ファイルが存在しない場合
                if (!File.Exists(strUserSettingPdfFilePath))
                {
                    // デフォルト設定を書き込む
                    UserSetting_PDFWrite();
                }

                //XmlSerializerオブジェクトの作成
                System.Xml.Serialization.XmlSerializer serXmlPdfUserRead = new System.Xml.Serialization.XmlSerializer(typeof(UserSettingsPdf));

                //ファイルを開く
                System.IO.StreamReader stmUserReader = new System.IO.StreamReader(strUserSettingPdfFilePath, Encoding.GetEncoding("shift_jis"));

                //XMLファイルから読み込み、逆シリアル化する
                clsUserSettingPdf = (UserSettingsPdf)serXmlPdfUserRead.Deserialize(stmUserReader);

                //閉じる
                stmUserReader.Close();

                bResult = true;
            }
            catch
            {
                // 読み込み出来ない場合はエラーを返す
                bResult = false;
            }
            return bResult;

        }

        /// <summary>
        /// ユーザー設定書き込み
        /// </summary>
        /// <returns></returns>
        private Boolean UserSetting_PDFWrite()
        {
            Boolean bResult = false;

            try
            {
                // ユーザー設定ファイルパス作成
                string strUserSettingPdfFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                            USER_SETFOLDERNAME
                       );

                if (!Directory.Exists(strUserSettingPdfFilePath))
                {
                    // フォルダ作成
                    System.IO.Directory.CreateDirectory(strUserSettingPdfFilePath);
                }

                strUserSettingPdfFilePath = Path.Combine(strUserSettingPdfFilePath,
                            USER_SETFILENAME_PDF
                       );

                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serXmlPdfUserWrite = new System.Xml.Serialization.XmlSerializer(typeof(UserSettingsPdf));

                //ファイルを開く
                System.IO.StreamWriter stmUserWrite = new System.IO.StreamWriter(strUserSettingPdfFilePath, false, Encoding.GetEncoding("shift_jis"));

                //シリアル化し、XMLファイルに保存する
                serXmlPdfUserWrite.Serialize(stmUserWrite, clsUserSettingPdf);

                //閉じる
                stmUserWrite.Close();

                bResult = true;
            }
            catch
            {
                // 更新できない場合はエラーを返す
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// SAB機密区分のテキストからSAB機密区分列挙体を取得
        /// </summary>
        private Secrecy GetSecrecyEnumeration(string secrecy)
        {
            if (secrecy == SECRECY_PROPERTY_S)
            {
                return Secrecy.S;
            }

            if (secrecy == SECRECY_PROPERTY_A)
            {
                return Secrecy.A;
            }

            if (secrecy == SECRECY_PROPERTY_B)
            {
                return Secrecy.B;
            }

            return Secrecy.None;
        }

        /// ラジオボタンの選択状態からSAB機密区分を取得
        /// </summary>
        /// <returns>選択中のSAB機密区分 列挙体</returns>
        private Secrecy GetSelectedSecrecyLevel()
        {
            if (this.rdoS.Checked == true)
            {
                return Secrecy.S;
            }

            if (this.rdoA.Checked == true)
            {
                return Secrecy.A;
            }

            if (this.rdoB.Checked == true)
            {
                return Secrecy.B;
            }

            return Secrecy.None;
        }


        /// <summary>
        /// SAB機密区分列挙体からSAB機密区分のテキストを取得
        /// </summary>
        private string GetSABText(Secrecy secrecy)
        {
            if (secrecy == Secrecy.S)
            {
                return Resources.TypeS;
            }

            if (secrecy == Secrecy.A)
            {
                return Resources.TypeA;
            }

            if (secrecy == Secrecy.B)
            {
                return Resources.TypeB;
            }

            return Resources.TypeElse;
        }

        /// <summary>
        /// ラジオボタンの選択状態から背景色を更新
        /// </summary>
        /// <param name="radioButton">対象のラジオボタン</param>
        private void ChangeBackColor(ref RadioButton radioButton)
        {
            if (radioButton.Checked == true)
            {
                radioButton.BackColor = Color.Green;
            }
            else
            {
                radioButton.BackColor = Color.Gray;
            }
        }

        /// <summary>
        /// スタンプ貼付け処理
        /// </summary>
        /// <param name="strTargetPdfFilePath"></param>
        /// <param name="strPdfFilePath"></param>
        /// <param name="strImageFilePath"></param>
        /// <param name="strClassNo"></param>
        /// <param name="strOfficeCode"></param>
        /// <param name="strSecrecyLevel"></param>
        /// <param name="bStamp"></param>
        /// <param name="iOpacity"></param>
        /// <param name="iStampPosition"></param>
        /// <param name="fStampSize"></param>
        /// <param name="rftRotate"></param>
        /// <returns></returns>
        private Boolean SetStamp(string strTargetPdfFilePath, string strPdfFilePath, string strImageFilePath, string strClassNo, string strOfficeCode, string strSecrecyLevel, Boolean bStamp, int iOpacity, int iStampPosition, float fStampSize, RotateFlipType rftRotate)
        {
            // 書き込まれるプロパティ
            string strWritePropertyData;

            Boolean bResult = false;

            try
            {
                // PDFReader作成
                PdfReader pdfReader = new PdfReader(strTargetPdfFilePath);

                // PDFファイル読み込み FileStream
                using (FileStream fs = new FileStream(strPdfFilePath, FileMode.Create, FileAccess.Write))
                {
                    // PDFファイル読み込み PdfStamper
                    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, fs))
                    {
                        // 書き込み情報作成
                        strWritePropertyData = string.Format("{0}; {1}; {2}", strSecrecyLevel, strClassNo, strOfficeCode);

                        // プロパティ書き込み
                        Dictionary<String, String> info = new Dictionary<String, String>();
                        info["Keywords"] = strWritePropertyData;
                        pdfStamper.MoreInfo = info;

                        // スタンプ貼り付け
                        while (true)
                        {
                            // スタンプ貼り付け無しの場合は貼り付け処理を行わない
                            if (bStamp == false) break;

                            // スタンプ画像のパスがない場合は貼り付けを行わない
                            if (strImageFilePath == "") break;

                            // PDFレイヤー取得
                            PdfLayer layer = new PdfLayer("WatermarkLayer", pdfStamper.Writer);

                            // ページ数分繰り返す
                            for (int ipage = 1; ipage <= pdfReader.NumberOfPages; ipage++)
                            {
                                // １ページ目以外の場合はスキップ
                                if (ipage != 1) continue;

                                // 画像を取り込む。
                                Bitmap bmp = new Bitmap(strImageFilePath);

                                // 白を透明化する
                                bmp.MakeTransparent(System.Drawing.Color.White);

                                // 回転
                                bmp.RotateFlip(rftRotate);

                                // テンポラリフォルダにスタンプファイルを保存
                                string strNewPngFilePath = Path.GetTempPath() + STAMP_TEMP_FILENAME;
                                bmp.Save(strNewPngFilePath, ImageFormat.Png);

                                // iTextSharpにてスタンプファイルを読み込み(System.Drawing.Imageでの取り込みでは透明化出来ない為)
                                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(strNewPngFilePath);

                                // テンポラリフォルダに作成したスタンプファイルを削除
                                System.IO.File.Delete(strNewPngFilePath);

                                // イメージサイズ取得
                                iTextSharp.text.Rectangle rect = pdfReader.GetCropBox(ipage);

                                // イメージローテーション情報取得
                                iTextSharp.text.Rectangle rotate = pdfReader.GetPageSizeWithRotation(ipage);

                                // ContentByteオブジェクト取得
                                PdfContentByte cb = pdfStamper.GetOverContent(ipage);

                                // ContentByteオブジェクトのレイヤー取得
                                PdfGState gState = new PdfGState();

                                // 透かし度を設定（薄）0.00～1.00（濃）
                                float fOpacity = float.Parse(iOpacity.ToString());
                                gState.FillOpacity = 1 - (fOpacity / 100);

                                // 透かし設定
                                cb.SetGState(gState);
                                cb.SetColorFill(BaseColor.WHITE);

                                // スタンプの幅を設定
                                float fImageW = image.Width / STAMP_MAGNIFICATION;

                                // スタンプの高さを設定
                                float fImageH = image.Height / STAMP_MAGNIFICATION;

                                // スタンプ位置
                                switch (iStampPosition)
                                {
                                    case STAMP_POSITION_UPPER_RIGHT:
                                        // 右上
                                        if ((rotate.Rotation == 0) || (rotate.Rotation == 180))
                                        {
                                            // 縦表示の場合
                                            image.SetAbsolutePosition(rect.Right - fImageW * fStampSize, rect.Top - fImageH * fStampSize);
                                        }
                                        else
                                        {
                                            // 横表示の場合
                                            image.SetAbsolutePosition(rect.Top - fImageW * fStampSize, rect.Right - fImageH * fStampSize);
                                        }
                                        break;
                                    case STAMP_POSITION_UNDER_LEFT:
                                        // 左下
                                        image.SetAbsolutePosition(rect.Left, rect.Bottom);
                                        break;
                                    case STAMP_POSITION_UNDER_RIGHT:
                                        // 右下
                                        if ((rotate.Rotation == 0) || (rotate.Rotation == 180))
                                        {
                                            // 縦表示の場合
                                            image.SetAbsolutePosition(rect.Right - fImageW * fStampSize, rect.Bottom);
                                        }
                                        else
                                        {
                                            // 横表示の場合
                                            image.SetAbsolutePosition(rect.Top - fImageW * fStampSize, rect.Bottom);
                                        }
                                        break;
                                    default:
                                        // 上記以外は左上とする
                                        if ((rotate.Rotation == 0) || (rotate.Rotation == 180))
                                        {
                                            // 縦表示の場合
                                            image.SetAbsolutePosition(rect.Left, rect.Top - fImageH * fStampSize);
                                        }
                                        else
                                        {
                                            // 横表示の場合
                                            image.SetAbsolutePosition(rect.Left, rect.Right - fImageH * fStampSize);
                                        }
                                        break;
                                }

                                // スタンプサイズ設定
                                image.ScaleAbsolute(fImageW * fStampSize, fImageH * fStampSize);

                                // スタンプ貼り付け
                                cb.AddImage(image);
                            }
                            break;
                        }
                        pdfStamper.Close();
                        pdfReader.Close();
                        bResult = true;
                    }
                }
            }
            catch
            {
                // 貼り付けできない場合はエラーを返す
                bResult = false;
            }
            return bResult;
        }

        #region <拡張子関連付けパス取得>
        /// <summary>
        /// 指定された拡張子に関連付けられた実行ファイルのパスを取得する。
        /// </summary>
        /// <param name="extName">".txt"などの拡張子。</param>
        /// <returns>見つかった時は、実行ファイルのパス。
        /// 見つからなかった時は、空の文字列。</returns>
        /// <example>
        /// 拡張子".txt"に関連付けられた実行ファイルのパスを取得する例
        /// <code>
        /// string exePath = FindAssociatedExecutable(".txt");
        /// </code>
        /// </example>
        public static string FindAssociatedExecutable(string extName)
        {
            //pszOutのサイズを取得する
            uint pcchOut = 0;
            //ASSOCF_INIT_IGNOREUNKNOWNで関連付けられていないものを無視
            //ASSOCF_VERIFYを付けると検証を行うが、パフォーマンスは落ちる
            AssocQueryString(AssocF.Init_IgnoreUnknown, AssocStr.Executable,
                extName, null, null, ref pcchOut);
            if (pcchOut == 0)
            {
                return string.Empty;
            }
            //結果を受け取るためのStringBuilderオブジェクトを作成する
            StringBuilder pszOut = new StringBuilder((int)pcchOut);
            //関連付けられた実行ファイルのパスを取得する
            AssocQueryString(AssocF.Init_IgnoreUnknown, AssocStr.Executable,
                extName, null, pszOut, ref pcchOut);
            //結果を返す
            return pszOut.ToString();
        }

        [DllImport("Shlwapi.dll",
            SetLastError = true,
            CharSet = CharSet.Auto)]
        private static extern uint AssocQueryString(AssocF flags,
            AssocStr str,
            string pszAssoc,
            string pszExtra,
            [Out] StringBuilder pszOut,
            [In][Out] ref uint pcchOut);
        #endregion

        /// <summary>
        /// 機密区分スタンプの選択チェック
        /// </summary>
        /// <returns></returns>
        private Boolean CheckStampOption()
        {
            Boolean bResult = false;

            while (true)
            {
                // スタンプの透かし度チェック
                int iStampOpacity;

                // 数値以外の場合
                if (int.TryParse(txtBoxStampOpacity.Text, out iStampOpacity) == false)
                {
                    MessageBox.Show(Resources.msgNotWatermark, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                }

                // 範囲外の場合
                if ((iStampOpacity > STAMP_OPACITY_MAX) || (STAMP_OPACITY_MIN > iStampOpacity))
                {
                    MessageBox.Show(Resources.msgNotWatermark, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                }

                bResult = true;
                break;
            }

            return bResult;
        }

        /// <summary>
        /// 機密区分取得
        /// </summary>
        /// <returns>機密区分</returns>
        private string GetSelectedSABCode()
        {
            Secrecy _selectedSecrecy = GetSelectedSAB();

            string _selectedSecrecyCode = ConvertSecrecyCode(_selectedSecrecy);

            return _selectedSecrecyCode;
        }

        /// <summary>
        /// スタンプファイル名取得
        /// </summary>
        /// <returns>ファイル名</returns>
        private string GetSelectedSTAMPFILE()
        {
            Secrecy _selectedSecrecy = GetSelectedSAB();

            string _selectedSecrecyFileName = ConvertSecrecyFileName(_selectedSecrecy);

            return _selectedSecrecyFileName;
        }

        /// <summary>
        /// 機密区分設定
        /// </summary>
        /// <returns>設定した機密区分</returns>
        private Secrecy GetSelectedSAB()
        {
            if (this.rdoS.Checked == true)
            {
                return Secrecy.S;
            }

            if (this.rdoA.Checked == true)
            {
                return Secrecy.A;
            }

            if (this.rdoB.Checked == true)
            {
                return Secrecy.B;
            }

            return Secrecy.None;
        }

        /// <summary>
        /// 機密区分変換
        /// </summary>
        /// <param name="secrecy">機密区分</param>
        /// <returns>プロパティ名</returns>
        private String ConvertSecrecyCode(Secrecy secrecy)
        {
            // 機密区分設定            
            switch (secrecy)
            {
                case Secrecy.S: return SECRECY_PROPERTY_S;

                case Secrecy.A: return SECRECY_PROPERTY_A;

                case Secrecy.B: return SECRECY_PROPERTY_B;

                case Secrecy.None: return SECRECY_PROPERTY_NONE;
            }
            return SECRECY_PROPERTY_NONE;
        }

        /// <summary>
        /// ファイル名取得
        /// </summary>
        /// <returns>ファイル名</returns>
        private String ConvertSecrecyFileName(Secrecy secrecy)
        {
            // 機密区分設定            
            switch (secrecy)
            {
                case Secrecy.S: return SECRECY_FILENAME_S;

                case Secrecy.A: return SECRECY_FILENAME_A;

                case Secrecy.B: return SECRECY_FILENAME_B;
            }
            return "";
        }
        
        /// <summary>
        /// 一時ファイル削除
        /// </summary>
        /// <returns>削除結果(true:正常, false:エラー)</returns>
        private bool DeleteTempFiles(List<string> tempFiles)
        {
            // 一時ファイル削除を10回試行
            for (int tryCount = 1; tryCount <= 10; tryCount++)
            {
                try
                {
                    foreach (var filePath in tempFiles)
                    {
                        File.Delete(filePath);
                    }
                }
                catch
                {
                    System.Threading.Thread.Sleep(100);

                    // 10回試行して削除できなかった場合はエラー
                    if (tryCount >= 10)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 一時ファイル削除(拡張子.sab.pdf)
        /// </summary>
        private void DeleteTempFiles()
        {
            string tempDir = Path.GetTempPath();

            try
            {
                string[] tempList = Directory.GetFiles(tempDir, "*.sab.pdf");

                // Delete source files that were copied.
                foreach (string f in tempList)
                {
                    File.Delete(f);
                }
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                MessageBox.Show(dirNotFound.Message, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (UnauthorizedAccessException accessException)
            {
                MessageBox.Show(accessException.Message, Resources.msgConfirmation, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        #endregion


        #region <クラス定義>

        /// <summary>
        /// ユーザー設定クラス
        /// </summary>
        public class UserSettingsPdf
        {
            // 機密スタンプ上書きオプション
            public int intStampOverwrite;

            // 機密スタンプの場所選択
            public int intStampLocation;

            // スタンプの大きさ
            public int intStampSize;

            // スタンプの透かし度
            public int intStampWatermark;

            public UserSettingsPdf()
            {
                // 機密スタンプ上書き設定デフォルト値
                intStampOverwrite = USER_SETDEF_OVERWRITE;

                // 機密スタンプの場所デフォルト値
                intStampLocation = USER_SETDEF_LOCATION;

                // スタンプの大きさデフォルト値
                intStampSize = USER_SETDEF_SIZE;

                // スタンプの透かし度デフォルト値
                intStampWatermark = USER_SETDEF_WATERMARK;
            }
        }
        #endregion

        /// <summary>
        /// 機密区分の判別方法ドキュメントの更新処理
        /// </summary>
        private void UpdateDocument()   // step2
        {
            // ネットワークに接続されているか
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                string _serverFilePath = clsCommonSettting.strSABListServerPath;
                string _localFilePath = clsCommonSettting.strSABListLocalPath;

                try
                {
                    // 設定値のチェック
                    if (_serverFilePath == "" || _localFilePath == "")
                    {
                        MessageBox.Show(Resources.msgFailedReadDocumentPath, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    // ファイルの有無
                    if (File.Exists(_serverFilePath) == true)
                    {
                        // ローカルの保存先があるか
                        string _localDir = Path.GetDirectoryName(_localFilePath);

                        if (Directory.Exists(_localDir) == false)
                        {
                            // フォルダ作成
                            Directory.CreateDirectory(_localDir);
                        }

                        // サーバとローカルのファイルを比較する
                        DateTime _serverDocument = File.GetLastWriteTime(_serverFilePath);
                        DateTime _localDocument = File.GetLastWriteTime(_localFilePath);

                        if (_serverDocument > _localDocument)
                        {
                            // ローカルファイルを更新する
                            File.Copy(_serverFilePath, _localFilePath, true);
                        }
                    }
                }
                catch
                {
                    // ファイルが更新できない場合はスルーする
                }
            }
        }

        // step2
        /// <summary>
        /// 保存先がOKかチェックする
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        private bool CheckSecurePath(string dirPath)
        {
            foreach (var secureFolder in clsCommonSettting.lstSecureFolder)
            {
                if (dirPath.StartsWith(secureFolder) == true)
                {
                    return true;
                }
            }
            MessageBox.Show(Resources.msgNotSavePdf, Resources.msgConfirmation, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return false;
        }

        // step2
        /// <summary>
        /// 機密区分によるファイルの保存先判定
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        private SaveExec CheckSaveDir(ref string dirPath)
        {
            // ファイル保存ダイアログを表示する。ファイルの保存先がOKかどうかを判定する。OKなら引数にパスを格納する。
            // 機密区分のチェックをする

            // 機密区分がS,Aのときは処理をする。B,以外のときは何もしない。
            bool _isSecrecySA = false;

            Secrecy _selectedSecrecy = GetSelectedSAB();

            switch (_selectedSecrecy)
            {
                case Secrecy.S:
                    _isSecrecySA = true;
                    break;
                case Secrecy.A:
                    _isSecrecySA = true;
                    break;
            }

            if(_isSecrecySA)
            {
                string _defaultName = Path.GetFileNameWithoutExtension(strTargetFilePath);

                SaveFileDialog sfd = new SaveFileDialog();

                // 初期フォルダを指定する
                sfd.InitialDirectory = Path.GetDirectoryName(strTargetFilePath);

                // 初期ファイル名を指定する
                sfd.FileName = _defaultName + STAMP_FILENAME;

                // タイトルを設定する
                sfd.Title = Resources.msgSelectFile;

                // [ファイルの種類]に表示される選択肢を指定する
                sfd.Filter = Resources.msgPDFfile;

                // 上書き保存の確認OFF
                sfd.OverwritePrompt = false;

                // 保存ダイアログを表示する
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return SaveExec.Not;
                }
                dirPath = sfd.FileName;

                // 保存先がOKかチェックする
                if (CheckSecurePath(dirPath) == true)
                {
                    return SaveExec.Sa;
                }
                else
                {
                    return SaveExec.Not;
                }
            }
            return SaveExec.Bnone;
        }

        // step2
        /// <summary>
        /// リンクラベルクリック
        /// </summary>
        private void lnkLblDoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // GCP機密文書(SA秘)一覧表を開く
            string _localFilePath = clsCommonSettting.strSABListLocalPath;

            if (File.Exists(_localFilePath) == true)
            {
                Process.Start(_localFilePath);
            }
            else
            {
                MessageBox.Show(Resources.msgFailedOpenGCPdocument, Resources.msgError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}