using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bokka
{
    public class Constants
    {
        public const int MAX_LOOP_COUNT = 100;
        public const int FILELOCK_RETRY_COUNT = 10;
        public const string WINDOW_TITLE_FORMAT = "{0} {1} {2}";
        public const int NPC_INDEX_COU = 57;
        public const int NPC_INDEX_COU_WAYPOINT = 175;
        public const string DIALOG_QUESTION_COU1 = "どうしますか？（チケット:([0-9]*)枚）";
        public const string DIALOG_QUESTION_COU2 = "種類を選んでください。";
        public const string DIALOG_QUESTION_COU3 = "どのワークスコールを受けますか？";
        public const string DIALOG_QUESTION_COU4 = "何枚使用しますか？（チケット:([0-9]*)枚）";
        public const string DIALOG_QUESTION_COU5 = "([0-9]*)枚でよろしいですね？";
        public const string DIALOG_QUESTION_COU6 = "どのワークスコールを報告しますか？";
        public const string DIALOG_QUESTION_WAYPOINT1 = "ワープ先を選択（所有ポイント:([0-9]*)cp）";
    }
}
