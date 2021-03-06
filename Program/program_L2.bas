#picaxe40x2
#no_data
'#no_table
#slot 0

#define oscFreq64
'#define oscFreq8

symbol rtcCS = b.6
symbol MISO = Pina.3
symbol MOSI = a.4
symbol SCLK = b.7
symbol adcCS = a.2
symbol memCS = d.6

symbol radIn = d.0	'radiation serial in
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

symbol RSSI = b.0	'adc pin for radio RSSI o/p


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
symbol phonectr = b54
symbol cycleCount = b34

symbol CamBotBoolROM = 0x4E
symbol CamTopboolRom = 0x4F
symbol PacketPtrlROM = 0x50
symbol PacketPtrhROM = 0x51
symbol MaxAltitudelROM = 0x52
symbol MaxAltitudehROM = 0x53
symbol AboutToLand = 0x54

symbol LGLatStartptr = 0x55			'55
symbol LGLatEnd = LGLatStartptr + 10 	'65
symbol LGLongStartptr = LGLatStartptr + 11'66
symbol LGLongEnd = LGLatStartptr + 22	'77

symbol RAMLatptr = 60
symbol RAMLongptr = 71
symbol RAMLatStart = 61
'symbol RAMlatStartp1 = RAMLatStart + 1
symbol RAMlongStart = 72
'symbol RAMLongStartp1 = RAMlongStart + 1
symbol RAMLatEnd = 70
symbol RAMLongEnd = 82
symbol RAMAltptr = 83
symbol RAMAltStart = 84
symbol RAMAltend = 88


symbol PacketPtrl = b38
symbol PacketPtrh = b39
symbol PacketPtr = w19

'symbol TXBaud = 39999	'8mhz:39999 for 50 baud
symbol TXBauds = 39999
symbol TXBaudf = B300_8
symbol TXMode = %110
symbol RXBaud = 52630' 38    old: 53332	'37.5
symbol RXMode = %111

#ifdef oscFreq8
symbol lightcountT = 10
symbol lightcountTl = 100

symbol temppause = 750
symbol irdBaud = n9600_8
symbol irdWait = 1000

symbol phoneBaud = t9600_8
symbol phonetimeout = 1000
#else
symbol lightcountT = 80
symbol lightcountTl = 800
symbol temppause = 6000
symbol irdBaud = n9600_64
symbol irdWait = 8000
symbol phoneBaud = t9600_64
symbol phonetimeout = 8000
#endif

'########
'########
'########


symbol AltThresholdHigh = 190
symbol AltThresholdLow = 110
symbol AltFallingDistance = 50
symbol AboutToLandCntMax = 6
symbol CameraHyst = 3
symbol AltThresholdLowC = 120
symbol maxcycles = 2


'phone stuff

table 0x00,("07922123456")


'no commands can be stored on or past 0xF8
table 0x80,("PINGOPg7eW")	'ping command and pwd
table ("CDWNytB48U")		'cutdown command and pwd
table ("FILMhdERY7")
table ("RESTOPg7eW")
table ("IRDOhyxapr")
table ("IRDFh7wv7k")
table ("SHUTp1cX7W")
table ("TESTN86GhH")
				'blanking

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

setfreq em64
b36 = 1
serrxd [32000,main],("C")

run 2

low cam1
low cam2

'sertxd("Rst")


main:

settimer 49110				' 1 second major tick
timer = 65315 				' preload to 120 tick
toflag = 0
setintflags %10000000,%10000000	' interrupt on toflag

'sertxd("Rst2")
#ifdef oscFreq64
setfreq em64
#else
'setfreq m8
#endif
'gosub RTCRAMClear

'sertxd("x ",#b37)

'write packet start

b16 = "$"
b17 = "$"
b18 = "A"
b19 = "P"
b20 = "E"
b21 = "X"

b10 = 0
b11 = 16
b12 = 21
ramptr = 6
gosub RTCRAMWRitemany


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




'turn on radio

'sertxd("f ",#b37)
hsersetup off
low c.6
high radiocsrx
low radiocstx
'hsersetup TXBauds, TXMode

'sertxd("c ",#b37)

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
poke RAMLatStart,"-"
for b20 = 1 to 9			'copy values into free RAM
	peek b20,b19
	b18 = b20 + RAMLatStart
	poke b18,b19
next
'b10 = ramptr

if b0 <> 0 then
	if b10 = "S" then
	'	ramptr = ramptr + 10
		'b11 = RAMLatStart
		poke RAMlatptr,0
		write LGLatStartptr,0
	else
	'	ramptr = ramptr + 9
	'	b11 = RAMLatStart + 1
		poke RAMlatptr,1
		write LGLatStartptr,1
	endif
	b10 = LGLatStartPtr + 1
	b11 = RamLatStart
	b12 = RAMLatEnd
	gosub ROMWriteMany
	'gosub RTCRAMWriteMany
else
	poke RAMlatptr,100
endif
'gosub WriteComma



'GET GPS (long)
poke RAMlongStart,"-"
gosub GetLongitude

b30 = b12
b31 = b13	'copy # sats
b32 = b0	'copy whether valid

for b20 = 1 to 10			'copy values into free RAM
	peek b20,b19
	b18 = b20 + RAMlongStart
	poke b18,b19
next
'b10 = ramptr

if b0 <> 0 then
	if b11 = "W" then
		'ramptr = ramptr + 11
		'b11 = RAMlongStart
		poke RAMlongptr,0
		write LGLongStartptr,0
	else
		'ramptr = ramptr + 10
		'b11 = RAMlongStart + 1
		poke RAMlongptr,1
		write LGLongstartptr,1
	endif
	b10 = LGLongStartptr + 1
	b11 = RAMlongStart
	b12 = RAMLongEnd
	gosub ROMWriteMany
		
	'gosub RTCRAMWriteMany
else
	poke RAMlongptr,100
endif	
'gosub WriteComma


'GET GPS (alt)

gosub GetAltitude
'populate current altitude
if b0 <> 0 then
	for b20 = 1 to 5			'copy values into free RAM
		peek b20,b19
		b18 = b20 + 20
		b17 = b20 + RAMAltptr
		poke b18,b19
		poke b17,b19
	next
	'b10 = ramptr
	
	
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
	
	
	'ramptr = ramptr + b20

	
	b5 = b5 - 48
	b4 = b4 - 48
	b3 = b3 - 48
	b2 = b2 - 48
	b1 = b1 - 48
	
	'poke RAMaltptr,100	
	if b5 > 9 then altdone
	if b4 > 9 then altdone
	if b3 > 9 then altdone
	if b2 > 9 then altdone
	if b1 > 9 then altdone
	poke RAMAltptr,b20			

	w25 = b5
	
	w11 = b4 * 10
	w25 = w25 + w11
	w11 = b3 * 100
	w25 = w25 + w11
	w11 = b2 * 1000
	w25 = w25 + w11
	w11 = b1 * 10000
	w25 = w25 + w11

	
	'sertxd("alt: ",#w25,cr,lf)
	
	'read max altitude
	
	read MaxAltitudelROM,b20
	read MAXAltitudehROM,b21	'w10
	'sertxd("R alt: ",#w10,cr,lf)
	
	if w25 > w10 then			'new highest alt
		'sertxd("W alt ",#w25,cr,lf)
		write MaxAltitudelROM,b50
		write MAXAltitudehROM,b51
		w10 = w25
	else
		w11 = w10 - w25
		'sertxd("fall ",#w11,cr,lf)
		if w11 >= altfallingdistance then
			if w25 >= altthresholdhigh then
				read camtopboolrom,b26
				'sertxd("rdtb ",#b26,cr,lf)
				b26 = b26 + 1
				if b26 > 250 then : b26 = 240 endif
				write camtopboolrom,b26
				if b26 = CameraHyst then
					
					'sertxd("T FM",cr,lf)
					high cam1
					high cam2
					b35 = 5
				endif
			endif
		endif
		
	endif
	
	'landed?
	
	if w10 > AltThresholdHigh then
		if w25 < AltThresholdlow then
			'about to land
			read AboutToLand,b16
			if b16 <= AboutToLandCntMax then
				b16 = b16 + 1
				write AboutToland,b16
			endif
			
			'sertxd("w lnd",cr,lf)
			
		endif
		if w25 < AltThresholdlowC then
			
			read cambotboolrom,b16
			'sertxd("rdbb ",#b16,cr,lf)
			b16 = b16 + 1
			if b16 > 250 then : b16 = 240 endif
			write cambotboolrom,b16
			if b16 = CameraHyst then
			
				'sertxd("DFM",cr,lf)
				high cam1
				high cam2
				b35 = 5
			endif
		endif
	endif	
	
	
	altdone:
	
else

	poke RAMaltptr,100
	
	
endif

#ifdef oscFreq16
	setfreq em64
#endif
#rem
read AboutToLand,b55
'b55 = 1			'REMOVE LATER!!!!!
'sertxd("r land ",#b55," ")

if b55 >= AboutToLandCntMax then
	b55 = 0
	sertxd("TXT ")
	'text start sequence

	
	serout phoneMOSI,phoneBaud,("AT",0x0D)
	pause 1600
	serout phoneMOSI,phoneBaud,("ATZ",0x0D)
	serin [phonetimeout,phonefail],phoneMISO,phoneBaud,("OK")
	pause 1600
	serout phoneMOSI,phoneBaud,("AT+CMGF=1",0x0D)
	serin [phonetimeout,phonefail],phoneMISO,phoneBaud,("OK")
	pause 400
	serout phoneMOSI,phonebaud,("ATE0",0x0D)
	pause 400
	serout phoneMOSI,phoneBaud,("AT+CMGS=",34)
	'	serout phoneMOSI,phoneBaud,("AT+CMGS=",34)
	
	b10 = phonectr % 3
	phonectr = phonectr + 1
	select case b10
		case 0
			serout phoneMOSI,phoneBaud,("07922123456")
		case 1
			serout phoneMOSI,phoneBaud,("07922123457")
		case 2
			serout phoneMOSI,phoneBaud,("07922123458")
	end select
	serout phoneMOSI,phoneBaud,(34,0x0D)
	serin [phonetimeout,phonefail],phoneMISO,phoneBaud,(62,32)

	'serin [phonetimeout,phonefail],phoneMISO,phoneBaud,(">")

	
	b55 = AboutToLandCntMax
	phonefail:

	
endif
#endrem

'now actually write GPS values
b52 = 0
peek RAMlatptr,b20
if b20 > 30 then
	if b55 >= AboutToLandCntMax then
		b52 = 1
		b10 = RAMlatStart
		b11 = LGLatStartptr + 1
		b12 = LGLatEnd
		gosub ROMReadMany
		read LGLatStartptr,b20
		poke RAMlatptr,b20
	endif
endif


b10 = ramptr
peek RAMlatptr,b11
b11 = b11 + RAMlatstart
b12 = RAMlatend
b13 = b12 - b11
b13 = b13 + 1

if b55 >= AboutToLandCntMax then

	for b21 = b11 to b12
		peek b21,b22
		serout phoneMOSI,phoneBaud,(b22)
	next 

endif	
if b20 < 30 then	
	ramptr = ramptr + b13
	gosub RTCRAMWriteMany	
endif
gosub writecomma


'LONG


peek RAMlongptr,b20
if b20 > 30 then
	if b55 >= AboutToLandCntMax then
		b10 = RAMlongStart
		b11 = LGLongStartptr + 1
		b12 = LGLongEnd
		gosub ROMReadMany
		read LGLongStartptr,b20
		poke RAMlongptr,b20
	endif
endif


b10 = ramptr
peek RAMlongptr,b11
b11 = b11 + RAMlongstart
b12 = RAMlongEnd
b13 = b12 - b11
b13 = b13 + 1

if b55 >= AboutToLandCntMax then
	
	for b21 = b11 to b12
		peek b21,b22
		serout phoneMOSI,phoneBaud,(b22)
	next
	serout phoneMOSI,phoneBaud,(",")

endif	
if b20 < 30 then	
	ramptr = ramptr + b13
	gosub RTCRAMWriteMany	
endif
gosub writecomma


'ALT


peek RAMaltptr,b20
'sertxd("altptr: ",#b20,cr,lf)


b10 = ramptr	
peek RAMAltptr,b13

b11 = RAMAltEnd - b13
b11 = b11 + 1
b12 = RAMaltEnd
if b55 >= AboutToLandCntMax then

	for b21 = b11 to b12
		peek b21,b22
		serout phoneMOSI,phoneBaud,(b22)
	next
	serout phoneMOSI,phoneBaud,(26)

endif	
if b20 < 30 then	
	ramptr = ramptr + b13
	gosub RTCRAMWriteMany	
endif
gosub writecomma




if cycleCount < maxcycles then



'gosub WriteComma

'GPS speed/bearing

gosub GetSpeedBearing

for b20 = 1 to 7			'copy values into free RAM
	peek b20,b19
	b18 = b20 + 60
	poke b18,b19
next
b10 = ramptr

if b0 <> 0 then
	ramptr = ramptr + 7
	b11 = 61
	b12 = 67
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




'temps



owout tempow,%1001,($55,40,241,136,209,1,0,0,139,$44)
owout tempow,%1001,($55,40,250,228,94,2,0,0,228,$44)

 pause temppause '� wait 750ms with strong pullup 
 
owout tempow,%0001,($55,40,241,136,209,1,0,0,139,$BE) 
 owin tempow,%0000,(b26,b27) '� read in result 

owout tempow,%0001,($55,40,250,228,94,2,0,0,228,$BE) 
owin tempow,%0000,(b0,b1) '� read in result 


for b16 = 0 to 1

gosub PrintReadTemp12
for b20 = 0 to 5			'copy values into free RAM
	peek b20,b19
	b18 = b20 + 60
	poke b18,b19
next
b10 = ramptr
b20 = b9 - b8
b20 = b20 + 1
ramptr = ramptr + b20
b11 = b8 + 60
b12 = b9 + 60
gosub RTCRAMwritemany

gosub WriteComma
w0 = w13
next




'check ADC channels

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


if cyclecount = 0 then

'ird1
w5 = 0
w11 = 0
serout radIn,irdBaud,("C1")

serin [irdWait,irddone],radOut,irdBaud,("##"),b10,b11,b22,b23

irddone:

gosub bintohex

b10 = ramptr
ramptr = ramptr + 4
b11 = 0
b12 = 3
gosub RTCRAMWriteMany

gosub writecomma
'ird2
w5 = w11
gosub bintohex
b10 = ramptr
ramptr = ramptr + 4
b11 = 0
b12 = 3
gosub RTCRAMWriteMany



else
	gosub writecomma
endif

gosub writecomma


'check light
low lightCS
high lightS2
low lightS3
w10 = lightcountT
b26 = 0
for b25 = 1 to 3

	
	low lights1
	low lights0
	b16 = b25 AND 1
	if b16 = 1 then : high lights1 endif
	b16 = b25 AND %10
	if b16 = %10 then : high lightS0 endif
	
	
	
	count lightout,lightcountT,w9

	
	if w9 > 40 then highenough
	if b25 = 3 then
		'sertxd("I ",#w9)
		
		count lightout,lightcountTl,w9
		w10 = lightcountTl
		if w9 =< 2 then
			b26 = 2
			w10 = lightcountTl * 100
			goto highenough
		endif
		
		if w9 =< 20 then
			b26 = 1
			w10 = lightcountTl * 10
			goto highenough
		endif
		

		
	
		goto highenough
	endif 


next

highenough:

count lightout,w10,b17
'sertxd("scale - ",#b25,cr,lf)
'sertxd("red - ",#b17,cr,lf)

b11 = b17

low lightS2
low lightS3

pause 20
count lightout,w10,b10
high lightCS


'sertxd("red - ",#b10,cr,lf)

gosub bintohex

b10 = ramptr
ramptr = ramptr + 4
b11 = 0
b12 = 3
gosub RTCRAMWriteMany

low lightCS

b16 = b25 AND 1					'lightS0 is shared by clk so restore value
if b16 = 1 then : high lights1 endif

high lightS2
high lightS3


count lightout,w10,b11



'sertxd("grn - ",#b11,cr,lf)

low lightS2
high lightS3


count lightout,w10,b10
high lightCS


'sertxd("blue - ",#b10,cr,lf)

gosub bintohex

b4 = b25 + 48
b4 = b4 + b26
b10 = ramptr
ramptr = ramptr + 5
b11 = 0
b12 = 4
gosub RTCRAMWriteMany

gosub writecomma
DirsA = DirsA AND %11110111









'check humidity

'gosub writecomma



'RSSI

b10 = b37
gosub bintohex
b10 = ramptr
ramptr = ramptr + 2
b11 = 2
b12 = 3
gosub rtcramwritemany

'no comma needed - end of string

else			'(if 50 baud packet)

	for b15 = 1 to 10				'<-- change this
		gosub writecomma	
	next

endif

if b52 > 0 then
if b55 > 0 then

	b19 = ","
	b20 = "L"
	b21 = "G"
	b10 = ramptr
	ramptr = ramptr + 3
	b11 = 19
	b12 = 21
	gosub RTCRAMwritemany

endif
endif


if b36 > 0 then

	
	b19 = ","
	b20 = "R"
	b21 = "T"
	b10 = ramptr
	ramptr = ramptr + 3
	b11 = 19
	b12 = 21
	gosub RTCRAMwritemany
	b36 = 0

endif


'turn off RX/hserin




'camera thing
sertxd("### 35: ",#b35,cr,lf)

if b35 > 0 then
	b35 = b35 - 1
	if b35 = 0 then
		low cam1
		low cam2
	endif

endif




'process RX buffer
ptr = 0
do
	b0 = @ptrinc
	'sertxd(b0)
	if b0 = "#" then
	'	sertxd("# found",cr,lf)		
		if @ptrinc = "#" then
		'	sertxd("## found",cr,lf)
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
'	sertxd(byte_)
	gosub crc16add2

next

crc = crc ^ 0x0000

w5 = crc

'sertxd("CK: ",#w5,cr,lf)

gosub bintohex
'sertxd(b0,b1,b2,b3,cr,lf)

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


w7 = PacketPtr / 2
w8 = PacketPtr AND 1

if w8 > 0 then
	b13 = 128
	

else
	b13 = 0

endif

b10 = ramptr
if ramptr > 128 then : b10 = 128 endif

#ifdef oscfreq64
setfreq em64
#endif
gosub FlashWritePage
pause 100
'read status
b10 = _RDSR
gosub FlashRead_byte
sertxd("fs ",#b0)


'increment and write counter

PacketPtr = PacketPtr + 1
write PacketPtrhROM,PacketPtrh
write PacketPtrlROM,PacketPtrl



'sertxd for testing
ptr = 0
for b15 = 0 to ramptr
sertxd(@ptrinc)
next
sertxd(cr,lf)


'transmit scratchpad
setfreq m8

low c.6

if cycleCount = maxcycles then

	hsersetup TXBauds, TXMode

	'wait 5


	ptr = 0
	for b16 = 0 to 7
		hserout 0,("U")
	next
	for b16 = 0 to ramptr
		hserout 0,(@ptrinc)
	next


else

	hsersetup TXBaudf, TXMode
	
	
	for b16 = 0 to 7
		hserout 0,("U")
	next
		
	for b20 = 0 to 1
	ptr=0

	for b16 = 0 to ramptr
		hserout 0,(@ptrinc)
	next
	
	wait 1
	
	next


endif

wait 2

hsersetup OFF
low c.6


if cyclecount = maxcycles then

	high radiocstx
	low radiocsrx

	'enable RX
	ptr = 0
	for w8 = 0 to 1023
		@ptrinc = 0		'clear spad
	next

	hsersetup RXBaud, RXMode
	low radiocsrx
	'sertxd("G",cr,lf)
	adcsetup = %0001000000000000
	b37 = 0
	for b16 = 0 to 9
		readadc 12,b17
		if b17 > b37 then
			b37 = b17
		endif
		wait 1
	next

	cyclecount = 0

else

	cyclecount = cyclecount + 1

endif


#ifdef oscFreq64
setfreq em64 
#endif

sertxd("S ",#b37,cr,lf)

'wait 10
goto main



    
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
'sertxd("CMDFND ETERED",cr,lf)
'starts at 0x80
b15 = 0x80	'start of each sequence pointer
b16 = 0x80	'moving pointer
'b17 - holds value @ b16
'b18 - number of matching chars
b18 = 0
b19 = ptr	' hold the entry value for ptr

do while ptr < 254
	
	readtable b16,b17
	
		
	if @ptrinc <> b17	then
		ptr = b19	'reset ptr		
		b15 = b15 + 10
		b16 = b15
		if b15 >= 0xF8 then : return endif
		b18 = 0
	else
		b18 = b18 + 1
		b16 = b16 + 1
	endif
	
	if b18 = 10 then
	
		'reply to hte command
		b21 = b15 + 3
		gosub writecomma
		for b20 = b15 to b21
			readtable b20,b11
			b10 = ramptr
			ramptr = ramptr + 1
			gosub RTCRAMWriteSingle
		
			
		next
	
		b15 = b15 - 0x80  ' remove memory offset
		b15 = b15 / 10
		
	
		branch b15,(pingcmd,cdwncmd,filmcmd,rstcmd)
		
		return
	endif	

loop
ptr = b19

return




pingcmd:



'sertxd("OMG IT WORKED :O",cr,lf)

return

cdwncmd:
high FET1
high FET2
pause 8000
low FET2
low FET1





return

rstcmd:
reset
return

#rem
IRDoncmd:

b20 = ","
b21 = "I"
b22 = "R"
b23 = "D"
b24 = "N"

b10 = ramptr
ramptr = ramptr + 5
b11 = 20
b12 = 24
gosub RTCRAMWriteMany

return

IRDoffcmd:

b20 = ","
b21 = "I"
b22 = "R"
b23 = "D"
b24 = "F"

b10 = ramptr
ramptr = ramptr + 5
b11 = 20
b12 = 24
gosub RTCRAMWriteMany

return

shutdowncmd:

b20 = ","
b21 = "S"
b22 = "H"
b23 = "U"
b24 = "T"

b10 = ramptr
ramptr = ramptr + 5
b11 = 20
b12 = 24
gosub RTCRAMWriteMany

return

testcmd:

b20 = ","
b21 = "T"
b22 = "E"
b23 = "S"
b24 = "T"

b10 = ramptr
ramptr = ramptr + 5
b11 = 20
b12 = 24
gosub RTCRAMWriteMany

return
#endrem
filmcmd:

high Cam1
high cam2
b35 = 5




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

'b10 = _WREN
'gosub FlashSingleOpCode	'enable write

'b10 = _WRSR
'b11 = 0
'gosub FlashWrite_byte

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
#rem
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
#endrem

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

#rem
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
#endrem
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


#rem
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
#endrem

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
'pause 1
pulsout sclk, 10
'pause 1
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


setfreq m8
serin [2000,endgps], GPSIn2,T4800,("$GPGGA,"),b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5,b6,b7,b8,b9,b45,b10',b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b0
#ifdef oscFreq64
setfreq em64 
#endif
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
setfreq m8
serin [2000,endgps],GPSIn2,T4800,("$GPGGA,"),b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b0,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5,b6,b7,b8,b9,b10,b45,b11,b45,b45,b45,b12,b13
#ifdef oscFreq64
setfreq em64 
#endif
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
setfreq m8
serin [2000,endgps],GPSIn2,T4800,("$GPGGA,"),b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b0,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5,b6,b7,b8,b9,b10,b45,b11,b45,b45,b45,b12,b13,b45,b45,b45,b45,b45,b45,b1,b2,b3,b4,b5
#ifdef oscFreq64
setfreq em64 
#endif
if b0 = "," then 
	b0 = 0
else
	b0 = 1
endif	

return

GetSpeedBearing:

'b5-b7 : bearing
'b1-b3 : speed kms
'b4 - ","

setfreq m8
serin [2000,endgps],GPSIn2,T4800,("GPVTG,"),b5,b6,b7,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b1,b2,b3
#ifdef oscFreq64
setfreq em64 
#endif
b4 = ","
if b5 = "," then
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
setfreq m8
serin [2000,endgps],GPSIn2,T4800,("$GPGGA,"),b1,b2,b4,b5,b7,b8',b45,b45,b45,b45,b0',b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b45,b0,b45,b9,b10
#ifdef oscFreq64
setfreq em64 
#endif
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






PrintReadTemp12:

'b0  -
'b1  1
'b2  2
'b3  .
'b4  1
'b5  4
'b8 - start
'b9 - end (5)

'takes a value in on w0



 'ReadTemp12 tempow, w0
  If bit15 <> 0 Then
    SerTxd( "-" )
    b8 = 0
    w0 = -w0
  Else
    b8 = 1
  End If
  w23 = 0
  If bit0 = 1 Then : w23 = w23 + 06 : End If
  If bit1 = 1 Then : w23 = w23 + 13 : End If
  If bit2 = 1 Then : w23 = w23 + 25 : End If
  If bit3 = 1 Then : w23 = w23 + 50 : End If
  w24 = w0 / 16
  bintoascii b48,b45,b1,b2
  if b1 = "0" then
  	b1 = "-"
  	b8 = b8 + 1
  endif
  'SerTxd( #w0, "." )
  
  bintoascii b46,b45,b4,b5
  
  'Select Case w23
  '  Case =  0 : SerTxd( "000" )
  '  Case < 10 : SerTxd( "0"   )
  'End Select
  'SerTxd( #w23 )
  
  b0 = "-"
b3 = "."
b9 = 5
  
  Return
  
  
ROMWriteMany:
'b10 - ROM start address
'b11 - PIC start address
'b12 - PIC end address
b45 = b10
b46 = b11
b47 = b12

for b48 = b46 to b47

	peek b48,b49
	write b45,b49
	b45 = b45 + 1

next


return

ROMReadMany:
'b10 - RAM start address
'b11 - ROM start address
'b12 - ROM end address
b45 = b10
b46 = b11
b47 = b12

for b48 = b46 to b47

	read b48,b49
	poke b45,b49

	b45 = b45 + 1

next


return

interrupt:
	timer = 65315
	toflag = 0
'	sertxd("IPT")

	setintflags %10000000,%10000000
	pause 100
	reset
return
