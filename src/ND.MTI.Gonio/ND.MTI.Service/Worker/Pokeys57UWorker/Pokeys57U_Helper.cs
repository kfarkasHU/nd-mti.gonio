namespace ND.MTI.Service.Worker.Pokeys
{
    /// <summary>
    ///  Direction:
    ///  <para>
    ///     0 - LEFT
    ///     1 - RIGHT
    ///  </para>
    ///  Enable:
    ///  <para>
    ///     0 - ENABLED
    ///     1 - DISABLED
    ///  </para>
    ///  Reserved:
    ///  <para>
    ///     0 - Send logical 0
    ///     1 - Send logical 1
    ///  </para>
    /// </summary>
    internal class Pokeys57U_Commands
    {
        internal readonly static string DIR0_ENA0_RES0 = "000";
        internal readonly static string DIR0_ENA0_RES1 = "001";

        internal readonly static string DIR0_ENA1_RES0 = "010";
        internal readonly static string DIR0_ENA1_RES1 = "011";

        internal readonly static string DIR1_ENA0_RES0 = "100";
        internal readonly static string DIR1_ENA0_RES1 = "101";

        internal readonly static string DIR1_ENA1_RES0 = "110";
        internal readonly static string DIR1_ENA1_RES1 = "111";
    }

    internal enum Pokeys57U_PinNumbers
    {
        PIN_1 = 0,
        PIN_2 = 1,
        PIN_3 = 2,
        PIN_4 = 3,
        PIN_5 = 4,
        PIN_6 = 5,
        PIN_7 = 6,
        PIN_8 = 7,
        PIN_9 = 8,
        PIN_10 = 9,
        PIN_11 = 10,
        PIN_12 = 11,
        PIN_13 = 12,
        PIN_14 = 13,
        PIN_15 = 14,
        PIN_16 = 15,
        PIN_17 = 16,
        PIN_18 = 17,
        PIN_19 = 18,
        PIN_20 = 19,
        PIN_21 = 20,
        PIN_22 = 21,
        PIN_23 = 22,
        PIN_24 = 23,
        PIN_25 = 24,
        PIN_26 = 25,
        PIN_27 = 26,
        PIN_28 = 27,
        PIN_29 = 28,
        PIN_30 = 29,
        PIN_31 = 30,
        PIN_32 = 31,
        PIN_33 = 32,
        PIN_34 = 33,
        PIN_35 = 34,
        PIN_36 = 35,
        PIN_37 = 36,
        PIN_38 = 37,
        PIN_39 = 38,
        PIN_40 = 39,
        PIN_41 = 40,
        PIN_42 = 41,
        PIN_43 = 42,
        PIN_44 = 43,
        PIN_45 = 44,
        PIN_46 = 45,
        PIN_47 = 46,
        PIN_48 = 47,
        PIN_49 = 48,
        PIN_50 = 49,
        PIN_51 = 50,
        PIN_52 = 51,
        PIN_53 = 52,
        PIN_54 = 53,
        PIN_55 = 54
    }

    internal enum Pokeys57U_PinFunctions
    {
        PIN_INACTIVE = 0,
        PIN_DIGITAL_INPUT = 2,
        PIN_DIGITAL_OUTPUT = 4,
        PIN_ANALOG_INPUT = 8,
        PIN_ANALOG_OUTPUT = 16,
        PIN_INVERT = 128
    }
}
