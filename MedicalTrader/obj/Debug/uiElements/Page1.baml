   M S B A M L   `   `   `  ����H  DMedicalTrader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MedicalTrader.uiElementsMedicalTrader.uiElements  5      $    MedicalTrader.uiElements.Page1   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:MedicalTrader.uiElements     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
     N� Title$  Page1��5
      .��5      � 
�������$	��300��6   $	��220��6+   $��Center=�68    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��50px �6   .+�5   
   � $��0��6   ���	#FFF1F1F1.+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��15q�60   .+�5      �� $ 
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ DatabaseRefresh=�6*   ���	#FF747474$��20��6Z   $��20��6e   �� 5      $��Center=�6   
�������$	��200��6I   $��15 0 0 0q�6U   $
��Wrap=�6g   42Какую именно базу обновить?5      5      5      5      �� 5   
   $��1��6   $ Vertical=�6#   $��Center=�6:   $��Center=�6W   $��27,23,27,22q�6r   $	��246��6�   .+�5      �� $��5q�6    d� 	IsChecked$ falseY�5      $/��)Фальсифицированные ЛС��5       -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 20Q�5!      ���	#FF6C6C6C���	#FF6C6C6C6L   �� 5"      $��5q�6   $ falseY�5#      $#��Сомнительные ЛС��5$      $ 20Q�5%      ���	#FF6C6C6C���	#FF6C6C6C6L   �� 5&      $��5q�6   $
 trueY�5'      $1��+Недоброкачественные ЛС��5(      $ 20Q�5)      ���	#FF6C6C6C���	#FF6C6C6C6L   5,      �� 5-   
   $��Center=�6   $��2��62   $ 
Horizontal=�6?   .+�5/      �� {�. )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 6&       MaterialDesignOutlinedButton#��[  6h   $��4q�6�   $��Center=�6�   ���	#FFE53935���	#FFE53935.��6�   Отмена51      �� 52      #��Z 6   #��[  6W   $��4q�6�   $��Center=�6�   ���	#FF56ADC7���	#FF56ADC7.��6�   Продолжить54      55      56      57      