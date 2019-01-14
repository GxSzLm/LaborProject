using System.ComponentModel.Composition;
using Caliburn.Micro;
//using LaborProject.Modules.Home.Commands;
using LaborProject.Modules.TestCmdWindow.ViewModels;
using Gemini.Framework;
using Gemini.Framework.Menus;
using Gemini.Modules.Output;

namespace LaborProject.Modules.TestCmdWindow
{
    [Export(typeof(IModule))]
    public class Module : ModuleBase
    {
        //[Export]
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
            Shell.ShowTool<IOutput>();      // 用来确保软件打开时输出窗口是显示在界面中的。也许应该放到某个地方的Activate方法中。
        }
    }
}
