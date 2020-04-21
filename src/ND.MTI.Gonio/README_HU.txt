Az átadott csomag tartalma
==========================
Az átadott csomag tartalmazza a Gonio szabályozószoftver legutóbbi verzióját, az egyéb kisegítõszoftvereket, továbbá
az aktuális csomag forráskódját, az Felhasználói és Telepítési dokumentációt, illetve jelen állományt.
A csomag tartalmát az alábbi struktúra szemlélteti.

|
|\__ _TOOLS
|\__ _SRC
|\__ _GONIOAPP{{version}}
|\__ _DOCS
|\__ README_HU.txt
|\__ README_EN.txt
\___ GonioApp.lnk

_TOOLS: A mappa tartalmazza azon egyéb szoftvereket, melyek kisegítõ lehetõségeket biztosítanak a méréshez. Az "Egyéb
eszközök" részben kerülnek részletezésre.

_SRC: A mappa tartalmazza az átadott szoftver forráskódját.

_GONIOAPP{{version}}: A mappa tartalmazza az átadott szoftver Windowsra fordított állományait (binaries).

Telepítés
=========
A telepítéshez nincs szükség semmilyen bonyolult lépésre. Az átadott csomag kibontása utána, a gyökérkönyvtárban
található parancsikonnal a szoftver indítható.

Egyéb eszközök
==============
A csomag a Gonio szabályozószoftveren kívül tartalamaz egyéb szoftvereket is, melyek a kalibrációhoz, teszteléshez,
vagy a méréshez szükségesek ám, meglétük nem kötelezõ.
Ezen szoftverek az átadott csomag _TOOLS mappájában találhatók.

ver 1.0.2.1:
    - ND.MTI.GONIO.RawPosition: A szoftver a motorok pozíciójának kezelésére szolgál. Az alkalmazásban megjelnítésre
                                kerül az enkóder felõl beérkezõ értéke (RAW), az enkóder 0 pozíciójától való eltérés
                                fokban (ANGLE), illetve az abszolút zéró pozíciótól való eltérés fokban (NORMALISED).
                                Az alkalmazásban lehetõség van a motorok forgatására.

                                HINT: Az Y enkóder iránya ellentétes a kívánalmakkal, így a szoftver implementációjában
                                      egy -1-szeres szorzás került megvalósításra.

    - ND.MTI.GONIO.RouteGenerator: A szoftver segítségével generálhatók olyan útvonalak a méréshez, amelyekkel nem
                                   lineáris útvonalak járhatók be.


ÓE-KVK MTI VKM
Farkas Kolos - 2020
callsign.sohamar@gmail.com
http://github.com/kfarkasHU/nd.mti-gonio