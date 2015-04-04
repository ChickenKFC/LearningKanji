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
using LearningKanji.Classes;
using LearningKanji.ServiceReference1;

namespace LearningKanji.View
{
    public partial class FrontView : UserControl
    {
        private ServiceReference1.KanjiObj KanjiObj;

        private KanjiObj _mCharacters { get; set; }

        private WebServices webservice;

        public FrontView()
        {
            InitializeComponent();
            webservice = new WebServices();
        }

        public FrontView(ServiceReference1.KanjiObj KanjiObj)
        {
            InitializeComponent();

            webservice = new WebServices();
            // TODO: Complete member initialization
            this.KanjiObj = KanjiObj;
            // Update screen
            updateScreen();
        }

        private void updateScreen()
        {
            this.txtCharacters.Text = KanjiObj._mVocabulary.ToString();
            this.lblLessionName.Text = KanjiObj._mLessionName;
            UpdateLayout();
        }
    }
}
