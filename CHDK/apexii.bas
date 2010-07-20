@title Apex II 
@param a Interval in Seconds
@default a 5

:init
a=a*8
b=0
sleep 1000

:main
is_key k "remote"
if k=1 then goto "capture"
b=b+1
if b > a then goto "capture"
goto "main"

:capture
b=0
k=0
press "shoot_full"
set_focus 65535
set_zoom 0
sleep 900
release "shoot_full"
sleep 5000
goto "main"