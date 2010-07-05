#picaxe40x2
#no_data
'#no_table
#slot 2
symbol rtcCS = b.6
symbol MISO = Pina.3
symbol MOSI = a.4
symbol SCLK = b.7
symbol adcCS = a.2
symbol memCS = d.6

symbol radIn = Pind.0	'radiation serial in
symbol radOut = d.1	'radiation serial out, can be switched with above pin

symbol lightO0 = d.2	'ouputs to light sensor, 
symbol lightO1 = d.3	'actual useage undefined so far
symbol lightO2 = c.0

symbol FET1 = b.1		'FET O/Ps
symbol FET2 = d.7

symbol humidityIn = pina.7'	humidity sensor when pin used as input
symbol humidityOut = a.7'	humidity sensor when pin used as ouput

symbol GPSIn1 = b.2		'GPS pins
symbol GPSOut1 = a.6
symbol GPSIn2 = b.3
symbol GPSOut2 = b.4

symbol cam1 = d.2
symbol cam2 = c.2

symbol IOHeader1 = c.3		'unused header	also i2c pins
symbol IOHeader2 = pinc.4

symbol tempOW = b.5	'temperature one wire bus

symbol LED = a.5		'SMD LED

symbol hseroutOP = c.6	'the hersin/out pints
symbol hserinIP = c.7




symbol radioCSTX = d.4	'CS for the radio, one is tx, other rx
symbol radioCSRX = d.5

symbol RSSI = pinb.0	'adc pin for radio RSSI o/p

symbol PhoneMOSI = a.0	'phone in
symbol PhoneMISO = a.1	'phone out


'#########
'#OPCODES#
'#########

symbol _WREN = 0x06
symbol _WRDI = 0x04
symbol _RDSR = 0x05
symbol _WRSR = 0x01
symbol _READ = 0x03
symbol _FAST_READ = 0x0B
symbol _PP = 0x02
symbol _SE = 0xD8
symbol _BE = 0xC7
symbol _DP = 0xB9
symbol _RDID = 0x9F
symbol _RES = 0xAB

'#########
'#########
'#########



'########
'varibles
'########

symbol CurrentAltitude = w25
symbol CurrentAltitudel = b50
symbol CurrentAltitudeh = b51
symbol RAMptr = b53	'ptrs store the next value to read
symbol tableptr = b54



symbol PacketPtrlROM = 0x50
symbol PacketPtrhROM = 0x51
symbol MaxAltitudelROM = 0x52
symbol MaxAltitudehROM = 0x53

symbol PacketPtrl = b38
symbol PacketPtrh = b39
symbol PacketPtr = w19

'########
'########
'########

table ("$$APEX,")

start:

high adccs
high rtccs
high memCS
high radioCSTX
high radioCSRX

DirsB = DirsB AND %11110011	'set GPS input pins as inputs


sertxd(cr,lf)
sertxd("______Control Panel_______",cr,lf,cr,lf)
sertxd("1) Read a flash page",cr,lf)
sertxd("2) Erase flash",cr,lf)
sertxd("3) Reset Counter",cr,lf)
sertxd("4) Multi page read",cr,lf)
sertxd("Enter your choice",cr,lf)

serrxd b0
b0 = b0 - 49

branch b0,(RDPG,BE,RST,MULTI)

goto start

RDPG:

sertxd("Enter page to read, max: 2047 (4 digits): ")
serrxd b16,b17,b18,b19

b16 = b16 - 48
b17 = b17 - 48
b18 = b18 - 48
b19 = b19 - 48


w7 = b16 * 1000
w10 = b17 * 100
w7 = w7 + w10
w10 = b18 * 10
w7 = w7 + w10
w7 = w7 + b19
b13 = 0
b10 = 255

sertxd(cr,lf,"page# ",#w7,cr,lf)
gosub FlashReadSpad

ptr = 0

for b16 = 0 to 255

	b17 = @ptrinc

	
	if b17 = cr then
		sertxd(cr,lf)
		goto start
	endif
	
	if b17 = lf then
		sertxd(cr,lf)
		goto start		
	endif

	sertxd(b17)

next


goto start

BE:

b10 = _WREN
gosub FlashSingleOpCode

b10 = _WRSR
b11 = 0
gosub FlashWrite_Byte

b10 = _WREN
gosub FlashSingleOpCode

b10 = _BE
gosub FlashSingleOpCode

wait 7

sertxd("done",cr,lf)


goto start


RST:

write PacketPtrlROM,0
write PacketPtrhROM,0

sertxd("done",cr,lf)


goto start


MULTI:

sertxd("Enter start page to read, max: 2047 (4 digits): ")
serrxd b16,b17,b18,b19

b16 = b16 - 48
b17 = b17 - 48
b18 = b18 - 48
b19 = b19 - 48


w16 = b16 * 1000
w10 = b17 * 100
w16 = w16 + w10
w10 = b18 * 10
w16 = w16 + w10
w16 = w16 + b19

'w16 ' start page

sertxd(cr,lf,"Enter end page to read, max: 2047 (4 digits): ",cr,lf)
serrxd b16,b17,b18,b19

b16 = b16 - 48
b17 = b17 - 48
b18 = b18 - 48
b19 = b19 - 48


w17 = b16 * 1000
w10 = b17 * 100
w17 = w17 + w10
w10 = b18 * 10
w17 = w17 + w10
w17 = w17 + b19

'w17 'end page

sertxd("w16: ",#w16,"  w17: ",#w17,cr,lf)

for w18 = w16 to w17
w7 = w18
b13 = 0
b10 = 255


gosub FlashReadSpad

ptr = 0

for b16 = 0 to 255

	b17 = @ptrinc

	
	if b17 = cr then
		sertxd(cr,lf)
		goto multidone1
	endif
	
	if b17 = lf then
		sertxd(cr,lf)
		goto multidone1		
	endif

	sertxd(b17)

next
multidone1:
next

goto start











'################################################
'################################################
'################################################

'		FLASH INTERFACE COMMANDS

'################################################
'################################################
'################################################


FlashSingleOpCode:
'b10 - opcode

low sclk
low memCS
b48 = b10
gosub clockout
high memCS

return

FlashRead_Byte:
'used to read a byte value after sending the OPCODE (eg status register)
'NOT for reading a byte from memory
'b10 - opcode
'b0 - byte value

low sclk
low memcs

b48 = b10
gosub clockout

for b45 = 0 to 7

	high sclk
	
	
	b0 = b0 << 1
	if MISO is on then
		b0 = b0 OR 1
	endif
	low sclk

next b45

high memcs

return


FlashWrite_Byte:
'used to write a byte value after sending the OPCODE (eg status register)
'NOT for writing a byte from memory
'b10 - opcode
'b11 - byte value
low sclk
low memcs

b48 = b10
gosub clockout
b48 = b11
gosub clockout

high memcs


return

FlashReadSpad:
'main function for reading data into spad
'w5 (b10:b11) - bytes to read

'b13 - addr start LSB		byte in page
'b14 - addr start		(w7)	page select LSB
'b15 - addr start MSB	(w7)	page select MSB

'b13:b15 select the address, b14:b15 (w7) select the page, and b13 the byte on the page



if w5 > 1024 then 'limit to max buffer size
	w5 = 1024 
endif

low sclk
low memcs

b48 = _READ	'opcode
gosub clockout
b48 = b15
gosub clockout
b48 = b14
gosub clockout
b48 = b13
gosub clockout
'address written, now recieve data

ptr = 0

for w24 = 0 to w5
	for b45 = 0 to 7

		high sclk	
		b46 = b46 << 1
		if MISO is on then
			b46 = b46 OR 1
		endif
		low sclk
	next b45
	@ptrinc = b46
next w24

high memCS

return


FlashWritePage:
'main function for writing data from spad - must write to a clear page
'b10 - bytes to write

'b13 - addr start LSB		byte in page
'b14 - addr start		(w7)	page select LSB
'b15 - addr start MSB	(w7)	page select MSB

'b13:b15 select the address, b14:b15 (w7) select the page, and b13 the byte on the page

b40 = b10	'copy variables
b43 = b13
b44 = b14
b45 = b15

b10 = _WREN
gosub FlashSingleOpCode	'enable write

b10 = _WRSR
b11 = 0
gosub FlashWrite_byte

b10 = _WREN
gosub FlashSingleOpCode	'enable write


low sclk
low memcs

b48 = _PP	'opcode
gosub clockout
b48 = b45
gosub clockout
b48 = b44
gosub clockout
b48 = b43
gosub clockout
'address written, now write data

ptr = 0
for b49 = 0 to b40
	b48 = @ptrinc
	gosub clockout
next b49
high memCS

return



'################################################
'################################################
'################################################

'		RTC INTERFACE COMMANDS

'################################################
'################################################
'################################################

RTCReadSingle:
'b10 - address
'b0 - read value

low sclk
low rtccs
b10 = b10 AND %01111111		'clear MSB for read


b48 = b10
gosub clockout	'write address

for b45 = 0 to 7

	high sclk
	low sclk
	
	b0 = b0 << 1
	if MISO is on then
		b0 = b0 OR 1
	endif
	

next b45

high rtccs


return


RTCWriteSingle:
'b10 - address
'b11 - value


low sclk
low rtccs
b10 = b10 OR %10000000		'set MSB for write



b48 = b10
gosub clockout	'write address

b48 = b11
gosub clockout	'write value

high rtccs


return


RTCRAMWriteSingle:
'b10 - RAM addr
'b11 - RAM data

b40 = b10	'copy variables
b41 = b11

b10 = 0x18
b11 = b40
gosub RTCWriteSingle

b10 = 0x19
b11 = b41
gosub RTCWriteSingle

return

RTCRAMWriteMany:
'writes a number of bytes to ram from the PIC RAM (remember 0-56 of ram = b0-b56)
'b10 - RTCRAM start addr
'b11 - PIC RAM start addr
'b12 - PIC RAM end addr

b40 = b10	'copy variables
b41 = b11
b42 = b12

b10 = 0x18		'write RTC RAM start address
b11 = b40
gosub RTCWriteSingle

low RTCCS
b48 = 0x99
gosub clockout	'write address

for b43 = b41 to b42
	peek b43,b48
	gosub clockout	'write value
next
high RTCCS

return


RTCRAMReadSingle:

'b10 - RAM addr
'b0 - value

b40 = b10	'copy variables
b41 = b11

b10 = 0x18
b11 = b40
gosub RTCWriteSingle

b10 = 0x19
gosub RTCReadSingle


return

RTCRAMClear:

b10 = 0x18
b11 = 0
gosub RTCWriteSingle

low rtccs
b48 = 0x99
gosub clockout	'write address

low MOSI
for b48 = 0 to 255	
for b45 = 0 to 7	
	high sclk
	low sclk

next b45
next b48

high rtccs

low rtccs


return

RTCRAMReadSpad:

'b10 - start address
'b11 - end address
'data saved in spad

b40 = b10	'copy variables
b41 = b11

b10 = 0x18
b11 = b40
gosub RTCWriteSingle


low rtccs
b48 = 0x19
gosub clockout	'write address

ptr = 0

for b48 = b40 to b41
	for b45 = 0 to 7

		high sclk
		low sclk
	
		b49 = b49 << 1
		if MISO is on then
			b49 = b49 OR 1
		endif
		
	next b45
	@ptrinc = b49
next b48

high rtccs

return


WriteComma:
b10 = RAMptr
b11 = ","
gosub RTCRAMWriteSingle
ramptr = ramptr + 1
return



bcd_decimal:
'input/output on b10,b11,b12,b13

	let b45 = b10 & %11110000 / 16 * 10
	let b10 = b10 & %00001111 + b45
	let b45 = b11 & %11110000 / 16 * 10
	let b11 = b11 & %00001111 + b45	
	let b45 = b12 & %11110000 / 16 * 10
	let b12 = b12 & %00001111 + b45
	let b45 = b13 & %11110000 / 16 * 10
	let b13 = b13 & %00001111 + b45

return

clockout:

'uses b45-b48
'b48 - byte to clockout

b47 = %10000000	
for b45 = 0 to 7

	b46 = b48 AND b47		'mask the current bit
	
	if b46 > 0 then
		high MOSI
	else
		low MOSI
	endif
	
	high sclk
	low sclk
	
	b47 = b47 >> 1

next b45
low MOSI
return


'###############################################################
'###############################################################
				'ADC commands
'###############################################################
'###############################################################


'b10 selects channel - remember selects channel of NEXT reading
'w0 is output word


ADCshift:
low sclk
low MOSI
low ADCcs

high MOSI
pulsout sclk, 10
high MOSI
pulsout sclk, 10

for b45 = 1 to 3
	b46 = b10 & %100
	if b46 > 0 then
		high MOSI
	else
		low MOSI
	endif
	pulsout sclk, 10
	b10 = b10 * 2
next b45
pause 1
pulsout sclk, 10
pause 1
pulsout sclk, 10

w0 = 0

for b45 = 1 to 12

	w0 = w0 * 2
	if MISO is on then
		w0 = w0 + 1
	endif
	pulsout sclk,10
next b45

high ADCcs
low MOSI

return



'###############################################################
'###############################################################
				'GPS commands
'###############################################################
'###############################################################

'needs support for heading/speed/altitude
'symbol GPSIn1 = b.2

GetLatitude:
'b0 - X if timeout
'result in variables b1-b9
'b9 - E/W or ',' for no fix


' use b45 to skip over decimal point
serin [2000,endlat], GPSIn1,T2400,("$GPGGA,")
serin 4,T2400,(","),b1,b2,b3,b4,b45,b5,b6,b7,b8,b45,b9

'sertxd("Lat",b1,b2,b3,b4,b5,b6,b7,b8,b9)

if b9 <> "," then	'Will be E or W if position is known, otherwise ,

endif

b0 = 0
return
endlat:
for b0 = 1 to 9
	poke b0,"X"
next
b0 = "X"
return

GetLongitude:
'b0 - X if timeout
'result in variables b1-b10

serin [2000,endlong],GPSIn1,T2400,("$GPGGA,")
serin [2000,endlong],GPSIn1,T2400,(",")
serin [2000,endlong],GPSIn1,T2400,(","),b45,b45,b1,b2,b3,b4,b5,b45,b6,b7,b8,b9,b45,b10'b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5,b45,b6,b7,b8,b9
'sertxd("Lon",b1,b2,b3,b4,b5,b6,b7,b8,b9,b10)
b0 = 0
return
endlong:
for b0 = 1 to 10
	poke b0,"X"
next
b0 = "X"
return

GetUTCTime:
'b0 - X if timeout
'b1,b2 - hour
'b3 - ':'
'b4,b5 - minute
'b6 - ':'
'b7,b8 - sec
serin [2000,endtime],GPSIn1,T2400,("$GPGGA,"),b1,b2,b4,b5,b7,b8
'sertxd("UTC: ",b1,b2,"h ",b3,b4,"m ",b5,b6,"s", 13,10)
b0 = 0
return
endtime:
for b0 = 1 to 8
	poke b0,"X"
next
b0 = "X"
return