/*
(c) Copyright ESRI.
This source is subject to the Microsoft Public License (Ms-PL).
Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
All other rights reserved.
*/

using System;
using System.Windows;

namespace ESRI.ArcGIS.Client.Application.Controls
{
    internal class ToolPanelLayoutStyleHelper
    {
        private ToolPanelLayoutStyleHelper() { }

        private static ToolPanelLayoutStyleHelper _instance;
        public static ToolPanelLayoutStyleHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ToolPanelLayoutStyleHelper();
                return _instance;
            }
        }

        public Style GetStyle(string styleName)
        {
            Style style = null;
            if (!string.IsNullOrEmpty(styleName))
            {
                if (LayoutManager.Current != null)
                    style = LayoutManager.Current.GetStyle(styleName);

                if (style == null)
                {
                    if (System.Windows.Application.Current != null &&
                        System.Windows.Application.Current.Resources != null &&
                        System.Windows.Application.Current.Resources.Contains(styleName))
                    {
                        style = System.Windows.Application.Current.Resources[styleName] as Style;
                    }

                    if (style == null && Resources != null)
                    {
                        if (Resources.Contains(styleName))
                            style = Resources[styleName] as Style;
                    }
                }
            }
            return style;
        }

        ResourceDictionary rd;
        private ResourceDictionary Resources
        {
            get
            {
                if (rd == null)
                {
                    rd = new ResourceDictionary();
                    rd.Source = new Uri("/ESRI.ArcGIS.Mapping.Windowing;component/ToolPanel/ToolPanel.Theme.xaml", UriKind.RelativeOrAbsolute);
                }

                return rd;
            }
        }
    }
}
