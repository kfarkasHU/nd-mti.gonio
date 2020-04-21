Az �tadott csomag tartalma
==========================
Az �tadott csomag tartalmazza a Gonio szab�lyoz�szoftver legut�bbi verzi�j�t, az egy�b kiseg�t�szoftvereket, tov�bb�
az aktu�lis csomag forr�sk�dj�t, az Felhaszn�l�i �s Telep�t�si dokument�ci�t, illetve jelen �llom�nyt.
A csomag tartalm�t az al�bbi strukt�ra szeml�lteti.

|
|\__ _TOOLS
|\__ _SRC
|\__ _GONIOAPP{{version}}
|\__ _DOCS
|\__ README_HU.txt
|\__ README_EN.txt
\___ GonioApp.lnk

_TOOLS: A mappa tartalmazza azon egy�b szoftvereket, melyek kiseg�t� lehet�s�geket biztos�tanak a m�r�shez. Az "Egy�b
eszk�z�k" r�szben ker�lnek r�szletez�sre.

_SRC: A mappa tartalmazza az �tadott szoftver forr�sk�dj�t.

_GONIOAPP{{version}}: A mappa tartalmazza az �tadott szoftver Windowsra ford�tott �llom�nyait (binaries).

Telep�t�s
=========
A telep�t�shez nincs sz�ks�g semmilyen bonyolult l�p�sre. Az �tadott csomag kibont�sa ut�na, a gy�k�rk�nyvt�rban
tal�lhat� parancsikonnal a szoftver ind�that�.

Egy�b eszk�z�k
==============
A csomag a Gonio szab�lyoz�szoftveren k�v�l tartalamaz egy�b szoftvereket is, melyek a kalibr�ci�hoz, tesztel�shez,
vagy a m�r�shez sz�ks�gesek �m, megl�t�k nem k�telez�.
Ezen szoftverek az �tadott csomag _TOOLS mapp�j�ban tal�lhat�k.

ver 1.0.2.1:
    - ND.MTI.GONIO.RawPosition: A szoftver a motorok poz�ci�j�nak kezel�s�re szolg�l. Az alkalmaz�sban megjeln�t�sre
                                ker�l az enk�der fel�l be�rkez� �rt�ke (RAW), az enk�der 0 poz�ci�j�t�l val� elt�r�s
                                fokban (ANGLE), illetve az abszol�t z�r� poz�ci�t�l val� elt�r�s fokban (NORMALISED).
                                Az alkalmaz�sban lehet�s�g van a motorok forgat�s�ra.

                                HINT: Az Y enk�der ir�nya ellent�tes a k�v�nalmakkal, �gy a szoftver implement�ci�j�ban
                                      egy -1-szeres szorz�s ker�lt megval�s�t�sra.

    - ND.MTI.GONIO.RouteGenerator: A szoftver seg�ts�g�vel gener�lhat�k olyan �tvonalak a m�r�shez, amelyekkel nem
                                   line�ris �tvonalak j�rhat�k be.


�E-KVK MTI VKM
Farkas Kolos - 2020
callsign.sohamar@gmail.com
http://github.com/kfarkasHU/nd.mti-gonio