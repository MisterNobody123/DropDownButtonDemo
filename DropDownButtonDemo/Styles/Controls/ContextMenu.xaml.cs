using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DropDownButtonDemo.Styles.Controls
{
    /// <summary>
    /// Interaction logic for ContextMenu.xaml
    /// </summary>
    /// <remarks>
    /// Note that there is only one instance of this style at all times.
    /// Hence, no instance members are possible in this class!
    /// </remarks>
    public partial class ContextMenuStyle : ResourceDictionary
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ContextMenuStyle()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Event Handlers

        /// <summary>
        /// Event handler for the "Opened" event of the context menu.
        /// </summary>
        /// <param name="sender">The opened menu.</param>
        /// <param name="e">Event data.</param>
        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = (ContextMenu)sender;

            // Here, custom animations for "standalone" context menus can be added...
        }

        /// <summary>
        /// Event handler for the "Closed" event of the context menu.
        /// </summary>
        /// <param name="sender">The closed menu.</param>
        /// <param name="e">Event data.</param>
        private void ContextMenu_Closed(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = (ContextMenu)sender;

            // Here, additional handling for "standalone" context menus can be added...
        }

        #endregion Event Handlers
    }
}
