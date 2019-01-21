using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
//using LaborProject.Modules.Home.Commands;
using LaborProject.Modules.GeTreeView.ViewModels;
using Gemini.Framework;
using Gemini.Framework.Menus;
//using Gemini.Modules.PropertyGrid;

namespace LaborProject.Modules.GeTreeView
{
    [Export(typeof(IModule))]
    public class Module : ModuleBase
    {
        public override void PostInitialize()
        {
            //IoC.Get<IPropertyGrid>().SelectedObject = IoC.Get<HomeViewModel>();
            //Shell.OpenDocument(IoC.Get<GeTreeViewViewModel>());
            Shell.ShowTool<GeTreeViewViewModel>();
        }
    }
}