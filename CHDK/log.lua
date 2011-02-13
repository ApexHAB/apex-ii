--[[
  Log file handling. Uses io functions if they are available, otherwise print().

  Usage:
  
    require "f-log"
    log.open("my_log.txt")
    log.print("A quick brown fox etc.\n")
    log.close()
  
  Author: fudgey 2008/10/27
  Licence: GPL v3 or higher
--]]

--require "date" -- for datetimestamp()
--require "disk"

log={}

-- If io.* are available, open log CHDK/LOGS/name for append. If name==nil, use lua_0000.log
function log.open(name)
	log.filename = name
    -- yes, use write() for logging
    if name==nil then name="lua_0000.log" end
    log.file,msg=io.open("A/CHDK/LOGS/"..name,"a")
    if not log.file then
      log.type=0  
      print_screen(1)
      print("Error opening log, using print() from now on: "..tostring(msg))
    else
    	log.type=1
      log.isopen=true
    end
  bi=get_buildinfo()
  log.print("\n--- Log opened at ",date.datetimestamp()," ---\n")
  log.print("platform: ",bi.platform," ",bi.platsub,"\n")
  log.print("version: ",bi.version," ",bi.build_number," built on ",bi.build_date," ",bi.build_time,"\n")
end

function log.close()
  if log.type==1 then
    log.print("\n--- Log closed at ",date.datetimestamp()," ---\n")
    io.close(log.file)
    log.isopen=false
  end
end

function log.print(...)
  if log.type==1 and log.isopen==true then
    log.file:write(...)
    log.file:flush()
  else
    print(...)
  end
end

--[[
    Find the smallest three digit zero-padded number which doesn't match any 
    existing file in A/CHDK/LOGS/ when used as a part of a file name of the 
    form headerNNN.extension. Return complete filename without path.
 
    Example:
    logfilename = log.find_new_filename("log_","txt")
    will return "log_002.txt" if log_000.txt and log_001.txt already exist.
 
    If all files up to log_999.txt are found, log_999.txt is returned.    
--]]
function log.find_new_filename(header,extension)
  local numstr  
  local filename
 
  for i=0,999 do
    -- zero pad
    if i<10 then 
      numstr = "00"..tostring(i)
    elseif i<100 then 
      numstr = "0"..tostring(i)
    else 
      numstr = tostring(i)
    end
 
    filename = tostring(header) .. numstr .. "." .. tostring(extension)
    local filepath="A/CHDK/LOGS/"..filename
    log.filename = "A/CHDK/LOGS/"..filename
    local r,msg = os.stat(filepath)
    if r==nil then 
      return filename
    end
    -- note: long for loop without forced sleep!
  end
 
  -- no free names found
  return filename
 
end

function log.segmentAndCopy(filePath)
	log.close()
	disk.moveFile("A/CHDK/LOGS/"..log.filename,filePath)
	log.open(log.filename)
end