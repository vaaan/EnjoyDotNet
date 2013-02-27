using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;

namespace EnjoyWPF
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    [ContentProperty("Children")]
    public partial class UserControl1 : UserControl
    {
        public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly(
               "Children",
               typeof(UIElementCollection),
               typeof(UserControl1),
               new PropertyMetadata());

        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty.DependencyProperty); }
            private set { SetValue(ChildrenProperty, value); }
        }

        public UserControl1()
        {
            InitializeComponent();
            Children = PART_Host.Children;
        }
    }
}
