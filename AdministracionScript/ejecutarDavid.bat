@echo off

sqlcmd -i scriptEliminarProcedure.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlexpress
sqlcmd -i ScriptAuxiliares.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlexpress
sqlcmd -i ScriptProcedures.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlexpress
sqlcmd -i ScriptFunciones.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlexpress
sqlcmd -i ScriptProcesos.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlexpress
sqlcmd -i ScriptNovedades.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlexpress
sqlcmd -i ScriptDavid.sql -U usuarioadmin -P usuarioadmin -S localhost\sqlexpress
pause