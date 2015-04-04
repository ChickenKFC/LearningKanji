using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningKanji.Web
{
    public class KanjiObj
    {
        public int _mID { get; set; }
        public string _mVocabulary { get; set; }
        public string _mHiragana { get; set; }
        public string _mChinese { get; set; }
        public string _mVietnames { get; set; }
        public string _mLessionID { get; set; }
        public int _mOrder { get; set; }
        bool mKatakana { get; set; }

        public string _mLessionName { get; set; }

        /* Constructor of Kanji Object */
        public KanjiObj()
        {
            this._mID = 0;
            this._mVocabulary = "";
            this._mHiragana = "";
            this._mChinese = "";
            this._mVietnames = "";
            this._mLessionID = "0";
            this._mOrder = 0;
        }
        public KanjiObj(int id, string voc, string hira, string chinese, string vn, string less, int order)
        {
            this._mID = id;
            this._mVocabulary = voc;
            this._mHiragana = hira;
            this._mChinese = chinese;
            this._mVietnames = vn;
            this._mLessionID = less;
            this._mOrder = order;
        }
    }
}