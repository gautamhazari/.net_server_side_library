SET folder=%~dp0

IF NOT EXIST %folder%secret-config.json EXIT /B
IF NOT EXIST %folder%original-config.json EXIT /B

attrib -R %folder%config.json
xcopy %folder%original-config.json %folder%config.json* /Y
del %folder%original-config.json /F /Q
