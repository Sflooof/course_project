﻿#pragma checksum "..\..\..\Pages\Game_detail.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5528C9DB5EEC4C1D1D8F6FABB6BEB9A2DA55CDE2BDE844BC636D436E74BAD180"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Games.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Games.Pages {
    
    
    /// <summary>
    /// Game_detail
    /// </summary>
    public partial class Game_detail : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Pages\Game_detail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bt_back;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\Game_detail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Img_photo;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\Game_detail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock name;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\Game_detail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock category;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Pages\Game_detail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock manufacturer;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\Game_detail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock description;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\Game_detail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock equipment;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\Game_detail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock release_year;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\Game_detail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock cost;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Games;component/pages/game_detail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Game_detail.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Bt_back = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Pages\Game_detail.xaml"
            this.Bt_back.Click += new System.Windows.RoutedEventHandler(this.Bt_back_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Img_photo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.name = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.category = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.manufacturer = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.description = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.equipment = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.release_year = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.cost = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

