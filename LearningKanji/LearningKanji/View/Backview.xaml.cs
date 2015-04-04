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
using LearningKanji.ServiceReference1;

namespace LearningKanji.View
{
    public partial class Backview : UserControl
    {
        KanjiObj displayKanji = null;
        public Backview()
        {
            InitializeComponent();
        }

        public Backview(KanjiObj inputCharacter)
        {
            InitializeComponent();
            this.displayKanji = inputCharacter;
            updateScreen();
        }

        // Update view
        private void updateScreen()
        {
            if (this.displayKanji != null)
            {
                this.txtChinese.Text = displayKanji._mHiragana;
                this.txtVietnamese.Text = displayKanji._mChinese;
            }
            UpdateLayout();
        }
        
    }
}
