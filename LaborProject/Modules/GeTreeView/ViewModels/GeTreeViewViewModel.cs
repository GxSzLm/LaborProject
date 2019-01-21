using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Gemini.Framework;
using Gemini.Framework.Services;
using System.Collections.ObjectModel;

using LaborProject.Modules.GePort;
using Caliburn.Micro;
using LaborProject.Models;
using LaborProject.Modules.GePort.ViewModels;

namespace LaborProject.Modules.GeTreeView.ViewModels
{
    [DisplayName("GeTree View Model")]
    [Export]
    class GeTreeViewViewModel : Tool, ITool
    { 
        public override PaneLocation PreferredLocation
        {
            get
            {
                return PaneLocation.Left;
            }
        }

        public override double PreferredWidth
        {
            get
            {
                return base.PreferredWidth;
            }
        }

        public override double PreferredHeight
        {
            get
            {
                return 300;
            }
        }

        public GeTreeViewViewModel()
        {
            DisplayName = "端口列表";

            DoubleClickCommand = new RelayCommand(this.OpenPortWindow);
            Node_Ports = new ObservableCollection<TesterPortVM>();
            //
            TesterPortVM[] Port = new TesterPortVM[4]
            {
                new TesterPortVM(0),
                new TesterPortVM(1),
                new TesterPortVM(2),
                new TesterPortVM(3)
            };

            Node_Ports.Add(Port[0]);
            Node_Ports.Add(Port[1]);
            Node_Ports.Add(Port[2]);
            Node_Ports.Add(Port[3]);
        }



        public override bool ShouldReopenOnStart
        {
            get { return true; }
        }

        public ObservableCollection<TesterPortVM> Node_Ports { get; set; }


        public RelayCommand ExpandCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }


        #region UI Functions
        public void OpenPortWindow(object parameter)
        {
            var shell = IoC.Get<IShell>();
            //shell.OpenDocument(PortInstance.ThePortViewModels[(int)parameter]);
            shell.OpenDocument(PortVMInstance.ThePortViewModels[0]);

            //var shell = IoC.Get<IShell>();
            //shell.OpenDocument(new HomeViewModel());


        }
        #endregion

    }

    public class TesterPortVM
    {
        public TesterPortVM(int id)
        {
            Leaf_PortParameter = new ObservableCollection<TesterPortParameterVM>();
            PortId = id;
            PortIdStr = PortId.ToString();

            TesterPortParameterVM a = new TesterPortParameterVM(ParameterType.Address);
            Leaf_PortParameter.Add(a);

        }
        public int PortId { get; private set; }
        public string PortIdStr { get; private set; }

        public ObservableCollection<TesterPortParameterVM> Leaf_PortParameter { get; set; }
    }

    public class TesterPortParameterVM
    {
        public ParameterType Type { get; set; }

        public TesterPortParameterVM(ParameterType tp)
        {
            Type = tp;
        }
    }

    public enum ParameterType
    {
        Address,
    }
}


