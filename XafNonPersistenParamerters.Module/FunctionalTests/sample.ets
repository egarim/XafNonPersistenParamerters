;#DropDB XafNonPersistenParamertersEasyTest

#Application XafNonPersistenParamertersWin
#Application XafNonPersistenParamertersBlazor

*FillForm
 User Name = Admin
*Action Log In

#IfDef XafNonPersistenParamertersWin

*Action About...
 
*Action OK

#EndIf

#IfDef XafNonPersistenParamertersBlazor
*Action Navigation(My Details)
#EndIf
