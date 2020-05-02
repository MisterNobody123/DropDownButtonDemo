using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DropDownButtonDemo.Controls.Utilities
{
    /// <summary>
    /// Provides utilities and properties for dropdown menus.
    /// </summary>
    public static class DropDownHelper
    {
        #region Public Members

        /// <summary>
        /// Callback for custom placement of the menu popup.
        /// </summary>
        public static CustomPopupPlacementCallback MenuPopupPlacementCallback => GetMenuPopupPlacements;

        #endregion Public Members

        #region Private Members

        /// <summary>
        /// Returns preferred placements of the menu popup.
        /// </summary>
        /// <param name="popupSize">The size of the menu popup.</param>
        /// <param name="targetSize">The Size of the placement target.</param>
        /// <param name="offset">The horizontal and vertical offset of the menu popup.</param>
        /// <returns>An array of possible placement positions for the menu popup, listed in order of preference.</returns>
        /// <remarks>
        /// Each placement describes the position of the top left corner of the menu popup
        /// relative to the top left corner of the target area.
        /// </remarks>
        private static CustomPopupPlacement[] GetMenuPopupPlacements(Size popupSize, Size targetSize, Point offset)
        {
            // Below and left-aligned to the placement target.
            CustomPopupPlacement bottomLeft = new CustomPopupPlacement(
                new Point(0, targetSize.Height), PopupPrimaryAxis.None);

            // Below and right-aligned to the placement target.
            CustomPopupPlacement bottomRight = new CustomPopupPlacement(
                new Point((targetSize.Width - popupSize.Width), targetSize.Height), PopupPrimaryAxis.None);

            // Above and left-aligned to the placement target.
            CustomPopupPlacement topLeft = new CustomPopupPlacement(
                new Point(0, -popupSize.Height), PopupPrimaryAxis.None);

            // Above and right-aligned to the placement target.
            CustomPopupPlacement topRight = new CustomPopupPlacement(
                new Point((targetSize.Width - popupSize.Width), -popupSize.Height), PopupPrimaryAxis.None);

            return new[] { bottomLeft, bottomRight, topLeft, topRight };
        }

        #endregion Private Members
    }
}
