using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DropDownButtonDemo.Controls
{
    /// <summary>
    /// Represents a button with a dropdown menu from which the user can select one of multiple commands.
    /// </summary>
    [ContentProperty("Content")]
    [TemplatePart(Name = "PART_Button", Type = typeof(ToggleButton))]
    [TemplatePart(Name = "PART_ButtonContent", Type = typeof(ContentControl))]
    [TemplatePart(Name = "PART_Menu", Type = typeof(ContextMenu))]
    public class DropDownButton : ItemsControl
    {
        #region Dependency Properties

        /// <summary>
        /// Gets or sets the layout orientation of the dropdown button.
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Orientation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(DropDownButton), new PropertyMetadata(Orientation.Horizontal));

        /// <summary>
        /// Gets or sets a value which indicates whether the menu popup is shown.
        /// </summary>
        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsExpanded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(DropDownButton), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets the content displayed on the dropdown button.
        /// </summary>
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(DropDownButton), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the data template used to display the content of the dropdown button.
        /// </summary>
        public DataTemplate ContentTemplate
        {
            get { return (DataTemplate)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentTemplateProperty =
            DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(DropDownButton), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a template selector that enables an application writer to provide custom template-selection logic.
        /// </summary>
        public DataTemplateSelector ContentTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty); }
            set { SetValue(ContentTemplateSelectorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentTemplateSelector.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentTemplateSelectorProperty =
            DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(DropDownButton), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a composite string that specifies how to format the content property if it is displayed as a string.
        /// </summary>
        public string ContentStringFormat
        {
            get { return (string)GetValue(ContentStringFormatProperty); }
            set { SetValue(ContentStringFormatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentStringFormat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentStringFormatProperty =
            DependencyProperty.Register("ContentStringFormat", typeof(string), typeof(DropDownButton), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the style of the dropdown button.
        /// </summary>
        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(DropDownButton), new PropertyMetadata(default(Style)));

        /// <summary>
        /// Gets or sets the style of the menu popup.
        /// </summary>
        public Style MenuStyle
        {
            get { return (Style)GetValue(MenuStyleProperty); }
            set { SetValue(MenuStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuStyleProperty =
            DependencyProperty.Register("MenuStyle", typeof(Style), typeof(DropDownButton), new PropertyMetadata(default(Style)));

        /// <summary>
        /// Gets or sets the element relative to which the menu popup is positioned when it opens.
        /// </summary>
        public UIElement MenuPlacementTarget
        {
            get { return (UIElement)GetValue(MenuPlacementTargetProperty); }
            set { SetValue(MenuPlacementTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuPlacementTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuPlacementTargetProperty =
            DependencyProperty.Register("MenuPlacementTarget", typeof(UIElement), typeof(DropDownButton));

        #endregion Dependency Properties

        #region Private Members

        private ContextMenu _ContextMenu;
        private ToggleButton _ToggleButton;

        /// <summary>
        /// Removes a child element from the logical and visual tree of the dropdown button.
        /// </summary>
        /// <param name="element">The element to be removed.</param>
        private void DetachChildElement(object element)
        {
            if (element is Visual visual)
            {
                FrameworkElement logicalParent = LogicalTreeHelper.GetParent(visual) as FrameworkElement;
                FrameworkElement visualParent = VisualTreeHelper.GetParent(visual) as FrameworkElement;
                FrameworkElement parent = logicalParent ?? visualParent;

                /// Verify that the element is a child of the dropdown button
                /// before attempting to remove it from the logical and visual tree
                /// (removal is only possible for own child elements).
                if (Equals(parent, this))
                {
                    RemoveLogicalChild(visual);
                    RemoveVisualChild(visual);
                }
            }
        }

        /// <summary>
        /// Moves an item, which has been specified at top level, to the dropdown menu.
        /// </summary>
        /// <param name="item">The item to be moved.</param>
        private void MoveItemToMenu(object item)
        {
            /// The item already has a logical parent (DropDownButton) and needs to be detached first
            /// before it can be added to an other element (ContextMenu).
            this.DetachChildElement(item);
            _ContextMenu.Items.Add(item);
        }

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Static constructor.
        /// </summary>
        static DropDownButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DropDownButton), new FrameworkPropertyMetadata(typeof(DropDownButton)));
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DropDownButton()
        {
            // Subscribe to "Loaded" event.
            Loaded += DropDownButton_Loaded;
        }

        #endregion Constructors

        #region Event Handlers

        /// <summary>
        /// Invoked as soon as the defined control template is applied to the dropdown button.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _ToggleButton = GetTemplateChild("PART_Button") as ToggleButton;
            _ContextMenu = GetTemplateChild("PART_Menu") as ContextMenu;

            /// If an ItemsSource is set on the DropDownButton,
            /// the ContextMenu automatically binds to that source via TemplateBinding.
            /// If no ItemsSource is used, menu items can be declared on the DropDownButton.
            /// In this case, the items need to be moved from the top level to the ContextMenu.
            if (this.ItemsSource == null && this.Items != null)
                foreach (object item in this.Items)
                    MoveItemToMenu(item);
        }

        /// <summary>
        /// Event handler for the "Loaded" event of the dropdown button.
        /// </summary>
        /// <param name="sender">The loaded dropdown button instance.</param>
        /// <param name="e">Event data.</param>
        private void DropDownButton_Loaded(object sender, RoutedEventArgs e)
        {
            // Subscribe to "Opened" event of the context menu.
            _ContextMenu.Opened += ContextMenu_Opened;
        }

        /// <summary>
        /// Invoked whenever the items of the dropdown button are changed.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            // Ignore event if instance has not been loaded yet.
            if (!this.IsLoaded) { return; }

            /// Ignore change if the items originate from an ItemsSource.
            /// In this case, the ContextMenu automatically binds to that source via TemplateBinding.
            if (this.ItemsSource != null) { return; }

            switch (e.Action)
            {
                // Items added to the top level need to be moved to the ContextMenu.
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                        foreach (object addedItem in e.NewItems)
                            MoveItemToMenu(addedItem);
                    break;

                // Items removed from the top level can simply be removed from the ContextMenu as well.
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                        foreach (object removedItem in e.OldItems)
                            _ContextMenu.Items.Remove(removedItem);
                    break;

                /// Items replaced within the top level need to be removed from the ContextMenu,
                /// while the replacement items need to be moved to the ContextMenu.
                /// Items moved within the top level need to be moved in the ContextMenu accordingly.
                /// Note that a Move operation is logically treated as a Remove followed by an Add.
                case NotifyCollectionChangedAction.Move:
                case NotifyCollectionChangedAction.Replace:

                    if (e.OldItems != null)
                        foreach (object oldItem in e.OldItems)
                            _ContextMenu.Items.Remove(oldItem);

                    if (e.NewItems != null)
                        foreach (object newItem in e.NewItems)
                            MoveItemToMenu(newItem);

                    break;

                /// If the items were cleared from the top level, the ContextMenu can simply be cleared as well.
                /// Items which were newly set in the process need to be moved to the ContextMenu.
                case NotifyCollectionChangedAction.Reset:
                    if (this.Items != null)
                    {
                        _ContextMenu.Items.Clear();
                        foreach (object item in this.Items)
                            MoveItemToMenu(item);
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(e.Action));
            }
        }

        /// <summary>
        /// Event handler for the "Opened" event of the dropdown menu.
        /// </summary>
        /// <param name="sender">The opened menu.</param>
        /// <param name="e">Event data.</param>
        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = (ContextMenu)sender;

            Thickness originalMargin = contextMenu.Margin;
            contextMenu.Margin = new Thickness(
                contextMenu.Margin.Left, 0, contextMenu.Margin.Right, contextMenu.Margin.Bottom);

            NameScope.SetNameScope(this, new NameScope());

            TranslateTransform translation = new TranslateTransform();
            RegisterName("TranslateTransform", translation);

            contextMenu.RenderTransform = translation;

            DoubleAnimation translationAnimation = new DoubleAnimation()
            {
                From = -20,
                To = 0,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseOut, Power = 3 }
            };

            Storyboard.SetTargetProperty(translationAnimation, new PropertyPath(TranslateTransform.YProperty));
            Storyboard.SetTargetName(translationAnimation, "TranslateTransform");

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(translationAnimation);

            storyboard.Completed += new EventHandler((animation, eventArgs) =>
            {
                contextMenu.Margin = originalMargin;
            });

            storyboard.Begin(this);

            // Prevents the "Opened" event in the ContextMenu style from firing.
            e.Handled = true;
        }

        /// <summary>
        /// Event handler for right mouse button click events.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonUp(e);

            /// Stop event propagation.
            /// This prevents the context menu from being opened via right click on the button.
            e.Handled = true;
        }

        /// <summary>
        /// Event handler for keyboard events.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.Key == Key.Apps)
            {
                /// Stop event propagation.
                /// This prevents the context menu from being opened via the menu/application key.
                e.Handled = true;
            }
        }

        #endregion Event Handlers
    }
}
