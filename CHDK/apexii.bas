@title Apex II 
@param a Interval in Seconds
@default a 30

:init
print "Interval:",a,"secs"
a=a*8
print "(";a;")"
b=0
sleep 1000

:main
print "Time:",b
wait_click 1
is_key k "remote"
if k=1 then print "remote"
if k=1 then goto "capture"
b=b+1
if b > a then print "auto"
if b > a then goto "capture"
goto "main"

:capture
b=0
print "capturing..."
press "shoot_full"
set_focus 65535
set_zoom 0
sleep 900
release "shoot_full"
sleep 5000
goto "main"