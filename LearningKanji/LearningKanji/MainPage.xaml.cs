using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel;
using LearningKanji.ServiceReference1;

namespace LearningKanji
{
    public partial class MainPage : UserControl
    {
        private ServiceReference1.KanjiServiceClient webService = new ServiceReference1.KanjiServiceClient();
        
        public MainPage()
        {
            webService.GetListKanjiCompleted += new EventHandler<GetListKanjiCompletedEventArgs>(webService_GetListKanjiCompleted);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            webService.GetListKanjiAsync();
        }
        public void webService_GetListKanjiCompleted(object sender, ServiceReference1.GetListKanjiCompletedEventArgs e)
        {
            
            List<KanjiObject> lstResult = e.Result.ToList<KanjiObject>();
        }
    }
}