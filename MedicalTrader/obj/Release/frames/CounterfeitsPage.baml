   M S B A M L   `   `   `  ���� H  DMedicalTrader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MedicalTraderMedicalTrader  $    MedicalTrader.CounterfeitsPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:MedicalTrader     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  CounterfeitsPage��.���  � RowDefinitions �� $��* ��� $
��auto ��� $��* �.+�� $��0�� �� $��64 ��� $��55 ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $��Center=�$��Light"�$��0��$��0��$��20(�$��20q� $   MaterialDesignHeadline4TextBlock#��[  $.��(Фальсификат на складе���� -   $��Center=�+  %MaterialDesignThemes.Wpf.RippleAssist   Feedback �	#FF5693EA
 � Tag$ 2��  MaterialDesignFlatButton#��[ $��Все�����	#FF2F67B8�� $��Center=�{�.   �	#FF5693EA#��[ $��Фальсификаты�����	#FF2F67B8`� $��1��$��0��.�c� -    c�Name$ toolbarDrugs��  MaterialDesignToolBar#���  }�.  .@��� -    � ToolTip$ Сохрнаить�����	#99000000��0  *MaterialDesignThemes.Wpf.PackIconExtension  *ContentSave+�� �� -   $' !Добавить препарат�����	#99000000��     Kind$	 Add=��� �� -   $ Обновить�����	#99000000��  $ Refresh=��� �� ��  �� SelectedIndex$ 0�� �� .+��� $)��#MaterialDesignToolToggleFlatListBox���� $��Exclusive selection���� $A��;ListBoxAssist.IsToggle allows more natural toggle behaviour���� 	 �� SelectionMode$	 Extended=� �� .+��� $%��MaterialDesignToolToggleListBox���� $��Multiple selection���� $A��;ListBoxAssist.IsToggle allows more natural toggle behaviour���� $��Поиск по:��$��Center=��� -   
 ��Name$
 
SearchType��.@���  �� 
IsSelected . $��Наименованию���� $��Партии���� $��
Серии���� -    ��Name$ SearchField��$��1��$��8 0 0 0q�$
��30px��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Введите запрос��$��0q�$	��200��$��Center=��� -   $ 
Поиск����  *Search+�� �� $��2��$��0��._�&   System.Windows.Controls.DataGrid  -	     Name$ 
tableDrugs��   
IsReadOnly .    AutoGenerateColumns .  ��. $
��Auto=�$
��Auto=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   MaxWidth$ 86Q�   CellTemplate �� .R��� $) #Вернуть поставщику��   MaterialDesignOutlinedButton#��[ ��  *SwapHorizontalBold+ � DataContext ��  �� Path$ id�0  *System.Windows.Controls.DataGridTextColumn     Header$ id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� $ id�  $ 
Серия�� �� $ series�  $ Партия�� �� $ party�  $ Наименование�� �� $ nomenclature�  $ 
Склад�� �� $ 	warehouse�  $) #Серия изготовителя�� �� $ seriesManufacturer�  $' !Единица измерения�� �� $
 unit�  $ Изготовитель�� �� $ manufacturer�  $ Страна�� �� $ country�  $ Кол-во�� �� $ quantity�  $ Доступно�� �� $ availableQuantity�  $ Цена�� �� $ price�  $ Срок годности�� �� $ expirationDate�  $L FНомер регистрационного удостоверения�� �� $ 
certNumber��� $��2��$��0��$y�Hidden=�._�  -
   $ tableDrugsResults�� .  ��. $
��Auto=�$
��Auto=�.@�>   $ id�� �� $ id�  $ 
Серия�� �� $ series�  $ Партия�� �� $ party�  $ Наименование�� �� $ nomenclature�  $ 
Склад�� �� $ 	warehouse�  $ Изготовитель�� �� $ manufacturer�  $ Страна�� �� $ country�  $ Кол-во�� �� $ quantity�  $ Доступно�� �� $ availableQuantity�  $ Цена�� �� $ price�  $ Срок годности�� �� $ expirationDate�  $L FНомер регистрационного удостоверения�� �� $ 
certNumber��� $��1�� �� ShowsPreview . $��3��$��Stretch=�$��Center=�� $��2�� �� $��64 ��� $��55 ��� $��* �.+��� $��Light"�$��0��$��0��$��20(�$��20q�#��[  $L��FГосударственный реестр фальсификатов��`� $��1��$��0��.�c� -   $ toolbarClients��#���  }�.  .@��� -   $ Сохранить�����	#99000000��  *ContentSave+�� )	  #MaterialDesignThemes.Wpf.DialogHost	    MaterialDesignDivider#���   	  DialogContent � 
�������$	��300��$	��220��$��Center=� �� $
��auto ��� $��* ��� $
��50px �.+�� $��0�����	#FFF1F1F1.+��� $ 
Horizontal=�$��15q�.+��� $ 
Horizontal=�.+�'
  !MaterialDesignThemes.Wpf.PackIcon
   
  Kind$ DatabaseRefresh=����	#FF747474$��20��$��20���� $��Center=�
�������$	��200��$��15 0 0 0q�$
��Wrap=�42Какую именно базу обновить?�� $��1��$ Vertical=�$��Center=�$��Center=�$��27,23,27,22q�$	��246��.+��� $��5q� d� 	IsChecked$ falseY�$/��)Фальсифицированные ЛС��-  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 20Q����	#FF6C6C6C���	#FF6C6C6C�� $��5q�$ falseY�$#��Сомнительные ЛС��$ 20Q����	#FF6C6C6C���	#FF6C6C6C�� $��5q�$
 trueY�$1��+Недоброкачественные ЛС��$ 20Q����	#FF6C6C6C���	#FF6C6C6C�� $��Center=�$��2��$ 
Horizontal=�.+���  �	#FFE53935 	  CloseDialogCommand#��Z #��[ $��4q�$��Center=����	#FFE53935���	#FFE53935.��Отмена��  �	#FF56ADC7#��Z #��[ $��4q�$��Center=����	#FF56ADC7���	#FF56ADC7.��Продолжить.���� -    ��Name$ updateGRLSBtn�� 	  OpenDialogCommand#��Z $��	10 0 10 0q� �	#FF7FD4EE#��[ $< 6Удалить базу и скачать заново��$��Обновить базу�����	#FF56ADC7���	#FF56ADC7�� �� -   $$ SearchRegistryCounterfeitField��$��5 0 0 0q�$��Center=�$��1��$��	10 0 10 0q�$
��30px��$V PПоиск по наименованию / серии / изготовителю��$��0q�$	��200��$��Center=��� -   $ search��$ 
Поиск��
�������
���������  *Search+�� �� $��2��$��0��._�  -   $ tableRegistryCounterfeit�� .  .  ��. $
��Auto=�$
��Auto=�   $ id�� �� $ id�  $ Наименование�� �� $
 name�  $ Статус�� �� $ status�  $ 
Серия�� �� $ series�  $ Изготовитель�� �� $ manufacturer�  $ Страна�� �� $ country�  $ Масштаб�� �� $ scale�  $ Форма выпуска�� �� $ formRealease�  $ Справка�� �� $ documentUrl��� $��2��$��0��._�  -   $% tableRegistryCounterfeitResults�� . $y�Hidden=� .  ��. $
��Auto=�$
��Auto=�   $ 86Q�  $ id�� �� $ id�  $ Наименование�� �� $
 name�  $ Статус�� �� $ status�  $ 
Серия�� �� $ series�  $ Изготовитель�� �� $ manufacturer�  $ Страна�� �� $ country�  $ Масштаб�� �� $ scale�  $ Форма выпуска�� �� $ formRealease�  $ Справка�� �� $ documentUrl�