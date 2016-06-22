SET folder=%~dp0

IF NOT EXIST %folder%secret-config.json EXIT /B

attrib -R %folder%config.json
xcopy %folder%config.json %folder%original-config.json* /Y
xcopy %folder%secret-config.json %folder%config.json* /Y
