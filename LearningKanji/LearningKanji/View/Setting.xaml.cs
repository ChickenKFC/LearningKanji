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

namespace LearningKanji.View
{
    public partial class Setting : ChildWindow
    {
        Dictionary<int, string> mDicManagement = null;

        /// <summary>
        /// Index of lession
        /// </summary>
        public int indexLession {get;set;}
        /// <summary>
        /// Flag for mode Random or Order
        /// TRUE: Random
        /// FALSE: Order
        /// </summary>
        public bool isMode { get; set; }
        /// <summary>
        /// Flag for view lession or not 
        /// TRUE: view Lession name
        /// FALSE: Don't view lession name
        /// </summary>
        public bool isViewLession { get; set; }

        public Setting()
        {
            InitializeComponent();
            indexLession = 0;
            isMode = true;
            isViewLession = true;
            mDicManagement = new Dictionary<int, string>();
        }
        public Setting(Dictionary<int,string> dicManagement, bool mode, bool viewLession, int iLession)
        {
            InitializeComponent();
            
            isMode = mode;
            if (isMode == true)
            {
                radRandom.IsChecked = true;
            }
            else
            {
                radOrder.IsChecked = true;
            }

            isViewLession = viewLession;

            if (isViewLession == true)
            {
                radTrue.IsChecked = true;
            }
            else
            {
                radFalse.IsChecked = true;
            }

            mDicManagement = dicManagement;

            foreach (KeyValuePair<int, string> kvp in mDicManagement)
            {
                cmbLession.Items.Add(kvp.Value);
            }

            indexLession = iLession;
            cmbLession.SelectedIndex = indexLession;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            //Set lession
            indexLession = cmbLession.SelectedIndex;

            // Set mode 
            if (radRandom.IsChecked == true)
            {
                isMode = true;
            }
            else
            {
                isMode = false;
            }

            // Set View lession
            if (radTrue.IsChecked == true)
            {
                isViewLession = true;
            }
            else
            {
                isViewLession = false;
            }

            this.DialogResult = true;
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

