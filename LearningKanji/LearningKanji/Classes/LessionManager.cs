using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LearningKanji.Classes;
using System.Collections.Generic;
using LearningKanji.ServiceReference1;

namespace LearningKanji.Classes
{
    /* Class Lession */
    public class LessionObject
    {
        public int _mLessionID { get; set; }
        public string _mLessionName { get; set; }

        public List<KanjiObj> _mKanjiManage { get; set; }
        public int _mCurrentKanji { get; set; }

        public LessionObject()
        {
            this._mLessionID = 0;
            this._mLessionName = "スタト";
            _mKanjiManage = new List<KanjiObj>();
        }

        public List<LearningKanji.ServiceReference1.KanjiObj> GetKanjiManage()
        {
            if (this._mKanjiManage.Count != 0)
            {
                return this._mKanjiManage;
            }
            return null;
        }

        public void releaseKanjiManage()
        {
            if (this._mKanjiManage.Count != 0)
            {
                this._mKanjiManage.Clear();
            }
        }

        public KanjiObj GetCurrentKanji()
        {
            this._mKanjiManage[this._mCurrentKanji]._mLessionName = this._mLessionName;
            return this._mKanjiManage[this._mCurrentKanji];
        }

        public void PushKanjiList(List<KanjiObj> lstKanji)
        {
            this._mKanjiManage = lstKanji;
            if (this._mKanjiManage.Count > 0)
            {
                this._mLessionID = Int32.Parse(_mKanjiManage[0]._mLessionID);
            }
        }

    }
}
