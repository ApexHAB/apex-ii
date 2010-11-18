{\rtf1\ansi\ansicpg1252\cocoartf1038\cocoasubrtf320
{\fonttbl\f0\fmodern\fcharset0 Courier;}
{\colortbl;\red255\green255\blue255;}
\paperw11900\paperh16840\margl1440\margr1440\vieww9000\viewh8400\viewkind0
\deftab720
\pard\pardeftab720\ql\qnatural

\f0\fs24 \cf0 print("Hello CHDK\'a0!")\
\
\pard\pardeftab720
\cf0 --[[\
@title APEX II 2.00.1 BETA\
@param a Interval in Seconds\
@default a 1\
\'a0\
based on APEX II 1st Launch Script\
http://chdk.setepontos.com/index.php/topic,2646.0.html\
\pard\pardeftab720\ql\qnatural
\cf0 set_backlight(0)\
\pard\pardeftab720
\cf0 --]]\
\
\pard\pardeftab720\ql\qnatural
\cf0 logfile=io.open("A/FLIGHTLOG.log","wb")\
io.output(logfile)\
\pard\pardeftab720
\cf0 \'a0\
repeat\
\pard\pardeftab720\ql\qnatural
\cf0 wait_click(key_delay)\
  if is_pressed "remote" then\
   capture()\
  end\
until false\
\pard\pardeftab720
\cf0 \
\pard\pardeftab720\ql\qnatural
\cf0 function set_focus_status(n)\
\'a0 \'a0 if get_propset() == 2 then\
\'a0 \'a0 \'a0 \'a0 set_prop(6,n -1)\
\'a0 \'a0 else\
\'a0 \'a0 \'a0 \'a0 set_prop(11,n -1)\
\'a0 \'a0 end\
end\
\
\pard\pardeftab720
\cf0 function capture()\
  press("shoot_half")\
  set_focus_status(25535)\
  log("shooting...")\
<<< get battery voltage\
<<< get temps\
<<< log("tbat",tbat,"tccd",tccd,"vbat",vbat)\
  press("shoot_full")\
  release("shoot_full")\
  release("shoot_half")\
  repeat\
    sleep(1)\
  until get_shooting() ~= true\
end\
\'a0\'a0\
logfile=io.open("A/FLIGHTLOG.log","wb")\
io.output(logfile)\
\'a0\
function log(...)\
	io.write(...)\
	io.write("\\n")\
end\
\'a0\
\'a0\
\
end\
log("done!")\
logfile:close()\
}