using System.ComponentModel.Composition;
using Caliburn.Micro;
//using LaborProject.Modules.Home.Commands;
using LaborProject.Modules.TestCmdWindow.ViewModels;
using Gemini.Framework;
using Gemini.Framework.Menus;


namespace LaborProject.Modules.TestCmdWindow
{
    [Export(typeof(IModule))]
    public class Module : ModuleBase
    {
        [Export]
        // public static MenuItemGroupDefinition ViewDemoMenuGroup = new MenuItemGroupDefinition(
        //    Gemini.Modules.MainMenu.MenuDefinitions.ViewMenu, 10);

        //public override IEnumerable<IDocument> DefaultDocuments
        //{
        //    get
        //    {
        //        yield return IoC.Get<HomeViewModel>();
        //    }
        //}

        public override void PostInitialize()
        {
            Shell.OpenDocument(IoC.Get<TestCmdWindowViewModel>());

        }
    }
}
