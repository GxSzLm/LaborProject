using Gemini.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborProject.Modules.GeTreeView.Commands
{
    [CommandDefinition]
    public class GeTreeViewCommandDefinition : CommandDefinition
    {
        public const string CommandName = "GeTreeView";

        public override string Name
        {
            get { return CommandName; }
        }

        public override string Text
        {
            get { return "全部节点"; }
        }

        public override string ToolTip
        {
            get { return "全部节点"; }
        }
    }
}
