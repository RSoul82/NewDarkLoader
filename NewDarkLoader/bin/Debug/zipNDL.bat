set zpath="C:\Program Files\7-Zip\7z.exe"
set zfile=NewDarkLoader1.6.0.zip

if exist %zfile% del %zfile%

%zpath% a -tzip %zfile% 7z.dll
%zpath% a -tzip %zfile% NAudio.dll
%zpath% a -tzip %zfile% NewDarkLoader.dll
%zpath% a -tzip %zfile% SevenZipSharp.dll
%zpath% a -tzip %zfile% readme.html
%zpath% a -tzip %zfile% c:\games\thief2\fms\english.ini