#picaxe40x2
#no_data
'#no_table
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

DirsB = DirsB AND %11110011	'set GPS input pins as inputs

main:


gosub ShowReadTemp12InW0
wait 1
goto main


ShowReadTemp12InW0:
 ReadTemp12 tempow, w0
  If bit15 <> 0 Then
    SerTxd( "-" )
    w0 = -w0
  Else
    SerTxd( "+" )
  End If
  w1 = 0
  If bit0 = 1 Then : w1 = w1 + 06 : End If
  If bit1 = 1 Then : w1 = w1 + 13 : End If
  If bit2 = 1 Then : w1 = w1 + 25 : End If
  If bit3 = 1 Then : w1 = w1 + 50 : End If
  w0 = w0 / 16
  SerTxd( #w0, "." )
  Select Case w1
    Case =    0 : SerTxd( "000" )
    Case < 10 : SerTxd( "0"   )
  End Select
  SerTxd( #w1 )
  Return