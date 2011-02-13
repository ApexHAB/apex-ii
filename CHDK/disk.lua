--[[
  Functions to help CHDK Lua scripts estimate free disk space.

  Author: fudgey 2008/10/27
  Licence: GPL v3 or higher
--]]


disk = {}

--[[
Returns estimated remaining disk space in number of shots based on shots
taken by your script (not based on Canon's estimate).

free_start is disk space in kiB (see get_free_disk_space()) at the time
of starting your script and shots_taken is number of shots taken by your 
script so far.

If shots_taken is below 1 or disk space has not decreased, image size of 
4 MiB will be assumed.
--]]
function disk.remaining_shots(free_start, shots_taken)

  local filesize
  local free_now = get_free_disk_space()
  
  -- figure out average file size in kiB:
  if (shots_taken<1) or (free_now>=free_start) then 
    shots_taken=1
    filesize=4096
  else
    filesize=free_start-free_now
    filesize=filesize/shots_taken
  end

  if filesize<1 then filesize=1 end
  
  -- calculate and return remaining shots:
  return (free_now / filesize)
end

--[[
Returns estimated remaining script run time in seconds until disk full.

free_start is disk space in kiB (see get_free_disk_space()) at the time
of starting your script.

tick_start is output from get_tick_count() from when the script started.
This is system clock (reset to 0 at boot time) in milliseconds (updated
by the camera in 10 ms increments). If it is a 32-bit signed number, it
will wrap around to in about 2^31/1000/60/60 hours i.e. 
24 days and 20:31:23 after camera start. After that the estimate will be
very pessimistic.
--]]
function disk.secs_to_disk_full(free_start, tick_start)

  local free_now = get_free_disk_space()
  local tick_now = get_tick_count()
  local used = free_start - free_now
  local dt = tick_now - tick_start
  
  -- free space has not decreased, return a large number
  if used <= 0 then 
    return 65535
  end

  -- Tick count has just now wrapped around or we were called right after 
  -- memorizing tick count. Return a large number:
  if dt==0 then
    return 65534 
  end
  
  local remaining = dt/used
  remaining = remaining * free_now / 1000
  if remaining<0 then
    remaining=-remaining
  end
  return remaining
end

--deletes list of files
function disk.deleteFiles(fileList)
	local count = table.getn(fileList)
	local i = 0
	while i ~= count do
		i = i + 1
		os.remove(fileList[i])
	end
end

function disk.copyFile(original, duplicate)
	local logFile = io.open(original)
	local newFile = io.open(duplicate,"w")
	
	while true do
		local bytes = logFile:read(4096)
		if not bytes then break end
		newFile:write(bytes)
	end
	logFile:close()
	newFile:close()
	os.utime(duplicate)
end

function disk.moveFile(original, newPath)
	disk.copyFile(original, newPath)
	os.remove(original)
end

-- returns list of files that contain the provided search string
function disk.filterImageFiles(searchString)
	local imageList = disk.getImageList()
	local count = table.getn(imageList)
	log.print("disk.filterImageFiles - count:",count,"\n")
	local i = 0
	while i ~= count do
		i = i + 1
		if(string.find(imageList[i],searchString,17, true) == nil) then
			table.remove(imageList,i)
			i = i - 1
			count = count - 1
		end
	end 
	log.print("disk.filterImageFiles - end count:",count,"\n")
	return imageList
end

-- TODO

--warning - get_jpg_count doesn't work until a shot is taken.
function disk.deleteUntilJpgFree(min,target)

	local jpgCount = get_jpg_count()
	--log.print("jpgCount:"..jpgCount.."\n")
	if (jpgCount <= min) then
		local deleteCount = target - jpgCount
		--log.print("deleteCount:"..deleteCount.."\n")
		local imgTable = getImageList()
		if (deleteCount > table.getn(imgTable)) then 
			deleteCount = table.getn(imgTable)
		end
		--log.print("table count:"..table.getn(imgTable))
		if(table.getn(imgTable) > 0) then
			local i = 0
			repeat
				i = i + 1
				--log.print("image to delete:"..imgTable[1])
				os.remove(imgTable[1])
				table.remove(imgTable,1)
			until deleteCount == i
		end	
	end
end

function disk.deleteUntilMbFree(mbMin, mbTarget)
	log.print("disk.deleteUntilMbFree - Mb Min:",mbMin,"Mb Target",mbTarget)
	local kbMin = mbMin * 1024
	local kbTarget = mbTarget * 1024
	if(get_free_disk_space() < kbMin) then
		local imgTable = disk.getImageList()
		repeat
			log.print("disk.deleteUntilMbFree - Image to Delete: ",imgTable[1])
			os.remove(imgTable[1])
			table.remove(imgTable,1)
		until get_free_disk_space() > kbTarget
	end
end

--[[ Loops through directories within DCIM dir, checks to see 
that each directory contains images. returns list of directories. 
deletes empty directories 
]]
function disk.getImageDirectories()
	local imgTable = {}
	--get directories that may contain images
	local dcimList = os.listdir("A/DCIM", false)
	if(dcimList) then
		local dirCount = table.getn(dcimList)
		table.sort(dcimList)
			--loop through directories
			local i = 0
			while ( dirCount ~= i) do
				i = i + 1
				dcimList[i] = "A/DCIM/"..dcimList[i]
				--get file list
				local imgDirList = os.listdir(dcimList[i], false)
				if(imgDirList) then
					local imgCount = table.getn(imgDirList)
					table.sort(imgDirList)
					if(imgCount == nil) then
						os.remove(dcimList[i])
						table.remove(dcimList,i)
					end
				else
					os.remove(dcimList[i])
					table.remove(dcimList,itemCount)
				end
			end
	end
	
	--log.print("-end- getImageDirectories ")
	return dcimList
end

--[[ Loops through DCIM dirs and creates list of files ]]
function disk.getImageList()
	local imgTable = {}
	local dcimList = disk.getImageDirectories()
	local dirCount = table.getn(dcimList)
	local i = 0
	while ( dirCount ~= i) do
		i = i + 1
		--log.print(dcimList[i].."\n")
		local imgDirList = os.listdir(dcimList[i], false)
		local imgCount = table.getn(imgDirList)
		--log.print("imgCount:"..imgCount)
		table.sort(imgDirList)
		local a = 0
		while (imgCount ~= a) do
			a = a + 1
			--log.print(dcimList[i].."/"..imgDirList[a])
			table.insert(imgTable,dcimList[i].."/"..imgDirList[a])
			sleep(1)
		end
	end
	return imgTable
end


--[[ returns newest file, assumes camera will save files 
with "IMG" prefix and its the last file alphabetically
]]
function disk.getNewImage()
	log.print("disk.getNewImage\n")
	local t = disk.filterImageFiles("IMG")
	local count = table.getn(t)
	if(count > 0) then
		return t[count]
	else
		return nil
	end
end

function disk.renameNewImage(name)
	local currentFile = disk.getNewImage()
 	local currentFileDir = string.sub(currentFile,1,16)
	os.rename(currentFile,currentFileDir..name)
end