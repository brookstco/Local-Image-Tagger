   M S B A M L   `   `   `  ����K  GLocalImageTagger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LocalImageTaggerLocalImageTagger  5   	   M+clr-namespace:LocalImageTagger.UserControlsLocalImageTagger.UserControls  5   	   R NWpf.Controls.PanAndZoom, Version=2.3.3.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:Wpf.Controls.PanAndZoom;assembly=Wpf.Controls.PanAndZoomWpf.Controls.PanAndZoom 5   	   "    LocalImageTagger.ImageViewer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LocalImageTagger     5   	   :uc+clr-namespace:LocalImageTagger.UserControls     5   	   VpazFclr-namespace:Wpf.Controls.PanAndZoom;assembly=Wpf.Controls.PanAndZoom     5   	     � Title$#  Local Image Tagger Image View��5
   	   ��5   	   ��  �� Path$ WindowHeight� �� Mode$ TwoWay=���5   	   �� $ WindowWidth�$ TwoWay=���5   	   �� *WindowMinimumHeight+��63   �� *WindowMinimumWidth+ � Left 5   	   �� *
WindowLeft+$ TwoWay=�
 � Top 62   �� *	WindowTop+$ TwoWay=� � WindowStyle 5   	   �� *WindowStyle+ � WindowState 5   	   �� *WindowState+ � 	Resources 5         BoolToVisibility��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5       $��* �6   	 � ColumnDefinitions	 5"   
   �� 5#      $
��Auto �6   �� 5$      $��* �6   .+�5'   
   ]� .+�5(      �� $
��Left=�6   y�6/   �� *SidebarVisible+
 �� 	Converter#
 [  .+�5+      �� Tag6!   �� 5-      $��90��6�   ��6   �� *ButtonRenderContent+ � ToolTip 6A   �� *ButtonRenderToolTip+��6i   �� *SwapRenderingMode+6�   �� 5.      $��_Fullscreen��6   $ Toggle Fullscreen��6/   $��90��6p   ��6K   �� *ToggleFullscreen+6p   �� 5/      $��
_Open With��6   $" Open in another application.��6.   $��90��6r   ��6U   �� *
OpenWith+6r   50      51      �� 53   
   $	��Top=�6x   
������ $��15��55      $��15��6    K� ZIndex$ 3��6(   ��53      �� *OpenCloseSidebar+��67   �� *" ButtonSidebarHorizontalAlignment+��54   *   Z� ��6A   �� *ButtonSidebarColumn+.��56      �� $)��#/Images/arrows/arrow_black_left.png��6   $
��None=�6A    J� RenderTransformOrigin$ 0.5,0.5&�6P   z�57      �� 58       �� ScaleX 6%   �� *ButtonSidebarDirection+5:      5;      .   (LocalImageTagger.UserControls.ZoomBorder  5=   
   $
}�True��6   $��Stretch=�5>      $��Stretch=�65   $��2��5?         Child. 5@      �� $��Uniform=�6-   $
��Left=�6?   $	��Top=�6Z   ��6   �� *Image+ �� BitmapScalingMode 6r   �� *RenderingBitmapScalingMode+5A      5B      5D      