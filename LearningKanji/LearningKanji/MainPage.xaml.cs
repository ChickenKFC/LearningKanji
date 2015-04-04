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
using LearningKanji.View;
using LearningKanji.ServiceReference1;
using LearningKanji.Classes;
using System.Threading;

namespace LearningKanji
{
    public partial class MainPage : UserControl
    {
        private ServiceReference1.KanjiServiceClient webService = new ServiceReference1.KanjiServiceClient();
        private Dictionary<int, string> _mLessionManager = new Dictionary<int, string>();
        private LessionObject LessionManager = new LessionObject();
        Thread workerThread;

        private bool isOrder = false;

        // For setting
        /// <summary>
        /// Flag for view lession or not 
        /// TRUE: view Lession name
        /// FALSE: Don't view lession name
        /// </summary>
        private bool isViewLession = true;
        /// <summary>
        /// Flag for mode Random or Order
        /// TRUE: Random
        /// FALSE: Order
        /// </summary>
        private bool isMode = false;
        /// <summary>
        /// Index of lession
        /// </summary>
        private int indexLession = 0;

        public MainPage()
        {
            InitializeComponent();
            this.isOrder = false;
        }

        private void webService_GetLessionNameCompleted(object sender, GetLessionNameCompletedEventArgs e)
        {
            _mLessionManager = e.Result;
            if (this.LessionManager._mLessionID != 0)
            {
                this.LessionManager._mLessionName = _mLessionManager[this.LessionManager._mLessionID];
            }
        }
        public void webService_GetListKanjiCompleted(object sender, GetListKanjiCompletedEventArgs e)
        {
            this.LessionManager.PushKanjiList(e.Result);
            this.LessionManager._mCurrentKanji = -1;
            if (this.LessionManager._mLessionID != 0)
            {
                this.LessionManager._mLessionName = _mLessionManager[this.LessionManager._mLessionID];
            }
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {

            Setting setting = new Setting(_mLessionManager, isMode, isViewLession, indexLession);

            setting.Show();

            setting.Closed += (s, eargs) =>
            {
                if (setting.DialogResult == true)
                {
                    isMode = setting.isMode;
                    isViewLession = setting.isViewLession;
                    indexLession = setting.indexLession;
                }
            };
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {

            if (this.LessionManager._mKanjiManage == null || this.LessionManager._mKanjiManage.Count == 0) return;

            if (isOrder == false)
            {
                if (this.LessionManager._mCurrentKanji < this.LessionManager._mKanjiManage.Count - 1)
                {
                    this.LessionManager._mCurrentKanji += 1;
                }
                else
                {
                    this.LessionManager._mCurrentKanji = this.LessionManager._mKanjiManage.Count - 1;
                }

            }
            else
            {
                this.LessionManager._mCurrentKanji = new Random().Next(0, this.LessionManager._mKanjiManage.Count - 1);
            }


            FrontView frontView = new FrontView(this.LessionManager.GetCurrentKanji());
            if (showPannel.Children.Count > 0)
            {
                // remove current childrent of showPannel
                showPannel.Children.Clear();
            }
            // Add new children.
            showPannel.Children.Add(frontView);
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            if (this.LessionManager._mKanjiManage == null || this.LessionManager._mKanjiManage.Count == 0) return;

            if (isOrder == false)
            {
                if (this.LessionManager._mCurrentKanji > 0)
                {
                    this.LessionManager._mCurrentKanji -= 1;
                }
                else
                {
                    this.LessionManager._mCurrentKanji = 0;
                }

            }
            else
            {
                this.LessionManager._mCurrentKanji = new Random().Next(0, this.LessionManager._mKanjiManage.Count - 1);
            }


            // Get kanji

            FrontView frontView = new FrontView(this.LessionManager.GetCurrentKanji());
            if (showPannel.Children.Count > 0)
            {
                // remove current childrent of showPannel
                showPannel.Children.Clear();
            }
            // Add new children.
            showPannel.Children.Add(frontView);
        }

        private void showPannel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserControl currentView = (UserControl)this.showPannel.Children.ElementAt(0);
            double actualWidth = showPannel.ActualWidth;
            double actualHeight = showPannel.ActualHeight;

            if (e.GetPosition(showPannel).X <= (actualHeight * 0.3) || e.GetPosition(showPannel).X >= (actualHeight * 0.6))
            {
                UserControl showScreen;
                // transition to new page.
                if (this.LessionManager._mKanjiManage.Count == 0) return;

                if (currentView is FrontView)
                {
                    showScreen = new Backview(this.LessionManager.GetCurrentKanji());
                }
                else
                {
                    showScreen = new FrontView(this.LessionManager.GetCurrentKanji());
                }


                if (showPannel.Children.Count > 0)
                {
                    // remove current childrent of showPannel
                    showPannel.Children.Clear();
                }
                // Add new children.
                showPannel.Children.Add(showScreen);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.workerThread = new Thread(startToFetchDatabase);
            this.workerThread.Start();
        }

        // Start to get data from database.
        public void startToFetchDatabase()
        {
            webService.GetListKanjiCompleted += new EventHandler<GetListKanjiCompletedEventArgs>(webService_GetListKanjiCompleted);
            webService.GetLessionNameCompleted += new EventHandler<GetLessionNameCompletedEventArgs>(webService_GetLessionNameCompleted);
            webService.GetListKanjiAsync();
            webService.GetLessionNameAsync();
        }
    }
}