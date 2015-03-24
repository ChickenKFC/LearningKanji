using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LearningKanji.Classes.KanjiObject;

namespace LearningKanji.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "KanjiService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select KanjiService.svc or KanjiService.svc.cs at the Solution Explorer and start debugging.
    public class KanjiService : IKanjiService
    {
        public List<KanjiObject> GetListKanji()
        {
            List<KanjiObject> lstKanji = new List<KanjiObject>();
            kanjidbDataContext dbConnection = new kanjidbDataContext();
            var result = from kanji in dbConnection.KANJI_TBLs select kanji;

            foreach (var kj in result)
            {
                KanjiObject eKanji = new KanjiObject((int)kj.ID, (string)kj.VOCABULARY, (string)kj.HIRAGANA,
                                            (string)kj.CHINESE, (string)kj.VIETNAMESE, (string)kj.LESSION_ID, (int)kj.STT);
                lstKanji.Add(eKanji);
            }

            return lstKanji;
        }
    }
}
