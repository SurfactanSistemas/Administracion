@echo off

sqlcmd -i scriptEliminarProcedure.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlserver2008
sqlcmd -i ScriptAuxiliares.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlserver2008
sqlcmd -i ScriptProcedures.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlserver2008
sqlcmd -i ScriptFunciones.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlserver2008
sqlcmd -i ScriptProcesos.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlserver2008
sqlcmd -i ScriptNovedades.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlserver2008
sqlcmd -i ScriptDavid.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlserver2008
pause