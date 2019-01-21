using Gemini.Framework.Commands;
using Gemini.Framework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LaborProject.Modules.GeTreeView.ViewModels;

namespace LaborProject.Modules.GeTreeView.Commands
{
    [CommandHandler]
    public class GeTreeViewCommandHandler : CommandHandlerBase<GeTreeViewCommandDefinition>
    {
        private readonly IShell _shell;

        [ImportingConstructor]
        public GeTreeViewCommandHandler(IShell shell)
        {
            _shell = shell;
        }

        public override Task Run(Command command)
        {
            _shell.ShowTool<GeTreeViewViewModel>();
            return Gemini.Framework.Threading.TaskUtility.Completed;
        }
    }
}
