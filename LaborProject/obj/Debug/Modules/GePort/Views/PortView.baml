   M S B A M L   `   `   `  ����A  =Gemini, Version=0.7.0.0, Culture=neutral, PublicKeyToken=nullW8clr-namespace:Gemini.Framework.Behaviors;assembly=GeminiGemini.Framework.Behaviors  5      G CLaborProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:LaborProject.Modules.GePort.Views!LaborProject.Modules.GePort.Views 5      0   *LaborProject.Modules.GePort.Views.PortView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N	behaviors8clr-namespace:Gemini.Framework.Behaviors;assembly=Gemini     5      Alocal/clr-namespace:LaborProject.Modules.GePort.Views     5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      ��5   
   �� 5       �� Color$ White��6   .+�5   
   �� -   5         ��Name$ groupBox��5      $��端口信息��6%   $��5q�63   $��Stretch=�5      $��Stretch=�6/   .��5      �� $��Stretch=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Stretch=�66   .+�5      �� $
��Wrap=�6    $��
Port ID : ��64   $��0,0,0,10q�6F   �� 5      -   5         ��Name$ Content_PortId��5       $
��Wrap=�68   $��0,0,0,10q�6L   ��6^   �� *Content_PortId+5      �� 5       -   5        $ Text_PortIp��5       $
��Wrap=�61   $��
IP Address��6E   $��0q�5!      �� 5"       �� 
IsReadOnly . ��6,   �� *Content_PortIp+�� 5#      $y�Hidden=�6   �� 5$      -   5        $ Text_PortMac��5$      $
��Wrap=�62   $��Mac Address��6F   $��0q�5%      �� 5&       . ��6,   �� *Content_PortMac+�� 5'      -   5         ��Name$ 
TestButton��5'      $��Center=�6-   $��Center=�6H   $��20��6e   $��20��6q   5)      5*      5+      5.      5/      