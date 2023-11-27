echo copying unmanaged dependencies to AeroServer output dir...
echo * projectdir %1
echo * configurationname %2
echo * targetdir %3
echo * platformtarget %4

echo %1Sources\Help.html
echo Target dir %3
echo ********************************************
copy "%1Sources\Help.html" %3 