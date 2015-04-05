using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LearningKanji.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "KanjiService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select KanjiService.svc or KanjiService.svc.cs at the Solution Explorer and start debugging.
    public class KanjiService : IKanjiService
    {
        public List<KanjiObj> GetListKanji()
        {
            List<KanjiObj> lstKanji = new List<KanjiObj>();
            kanjidbDataContext dbConnection = new kanjidbDataContext();
            var result = from kanji in dbConnection.KANJI_TBLs select kanji;
            foreach (var kj in result)
            {
                KanjiObj eKanji = new KanjiObj((int)kj.ID, (string)kj.VOCABULARY, (string)kj.HIRAGANA,
                                            (string)kj.CHINESE, (string)kj.VIETNAMESE, (string)kj.LESSION_ID, (int)kj.STT);
                lstKanji.Add(eKanji);
            }

            return lstKanji;
        }

        public Dictionary<int, string> GetLessionName()
        {
            Dictionary<int, string> lessionManager = new Dictionary<int,string>();
            kanjidbDataContext dbConnection = new kanjidbDataContext();

            // Query database
            var strResult = from kanji in dbConnection.LESSION_TBLs select kanji;
            foreach (var lession in strResult)
            {
                lessionManager.Add((int)lession.LESSION_ID, lession.LESSION_NAME.ToString());
            }
            
            return lessionManager;
        }

        public List<KanjiObj> GetListKanjiByLessionID(int lessionID)
        {
            List<KanjiObj> lstResult = new List<KanjiObj>();
            kanjidbDataContext dbConnection = new kanjidbDataContext();
            var lstKanji = from kanji in dbConnection.KANJI_TBLs where kanji.LESSION_ID == lessionID.ToString() select kanji;

            foreach (var eRecord in lstKanji)
            {
                lstResult.Add(new KanjiObj((int)eRecord.ID, (string)eRecord.VOCABULARY, (string)eRecord.HIRAGANA,
                                            (string)eRecord.CHINESE, (string)eRecord.VIETNAMESE, (string)eRecord.LESSION_ID, (int)eRecord.STT));
            }
            return lstResult;
        }
    }
}
