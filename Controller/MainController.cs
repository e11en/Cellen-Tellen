using Finan.Controller;
using Finan.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finan.Controller
{
    /// <summary>
    /// The heart of the program. The different views and controllers are initialize here.
    /// </summary>
    public class MainController
    {
        public MainForm mainForm;

        //Models
        public ArrayList resultList;
        public ConnectionModel dbConnection;
        
        //Views
        public ResultView resultView;
        public InleesView inleesView;
        public MainView mainView;
        public LoadMapView loadMapView;
        public AdminLoginView adminLoginView;
        public StatisticView statisticView;

        //Controllers
        public FileController fileSelectController;
        public InleesViewController inleesViewController;
        public MainViewController mainViewController;
        public ResultController resultController;
        public ResultDialogController resultDialogController;
        public ColonyController colonyController;
        public StatisticController statisticController;

        //Other___________________________________________________
        /// <summary>
        /// Boolean to see if the current user is logged in as an administrator. True indicated that the user is logged in as administrator. 
        /// False indicates a normal user. Administrators have more options than normal users.
        /// </summary>
        public bool isAdministrator = false;
        // RESULT LIST FOR ALL PICTURES IN PANEL
        public List<ResultModel> resultModelList;

        /// <summary>
        /// Constructor for the MainController.
        /// </summary>
        public MainController()
        {
            Initialize();
        }

        /// <summary>
        /// All the variables are initialized here.
        /// </summary>
        private void Initialize()
        {
            //Other
            this.resultModelList = new List<ResultModel>();
            this.resultList = new ArrayList();

            //Model
            dbConnection = new ConnectionModel();

            //View
            this.mainForm = new MainForm();
            this.mainView = new MainView(this);
            this.adminLoginView = new AdminLoginView();
            this.inleesView = new InleesView(this);
            this.resultView = new ResultView(this);
            this.loadMapView = new LoadMapView(this);
            this.statisticView = new StatisticView(this);

            //Controller
            this.mainViewController = new MainViewController(this);
            this.inleesViewController = new InleesViewController(this);
            this.resultController = new ResultController(this);
            this.resultDialogController = new ResultDialogController(this);
            this.colonyController = new ColonyController();
            this.fileSelectController = new FileController(this);
            this.statisticController = new StatisticController(this);

            // ADD INLEESVIEW AND RESULTVIEW TO MAINVIEW
            this.mainViewController.AddToPage(inleesView, 0);
            this.mainViewController.AddToPage(resultView, 1);
            this.mainViewController.AddToPage(statisticView, 2);
            this.mainForm.Controls.Add(mainView);
            this.mainView.Dock = DockStyle.Fill;
            this.resultView.Dock = DockStyle.Fill;
            this.statisticView.Dock = DockStyle.Fill;

            // START APP
            Application.EnableVisualStyles();
            Application.Run(mainForm);
        }
    }
}
