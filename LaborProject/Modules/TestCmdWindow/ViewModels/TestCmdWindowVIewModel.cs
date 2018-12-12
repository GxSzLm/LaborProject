using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Gemini.Framework;
using Gemini.Framework.Services;

namespace LaborProject.Modules.TestCmdWindow.ViewModels
{
    [Export(typeof(TestCmdWindowViewModel))]
    public class TestCmdWindowViewModel : Document
    {
        public override string DisplayName
        {
            get { return "Command Window"; }
        }

        TestCmdWindowViewModel()
        {
            ;
        }
    }
}

