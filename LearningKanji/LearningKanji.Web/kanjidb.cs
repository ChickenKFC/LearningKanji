using System.Collections.Generic;
using System.Data.Linq;


namespace LearningKanji.Web
{
    partial class kanjidbDataContext
    {
        /* Get list kanji of specification lession */
        public List<KanjiObj> GetListKanji(int lessionID)
        {
            List<KanjiObj> lstKanji = new List<KanjiObj>();

            /* Create database connection */
            kanjidbDataContext dbConnection = new kanjidbDataContext("");
            return lstKanji;
        }
    }
}
