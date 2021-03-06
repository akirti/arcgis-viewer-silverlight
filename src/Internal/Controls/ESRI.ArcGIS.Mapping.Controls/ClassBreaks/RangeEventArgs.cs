/*
(c) Copyright ESRI.
This source is subject to the Microsoft Public License (Ms-PL).
Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
All other rights reserved.
*/

using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ESRI.ArcGIS.Mapping.Controls
{
    public class BaseEventArgs : EventArgs
    {
        public Rectangle ClickedRectangle { get; set; }
        public Slider LowSlider { get; set; }
        public Slider HighSlider { get; set; }
    }

    public class SliderClickedEventArgs : BaseEventArgs
    {

    }

    public class AddRangeCommandEventArgs : BaseEventArgs
    {

    }

    public class DeleteRangeCommandEventArgs : BaseEventArgs
    {

    }
}
