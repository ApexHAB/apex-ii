#picaxe40x2
#no_data
'#no_table
#slot 0
symbol rtcCS = b.6
symbol MISO = Pina.3
symbol MOSI = a.4
symbol SCLK = b.7
symbol adcCS = a.2
symbol memCS = d.6

symbol radIn = Pind.0	'radiation serial in
symbol radOut = d.1	'radiation serial out, can be switched with above pin

symbol lightCS = d.3
symbol lightOut = c.0
symbol lightS0 = c.5
symbol lightS1 = b.7
symbol lightS2 = a.4
symbol lightS3 = a.3


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


symbol TXBaud = 39999	'8mhz:39999 for 50 baud
symbol TXMode = %110
symbol RXBaud = B300_8
symbol RXMode = %111

'########
'########
'########

table ("$$APEX,")		'start of string

'no commands can be stored on or past 0xF8
table 0x80,("PINGftnjqw")	'ping command and pwd
table ("CDWNtqnhgr")		'cutdown command and pwd
table ("IRDOhyxapr")
table ("IRDFh7wv7k")
table ("SHUTp1cX7W")
table ("TESTN86GhH")
table ("XXXXXXXXXX")		'blanking
table ("XXXXXXXXXX")
table ("XXXXXXXXXX")
table ("XXXXXXXXXX")
table ("XXXXXXXXXX")
table ("XXXXXXXXXX")


high adccs
high rtccs
high memCS
high radioCSTX
high radioCSRX
high lightcs

DirsB = DirsB AND %11110011	'set GPS input pins as inputs



serrxd [2000,main],("C")

run 2



main:





'gosub RTCRAMClear
RAMptr = 0
tableptr = 0

'write packet start
readtable tableptr,b15
tableptr  = tableptr + 1
do while b15 <> ","
	b10 = RAMptr
	b11 = b15
	gosub RTCRAMWriteSingle
	ramptr = ramptr + 1
	readtable tableptr,b15
	tableptr  = tableptr + 1
loop

gosub WriteComma


'write packet ID

read PacketPtrlROM,PacketPtrl		'get next packet id
read PacketPtrhROM,PacketPtrh		

bintoascii PacketPtr,b15,b16,b17,b18,b19	'convert to ascii
b10 = ramptr

b20 = 5
if b15 <> "0" then writepckt
b20 = 4
if b16 <> "0" then writepckt
b20 = 3
if b17 <> "0" then writepckt
b20 = 2
if b18 <> "0" then writepckt
b20 = 1


writepckt:

ramptr = ramptr + b20

b11 = 20 - b20

b12 = 19
gosub RTCRAMWriteMany		'send all 5 values
gosub WriteComma


'GET GPS (time)



gosub GETUTCTime
for b20 = 1 to 8			'copy values into free RAM
	peek b20,b19
	b18 = b20 + 60
	poke b18,b19
next
if b0 <> 0 then
	b10 = ramptr
	ramptr = ramptr + 8
	b11 = 61
	b12 = 68

	gosub RTCRAMWriteMany
endif
gosub WriteComma





'GET GPS (lat)

gosub GetLatitude
poke 60,"-"
for b20 = 1 to 9			'copy values into free RAM
	peek b20,b19
	b18 = b20 + 60
	poke b18,b19
next
b10 = ramptr

if b0 <> 0 then
	if b10 = "S" then
		ramptr = ramptr + 10
		b11 = 60
	else
		ramptr = ramptr + 9
		b11 = 61
	endif
	b12 = 69
	gosub RTCRAMWriteMany
endif
gosub WriteComma



'GET GPS (long)
poke 60,"-"
gosub GetLongitude

b30 = b12
b31 = b13	'copy # sats
b32 = b0	'copy whether valid

for b20 = 1 to 10			'copy values into free RAM
	peek b20,b19
	b18 = b20 + 60
	poke b18,b19
next
b10 = ramptr

if b0 <> 0 then
	if b11 = "W" then
		ramptr = ramptr + 11
		b11 = 60
	else
		ramptr = ramptr + 10
		b11 = 61
	endif
	b12 = 70

	gosub RTCRAMWriteMany
endif	
gosub WriteComma


'GET GPS (alt)

gosub GetAltitude
'populate current altitude
if b0 <> 0 then
	for b20 = 1 to 5			'copy values into free RAM
		peek b20,b19
		b18 = b20 + 20
		poke b18,b19
	next
	b10 = ramptr
	
	b20 = 5
	if b21 <> "0" then writealt
	b20 = 4
	if b22 <> "0" then writealt
	b20 = 3
	if b23 <> "0" then writealt
	b20 = 2
	if b24 <> "0" then writealt
	b20 = 1

	
	
	writealt:
	
	ramptr = ramptr + b20

	b11 = 26 - b20
	b12 = 25
	gosub RTCRAMWriteMany
	
	b5 = b5 - 48
	b4 = b4 - 48
	b3 = b3 - 48
	b2 = b2 - 48
	b1 = b1 - 48
	
	if b5 > 9 then altdone
	if b4 > 9 then altdone
	if b3 > 9 then altdone
	if b2 > 9 then altdone
	if b1 > 9 then altdone			

	w25 = b5
	
	w11 = b4 * 10
	w25 = w25 + w11
	w11 = b3 * 100
	w25 = w25 + w11
	w11 = b2 * 1000
	w25 = w25 + w11
	w11 = b1 * 10000
	w25 = w25 + w11

	
	sertxd("alt: ",#w25,cr,lf,cr,lf)
	
	altdone:
	
endif


'check if current altitude > highest
	'update highest


gosub WriteComma

'GPS speed/bearing

gosub GetSpeedBearing

for b20 = 1 to 11			'copy values into free RAM
	peek b20,b19
	b18 = b20 + 60
	poke b18,b19
next
b10 = ramptr

if b0 <> 0 then
	ramptr = ramptr + 11
	b11 = 61
	b12 = 71
	gosub RTCRAMWriteMany
else
	gosub WriteComma	
endif
gosub WriteComma

'gosub WriteComma

'GPS bearing



'gosub WriteComma

'GPS sats

if b32 <> 0 then
	b10 = ramptr
	ramptr = ramptr + 2
	b11 = 30
	b12 = 31
	gosub RTCRAMWriteMany
endif

gosub WriteComma
'phone stuff




'gosub WriteComma
'take pictures




'check ADC channels
#rem
b10 = 0
gosub ADCShift
for b16 = 1 to 4

	gosub writecomma

	b10 = b16
	b10 = b10 AND %11		'sending 4 on final loop is not a valid number
	gosub ADCShift
'	w0 = 1494
	
	w5 = w0
	gosub bintohex
	
	
	b10 = ramptr
	b11 = 1
	b12 = 3
	ramptr = ramptr + 3
	gosub RTCRAMWriteMany

next
#endrem

b10 = 0
gosub ADCShift
b10 = 0
gosub ADCShift
w5 = w0
gosub bintohex
b10 = ramptr
b11 = 1
b12 = 3
ramptr = ramptr + 3
gosub RTCRAMWriteMany

gosub writecomma
b10 = 1
gosub ADCShift
b10 = 1
gosub ADCShift
w5 = w0
gosub bintohex
b10 = ramptr
b11 = 1
b12 = 3
ramptr = ramptr + 3
gosub RTCRAMWriteMany

gosub writecomma


'check humidity



'check light

high lightS2
low lightS3

for b25 = 1 to 3

	
	low lights1
	low lights0
	b16 = b25 AND 1
	if b16 = 1 then : high lights1 endif
	b16 = b25 AND %10
	if b16 = %10 then : high lightS0 endif
	
	low lightCS
	pause 20
	count lightout,10,b17
	high lightCS
	
	if b17 > 40 then highenough
	if b25 = 3 then highenough


next

highenough:
low a.4
pause 100
sertxd("scale - ",#b25,cr,lf)
sertxd("red - ",#b17,cr,lf)

b11 = b17

low lightS2
low lightS3
low lightCS
pause 20
count lightout,10,b10
high lightCS
low a.4
pause 100
sertxd("red - ",#b10,cr,lf)

gosub bintohex

b10 = ramptr
ramptr = ramptr + 4
b11 = 0
b12 = 3
gosub RTCRAMWriteMany

b16 = b25 AND 1					'lightS0 is shared by clk so restore value
if b16 = 1 then : high lights1 endif

high lightS2
high lightS3
low lightCS
pause 20
count lightout,10,b11
high lightCS
low a.4
pause 100
sertxd("grn - ",#b11,cr,lf)

low lightS2
high lightS3
low lightCS
pause 20
count lightout,10,b10
high lightCS
low a.4
pause 100
sertxd("blue - ",#b10,cr,lf)

gosub bintohex

b10 = ramptr
ramptr = ramptr + 4
b11 = 0
b12 = 3
gosub RTCRAMWriteMany

gosub writecomma

b25 = b25 + 48
b10 = ramptr
ramptr = ramptr + 1
b11 = 25
b12 = 25
gosub RTCRAMWriteMany
gosub writecomma
DirsA = DirsA AND %11110111	'set GPS input pins as inputs
'IRD comms






'turn off RX/hserin
hsersetup OFF


'check temp


'process RX buffer
ptr = 0
do
	if @ptrinc = "#" then		
		if @ptrinc = "#" then
			gosub commandfound
		endif
		
		
	endif
loop while ptr < 253







'check for texts





'copy RTC RAM to spad
ptr = 0
for w8 = 0 to 1023
	@ptrinc = 0
next

ramptr = ramptr - 1	'so ptr now contains the last bit of data rather than next location

b10 = 0
b11 = ramptr
gosub RTCRAMReadSpad

'CRC

symbol crc = w9
symbol k = w10
symbol byte_ = b22
symbol bit_ = b23
symbol POLYNOMIAL = $1021
symbol word2 = w12

crc = $FFFF

ptr = 2
for b16 = 2 to ramptr

	byte_ = @ptrinc
	sertxd(byte_)
	gosub crc16add2

next

crc = crc ^ 0x0000

w5 = crc

sertxd("CK: ",#w5,cr,lf)

gosub bintohex
sertxd(b0,b1,b2,b3,cr,lf)

ptr = ramptr + 1
ramptr = ramptr + 7
@ptrinc = "*"

for b16 = 0 to 3
	peek b16,b17
	
	@ptrinc = b17

next b16

'write crlf

@ptrinc = cr
@ptrinc = lf




'write to flash

b10 = ramptr
b13 = 0
w7 = PacketPtr
gosub FlashWritePage


'increment and write counter

PacketPtr = PacketPtr + 1
write PacketPtrhROM,PacketPtrh
write PacketPtrlROM,PacketPtrl

'transmit scratchpad
high radiocsrx
low radiocstx
low c.6
wait 5

hsersetup TXBaud, TXMode

ptr = 0
for b16 = 0 to ramptr
	hserout 0,(@ptrinc)
next

low c.6

wait 3
hsersetup OFF
high radiocstx
low radiocsrx
'sertxd for testing

ptr = 0
for b15 = 0 to ramptr
sertxd(@ptrinc)
next
sertxd(cr,lf)


'enable RX
ptr = 0
for w8 = 0 to 1023
	@ptrinc = 0		'clear spad
next

hsersetup RXBaud, RXMode

'wait 10
goto main


Crc16Add:
    FOR bit_ = 0 TO 7
      k = byte_ ^ crc & 1
      IF k = 0 THEN Crc16Add1
      k = POLYNOMIAL
    Crc16Add1:
      crc = crc / 2 ^ k
      byte_ = byte_ / 2
    NEXT
    RETURN
    
 crc16add2:

word2 = byte_ << 8
crc = crc ^ word2

for byte_ = 0 to 7

	word2 = crc & 0x8000
	if word2 > 0 then
		crc = crc << 1
		crc = crc ^ 0x1021
	else
		crc = crc << 1
	endif
	

next


return
    
    

commandfound:
'starts at 0x80
b15 = 0x80	'start of each sequence pointer
b16 = 0x80	'moving pointer
'b17 - holds value @ b16
'b18 - number of matching chars
b18 = 0
b19 = ptr	' hold the entry value for ptr

do while ptr < 254
	
	read b16,b17
	if @ptrinc <> b17	then
		ptr = b19	'reset ptr		
		b15 = b15 + 10
		if b15 >= 0xF8 then : return endif
		b18 = 0
	else
		b18 = b18 + 1
	endif
	
	if b18 = 10 then
		b15 = b15 - 0x80  ' remove memory offset
		b15 = b15 / 10
		branch b15,(pingcmd,cdwncmd)
		return
	endif	

loop


return




pingcmd:
b19 = ","
b20 = "P"
b21 = "O"
b22 = "N"
b23 = "G"

b10 = ramptr
ramptr = ramptr + 5
b11 = 19
b12 = 23
gosub RTCRAMWriteMany

return

cdwncmd:

high FET2
pause 500
low FET2

b19 = ","
b20 = "C"
b21 = "D"
b22 = "W"
b23 = "N"

b10 = ramptr
ramptr = ramptr + 5
b11 = 19
b12 = 23
gosub RTCRAMWriteMany


return











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
b10 = b10 OR %10000000		'set MSB for read



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


bintohex:
'b10,b11 input
'b0,b1 output for b11
'b2,b3 output for b10

b45 = b10 AND %1111
if b45 > 9 then
	b3 = b45 + 55
else
	b3 = b45 + 48
endif
b10 = b10 >> 4
b45 = b10 AND %1111
if b45 > 9 then
	b2 = b45 + 55
else
	b2 = b45 + 48
endif

b45 = b11 AND %1111
if b45 > 9 then
	b1 = b45 + 55
else
	b1 = b45 + 48
endif
b11 = b11 >> 4
b45 = b11 AND %1111
if b45 > 9 then
	b0 = b45 + 55
else
	b0 = b45 + 48
endif


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

#rem
'###############################################################
'###############################################################
				'GPS commands - for testing
'###############################################################
'###############################################################

'needs support for heading/speed/altitude
'symbol GPSIn1 = b.2

GetLatitude:
'b0 - X if timeout
'result in variables b1-b9
'b9 - E/W or ',' for no fix


' use b45 to skip over decimal point


b0 = 0
b1 = "5"
b2 = "1"
b3 = "."
b4 = "3"
b5 = "7"
b6 = "1"
b7 = "9"
b8 = "5"
b9 = "N"
return

GetLongitude:
'b0 - X if timeout
'result in variables b1-b10

b0 = 0
b1 = "0"
b2 = "0"
b3 = "0"
b4 = "."
b5 = "7"
b6 = "1"
b7 = "9"
b8 = "5"
b9 = "7"
b10 = "W"
return


GetUTCTime:
'b0 - X if timeout
'b1,b2 - hour
'b3 - ':'
'b4,b5 - minute
'b6 - ':'
'b7,b8 - sec
b0 = 0
b1 = "1"
b2 = "2"
b3 = ":"
b4 = "0"
b5 = "4"
b6 = ":"
b7 = "5"
b8 = "4"
return
#endrem

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








'#rem

'###############################################################
'###############################################################
				'GPS commands
'###############################################################
'###############################################################

'needs support for heading/speed/altitude
'symbol GPSIn1 = b.2

GetLatitude:
'b0 -  GPS quality indicator (0=invalid; 1=GPS fix; 2=Diff. GPS fix)
'result in variables b1-b10
'b10 - N/S or ',' for no fix


' use b45 to skip over decimal point
serin [2000,endgps], GPSIn2,T4800,("$GPGGA,"),b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5,b6,b7,b8,b9,b45,b10',b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b0
'serin [2000,endlat], GPSIn2,T4800,(",")

'sertxd("Lat",b1,b2,b3,b4,b5,b6,b7,b8,b9,b10)

'if b10 <> "," then	'Will be E or W if position is known, otherwise ,

'endif

if b1 = "," then
	b0 = 0
else
	b0 = 1
endif

return


GetLongitude:
'b0 -  GPS quality indicator (0=invalid; 1=GPS fix; 2=Diff. GPS fix)
'result in variables b1-b11
'b11 as b10 as above
'b12:b13 - # sats
serin [2000,endgps],GPSIn2,T4800,("$GPGGA,"),b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b0,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5,b6,b7,b8,b9,b10,b45,b11,b45,b45,b45,b12,b13
'serin [2000,endlong],GPSIn2,T4800,(",")
'serin [2000,endlong],GPSIn2,T4800,(","),b45,b45,b1,b2,b3,b4,b5,b45,b6,b7,b8,b9,b45,b10'b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5,b45,b6,b7,b8,b9
'sertxd("Lon",b1,b2,b3,b4,b5,b6,b7,b8,b9,b10)
'sertxd(b12,b13,cr,lf)
if b0 = "," then 
	b0 = 0
else
	b0 = 1
endif	

return



GetAltitude:
'b0 -  GPS quality indicator (0=invalid; 1=GPS fix; 2=Diff. GPS fix)
'result in variables b1-b5
'b11 as b10 as above
'b12:b13 - # sats
serin [2000,endgps],GPSIn2,T4800,("$GPGGA,"),b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b0,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5,b6,b7,b8,b9,b10,b45,b11,b45,b45,b45,b12,b13,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5
'serin [2000,endlong],GPSIn2,T4800,(",")
'serin [2000,endlong],GPSIn2,T4800,(","),b45,b45,b1,b2,b3,b4,b5,b45,b6,b7,b8,b9,b45,b10'b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5,b45,b6,b7,b8,b9
'sertxd("Lon",b1,b2,b3,b4,b5,b6,b7,b8,b9,b10)
'sertxd(b12,b13,cr,lf)
if b0 = "," then 
	b0 = 0
else
	b0 = 1
endif	

return

GetSpeedBearing:

'b7-b11 : bearing
'b1-b5 : speed kms
'b6 - ","


serin [2000,endgps],GPSIn2,T4800,("GPVTG,"),b7,b8,b9,b10,b11,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5
b6 = ","
if b1 = "," then
	b0 = 0
else
	b0 = 1
endif

return

GetUTCTime:

'b1,b2 - hour
'b3 - ':'
'b4,b5 - minute
'b6 - ':'
'b7,b8 - sec
'b0 -  GPS quality indicator (0=invalid; 1=GPS fix; 2=Diff. GPS fix)

serin [2000,endgps],GPSIn2,T4800,("$GPGGA,"),b1,b2,b4,b5,b7,b8',b45,b45,b45,b45,b0',b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b0,b45,b9,b10
'sertxd("UTC: ",b1,b2,"h ",b3,b4,"m ",b5,b6,"s", 13,10)

if b2 = "," then
	b0 = 0
else
	b0 = 1
endif

b3 = ":"
b6 = ":"
return


endgps:
b0 = 0
return

'#endrem


ConfigureGPS:

'gpsout2


return 