namespace HomeSeer.PluginSdk.Devices {

    public enum EControlType {

        NotSpecified       = 1,
        TextSelectList     = 3,
        Button             = 5,
        ValueRangeDropDown = 6, // Rendered as a drop-list by default.
        ValueRangeSlider   = 7,
        TextBoxNumber      = 9,
        TextBoxString      = 10,
        RadioOption        = 11,
        ButtonScript       = 12, // Rendered as a button, executes a script when activated.
        ColorPicker        = 13  

    }

}