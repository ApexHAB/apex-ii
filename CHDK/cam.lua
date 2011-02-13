--[[
          cam.lua
          
          functions taken from - 
          fbonomi's library of lua functions for CHDK
          
          Copyright 2008 Francesco Bonomi.
          Released under GPL
          
          v. 1.2 2008-08-17
 ]]


propcase=require("propcase")
 
 cam = {}
 
 -- convert seconds to APPROXIMATE tv96 values
 -- in: only whole seconds, in range 1 to 65
 -- out: approximate tv96 value (calculated with integer math in steps of 12)
 function cam.sec_to_tv96(sec)
  local tv96, sec1000, countsec
  
  tv96=0
 
  sec=util.check_range(sec,1,65)
   
  sec1000=sec*1000
  countsec=1000
  
  while countsec<sec1000 do
   countsec=(countsec*1091)/1000
   tv96=tv96-12
  end
  
  return tv96
 end

 
 -- convert seconds/1000 to APPROXIMATE tv96 values
 -- in: , in range 1 to 65.000 
 -- (but for larger values, better use sec_to_tv96 above)
 -- out: approximate tv96 value (calculated with integer math in steps of 12)
 function cam.sec1000_to_tv96(sec1000)
  local tv96, secM, countsec
  
  tv96=960
  
  sec1000=util.check_range(sec1000,1,65000)
   
  secM=sec1000*1000
  countsec=1000
  
  while countsec<secM do
   countsec=(countsec*1091)/1000
   tv96=tv96-12
  end
  
  return tv96
 end

   
 -- convert ISO to APPROXIMATE sv96 values
 -- in: ISO, in range 50 to 2100 (higher values would give an overflow)
 -- note to self: implement workaround to allow ISO>2100, with lesser precision
 -- out: approximate sv96 value (calculated with integer math in steps of 12)
 function cam.ISO_to_sv96(ISO)
  local sv96, ISO1000, countISO
  
  sv96=323

  ISO=util.check_range(ISO,50,2100)  
   
  ISO1000=ISO*1000
  countISO=50000
  
  while countISO<ISO1000 do
   countISO=(countISO*1091)/1000
   sv96=sv96+12
  end
  
  return sv96
 end


--sets exposure time, film speed, and focus while returning brightness and aperture values
function cam.smartShoot(tv,sv,focusDistance)
	-- Shoot: Half press and wait until camera is ready
  press("shoot_half")
  repeat 
    sleep(1)
  until get_shooting() == true
  --not sure what good this does
  local bv=get_bv96()
  local av=get_av96()
  
  --init aperture and exposure
  if(tv ~= nil)then set_prop(propcase.TV,tv) end
  if(sv ~= nil)then set_prop(propcase.SV,sv) end
  
  set_focus(subjdist)
  press("shoot_full")
  release("shoot_full")
  release("shoot_half")
  repeat
    sleep(1)
  until get_shooting() ~= true
  return bv, av
end