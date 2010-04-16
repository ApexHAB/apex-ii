@title Interval shooting
@param a Shoot count
@default a 5
@param b Interval (Minutes)
@default b 0
@param x Def
@default x 3
@param r Focus Distance
@default r 65535

rem Max focus value is likely max word variable value (65535)

:run1

set_zoom 0


 do
      a = get_usb_power
   until a>0 
   if a > 10 then gosub "capture" 
wend


:capture
get_focus x
:run2
if x <> 65536
click "up"
endif
rem print x
rem print r
click "shoot_full"
rem get_focus x
rem print x

cls

goto "run1"

end