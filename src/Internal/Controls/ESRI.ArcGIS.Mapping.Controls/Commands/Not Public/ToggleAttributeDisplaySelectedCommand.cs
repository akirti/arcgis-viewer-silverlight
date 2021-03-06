/*
(c) Copyright ESRI.
This source is subject to the Microsoft Public License (Ms-PL).
Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
All other rights reserved.
*/

using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Extensibility;

namespace ESRI.ArcGIS.Mapping.Controls
{
    //[Export(typeof(ICommand))]
    //[Category("CategoryAttributeTable")]
    //[DisplayName("FilterBySelectionSelected")]
    //[Description("FilterBySelectionSelectedDescription")]
    public class ToggleAttributeDisplaySelectedCommand : LayerCommandBase, IToggleCommand
    {
        public ToggleAttributeDisplaySelectedCommand()
        {
            // need to know when the filter type changes on the Attribute Display
            if (View.Instance != null && View.Instance.AttributeDisplay != null)
            {
                View.Instance.AttributeDisplay.FilterBySelectionChanged -= AttributeDisplayFilterBySelectionChanged;
                View.Instance.AttributeDisplay.FilterBySelectionChanged += AttributeDisplayFilterBySelectionChanged;
            }
        }

        #region IToggleCommand Members

        public override bool CanExecute(object parameter)
        {
            if (Layer == null)
                return false;

            GraphicsLayer graphicsLayer = Layer as GraphicsLayer;
            if (graphicsLayer == null)
                return false;

            // needs to be features to enable this button
            bool anyGraphics = graphicsLayer.Graphics.Count() > 0;
            return (anyGraphics && View.Instance != null && View.Instance.AttributeDisplay != null &&
                    View.Instance.AttributeDisplay.HasFeatures);
        }

        public override void Execute(object parameter)
        {
            if (View.Instance != null && View.Instance.AttributeDisplay != null)
            {
                View.Instance.AttributeDisplay.FilterBySelection =
                        AttributeDisplay.FilterBySelectionTypeEnum.Selected;
            }
        }

        public bool IsChecked()
        {
            bool sts= (View.Instance != null
                    && View.Instance.AttributeDisplay != null
                    && View.Instance.AttributeDisplay.FilterBySelection ==
                        AttributeDisplay.FilterBySelectionTypeEnum.Selected);
            return sts;
        }

        #endregion

        private void AttributeDisplayFilterBySelectionChanged(object sender, EventArgs e)
        {
            RaiseCanExecuteChangedEvent(this, EventArgs.Empty);
        }
    }
}
