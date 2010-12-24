require "propcase"
require "capmode"
print("Hello CHDK !")

--[[
@title APEX II 2.00.1 BETA
@param a Interval in Seconds
@default a 1
 
based on APEX II 1st Launch Script
http://chdk.setepontos.com/index.php/topic,2646.0.html
set_backlight(0)
--]]

logfile=io.open("A/FLIGHTLOG.log","wb")
io.output(logfile)

function timerwait()
    for i=0,a do
        sleep(1)
    end
    capture()
end

repeat
    timerwait()
until false

function set_focus_status(n)
    if get_propset() == 2 then
        set_prop(6,n -1)
    else
        set_prop(11,n -1)
    end
end

function capture()
    press("shoot_half")
    set_focus_status(25535)
    log("shooting...")
    --get battery voltage
    --get temps
    --log("tbat",tbat,"tccd",tccd,"vbat",vbat)
    press("shoot_full")
    release("shoot_full")
    release("shoot_half")
end

function vbatt()
    props=require("propcase")
    tv=get_prop(props.TV)

end

function gtime()
    ttime=get_time("D,h,m,s")
    log(ttime)
end

function gtemp()
    ftemp = get_temperature(0)
    log(ftemp)
     ftemp = get_temperature(1)
    log(ftemp)
     ftemp = get_temperature(2)
    log(ftemp)
end
  
logfile=io.open("A/FLIGHTLOG.log","wb")
io.output(logfile)
 
function log(...)
    io.write(...)
    io.write("\n")
end

end
log("done!")
logfile:close()

