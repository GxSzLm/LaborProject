   M S B A M L   `   `   `  ����G  CLaborProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:LaborProject.Modules.TestCmdWindow.Views(LaborProject.Modules.TestCmdWindow.Views  5      A =Gemini, Version=0.7.0.0, Culture=neutral, PublicKeyToken=nullW8clr-namespace:Gemini.Framework.Behaviors;assembly=GeminiGemini.Framework.Behaviors 5      @    :LaborProject.Modules.TestCmdWindow.Views.TestCmdWindowView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:LaborProject.Modules.TestCmdWindow.Views     5      N	behaviors8clr-namespace:Gemini.Framework.Behaviors;assembly=Gemini     5      
�������.��5      �   � ShowGridLines  . $��0,0,0,0q�6     � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   ��5   
   �� 5       �� Color 6   �� *
Background+ �� FallbackValue$ White��.+�5   
   �� -   5        $��Panel1��5      $��0��5      $��0��6%   $	��Top=�5      $��0q�5      .+�5      �� $��Center=�6   .��61   AREA 169   �� 5      -   5        $��OpenComButton��5      $��Hit__To__Open__COM��5      $��5q�5      5       �� 5!      -   5        $��InitializeButton��5!      $��Hit__To__Initialize��5"      $��5q�5#      5$      �� 5&      -   5         ��Name$ ResetButton��5&      $��Hit__to__Reset��5'      $��5q�5(      5)      �� 5*      -   5         ��Name$ listBox��5*      .@�5+      �� -   5         ��Name$ 	PortList1��5+       �� 
IsSelected . .��6D   Port16K   �� 5,      -   5        $ 	PortList2��5,      .��62   Port269   5-      5.      �� 50   
   -   5        $��OutputWindow��50      $��2��51      $��Center=�52      $��10,10,10,10q�6#   $��24(�53      $
��Wrap=�54      	 �� TextAlignment	 51   $   �� *TextAlignment+$ Center����53      �� *Text+&$This is the Prototype of the Project��56      �� 57       6"   �� *
Foreground+$ Black��59      �� 5;   
   -	   5        $��
TheTextBox��5;      $��1��5<      $��10q�6"   
 �� 
IsReadOnly
 . " �� VerticalScrollBarVisibility$
 Auto=�5>      
�������.��5?   %   输出内容显示区域5B      5C      5D      