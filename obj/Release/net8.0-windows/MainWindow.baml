   M S B A M L   `   `   `  ���� D  @Stopwatch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:StopwatchAppStopwatchApp      StopwatchApp.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:StopwatchApp       � WindowStyle$
  None=� � AllowsTransparency$
 True��
������ $	��316��$	��221��$	��316��$	��221�� � Title$ 	StopWatch��$	��316��$	��221�����	#FFD4D4D4 � Icon$K EC:\Users\BeanZ\source\repos\Stopwatch\Stopwatch\Resources\favicon.ico��'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�   ResizeBorderThickness$ 5q�.����  �� CornerRadius$ 8��$��4q�����  �� 
StartPoint$
 0, 0&�	 �� EndPoint$
	 1 ,1&�.���    LightGSBackground
 � Color#
 �   ._�� ���� $
 0, 0&�$
	 1 ,1&�.��� #
 �    � RowDefinitions �� $��19 ���  � ContextMenu �� $��0q�$��10(�$��0q�$��90��  LightBackground#���    LightForeground#���  .@�m� -   $��0q�$��90��$	��5,2q�$��Light Theme��#���  #���  ����  �� 
TargetType" m�.R�� #���  .+��� #���  ._��� $��Header��$��2q�m� -   $��0q�$��90��$	��5,2q�$��
Dark Theme��#���  #���  ���� " m�.R�� #���  .+��� #���  ._��� $��Header��$��2q�m� -   $��0q�$��90��$	��5,2q�$��Amoled Theme��#���  #���  ���� " m�.R�� #���  .+��� #���  ._��� $��Header��$��2q�����  �� 
TargetType" m� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� Property � �� �� Value
 � � �m� -   $��0q�$��90��$	��5,2q�$��	Red Theme��#���  #���  ���� " m�.R�� #���  .+��� #���  ._��� $��Header��$��2q�.+��� -    ��Name$ AlwaysOnTopIndicator��$��aot.png��$
��Left=�$��Center=�$��	186,0,0,0q�$��37��$��35��$y�	Collapsed=��� -    ��Name$ lstTimestamps��#���  $��0q�$��48,88,48,28q�$��1��$��Hidden=�$��Hidden=�$��Yu Gothic UI)�$��10(�#���   J� OpacityMask �� $	 0,0&�$		 0,1&�.��� $
 White�� � Offset$ 0Q�� $
 White��$	 0.7Q�� $
 Transparent��$ 1Q����� .R�� $��Stretch=�$��Center=�.+���  J� Opacity$ 1Q�$��Center=�$��Center=� �� TextAlignment$ Center=����� z�T� translateTransform�� � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  W� From -5	 W� To 0 g� Duration$ 0:0:0.3D� �� 
TargetName$ translateTransform��  �� TargetProperty$  Y�W�  0 1$ 0:0:0.5D�$  Opacity��� -   $��0��
������ �� -   $
��Left=�$��Center=�$��2,0,0,0q�$��9��$��9�����#fc5753���� " ��.R�� .+��� ! ��Name$! border1��#��z��$ 50���� $��Center=�$��Center=�" �� Triggers" P�  �@J�IsMouseOver$
 True��. ��� # �� 
TargetName$# border1�� � �� �#993532�� -	   $�� ��$
��Left=�$��Center=�$��16,0,0,0q�$��9��$��9�����#fdbc40���� " ��.R�� .+��� $! border��#��z��$ 50���� $��Center=�$��Center=�" P�  �@J�IsMouseOver$
 True��. ��� $# border�� � �� �#c79330�� -
   $ ��Name$$ lblMin��$��00��$
��Left=�$��	60,10,0,0q�$	��Top=�$��1��#���  #���  $��30(�$��50��$��47��$��Verdana)��� -   $$ lblSec��$��00��$
��Left=�$��
104,10,0,0q�$	��Top=�$��1��#���  #���  $��30(�$��50��$��54��$��Verdana)��� -   $$ lblCs��$��00��$
��Left=�$��
112,41,0,0q�$	��Top=�$��1��
������ #���  $��23(�$��34��$��44��$��verdana)�� -   % �Name$% progressBar��$��1��$��3��$	��Top=�$��	48,6,48,0q�
������ ���� " �.���  � ��
 �  �� �� & �� Binding& �� *
IsActive+' �� Value' True( N� EnterActions( �� .���� .��W� $  Value� 0 100$ 0:0:5D��� -   ) ��Name$) BtnStartStop��$��Center=�$	��Top=�$��	0,226,0,0q�$��35��$��35��#���  $��1������ " ��.R�� .+��� $! border��#���  $ 50���� * ��Name$* contentPresenter��$��Center=�$��Center=�F� + F�Name$+ BtnStartStopIcon��"����        р��@x}�    ���	#���  , �� Stretch$, Uniform=�$��10��$��10��$��0,-1,0,0q�" P�  �@J�IsMouseOver$
 True��. ��� $# border�� ! LightMouseOverBackgroundColor# �   � ���� $# BtnStartStopIcon�� ! LightMouseOverForegroundColor# �   � ���� -   $$ 	lblParent��$��:��$��Center=�$��0,16,0,0q�$��1��$	��Top=�#���  $��31��$��17(�$��14���� -   $) BtnReset��$
��Left=�$	��Top=�$��
54,233,0,0q�$��20��$��20��#���  #���  $��1��$��RESET��$��7(����� " ��.R�� .+��� $! border��#��z��$ 50��F� $+ 	resetIcon��  	ResetIcon#��[ #���  $��Center=�$��Center=�$, Uniform=�$��10��$��10��" P�  �@J�IsMouseOver$
 True��. ��� $# 	resetIcon��# �   � ���� $# border��# �   � ���� -   $) BtnAddTimestamp��$y�	Collapsed=�$
��Left=�$��Bottom=�$��
139,0,0,36q�$��20��$��20��#���  #���  $��1��$��7(����� " ��.R�� .+��� $! border��#��z��$ 50���� $* contentPresenter��$	��LAP��$��Center=�$��Center=�" P�  �@J�IsMouseOver$
 True��. ��� $# contentPresenter��# �   � ���� $# border��# �   � ��