   M S B A M L   `   `   `  ????K  GHackathonXAMLApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HackathonXAMLApp.ConvertersHackathonXAMLApp.Converters  5   	   3clr-namespace:HackathonXAMLAppHackathonXAMLApp  5   	   !    HackathonXAMLApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:HackathonXAMLApp.Converters     5   	   1local2clr-namespace:HackathonXAMLApp     5   	     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)    ? 	Resources 5      <   6HackathonXAMLApp.Converters.FoodXToVisibilityConverter   FoodXToVisibilityConverter@   :HackathonXAMLApp.Converters.FoodCheckToVisibilityConverter " FoodCheckToVisibilityConverter??%:   &	        &	        5   
   6+     5   
   6/   5       ? DataContext 5         HackathonXAMLApp.User  5   
   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5      ?? 5      $??20 ?6   ?? 5      $??* ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $??80 ?6   ?? 5      $??50 ?6   ?? 5      .+?5!   
   ?? -   5        $??Create Profile??5!      $??24(?5"      $??0??5#      $??0??5$      $	??160??5%      $??60??5&      5'      ?? 5(   
   $??Camera??6   $??4??5)      $??0??5*      $??24(?5+      $	??160??5,      $??60??5-      ?? 5.   
   $??FoodSafe??6   $??0??5/      $??1??50      $??3??51      $??Center=?52      $??Center=?53      $??60(?54      $??Italic$?55      ?? 56   
   $??1??6   $??0??57      $??2??58      ??59      ?? *
Profiles+ ?? UpdateSourceTrigger$ PropertyChanged=??? 5:   
    ?? Orientation$ 
Horizontal=?6   $??1??5;      $??3??5<      $??2??5=      .+?5>      ?? $??1??6   $??3??5?      $??Center=?5@      $??Center=?5A      $??24(?5B      $??Barcode:??5C      ?? 5D      $??1??6   $??4??5E      $??2??5F      $	??200??5G      $	??200??5H      ??5I      ?? *	Barcode+$ PropertyChanged=??? 5J      -   5         ??Name$	 Run??5J      $??Submit??5K      $??16(?5L      $??89??5M      5N      ?? 5O   
   $??2??6   $??0??5P      $??2??5Q      $ Vertical=?5R      .+?5S      ?? $ 
Horizontal=?6   .+?5T      ?? $??Food:??6   $??24(?5U      ?? 5V      $	??200??6   $	??250??5W      ??5X      ?? *
FoodName+5Y      ?? 5Z      $	??260??6   .+?5[      ?? $Y??SC:\Users\t321s\OneDrive\Documents\My Projects\HackathonXAMLApp\Images\checkMark.PNG??6    ?? Bottom$ 20??5\      	 ?? Left$	 80??5]      $
??Left=?5^      $	??227??5_      y?5`      ?? *
visibility+
 ?? 	Converter#
 [ ?? 5a      $V??PC:\Users\t321s\OneDrive\Documents\My Projects\HackathonXAMLApp\Images\errorX.PNG??6   $ 1??5b      $	 60??5c      $	??259??5d      $	??275??5e       K? ZIndex$ -1??5f      y?5g      ?? *
visibility+#
 [ 5h      5i      ?? 5k   
   $??2??6   $??3??5l      $??2??5m      $??Center=?5n      $	??Top=?5o      $??40??5p      $??Nutritional Information??5q      $??24(?5r      &   System.Windows.Controls.DataGrid  5s   
   $??2??6   $??3??5t      $??2??5u      $??0 40 0 0q?5v      5x      5y      5z      