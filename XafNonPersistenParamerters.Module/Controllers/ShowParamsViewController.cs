using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XafNonPersistenParamerters.Module.BusinessObjects;

namespace XafNonPersistenParamerters.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ShowParamsViewController : ViewController
    {
        PopupWindowShowAction ShowParamsWindows;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ShowParamsViewController()
        {
            InitializeComponent();
            ShowParamsWindows = new PopupWindowShowAction(this, "Show Params Window", "View");
            ShowParamsWindows.Execute += ShowParamsWindows_Execute;
            ShowParamsWindows.CustomizePopupWindowParams += ShowParamsWindows_CustomizePopupWindowParams;


            this.TargetObjectType = typeof(Directory);
            this.TargetViewType = ViewType.ListView;


            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        private void ShowParamsWindows_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
           
            var CurrentParams = e.PopupWindowViewCurrentObject as NonPersistentParams;
            var dir=this.View.ObjectSpace.CreateObject<Directory>();
            dir.Name= CurrentParams.Name;
            dir.Category= this.View.ObjectSpace.GetObject<Category>(CurrentParams.Category);
            foreach (DirectoryParams directoryParams in CurrentParams.DirectoryParams)
            {
               dir.Params.Add(this.View.ObjectSpace.GetObject<DirectoryParams>(directoryParams));
            }
            this.View.ObjectSpace.CommitChanges();
            this.View.Refresh(true);

          
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        private void ShowParamsWindows_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var Os = this.Application.CreateObjectSpace(typeof(NonPersistentParams));
            var Params = Os.CreateObject<NonPersistentParams>();
            e.View = this.Application.CreateDetailView(Os, Params);
            // Set the e.View parameter to a newly created view (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
