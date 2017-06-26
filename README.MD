# ChildrensGame

This application is programmed in Windows Form MVP pattern to separating concerns and enabling unit testing ability.  The presenter’s constructor would take a IView and IRepository. This means the program can plug in any class that implements IView or IRepository and be able to display data on the new view and get/set data for the new data repository. 

There are possible two (or more) ways to solve the children's game problem. Using recursive methods or collections. The former would take more time but consume less memory and the latter would consume more memory but take less time.
