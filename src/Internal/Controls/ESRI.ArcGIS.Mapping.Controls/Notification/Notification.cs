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
    public class Notification
    {
        public string Header { get; set; }
        public string Message { get; set; }
        public MessageType Type { get; set; }
        public string Details { get; set; }

        public override int GetHashCode()
        {
            return Message != null ? Message.GetHashCode() : base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Notification not = obj as Notification;
              
            return not != null && not.GetHashCode() == GetHashCode(); 
        }

    }
}
