using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EliteMMO.API;
using System.Threading;
using System.Media;

namespace Bokka
{
    public partial class MainForm : Form
    {
        private enum MessageKind
        {
            Unknown,
            Normal,
            Execute,
            Warning,
            Critical,
        }
        private enum WayDirectionKind
        {
            CouToWaypoint,
            WaypointToCou,
        }
        struct Point
        {
            public float X;
            public float Z;
            public Point(float iX, float iZ)
            {
                this.X = iX;
                this.Z = iZ;
            }
        }
        struct MovePoint
        {
            public Point Point1;
            public Point Point2;
            public MovePoint(Point iPoint1, Point iPoint2)
            {
                this.Point1 = iPoint1;
                this.Point2 = iPoint2;
            }
        }
        private List<MovePoint> movePoint = new List<MovePoint> {
                                          new MovePoint(new Point(-29.6f, 37.1f), new Point(-28.8f, 34.3f)),
                                          new MovePoint(new Point(-31.0f, 31.2f), new Point(-32.2f, 32.2f)),
                                          new MovePoint(new Point(-33.8f, 29.1f), new Point(-33.6f, 27.4f)),
                                          new MovePoint(new Point(-17.3f, 12.1f), new Point(-19.0f, 10.8f)),
                                          new MovePoint(new Point(  6.2f, -4.5f), new Point(  2.0f, -5.3f)),
                                        };
        private EliteAPI api;
        private Settings settings;
        private bool isExec = false;
        private int remainCp = 0;
        private int remainTicket = 0;
        Random rnd = new Random();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region フォーム処理
        /// <summary>
        /// フォームLoadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == System.Windows.Forms.Keys.Shift)
            {
                this.Width = 470;
            }
#if DEBUG
            this.Width = 470;
#endif

            //pol
            setPolList();
            if (cmbPol.Items.Count < 1)
            {
                MessageBox.Show("FF11を起動してください。", MiscTools.GetAppTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                System.Environment.Exit(0); //プログラム終了
            }
            cmbPol.SelectedIndex = 0;
            btnPolAttach_Click(this, new EventArgs());
            //チャットクリア
            EliteAPI.ChatEntry cl = api.Chat.GetNextChatLine();
            while (cl != null) cl = api.Chat.GetNextChatLine();

            //フォーム初期化
            initForm();

            //timer起動
            timMonitor.Interval = 100;
            timMonitor.Enabled = true;
            timDebug.Interval = 100;
            timDebug.Enabled = true;
        }
        /// <summary>
        /// フォームFormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }
        /// <summary>
        /// 画面初期化
        /// </summary>
        private void initForm()
        {
            remainTicket = 0;
            remainCp = 0;

            //form
            this.Left = settings.FormPosX;
            this.Top = settings.FormPosY;
            lblTicket.Text = "--";
            lblCP.Text = "--";
            for (int i = 1; i <= 3; i++) cmbTicketUseEach.Items.Add(i);
            cmbTicketUseEach.Text = settings.TicketUseEach.ToString();
            for (int i = 0; i <= 14; i++) cmbLimitTicket.Items.Add(i);
            cmbLimitTicket.Text = settings.LimitTicket.ToString();
            txtLimitCp.Value = settings.LimitCp;
            txtMenuIndexWorksCall.Value = settings.MenuIndexWorksCall;
            txtMenuIndexArea.Value = settings.MenuIndexArea;
            txtMenuIndexBivouac.Value = settings.MenuIndexBivouac;
            btnExec.Text = "開　　始";
            lblMessage.Text = string.Empty;
        }
        private void btnMenuIndexClear_Click(object sender, EventArgs e)
        {
            settings.MenuIndexWorksCall = -1;
            settings.MenuIndexArea = -1;
            settings.MenuIndexBivouac = -1;
            txtMenuIndexWorksCall.Value = settings.MenuIndexWorksCall;
            txtMenuIndexArea.Value = settings.MenuIndexArea;
            txtMenuIndexBivouac.Value = settings.MenuIndexBivouac;
        }
        #region コントロール値変更
        private void cmbTicketUseEach_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.TicketUseEach = int.Parse(cmbTicketUseEach.Text);
        }
        private void cmbLimitTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.LimitTicket = int.Parse(cmbLimitTicket.Text);
        }
        private void txtLimitCp_ValueChanged(object sender, EventArgs e)
        {
            settings.LimitCp = (int)txtLimitCp.Value;
        }
        private void txtMenuIndexWorksCall_ValueChanged(object sender, EventArgs e)
        {
            settings.MenuIndexWorksCall = (int)txtMenuIndexWorksCall.Value;
        }
        private void txtMenuIndexArea_ValueChanged(object sender, EventArgs e)
        {
            settings.MenuIndexArea = (int)txtMenuIndexArea.Value;
        }
        private void txtMenuIndexBivouac_ValueChanged(object sender, EventArgs e)
        {
            settings.MenuIndexBivouac = (int)txtMenuIndexBivouac.Value;
        }
        #endregion
        #endregion

        /// <summary>
        /// 開始ボタン　クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExec_Click(object sender, EventArgs e)
        {
            if (isExec)
            {
                stop();
            }
            else
            {
                saveSettings();
                start();
            }
        }
        /// <summary>
        /// 開始
        /// </summary>
        private void start()
        {
            
            btnExec.Text = "停　　止";
            isExec = true;
            wkBokka.RunWorkerAsync();
        }
        /// <summary>
        /// 停止
        /// </summary>
        private void stop()
        {
            if(wkBokka.IsBusy) wkBokka.CancelAsync();
            //setMessage("停止しました", MessageKind.Normal);

            btnExec.Text = "開　　始";
            isExec = false;
        }

        #region メイン処理
        /// <summary>
        /// メイン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wkBokka_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            setMessage("開始しました", MessageKind.Execute);
            //開始前チェック処理
            if (api.Player.HasKeyItem(2214) ||  //ケイザックFB設営物資
                api.Player.HasKeyItem(2215) ||  //エヌティエルFB設営物資
                api.Player.HasKeyItem(2216) ||  //モリマーFB設営物資
                api.Player.HasKeyItem(2403) ||  //マリアミFB設営物資
                api.Player.HasKeyItem(2404) ||  //ヨルシアFB設営物資
                api.Player.HasKeyItem(2463))    //カミールFB設営物資
            {
                setMessage("FB設営物資を持っている", MessageKind.Critical);
                e.Cancel = true;
                return;
            }

            for (int l = 0; l < Constants.MAX_LOOP_COUNT; l++)
            {
                //COU NPCチェック
                EliteAPI.XiEntity entCouNpc = api.Entity.GetEntity(Constants.NPC_INDEX_COU);
                if (entCouNpc.Distance > 5.0f)
                {
                    setMessage("COUのカウンター近くで実行してください", MessageKind.Critical);
                    e.Cancel = true;
                    return;
                }
                //メニューを閉じる
                closeMenu();

                //キャンセルチェック
                if (worker.CancellationPending)
                {
                    setMessage("キャンセルしました", MessageKind.Normal);
                    e.Cancel = true;
                    return;
                }

                //COUカウンター ワークスコール受領
                setMessage("ワークスコール受領中", MessageKind.Execute);
                faceTo(Constants.NPC_INDEX_COU);
                talkToNpcWaitDialogOpen(Constants.NPC_INDEX_COU);
                waitDialogTitle(Constants.DIALOG_QUESTION_COU1); //どうしますか？（チケット:([0-9]*)枚）
                if (remainTicket <= settings.LimitTicket)
                {
                    setMessage(string.Format("チケットが{0}枚以下になったので停止", settings.LimitTicket), MessageKind.Normal);
                    return;
                }
                setDialogIndex(0, 3);
                waitDialogTitle(Constants.DIALOG_QUESTION_COU2); //種類を選んでください。
                setDialogIndex(2, 3);
                waitDialogTitle(Constants.DIALOG_QUESTION_COU3); //どのワークスコールを受けますか？
                if (settings.MenuIndexWorksCall >= 0)
                    setDialogIndex((ushort)settings.MenuIndexWorksCall, 3);
                else
                {
                    setMessage("行き先を選択", MessageKind.Warning);
                    SystemSounds.Question.Play();
                    settings.MenuIndexWorksCall = getSelectedDialogIndex();
                    setNumericUpDown(txtMenuIndexWorksCall, settings.MenuIndexWorksCall);
                    setMessage("ワークスコール受領中", MessageKind.Execute);
                }
                waitDialogTitle(Constants.DIALOG_QUESTION_COU4); //何枚使用しますか？（チケット:([0-9]*)枚）
                ushort indexTicket = (ushort)(settings.TicketUseEach - 1);
                setDialogIndex(indexTicket, 3);
                waitDialogTitle(Constants.DIALOG_QUESTION_COU5); //([0-9]*)枚でよろしいですね？
                setDialogIndex(0, 3);
                //キャンセルチェック
                if (worker.CancellationPending)
                {
                    setMessage("キャンセルしました", MessageKind.Normal);
                    e.Cancel = true;
                    return;
                }

                //COUからWaypointまで移動
                setMessage("Waypointまで移動中", MessageKind.Execute);
                moveCouToWaypoint(WayDirectionKind.CouToWaypoint);
                //キャンセルチェック
                if (worker.CancellationPending)
                {
                    setMessage("キャンセルしました", MessageKind.Normal);
                    e.Cancel = true;
                    return;
                }

                //Waypoint
                setMessage("ワープ先選択中", MessageKind.Execute);
                faceTo(Constants.NPC_INDEX_COU_WAYPOINT);
                talkToNpcWaitDialogOpen(Constants.NPC_INDEX_COU_WAYPOINT);
                //エリア
                waitDialogTitle(Constants.DIALOG_QUESTION_WAYPOINT1); //ワープ先を選択（所有ポイント:([0-9]*)cp）
                if (remainCp <= settings.LimitCp)
                {
                    setMessage(string.Format("Cpが{0}以下になったので停止", settings.LimitCp), MessageKind.Normal);
                    return;
                }
                if (settings.MenuIndexArea >= 0)
                    setDialogIndex((ushort)settings.MenuIndexArea, 3);
                else
                {
                    setMessage("エリアを選択してください", MessageKind.Warning);
                    SystemSounds.Question.Play();
                    settings.MenuIndexArea = getSelectedDialogIndex();
                    setNumericUpDown(txtMenuIndexArea, settings.MenuIndexArea);
                    setMessage("ワープ先選択中", MessageKind.Execute);
                    Thread.Sleep(settings.BaseWait);
                }
                //ビバック
                waitDialogTitle(Constants.DIALOG_QUESTION_WAYPOINT1); //ワープ先を選択（所有ポイント:([0-9]*)cp）
                if (settings.MenuIndexBivouac >= 0)
                    setDialogIndex((ushort)settings.MenuIndexBivouac, 3);
                else
                {
                    setMessage("ビバックを選択してください", MessageKind.Warning);
                    SystemSounds.Question.Play();
                    settings.MenuIndexBivouac = getSelectedDialogIndex();
                    setNumericUpDown(txtMenuIndexBivouac, settings.MenuIndexBivouac);
                    setMessage("ワープ先選択中", MessageKind.Execute);
                }
                //ワープ中
                setMessage("ワープ待機中", MessageKind.Execute);
                waitZoneing();
                //キャンセルチェック
                if (worker.CancellationPending)
                {
                    setMessage("キャンセルしました", MessageKind.Normal);
                    e.Cancel = true;
                    return;
                }

                //Administratorへ物資を渡す
                setMessage("近くのAdministratorを検索", MessageKind.Execute);
                int adminIndex = findNpcIndexFromName("Bivouac#([0-9]*) Administrator");
                if (adminIndex >= 0)
                {
                    EliteAPI.XiEntity adminEntity = api.Entity.GetEntity(adminIndex);
                    setMessage("Waypointまで移動中", MessageKind.Execute);
                    moveTo(adminEntity.X, adminEntity.Z, (float)(0.5f + (1.5f * rnd.NextDouble())));
                    setMessage("Administratorへ物資を渡し中", MessageKind.Execute);
                    faceTo(adminEntity.X, adminEntity.Z);
                    talkToNpcWaitTalkFinish(adminIndex);
                }
                else
                {
                    setMessage("Administratorが見つからない", MessageKind.Critical);
                    e.Cancel = true;
                    return;
                }
                //キャンセルチェック
                if (worker.CancellationPending)
                {
                    setMessage("キャンセルしました", MessageKind.Normal);
                    e.Cancel = true;
                    return;
                }

                //AdministratorからWaypointまで移動
                setMessage("近くのWaypointを検索", MessageKind.Execute);
                int waypointIndex = findNpcIndexFromName("Waypoint");
                if (waypointIndex >= 0)
                {
                    EliteAPI.XiEntity waypointEntity = api.Entity.GetEntity(waypointIndex);
                    setMessage("Waypointまで移動中", MessageKind.Execute);
                    moveTo(waypointEntity.X, waypointEntity.Z, (float)(0.5f + (1.5f * rnd.NextDouble())));
                }
                else
                {
                    setMessage("Waypointが見つからない", MessageKind.Critical);
                    e.Cancel = true;
                    return;
                }
                //キャンセルチェック
                if (worker.CancellationPending)
                {
                    setMessage("キャンセルしました", MessageKind.Normal);
                    e.Cancel = true;
                    return;
                }

                //Waypoint
                setMessage("ワープ先選択中", MessageKind.Execute);
                faceTo(waypointIndex);
                talkToNpcWaitDialogOpen(waypointIndex);
                //エリア
                waitDialogTitle(Constants.DIALOG_QUESTION_WAYPOINT1); //ワープ先を選択（所有ポイント:([0-9]*)cp）
                setDialogIndex(2, 3);
                //ビバック
                waitDialogTitle(Constants.DIALOG_QUESTION_WAYPOINT1); //ワープ先を選択（所有ポイント:([0-9]*)cp）
                setDialogIndex(1, 3);
                //ワープ中
                setMessage("ワープ待機中", MessageKind.Execute);
                waitZoneing();
                //キャンセルチェック
                if (worker.CancellationPending)
                {
                    setMessage("キャンセルしました", MessageKind.Normal);
                    e.Cancel = true;
                    return;
                }

                //WaypointからCOUまで移動
                setMessage("Waypointまで移動中", MessageKind.Execute);
                moveCouToWaypoint(WayDirectionKind.WaypointToCou);
                //キャンセルチェック
                if (worker.CancellationPending)
                {
                    setMessage("キャンセルしました", MessageKind.Normal);
                    e.Cancel = true;
                    return;
                }

                //COUカウンター ワークスコール報告
                setMessage("ワークスコール報告中", MessageKind.Execute);
                faceTo(Constants.NPC_INDEX_COU);
                talkToNpcWaitDialogOpen(Constants.NPC_INDEX_COU);
                waitDialogTitle(Constants.DIALOG_QUESTION_COU1); //どうしますか？（チケット:([0-9]*)枚）
                setDialogIndex(0, 3);
                waitDialogTitle(Constants.DIALOG_QUESTION_COU2); //種類を選んでください。
                setDialogIndex(0, 3);
                waitDialogTitle(Constants.DIALOG_QUESTION_COU6); //どのワークスコールを報告しますか？
                setDialogIndex(0, 3);
                while (api.Menu.IsMenuOpen) Thread.Sleep(settings.BaseWait);
            }

            //e.Result = "すべて完了";
        }
        private void wkBokka_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                SystemSounds.Exclamation.Play();
                //MessageBox.Show("キャンセルされました");
            }
            else
            {
                SystemSounds.Asterisk.Play();
                // 処理結果の表示
                //this.Text = e.Result.ToString();
                //MessageBox.Show("正常に完了");
            }
            stop();
        }
        /// <summary>
        /// メニューを閉じる
        /// </summary>
        private void closeMenu()
        {
            while (api.Menu.IsMenuOpen)
            {
                api.ThirdParty.KeyPress(EliteMMO.API.Keys.ESCAPE);
                Thread.Sleep(settings.BaseWait);
            }
        }
        /// <summary>
        /// ターゲットを指定したNpcIndexに設定する
        /// </summary>
        /// <param name="iNpcIndex"></param>
        private void setTarget(int iNpcIndex)
        {
            while (api.Target.GetTargetInfo().TargetIndex != iNpcIndex)
            {
                api.Target.SetTarget(iNpcIndex);
                Thread.Sleep(settings.BaseWait);
            }
        }
        /// <summary>
        /// 指定したNpcIndexに話しかけ、ダイアログが開くまで待機する
        /// </summary>
        /// <param name="iNpcIndex"></param>
        private void talkToNpcWaitDialogOpen(int iNpcIndex)
        {
            //if (api.Player.ViewMode != (int)ViewMode.ThirdPerson) api.Player.ViewMode = (int)ViewMode.ThirdPerson;

            setTarget(iNpcIndex);
            while (!api.Menu.IsMenuOpen)
            {
                api.ThirdParty.KeyPress(EliteMMO.API.Keys.RETURN);
                Thread.Sleep(settings.BaseWait);
            }
        }
        /// <summary>
        /// 指定したNpcIndexに話しかけ、話し終わるまで待機する
        /// </summary>
        /// <param name="iNpcIndex"></param>
        private void talkToNpcWaitTalkFinish(int iNpcIndex)
        {
            //if (api.Player.ViewMode != (int)ViewMode.ThirdPerson) api.Player.ViewMode = (int)ViewMode.ThirdPerson;

            setTarget(iNpcIndex);
            while (api.Player.Status != (uint)Status.Event)
            {
                api.ThirdParty.KeyPress(EliteMMO.API.Keys.RETURN);
            }
            while (api.Player.Status == (uint)Status.Event)
            {
                Thread.Sleep(settings.BaseWait);
            }
        }
        /// <summary>
        /// ダイアログが指定した質問になるまで待機する
        /// </summary>
        /// <param name="iQuestion">質問内容（正規表現）</param>
        private void waitDialogTitle(string iQuestion)
        {
            List<string> regStr = new List<string>();
            while (!MiscTools.GetRegexString(api.Dialog.GetDialog().Question, iQuestion, out regStr))
            {
                Thread.Sleep(settings.BaseWait);
            }
            if (MiscTools.GetRegexString(api.Dialog.GetDialog().Question, Constants.DIALOG_QUESTION_COU1, out regStr))
                remainTicket = int.Parse(regStr[0]);
            if (MiscTools.GetRegexString(api.Dialog.GetDialog().Question, Constants.DIALOG_QUESTION_COU4, out regStr))
                remainTicket = int.Parse(regStr[0]);
            if (MiscTools.GetRegexString(api.Dialog.GetDialog().Question, Constants.DIALOG_QUESTION_WAYPOINT1, out regStr))
                remainCp = int.Parse(regStr[0]);

        }
        /// <summary>
        /// ダイアログのインデックスを設定する
        /// </summary>
        /// <param name="iIndex">ダイアログインデックス</param>
        /// <param name="iMaxRow">１ページの行数（省略可）</param>
        private void setDialogIndex(ushort iIndex, ushort iMaxRow = 0)
        {
            while (api.Dialog.DialogIndex != iIndex)
            {
                if (api.Dialog.DialogIndex < iIndex)
                {
                    if (iMaxRow != 0 && (iIndex - api.Dialog.DialogIndex) >= iMaxRow)
                        api.ThirdParty.KeyPress(EliteMMO.API.Keys.RIGHT);
                    else
                        api.ThirdParty.KeyPress(EliteMMO.API.Keys.DOWN);
                }
                else if (api.Dialog.DialogIndex > iIndex)
                {
                    if (iMaxRow != 0 && (api.Dialog.DialogIndex - iIndex) >= iMaxRow)
                        api.ThirdParty.KeyPress(EliteMMO.API.Keys.LEFT);
                    else
                        api.ThirdParty.KeyPress(EliteMMO.API.Keys.UP);
                }
                Thread.Sleep(100);
            }
            api.ThirdParty.KeyPress(EliteMMO.API.Keys.RETURN);
        }
        /// <summary>
        /// ダイアログで選択されたDialogIndexを取得する
        /// </summary>
        /// <param name="iQuestion"></param>
        /// <returns></returns>
        private short getSelectedDialogIndex()
        {
            short lastSelectedIndex = -1;
            int dialogIndex = api.Dialog.DialogId;
            while (api.Dialog.DialogId == dialogIndex)
            {
                lastSelectedIndex = (short)api.Dialog.DialogIndex;
                Thread.Sleep(10);
            }
            return lastSelectedIndex;
        }
        /// <summary>
        /// COU⇔Waypointを移動する
        /// </summary>
        /// <param name="iWayDirection">移動方向</param>
        private bool moveCouToWaypoint(WayDirectionKind iWayDirection)
        {
            List<MovePoint> points = new List<MovePoint>();
            if (iWayDirection == WayDirectionKind.CouToWaypoint)
                for (int i = 1; i < movePoint.Count; i++) points.Add(movePoint[i]);
            else if (iWayDirection == WayDirectionKind.WaypointToCou)
                for (int i = movePoint.Count - 2; i >= 0; i--) points.Add(movePoint[i]);
            
            for (int i = 0; i < points.Count; i++)
            {
                Point rndPoint = getRandomPoint(points[i]);
                if(!moveTo(rndPoint.X, rndPoint.Z)) return false;
            }
            return true;
        }
        /// <summary>
        /// MovePoint内の座標からランダムに座標を取得
        /// </summary>
        /// <param name="iMovePoint">MovePoint</param>
        /// <returns>ランダムな座標</returns>
        private Point getRandomPoint(MovePoint iMovePoint)
        {
            Point ret = new Point(0, 0);
            int min = 0;
            int max = 0;
            //X
            if (iMovePoint.Point1.X > iMovePoint.Point2.X)
            {
                min = (int)(iMovePoint.Point2.X * 10);
                max = (int)(iMovePoint.Point1.X * 10);
            }
            else
            {
                min = (int)(iMovePoint.Point1.X * 10);
                max = (int)(iMovePoint.Point2.X * 10);
            }
            ret.X = rnd.Next(min, max) / 10;
            //Z
            if (iMovePoint.Point1.Z > iMovePoint.Point2.Z)
            {
                min = (int)(iMovePoint.Point2.Z * 10);
                max = (int)(iMovePoint.Point1.Z * 10);
            }
            else
            {
                min = (int)(iMovePoint.Point1.Z * 10);
                max = (int)(iMovePoint.Point2.Z * 10);
            }
            ret.Z = rnd.Next(min, max) / 10;
            return ret;
        }
        /// <summary>
        /// 指定した座標へ移動する
        /// </summary>
        /// <param name="iX">目標座標X</param>
        /// <param name="iZ">目標座標Z</param>
        /// <param name="iStopDistance">停止する目標座標との距離</param>
        /// <returns>成功した場合True</returns>
        private bool moveTo(float iX, float iZ, float iStopDistance = 0.5f)
        {
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    //Console.WriteLine("dist={0}", getDistance(api.Player.X, api.Player.Z, iX, iZ));
                    if (api.Player.ViewMode != (int)ViewMode.FirstPerson) api.Player.ViewMode = (int)ViewMode.FirstPerson;
                    faceTo(iX, iZ);
                    api.ThirdParty.KeyDown((byte)KeyCode.NP_Number8);
                    if (getDistance(api.Player.X, api.Player.Z, iX, iZ) <= iStopDistance) return true;
                    Thread.Sleep(10);
                }
            }
            finally
            {
                api.ThirdParty.KeyUp((byte)KeyCode.NP_Number8);
            }
            return false;
        }
        /// <summary>
        /// キャラクターの方向を指定したNPCに設定する
        /// </summary>
        /// <param name="iNpcIndex">NpcIndex</param>
        private void faceTo(int iNpcIndex)
        {
            if (api.Player.ViewMode != (int)ViewMode.FirstPerson) api.Player.ViewMode = (int)ViewMode.FirstPerson;
            EliteAPI.XiEntity ent = api.Entity.GetEntity(iNpcIndex);
            faceTo(ent.X, ent.Z);
        }
        /// <summary>
        /// キャラクターの方向を指定した座標に設定する
        /// </summary>
        /// <param name="iX">座標X</param>
        /// <param name="iZ">座標Z</param>
        private void faceTo(float iX, float iZ)
        {
            var p = api.Entity.GetLocalPlayer();
            var angle = (byte)(Math.Atan((iZ - p.Z) / (iX - p.X)) * -(128.0f / Math.PI));
            if (p.X > iX) angle += 128;
            var radian = (((float)angle) / 255) * 2 * Math.PI;
            api.Player.H = (float)radian;
        }
        /// <summary>
        /// 座標から対象との距離を算出する
        /// </summary>
        /// <param name="iX1">座標X1</param>
        /// <param name="iZ1">座標Z1</param>
        /// <param name="iX2">座標X2</param>
        /// <param name="iZ2">座標Z2</param>
        /// <returns>座標間の距離</returns>
        private static float getDistance(float iX1, float iZ1, float iX2, float iZ2)
        {
            return (float)Math.Sqrt(Math.Pow(Math.Abs(iX1 - iX2), 2.0d) + Math.Pow(Math.Abs(iZ1 - iZ2), 2.0d));
        }
        /// <summary>
        /// エリアチェンジが完了するまで待機する
        /// </summary>
        private void waitZoneing()
        {
            while (api.Player.LoginStatus == (uint)LoginStatus.LoggedIn) Thread.Sleep(settings.BaseWait);
            while (api.Player.LoginStatus == (uint)LoginStatus.Loading) Thread.Sleep(settings.BaseWait);
        }
        /// <summary>
        /// Npc名からIndexを取得する
        /// </summary>
        /// <param name="iNpcName">NpcName</param>
        /// <returns>NpcIndex</returns>
        private int findNpcIndexFromName(string iNpcName)
        {
            List<string> regStr = new List<string>();
            for (int i = 0; i < Constants.MAX_LOOP_COUNT; i++)
            {
                for (int j = 0; j < 2048; j++)
                {
                    EliteAPI.XiEntity ent = api.Entity.GetEntity(j);
                    if (!string.IsNullOrEmpty(ent.Name) && MiscTools.GetRegexString(ent.Name, iNpcName, out regStr))
                    {
                        return j;
                    }
                }
                Thread.Sleep(settings.BaseWait);
            }
            return -1;
        }
        /// <summary>
        /// メッセージのセット
        /// </summary>
        /// <param name="iMessage"></param>
        /// <param name="iKind"></param>
        private void setMessage(string iMessage, MessageKind iKind = MessageKind.Unknown)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke
                ((MethodInvoker)delegate() { setMessage(iMessage, iKind); });
                return;
            }
            lblMessage.Text = iMessage;
            switch (iKind)
            {
                case MessageKind.Normal:
                    toolStrip.BackColor = SystemColors.Control;
                    break;
                case MessageKind.Execute:
                    toolStrip.BackColor = Color.FromArgb(0x80, 0xFF, 0xFF);
                    break;
                case MessageKind.Warning:
                    toolStrip.BackColor = Color.FromArgb(0xFF, 0xFF, 0x80);
                    break;
                case MessageKind.Critical:
                    toolStrip.BackColor = Color.FromArgb(0xFF, 0x80, 0x80);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region メソッド
        private bool saveSettings()
        {
            if (api.Player.Name.Length == 0 || api.Player.LoginStatus != (int)LoginStatus.LoggedIn) return false;
            settings.TicketUseEach = int.Parse(cmbTicketUseEach.Text);
            settings.LimitTicket = int.Parse(cmbLimitTicket.Text);
            settings.LimitCp = (int)txtLimitCp.Value;
            settings.MenuIndexWorksCall = (int)txtMenuIndexWorksCall.Value;
            settings.MenuIndexArea = (int)txtMenuIndexArea.Value;
            settings.MenuIndexBivouac = (int)txtMenuIndexBivouac.Value;
            return settings.Save(api.Player.Name);
        }
        private void setNumericUpDown(NumericUpDown iControl, int iValue)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke
                ((MethodInvoker)delegate() { setNumericUpDown(iControl, iValue); });
                return;
            }
            iControl.Value = iValue;
        }
        private string conv(string iSource)
        {
            byte[] raw = Encoding.GetEncoding("Windows-1252").GetBytes(iSource);
            return Encoding.GetEncoding("Shift_JIS").GetString(raw);
        }
        #endregion

        #region POL
        /// <summary>
        /// POLアタッチ クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPolAttach_Click(object sender, EventArgs e)
        {
            int polID = getSelectedPolID();
            string polName = getSelectedPolName();
            Console.WriteLine("PolID:{0}", polID);
            Console.WriteLine("PolID:{0}", polName);
            api = new EliteAPI(polID);
            settings = new Settings(polName);

            this.Text = string.Format(Constants.WINDOW_TITLE_FORMAT, MiscTools.GetAppTitle(), MiscTools.GetAppVersion(), polName);
        }
        /// <summary>
        /// POL更新 クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPolUpdate_Click(object sender, EventArgs e)
        {
            cmbPol.Items.Clear();
            setPolList();
            if (cmbPol.Items.Count > 0)
            {
                cmbPol.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// POLコンボボックスを更新
        /// </summary>
        private void setPolList()
        {
            Process[] pols = Process.GetProcessesByName("pol");
            foreach (Process pol in pols)
            {
                if (pol.MainWindowTitle.IndexOf("PlayOnline") < 0) //ログインしてないPOLは弾く
                {
                    cmbPol.Items.Add(string.Format("{0}({1})", pol.MainWindowTitle, pol.Id));
                }
            }

        }
        /// <summary>
        /// 選択されたPOLコンボボックスのプロセスIDを取得
        /// </summary>
        /// <returns></returns>
        private int getSelectedPolID()
        {
            if (cmbPol.Text.Length < 1 || cmbPol.Text.IndexOf("(") < 0 || cmbPol.Text.IndexOf(")") < 0) return -1;
            List<string> arg = new List<string>();
            bool reg = MiscTools.GetRegexString(cmbPol.Text, @"(.*)\(([0-9]*)\)", out arg);
            if (reg && arg.Count>0)
            {
                return int.Parse(arg[1]);
            }
            return -1;
        }
        /// <summary>
        /// 選択されたPOLコンボボックスのプレイヤー名を取得
        /// </summary>
        /// <returns></returns>
        private string getSelectedPolName()
        {
            if (cmbPol.Text.Length < 1 || cmbPol.Text.IndexOf("(") < 0 || cmbPol.Text.IndexOf(")") < 0) return string.Empty;
            List<string> arg = new List<string>();
            bool reg = MiscTools.GetRegexString(cmbPol.Text, @"(.*)\(([0-9]*)\)", out arg);
            if (reg && arg.Count > 0)
            {
                return arg[0];
            }
            return string.Empty;
        }
        #endregion

        #region デバッグ用
        /// <summary>
        /// Debugタイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timDebug_Tick(object sender, EventArgs e)
        {
            lblPlayerName.Text = api.Player.Name;
            lblStatus.Text = api.Player.Status.ToString();
            lblLoginStatus.Text = api.Player.LoginStatus.ToString();
            lblX.Text = api.Player.X.ToString("##0.0");
            lblY.Text = api.Player.Y.ToString("##0.0");
            lblZ.Text = api.Player.Z.ToString("##0.0");
            lblIsMenuOpen.Text = api.Menu.IsMenuOpen.ToString();
            lblTargetIndex.Text = api.Target.GetTargetInfo().TargetIndex.ToString();
            lblDialogID.Text = api.Dialog.DialogId.ToString();
            lblDialogIndex.Text = api.Dialog.DialogIndex.ToString();
            lblDialogOptionCount.Text = api.Dialog.DialogOptionCount.ToString();
            txtDialogQuestion.Text = api.Dialog.GetDialog().Question;
        }
        private void btnCouToWaypoint_Click(object sender, EventArgs e)
        {
            var t = Task.Factory.StartNew(() => moveCouToWaypoint(WayDirectionKind.CouToWaypoint));
        }
        private void btnWaypointToCOU_Click(object sender, EventArgs e)
        {
            var t = Task.Factory.StartNew(() => moveCouToWaypoint(WayDirectionKind.WaypointToCou));
        }
        #endregion

        private void timMonitor_Tick(object sender, EventArgs e)
        {
            List<string> regStr = new List<string>();
            if (api.Menu.IsMenuOpen)
            {
                if (MiscTools.GetRegexString(api.Dialog.GetDialog().Question, Constants.DIALOG_QUESTION_COU1, out regStr))
                {
                    remainTicket = int.Parse(regStr[0]);
                    lblTicket.Text = regStr[0];
                }
                if (MiscTools.GetRegexString(api.Dialog.GetDialog().Question, Constants.DIALOG_QUESTION_COU4, out regStr))
                {
                    remainTicket = int.Parse(regStr[0]);
                    lblTicket.Text = regStr[0];
                }
                if (MiscTools.GetRegexString(api.Dialog.GetDialog().Question, Constants.DIALOG_QUESTION_WAYPOINT1, out regStr))
                {
                    remainCp = int.Parse(regStr[0]);
                    lblCP.Text = int.Parse(regStr[0]).ToString("#,0");
                }

            }
            EliteAPI.ChatEntry cl = api.Chat.GetNextChatLine();
            while (cl != null)
            {
                Console.WriteLine(string.Format("type:{0} idx1:{1} idx2:{2} {3}",cl.ChatType, cl.Index1, cl.Index2, cl.Text));
                if (cl.ChatType == 144 && MiscTools.GetRegexString(cl.Text, "([0-9]*)枚になりました。", out regStr))
                {
                    remainTicket = int.Parse(regStr[0]);
                    lblTicket.Text = regStr[0];
                }
                if (cl.ChatType == 148 && MiscTools.GetRegexString(cl.Text, "([0-9]*)cpを消鳩てワープします。", out regStr))
                {
                    remainCp -= int.Parse(regStr[0]);
                    lblCP.Text = remainCp.ToString("#,0");
                }
                cl = api.Chat.GetNextChatLine();
            }
        }


    }
}
