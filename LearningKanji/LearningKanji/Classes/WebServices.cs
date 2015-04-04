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
using LearningKanji.ServiceReference1;
using System.Collections.Generic;


namespace LearningKanji.Classes
{
    public class WebServices
    {
        private ServiceReference1.KanjiServiceClient webService = new ServiceReference1.KanjiServiceClient();
        public List<KanjiObj> lstResult = null;
        public string _mLessionID = string.Empty;
        private Dictionary<int, string> _mLessionManager = new Dictionary<int, string>();

        public WebServices()
        {
            webService.GetListKanjiCompleted += new EventHandler<GetListKanjiCompletedEventArgs>(webService_GetListKanjiCompleted);
            webService.GetLessionNameCompleted += new EventHandler<GetLessionNameCompletedEventArgs>(webService_GetLessionNameCompleted);
            // Query to get all database.
            webService.GetLessionNameAsync();
        }


        // Get lession name
        public void webService_GetLessionNameCompleted(object sender, ServiceReference1.GetLessionNameCompletedEventArgs e)
        {
            _mLessionManager = e.Result;
        }
        public string GetLessionName(int iLessionID)
        {
            string strResult = string.Empty;
            if (_mLessionManager.Count > 0 && _mLessionManager.ContainsKey(iLessionID))
                strResult = _mLessionManager[iLessionID].ToString();
            return strResult;
        }

        // Return all of kanji.
        public void webService_GetListKanjiCompleted(object sender, ServiceReference1.GetListKanjiCompletedEventArgs e)
        {
            lstResult = e.Result;
        }

        public List<ServiceReference1.KanjiObj> GetListKanji()
        {
            webService.GetListKanjiAsync();
            if (lstResult != null) return lstResult;
            return null;
        }


    }
}
