   M S B A M L   `   `   `  ���� G  CLaborProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:LaborProject.Modules.TestCmdWindow.Views(LaborProject.Modules.TestCmdWindow.Views  A =Gemini, Version=0.7.0.0, Culture=neutral, PublicKeyToken=nullW8clr-namespace:Gemini.Framework.Behaviors;assembly=GeminiGemini.Framework.Behaviors @    :LaborProject.Modules.TestCmdWindow.Views.TestCmdWindowView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Hlocal6clr-namespace:LaborProject.Modules.TestCmdWindow.Views     N	behaviors8clr-namespace:Gemini.Framework.Behaviors;assembly=Gemini     
�������.���   � ColumnDefinitions  �� �� �� ��  � RowDefinitions �� �� ����  �� Color �� *
Background+ �� FallbackValue$ White��.+��� -    ��Name$ 	TreePanel��$��0��$��0��$��Stretch=�$��0q�$��Stretch=�.+�R� -    R�Name$ treeView��$��0q�
�������$��0q�$��Stretch=�$��Stretch=�.@�Q� $
��Port��$
��Auto��.@�Q� -   $��
Tree_Port0��$��Port0��Q� -   $��
Tree_Port1��$��Port1��Q� -   $��
Tree_Port2��$��Port2��Q� -   $��
Tree_Port3��$��Port3���� -   $��ButtonPanel��$��1��$��0��$	��Top=�$��0q�.+��� $��Center=�.��AREA 1�� -   $��OpenComButton��$��Hit__To__Open__COM��$��5q��� -	   $��InitializeButton��$��Hit__To__Initialize��$��5q��� -
    ��Name$ ResetButton��$��Hit__to__Reset��$��5q��� -   $ 
TestButton��$��Hit__to__Test��$��5q� J� RenderTransformOrigin$ 	0.501,0.5&��� -   $ TestButton2��$��Hit__to__Test2��$��5q�$ 	0.501,0.5&��� -   $��OutputWindow��$��3��$��Center=�$��10,10,10,10q�$��24(�$
��Wrap=� �� TextAlignment �� *TextAlignment+$ Center������ *Text+&$This is the Prototype of the Project����  �� *
Foreground+$ Black���� -   $��
TheTextBox��$��2��$��10q�	 �� 
IsReadOnly	 . "
 �� VerticalScrollBarVisibility$

 Auto=�
�������.��输出内容显示区域�� 
�������$��0 0 1 0q��� $��4��
�������$��0 0 0 1q��� $��Center=�$��0��$��1��$��4��.��AREA 2: Port Area�� -   $��
Port0Panel��$��0��$��1��$��4��$��Stretch=�$��Stretch=�$��0q�$y�Hidden=�.+��� -    ��Name$ textBlock_Port0_Name��$
��Wrap=�$��Port 0��$��0,0,0,10q��� -   $ textBlock_Port0_Ip��$
��Wrap=�$��
IP Address��$��0q��� �� -   $ textBlock_Port0_Mac��$
��Wrap=�$��Mac Address��$��0q��� �� -   $��
Port1Panel��$��0��$��1��$��4��$��Stretch=�$��Stretch=�$��0q�$y�Hidden=�.+��� -   $ textBlock_Port1_Name��$
��Wrap=�$��Port 1��$��0,0,0,10q��� -   $ textBlock_Port1_Ip��$
��Wrap=�$��
IP Address��$��0q��� �� -   $ textBlock_Port1_Mac��$
��Wrap=�$��Mac Address��$��0q��� �� -   $��
Port2Panel��$��0��$��1��$��4��$��Stretch=�$��Stretch=�$��0q�$y�Hidden=�.+��� -   $ textBlock_Port2_Name��$
��Wrap=�$��Port 2��$��0,0,0,10q��� -   $ textBlock_Port2_Ip��$
��Wrap=�$��
IP Address��$��0q��� �� -   $ textBlock_Port2_Mac��$
��Wrap=�$��Mac Address��$��0q��� �� -   $��
Port3Panel��$��0��$��1��$��4��$��Stretch=�$��Stretch=�$��0q�$y�Hidden=�.+��� -   $ textBlock_Port3_Name��$
��Wrap=�$��Port 3��$��0,0,0,10q��� -   $ textBlock_Port3_Ip��$
��Wrap=�$��
IP Address��$��0q��� �� -   $ textBlock_Port3_Mac��$
��Wrap=�$��Mac Address��$��0q��� 