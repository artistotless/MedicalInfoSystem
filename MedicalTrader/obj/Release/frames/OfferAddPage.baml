   M S B A M L   `   `   `  ���� H  DMedicalTrader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MedicalTraderMedicalTrader       MedicalTrader.OfferAddPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:MedicalTrader     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  OfferAddPage��.���� 1  +MaterialDesignThemes.Wpf.ScrollViewerAssist   IsAutoHideEnabled . $��1��$��Disabled=�$
��Auto=�.��� ���#F5F5F5 � ColumnDefinitions �� $��* ��� $
��auto ��� $��* � � RowDefinitions �� $
��65px ��� $��* �.+��� 
�������._��� -    ��Name$ titleBox��$��Light"�$��0��$��0��$��20(�$��20q� $   MaterialDesignHeadline4TextBlock#��[  $H��BСоздание коммерческого предложения���� 
�������$��0��$��2��._��� -    ��Name$ applyBtn��+  %MaterialDesignThemes.Wpf.RippleAssist   Feedback �	#FF8CEE81   MaterialDesignOutlinedButton#��[ $	��130��$��Right=�$��0 0 20 0q�$��Создать�����	#FF60C756���	#FF61C756� $��1��$��0�� �� $��80 ��� $	��140 ��� $��64 ��� $��* �.+��� $��	15 0 15 0q�$��0��$	��Top=�._��� -    ��Name$ 	nameOffer��$��Center=�$��	0 15 0 15q�$��50�� ! MaterialDesignOutlinedTextBox#��[ )  #MaterialDesignThemes.Wpf.HintAssist   Hint$- 'Наименование офффера��	 �� 
CaretBrush	 �	#FFB2B2B2���	#35FFFFFF���	#33000000�� -   $ 
descrOffer��$��1��$	��Top=�
 �� AcceptsReturn
 .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$��	15 0 15 0q�$	��100��#��[ $ Описание�����	#33FFFFFF���	#33000000`� $��2��$��0��.�c� -    c�Name$ toolbarDrugs��  MaterialDesignToolBar#���  }�.  .@��� -    � ToolTip$ Обновить�����	#99000000��0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Refresh=��� �� ��  �� SelectedIndex$ 0�� �� .+��� $)��#MaterialDesignToolToggleFlatListBox���� $��Exclusive selection���� $A��;ListBoxAssist.IsToggle allows more natural toggle behaviour����  �� SelectionMode$ Extended=� �� .+��� $%��MaterialDesignToolToggleListBox���� $��Multiple selection���� $A��;ListBoxAssist.IsToggle allows more natural toggle behaviour���� $��Поиск по:��$��Center=��� -    ��Name$ 
SearchType��.@���  �� 
IsSelected . $��Наименованию���� $��Партии���� $��
Серии���� -   $ SearchField��$��1��$��8 0 0 0q�$
��30px��$! Введите запрос��$��0q�$	��200��$��Center=��� -	   $ 	searchBtn��$ 
Поиск����  *Search+�� �� $��3��$��0��._�&   System.Windows.Controls.DataGrid  -
     Name$ 
tableDrugs��   
IsReadOnly .    AutoGenerateColumns .  ��. $
��Auto=�$
��Auto=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   MaxWidth$	 100Q�   CellTemplate �� .R�)  #MaterialDesignThemes.Wpf.DialogHost    MaterialDesignDivider#���     DialogContent � 
�������$	��300��$	��220��$��Center=� �� $
��auto ��� $��* ��� $
��50px �.+�� $��0�����	#FFF1F1F1.+���  �� Orientation$ 
Horizontal=�$��15q�.+��� $ 
Horizontal=�.+��� $��Center=�
�������$	��200��$��15 0 0 0q�$
��Wrap=�1/Введите кол-во препаратов�� $��1��$ Vertical=�$��Center=�$��Center=�$��27,23,27,22q�$	��246��.+��� $ count��$��5q�$��50��#��[ $ Кол-во��	 �	#4CB2B2B2���	#33FFFFFF���	#33000000�� $��Center=�$��2��$ 
Horizontal=�.+���  �	#FFE53935   CloseDialogCommand#��Z #��[ $��4q�$��Center=����	#FFE53935���	#FFE53935.��Отмена�� -    �	#FF56ADC7#��Z #��[ $��4q�$��Center=����	#FF56ADC7���	#FF56ADC7
 � Tag ��  �� ElementName$ count�� �� Path$
 Text�.��Добавить.���� $ updateGRLSBtn��    OpenDialogCommand#��Z  $��	10 0 10 0q� �	#FF7FD4EE#��[ $$ Добавить в оффер�����	#FF56ADC7���	#FF56ADC7��  *Add+0	  *System.Windows.Controls.DataGridTextColumn	  !   Header$! id��1
  +System.Windows.Controls.DataGridBoundColumn" 
  Binding" �� $ id�	  $! 
Серия��" �� $ series�	  $! Партия��" �� $ party�	  $! Наименование��" �� $ nomenclature�	  $! 
Склад��" �� $ 	warehouse�	  $)! #Серия изготовителя��" �� $ seriesManufacturer�	  $'! !Единица измерения��" �� $
 unit�	  $! Изготовитель��" �� $ manufacturer�	  $! Страна��" �� $ country�	  $! Кол-во��" �� $ quantity�	  $! Доступно��" �� $ availableQuantity�	  $! Цена��" �� $ price�	  $! Срок годности��" �� $ expirationDate�	  $L! FНомер регистрационного удостоверения��" �� $ 
certNumber��� $��3��$��0��$y�Hidden=�._�  -   $ tableDrugsResults�� .  ��. $
��Auto=�$
��Auto=�.@�>   $ 86Q� �� .R��� -   $$ Добавить в оффер��#��[ ��  *Add+# � DataContext# �� $ id�	  $! id��" �� $ id�	  $! 
Серия��" �� $ series�	  $! Партия��" �� $ party�	  $! Наименование��" �� $ nomenclature�	  $! 
Склад��" �� $ 	warehouse�	  $! Изготовитель��" �� $ manufacturer�	  $! Страна��" �� $ country�	  $! Кол-во��" �� $ quantity�	  $! Доступно��" �� $ availableQuantity�	  $! Цена��" �� $ price�	  $! Срок годности��" �� $ expirationDate�	  $L! FНомер регистрационного удостоверения��" �� $ 
certNumber��� ���	#FF616161$��1��$��1��$ �� ShowsPreview$ . $��1��$��Center=�$��Stretch=�� $��1��$��2�� �� $��80 ��� $��64 ��� $��* �.+��� -   $ 
clientList��$��	15 0 15 0q�$��0�����	#33FFFFFF���	#33000000 " MaterialDesignOutlinedComboBox#��[ $% Выберите клиента��{��� $ 	IsChecked�$% OutlinedComboBoxEnabledCheckBox���� $��	20 0 0 20q�$��Bottom=�$��1�� ! MaterialDesignButtonTextBlock#��[ $1��+Предложенные препараты�����	#FF818181�� $��2��._�  -   $ tableOfferDrugs�� .  .  ��. $
��Auto=�$
��Auto=�   $ 86Q� �� .R��� -   $&  Удалить из оффера�����	#FFE53935���	#FFE53935#��[ ��  *TrashCanOutline+# �� $ id�	  $! Наименование��" �� $ nomenclature�	  $! Кол-во��" �� $ quantity�	  $! Цена��" �� $ price�	  $! Изготовитель��" �� $ manufacturer�	  $! Страна��" �� $ country�	  $! Партия��" �� $ party�	  $! id��" �� $ id�