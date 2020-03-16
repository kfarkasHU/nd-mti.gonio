using ND.MTI.Service.Worker.PokeysCore.Helper;

namespace ND.MTI.Service.Worker.Pokeys.Helper
{
    public static class GonioPokeys_Pinout
    {
        public static Pokeys57U_Pin[] X_Input
        {
            get
            {
                return new Pokeys57U_Pin[]
                {
                    //Pokeys57U_Pin.PIN_1, // Do not use the reserved bit as Gray coded bit!

                    Pokeys57U_Pin.PIN_4,
                    Pokeys57U_Pin.PIN_5,
                    Pokeys57U_Pin.PIN_6,
                    Pokeys57U_Pin.PIN_7,
                    Pokeys57U_Pin.PIN_8,
                    Pokeys57U_Pin.PIN_9,
                    Pokeys57U_Pin.PIN_10,
                    Pokeys57U_Pin.PIN_11,
                    Pokeys57U_Pin.PIN_12,
                    Pokeys57U_Pin.PIN_13,
                    Pokeys57U_Pin.PIN_14,
                    Pokeys57U_Pin.PIN_15,
                    Pokeys57U_Pin.PIN_16
                };
            }
        }

        public static Pokeys57U_Pin[] Y_Input
        {
            get
            {
                return new Pokeys57U_Pin[]
                {
                    //Pokeys57U_Pin.PIN_19, // Do not use the reserved bit as Gray coded bit!

                    Pokeys57U_Pin.PIN_22,
                    Pokeys57U_Pin.PIN_23,
                    Pokeys57U_Pin.PIN_24,
                    Pokeys57U_Pin.PIN_25,
                    Pokeys57U_Pin.PIN_26,
                    Pokeys57U_Pin.PIN_27,
                    Pokeys57U_Pin.PIN_28,
                    Pokeys57U_Pin.PIN_29,
                    Pokeys57U_Pin.PIN_30,
                    Pokeys57U_Pin.PIN_31, // BUG
                    Pokeys57U_Pin.PIN_32,
                    Pokeys57U_Pin.PIN_33,
                    Pokeys57U_Pin.PIN_34
                };
            }
        }

        public static Pokeys57U_Pin[] X_Output
        {
            get
            {
                return new Pokeys57U_Pin[]
                {
                    Pokeys57U_Pin.PIN_35, // ENA
                    Pokeys57U_Pin.PIN_17, // SR
                    Pokeys57U_Pin.PIN_36, // DIR
                    Pokeys57U_Pin.PIN_37, // RES
                };
            }
        }

        public static Pokeys57U_Pin[] Y_Output
        {
            get
            {
                return new Pokeys57U_Pin[]
                {
                    Pokeys57U_Pin.PIN_38, // ENA
                    Pokeys57U_Pin.PIN_18, // SR
                    Pokeys57U_Pin.PIN_39, // DIR
                    Pokeys57U_Pin.PIN_40, // RES
                };
            }
        }

        public static Pokeys57U_Pin[] X_Endpoints
        {
            get
            {
                return new Pokeys57U_Pin[]
                {
                    Pokeys57U_Pin.PIN_2,
                    Pokeys57U_Pin.PIN_3
                };
            }
        }

        public static Pokeys57U_Pin[] Y_Endpoints
        {
            get
            {
                return new Pokeys57U_Pin[]
                {
                    Pokeys57U_Pin.PIN_20,
                    Pokeys57U_Pin.PIN_21
                };
            }
        }
    }
}
